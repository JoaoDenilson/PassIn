using Microsoft.EntityFrameworkCore;
using PassIn.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PassIn.Infrastructure.Repository
{
    public class ConcertRepository : IConcertRepository
    {
        private readonly DbSet<Concert> concerts;

        public ConcertRepository(IPassInDBContext context)
        {
            _ = context ?? throw new ArgumentNullException(nameof(context)); 
            this.concerts = context.Concerts;
        }

        //public async Task<IEnumerable<Event>> GetEventById()
        public async Task<Concert?> GetConcertById(Guid id)
        {
            var result = await this.concerts.Include(ev => ev.Attendees).FirstOrDefaultAsync(ev => ev.Id == id).ConfigureAwait(false);

            return result;
        }

        public async Task<Concert?> GetById(Guid id)
        {
            var result = await this.concerts.FindAsync(id).ConfigureAwait(false);

            return result;
        }
        public Concert? GetAllById(Guid id)
        {
            var result = this.concerts.Include(ev => ev.Attendees).ThenInclude(attendee => attendee.CheckIn).FirstOrDefault(p => p.Id == id);
            return result;
        }

        public Concert CreateConcert(Concert ev)
        {
            _ = this.concerts.Add(ev);
            
            return ev;
        }
    }
}