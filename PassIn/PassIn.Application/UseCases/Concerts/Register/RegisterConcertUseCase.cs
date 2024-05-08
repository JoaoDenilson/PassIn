using PassIn.Communication.Requests;
using PassIn.Communication.Responses;
using PassIn.Exceptions;
using PassIn.Infrastructure;
using PassIn.Infrastructure.Repository;

namespace PassIn.Application.UseCases.Events.Register;
public class RegisterConcertUseCase : IRegisterConcertUseCase
{
    private readonly IConcertRepository concertRepository;
    private readonly IPassInDBContext passInDBContext;
    public RegisterConcertUseCase(IConcertRepository eventRepository, IPassInDBContext passInDBContext)
    {
        this.concertRepository = eventRepository;
        this.passInDBContext = passInDBContext;
    }
    public ResponseRegisteredJson Execute(RequestConcertJson request)
    {
        Validate(request);

        var entity = new Infrastructure.Entities.Concert
        {
            Title = request.Title,
            Details = request.Details,
            Maximum_Attendees = request.MaximumAttendees,
            Slug = request.Title.ToLower().Replace(" ", "-"),
        };

        var result = concertRepository.CreateConcert(entity);

        passInDBContext.SaveChangesAsync(CancellationToken.None);

        var response = new ResponseRegisteredJson
        {
            Id = result.Id
        };

        return response;
    }

    public void Validate(RequestConcertJson request)
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