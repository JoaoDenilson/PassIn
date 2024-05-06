using PassIn.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PassIn.Infrastructure.Repository
{
    public interface IConcertRepository
    {
        Task<Concert?> GetConcertById(Guid id);
        Concert? GetAllById(Guid id);
        Task<Concert?> GetById(Guid id);

        Concert CreateConcert(Concert ev);
    }
}
