using Microsoft.EntityFrameworkCore;
using PassIn.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PassIn.Infrastructure.Repository
{
    public class EventRepository : IEventRepository
    {
        private readonly DbSet<Event> events;

        public EventRepository(IPassInDBContext context)
        {
            _ = context ?? throw new ArgumentNullException(nameof(context)); 
            this.events = context.Events;
        }

        //public async Task<IEnumerable<Event>> GetEventById()
        public async Task<Event?> GetEventById(Guid id)
        {
            var result = await this.events.Include(ev => ev.Attendees).FirstOrDefaultAsync(ev => ev.Id == id).ConfigureAwait(false);

            return result;
        }

        public async Task<Event?> GetById(Guid id)
        {
            var result = await this.events.FindAsync(id).ConfigureAwait(false);

            return result;
        }
        public Event? GetAllById(Guid id)
        {
            var result = this.events.Include(ev => ev.Attendees).ThenInclude(attendee => attendee.CheckIn).FirstOrDefault(p => p.Id == id);
            return result;
        }

        public Event CreateEvent(Event ev)
        {
            _ = this.events.Add(ev);
            
            return ev;
        }
    }
}