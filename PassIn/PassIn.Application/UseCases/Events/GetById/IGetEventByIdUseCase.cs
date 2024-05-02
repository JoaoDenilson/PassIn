using PassIn.Communication.Responses;

namespace PassIn.Application.UseCases.Events.GetById
{
    public interface IGetEventByIdUseCase
    {
        Task<ResponseEventJson> Execute(Guid id);
    }
}
