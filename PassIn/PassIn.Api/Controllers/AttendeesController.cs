using Microsoft.AspNetCore.Mvc;
using PassIn.Application.UseCases.Attendees.GetAllByEventId;
using PassIn.Application.UseCases.Events.RegisterAttendee;
using PassIn.Communication.Requests;
using PassIn.Communication.Responses;

namespace PassIn.Api.Controllers
{
    [Route("api/[controller]")]
    //[ApiController]
    public class AttendeesController : ControllerBase
    {
        [HttpPost]
        [Route("{eventId}/register")]
        [ProducesResponseType(typeof(ResponseRegisteredJson), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status409Conflict)]
        public IActionResult Register([FromBody] RequestRegisterEventJson request, [FromBody] Guid eventId)
        {
            var useCase = new RegisterAttendeeOnEventUseCase();

            var response = useCase.Execute(eventId, request);

            return Created(string.Empty, response);
        }

        [HttpGet]
        [Route("{eventId}")]
        [ProducesResponseType(typeof(ResponseAllAttendeesjson), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
        public IActionResult GetAll([FromBody] Guid eventId)
        {
            var useCase = new GetAllAttendeesByEventIdUseCase();

            var response = useCase.Execute(eventId);

            return Ok(response);
        }
    }
}
