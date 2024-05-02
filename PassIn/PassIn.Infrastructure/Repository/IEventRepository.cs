using PassIn.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PassIn.Infrastructure.Repository
{
    public interface IEventRepository
    {
        Task<Event?> GetEventById(Guid id);
        Event? GetAllById(Guid id);
        Task<Event?> GetById(Guid id);

        Event CreateEvent(Event ev);
    }
}
