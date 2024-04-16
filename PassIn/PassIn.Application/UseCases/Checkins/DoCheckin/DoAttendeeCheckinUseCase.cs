using PassIn.Communication.Responses;
using PassIn.Exceptions;
using PassIn.Infrastructure;
using PassIn.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PassIn.Application.UseCases.Checkings.DoCheckin
{
    public class DoAttendeeCheckinUseCase
    {
        private readonly PassInDbContext _dbContext;
        public DoAttendeeCheckinUseCase()
        {
            _dbContext = new PassInDbContext();
        }
        public ResponseRegisteredJson Execute(Guid attendeeId)
        {
            Validate(attendeeId);

            var entity = new CheckIn
            {
                Attendee_Id = attendeeId,
                Created_at = DateTime.UtcNow,
            };

            _dbContext.CheckIns.Add(entity);
            _dbContext.SaveChanges();

            return new ResponseRegisteredJson
            {
                Id = entity.Id,
            };
        }

        private void Validate(Guid attendeeId)
        {
            var existAttendee = _dbContext.Attendees.Any(at => at.Id == attendeeId);

            if (existAttendee ==  false)
            {
                throw new NotFoundException("The attendee with this Id was not found");
            }

            var existCheckIn = _dbContext.CheckIns.Any(ch => ch.Attendee_Id == attendeeId);
            if (existCheckIn)
            {
                throw new ConflicException("Attendee can not do checking twic in the same event");
            }
        }
    }
}
