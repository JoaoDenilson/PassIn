using PassIn.Communication.Requests;
using PassIn.Communication.Responses;
using PassIn.Exceptions;
using PassIn.Infrastructure;
using PassIn.Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace PassIn.Application.UseCases.Attendees.RegisterAttendee
{
    public class RegisterAttendeeOnConcertUseCase : IRegisterAttendeeOnConcertUseCase
    {
        private readonly IAttendeeRepository attendeeRepository;
        private readonly IConcertRepository eventRepository;
        private readonly IPassInDBContext passInDBContext;

        public RegisterAttendeeOnConcertUseCase(IAttendeeRepository attendeeRepository, IConcertRepository eventRepository, IPassInDBContext passInDBContext)
        {
            this.attendeeRepository = attendeeRepository;
            this.eventRepository = eventRepository;
            this.passInDBContext = passInDBContext;
        }

        public ResponseRegisteredJson Execute(Guid eventId, RequestRegisterConcertJson request)
        {

            Validate(eventId, request);

            var entity = new Infrastructure.Entities.Attendee
            {
                Email = request.Email,
                Name = request.Name,
                Event_Id = eventId,
                Created_At = DateTime.UtcNow,
            };

            var result = attendeeRepository.RegisterAttendee(entity);

            passInDBContext.SaveChangesAsync(CancellationToken.None);

            return new ResponseRegisteredJson
            {
                Id = result.Id
            };
        }

        private void Validate(Guid eventId, RequestRegisterConcertJson request)
        {
            var eventEntity = eventRepository.GetById(eventId);
            if (eventEntity is null)
                throw new NotFoundException("An event with this id dont exist.");

            if (string.IsNullOrWhiteSpace(request.Name))
            {
                throw new ErrorOnValidationException("The name is invalid.");
            }

            if (EmailIsValid(request.Email) == false)
            {
                throw new ErrorOnValidationException("The email is invalid.");
            }

            var attendeeAlreadyRegistered = attendeeRepository.AlreadyRegistered(request, eventId);

            if (attendeeAlreadyRegistered)
            {
                throw new ConflicException("You can not register towice on the same event.");
            }

            var atteedeesForEvent = attendeeRepository.atteedeesForEvent(eventId);
            if (atteedeesForEvent >= eventEntity.Result?.Maximum_Attendees)
            {
                throw new ErrorOnValidationException("There is no room for this event.");
            }

        }
        private bool EmailIsValid(string email)
        {
            try
            {
                new MailAddress(email);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
