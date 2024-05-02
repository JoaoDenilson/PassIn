using PassIn.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PassIn.Infrastructure.Repository
{
    public interface ICheckInRepository
    {
        bool hasCheckIn(Guid id);
        CheckIn registerCheckIn(CheckIn ch);
    }
}
