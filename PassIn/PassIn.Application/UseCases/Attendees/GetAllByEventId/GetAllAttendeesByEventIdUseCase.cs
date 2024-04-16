using Microsoft.EntityFrameworkCore;
using PassIn.Communication.Responses;
using PassIn.Exceptions;
using PassIn.Infrastructure;
using PassIn.Infrastructure.Entities;

namespace PassIn.Application.UseCases.Attendees.GetAllByEventId
{
    public class GetAllAttendeesByEventIdUseCase
    {
        private readonly PassInDbContext _dbContext;
        public GetAllAttendeesByEventIdUseCase()
        {
            _dbContext = new PassInDbContext();
        }
        public ResponseAllAttendeesjson Execute(Guid eventId)
        {

            var entity = _dbContext.Events.Include(ev => ev.Attendees).ThenInclude(att => att.CheckIn).FirstOrDefault(ev => ev.Id == eventId);
            if (entity is null)
                throw new NotFoundException("An event with this id dont exist.");

            return new ResponseAllAttendeesjson
            {
                Attendees = entity.Attendees.Select(attendee => new ResponseAttendeeJson
                {
                    Id = attendee.Id,
                    Name = attendee.Name,
                    Email = attendee.Email,
                    CreatedAt = DateTime.UtcNow,
                    CheckedInAt = attendee.CheckIn!.Created_At,
                    //CheckedInAt = attendee.CheckIn?.Created_At,
                }).ToList(),
            };
        }
    }
}
