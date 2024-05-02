using Microsoft.EntityFrameworkCore;
using PassIn.Communication.Responses;
using PassIn.Exceptions;
using PassIn.Infrastructure;
using PassIn.Infrastructure.Repository;

namespace PassIn.Application.UseCases.Events.GetById
{
    public class GetEventByIdUseCase : IGetEventByIdUseCase
    {
        private readonly IEventRepository eventRepository;

        public GetEventByIdUseCase(IEventRepository eventRepository)
        {
            this.eventRepository = eventRepository;
        }

        public async Task<ResponseEventJson> Execute(Guid id) 
        {

            var entity = await this.eventRepository.GetEventById(id).ConfigureAwait(false);
            if (entity is null)
                throw new NotFoundException("An event with this id dont exist.");

            return new ResponseEventJson
            {
                Id = entity.Id,
                Title = entity.Title,
                Details = entity.Details,
                MaximumAttendees = entity.Maximum_Attendees,
                AttendeesAmount = entity.Attendees.Count(),
            };
        }
    }
}
