using PassIn.Communication.Responses;

namespace PassIn.Application.UseCases.Events.GetById
{
    public interface IGetConcertByIdUseCase
    {
        Task<ResponseConcertJson> Execute(Guid id);
    }
}
