using Microsoft.EntityFrameworkCore;
using PassIn.Communication.Responses;
using PassIn.Exceptions;
using PassIn.Infrastructure;
using PassIn.Infrastructure.Entities;
using PassIn.Infrastructure.Repository;

namespace PassIn.Application.UseCases.Attendees.GetAllByEventId
{
    public class GetAllAttendeesByEventIdUseCase : IGetAllAttendeesByEventIdUseCase
    {
        private readonly IEventRepository eventRepository;

        public GetAllAttendeesByEventIdUseCase(IEventRepository eventRepository)
        {
            this.eventRepository = eventRepository;
        }

        public ResponseAllAttendeesJson Execute(Guid eventId)
        {

            var entity = eventRepository.GetAllById(eventId);
            // var entity = _dbContext.Events.Include(ev => ev.Attendees).ThenInclude(att => att.CheckIn).FirstOrDefault(ev => ev.Id == eventId);
            if (entity is null)
                throw new NotFoundException("An event with this id dont exist.");

            return new ResponseAllAttendeesJson
            {
                Attendees = entity.Attendees.Select(attendee => new ResponseAttendeeJson
                {
                    Id = attendee.Id,
                    Name = attendee.Name,
                    Email = attendee.Email,
                    CreatedAt = DateTime.UtcNow,
                    CheckedInAt = attendee.CheckIn?.Created_at,
                }).ToList(),
            };
        }
    }
}
