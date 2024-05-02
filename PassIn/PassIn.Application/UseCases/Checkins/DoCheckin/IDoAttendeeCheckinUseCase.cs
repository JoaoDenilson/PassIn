using PassIn.Communication.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PassIn.Application.UseCases.Checkins.DoCheckin
{
    public interface IDoAttendeeCheckinUseCase
    {
        ResponseRegisteredJson Execute(Guid attendeeId);
    }
}
