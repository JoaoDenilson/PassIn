using PassIn.Communication.Requests;
using PassIn.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PassIn.Infrastructure.Repository
{
    public interface IAttendeeRepository
    {
        Attendee RegisterAttendee(Attendee at);
        Boolean AlreadyRegistered(RequestRegisterConcertJson request, Guid eventId);
        int atteedeesForEvent(Guid eventId);
        Task<Attendee?> GetById(Guid id);
    }
}
