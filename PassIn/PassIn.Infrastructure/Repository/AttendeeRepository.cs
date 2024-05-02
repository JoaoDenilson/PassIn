using Microsoft.EntityFrameworkCore;
using PassIn.Communication.Requests;
using PassIn.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PassIn.Infrastructure.Repository
{
    public class AttendeeRepository : IAttendeeRepository
    {
        private readonly DbSet<Attendee> attendees;

        public AttendeeRepository(IPassInDBContext context)
        {
            _= context ?? throw new ArgumentNullException(nameof(context));
            this.attendees = context.Attendees;
        }

        public Attendee RegisterAttendee(Attendee at)
        {
            _ = this.attendees.Add(at);

            return at;
        }

        public async Task<Attendee?> GetById(Guid id)
        {
            var at = await this.attendees.FindAsync(id);

            return at;
        }
        public Boolean AlreadyRegistered(RequestRegisterEventJson request, Guid eventId)
        {
            var result = this.attendees.Any(att => att.Email.Equals(request.Email) && att.Event_Id == eventId);
            return result;
        }

        public int atteedeesForEvent( Guid eventId) 
        {
            return this.attendees.Count(att => att.Event_Id == eventId);
        }
    }
}
