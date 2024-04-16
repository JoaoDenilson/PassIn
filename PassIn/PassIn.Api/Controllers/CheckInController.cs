using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PassIn.Application.UseCases.Checkings.DoCheckin;
using PassIn.Communication.Responses;

namespace PassIn.Api.Controllers
{
    [Route("api/[controller]")]
    //[ApiController]
    public class CheckInController : ControllerBase
    {
        [HttpPost]
        //[Route("{AttendeeId}")]
        [ProducesResponseType(typeof(ResponseRegisteredJson), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status409Conflict)]
        public IActionResult CheckIn([FromQuery] Guid attendeeId)
        {
            var useCase = new DoAttendeeCheckinUseCase();

            var response = useCase.Execute(attendeeId);

            return Created(string.Empty, response);
        }
    }
}
