using PassIn.Application.UseCases.Checkins.DoCheckin;
using PassIn.Communication.Responses;
using PassIn.Exceptions;
using PassIn.Infrastructure;
using PassIn.Infrastructure.Entities;
using PassIn.Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PassIn.Application.UseCases.Checkings.DoCheckin
{
    public class DoAttendeeCheckinUseCase : IDoAttendeeCheckinUseCase
    {
        private readonly IAttendeeRepository attendeeRepository;
        private readonly ICheckInRepository checkInRepository;
        private readonly IPassInDBContext passInDBContext;

        public DoAttendeeCheckinUseCase(IAttendeeRepository attendeeRepository, ICheckInRepository checkInRepository, IPassInDBContext passInDBContext)
        {
            this.attendeeRepository = attendeeRepository;
            this.checkInRepository = checkInRepository;
            this.passInDBContext = passInDBContext;
        }

        public ResponseRegisteredJson Execute(Guid attendeeId)
        {
            Validate(attendeeId);

            var entity = new CheckIn
            {
                Attendee_Id = attendeeId,
                Created_at = DateTime.UtcNow,
            };

            checkInRepository.registerCheckIn(entity);
            passInDBContext.SaveChangesAsync(CancellationToken.None);

            return new ResponseRegisteredJson
            {
                Id = entity.Id,
            };
        }

        private void Validate(Guid attendeeId)
        {
            var existAttendee = attendeeRepository.GetById(attendeeId);

            if (existAttendee ==  null)
            {
                throw new NotFoundException("The attendee with this Id was not found");
            }

            var existCheckIn = checkInRepository.hasCheckIn(attendeeId);
            if (existCheckIn)
            {
                throw new ConflicException("Attendee can not do checking twic in the same event");
            }
        }
    }
}
