using PassIn.Communication.Requests;
using PassIn.Communication.Responses;
using PassIn.Exceptions;
using PassIn.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace PassIn.Application.UseCases.Events.RegisterAttendee
{
    public class RegisterAttendeeOnEventUseCase
    {
        private readonly PassInDbContext _dbContext;
        public RegisterAttendeeOnEventUseCase()
        {
            _dbContext = new PassInDbContext();
        }
        public ResponseRegisteredJson Execute( Guid eventId, RequestRegisterEventJson request)
        {

            Validate(eventId, request);

            var entity = new Infrastructure.Entities.Attendee
            {
                Email = request.Email,
                Name = request.Name,
                Event_Id = eventId,
                Created_At = DateTime.UtcNow,
            };

            _dbContext.Attendees.Add(entity);
            _dbContext.SaveChanges();

            return new ResponseRegisteredJson
            {
                Id = entity.Id
            };
        }

        private void Validate(Guid eventId, RequestRegisterEventJson request)
        {
            var eventEntity = _dbContext.Events.Find(eventId);
            if(eventEntity is null)
                throw new NotFoundException("An event with this id dont exist.");

            if (string.IsNullOrWhiteSpace(request.Name))
            {
                throw new ErrorOnValidationException("The name is invalid.");
            }

            if (EmailIsValid(request.Email) == false)
            {
                throw new ErrorOnValidationException("The email is invalid.");
            }

            var attendeeAlreadyRegistered = _dbContext
                .Attendees
                .Any(att => att.Email.Equals(request.Email) && att.Event_Id == eventId);

            if(attendeeAlreadyRegistered)
            {
                throw new ConflicException("You can not register towice on the same event.");
            }

            var atteedeesForEvent = _dbContext.Attendees.Count(att => att.Event_Id == eventId);
            if (atteedeesForEvent >= eventEntity.Maximum_Attendees)
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
            }catch
            {
                return false;
            }
        }
    }
}
