using PassIn.Communication.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PassIn.Application.UseCases.Attendees.GetAllByEventId
{
    public interface IGetAllAttendeesByEventIdUseCase
    {
        ResponseAllAttendeesJson Execute(Guid eventId);
    }
}
