using PassIn.Communication.Requests;
using PassIn.Communication.Responses;
using PassIn.Exceptions;
using PassIn.Infrastructure;
using PassIn.Infrastructure.Repository;

namespace PassIn.Application.UseCases.Events.Register;
public class RegisterEventUseCase : IRegisterEventUseCase
{
    private readonly IEventRepository eventRepository;
    private readonly IPassInDBContext passInDBContext;
    public RegisterEventUseCase(IEventRepository eventRepository, IPassInDBContext passInDBContext)
    {
        this.eventRepository = eventRepository;
        this.passInDBContext = passInDBContext;
    }
    public ResponseRegisteredJson Execute(RequestEventJson request)
    {
        Validate(request);

        var entity = new Infrastructure.Entities.Event
        {
            Title = request.Title,
            Details = request.Details,
            Maximum_Attendees = request.MaximumAttendees,
            Slug = request.Title.ToLower().Replace(" ", "-"),
        };

        var result = eventRepository.CreateEvent(entity);

        passInDBContext.SaveChangesAsync(CancellationToken.None);

        return new ResponseRegisteredJson
        {
            Id = result.Id
        };
    }

    public void Validate(RequestEventJson request)
    {
        if (request.MaximumAttendees <= 0)
        {
            throw new ErrorOnValidationException("The Maximum attendes is invalid.");
        }

        if (string.IsNullOrWhiteSpace(request.Title))
        {
            throw new ErrorOnValidationException("The title is invalid.");
        }

        if (string.IsNullOrWhiteSpace(request.Details))
        {
            throw new ErrorOnValidationException("The title is invalid.");
        }
    }
}