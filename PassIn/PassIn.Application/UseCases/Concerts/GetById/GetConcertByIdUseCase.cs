using Microsoft.EntityFrameworkCore;
using PassIn.Communication.Responses;
using PassIn.Exceptions;
using PassIn.Infrastructure;
using PassIn.Infrastructure.Repository;

namespace PassIn.Application.UseCases.Events.GetById
{
    public class GetConcertByIdUseCase : IGetConcertByIdUseCase
    {
        private readonly IConcertRepository eventRepository;

        public GetConcertByIdUseCase(IConcertRepository eventRepository)
        {
            this.eventRepository = eventRepository;
        }

        public async Task<ResponseConcertJson> Execute(Guid id) 
        {

            var entity = await this.eventRepository.GetConcertById(id).ConfigureAwait(false);
            if (entity is null)
                throw new NotFoundException("An event with this id dont exist.");

            return new ResponseConcertJson
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
