using PassIn.Communication.Requests;
using PassIn.Communication.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PassIn.Application.UseCases.Events.Register
{
    public interface IRegisterEventUseCase
    {
        ResponseRegisteredJson Execute(RequestEventJson request);
    }
}
