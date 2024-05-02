using Microsoft.AspNetCore.Mvc;
using PassIn.Application.UseCases.Events.GetById;
using PassIn.Application.UseCases.Events.Register;
using PassIn.Communication.Requests;
using PassIn.Communication.Responses;

namespace PassIn.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EventsController : ControllerBase
{
    private readonly IRegisterEventUseCase registerEventUseCase;
    private readonly IGetEventByIdUseCase eventByIdUseCase;
    public EventsController(IRegisterEventUseCase registerEventUseCase, IGetEventByIdUseCase eventByIdUseCase)
    {
        this.registerEventUseCase = registerEventUseCase;
        this.eventByIdUseCase = eventByIdUseCase;
    }

    [HttpPost]
    [ProducesResponseType(typeof(ResponseRegisteredJson), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
    public IActionResult Register([FromBody] RequestEventJson request)
    {
        
        var response = registerEventUseCase.Execute(request);

        return Created(string.Empty, response);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(typeof(ResponseRegisteredJson), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]

    public async Task<IActionResult> GetById(Guid id)
    {
        var response = await this.eventByIdUseCase.Execute(id).ConfigureAwait(false);

        return Ok(response);
    }
}
