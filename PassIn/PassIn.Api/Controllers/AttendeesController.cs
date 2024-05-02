using Microsoft.AspNetCore.Mvc;
using PassIn.Application.UseCases.Attendees.GetAllByEventId;
using PassIn.Application.UseCases.Attendees.RegisterAttendee;
using PassIn.Communication.Requests;
using PassIn.Communication.Responses;

namespace PassIn.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AttendeesController : ControllerBase
    {
        private readonly IRegisterAttendeeOnEventUseCase registerAttendeeOnEventUseCase;
        private readonly IGetAllAttendeesByEventIdUseCase getAllAttendeesByEventIdUseCase;

        public AttendeesController(IRegisterAttendeeOnEventUseCase registerAttendeeOnEventUseCase, IGetAllAttendeesByEventIdUseCase getAllAttendeesByEventIdUseCase)
        {
            this.registerAttendeeOnEventUseCase = registerAttendeeOnEventUseCase;
            this.getAllAttendeesByEventIdUseCase = getAllAttendeesByEventIdUseCase;
        }

        [HttpPost("{eventId}/register")]
        [ProducesResponseType(typeof(ResponseRegisteredJson), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status409Conflict)]
        public IActionResult Register([FromBody] RequestRegisterEventJson request, Guid eventId)
        {
            var response = registerAttendeeOnEventUseCase.Execute(eventId, request);

            return Created(string.Empty, response);
        }

        [HttpGet("{eventId}")]
        [ProducesResponseType(typeof(ResponseAllAttendeesJson), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
        public IActionResult GetAll( Guid eventId)
        {
            var response = getAllAttendeesByEventIdUseCase.Execute(eventId);

            return Ok(response);
        }
    }
}
