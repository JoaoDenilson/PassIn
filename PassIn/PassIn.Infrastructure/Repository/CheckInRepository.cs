using Microsoft.EntityFrameworkCore;
using PassIn.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PassIn.Infrastructure.Repository
{
    public class CheckInRepository : ICheckInRepository
    {
        private readonly DbSet<CheckIn> checkIns;

        public CheckInRepository(IPassInDBContext context)
        {
            _ = context ?? throw new ArgumentNullException(nameof(context));
            this.checkIns = context.CheckIns;
        }

        public bool hasCheckIn(Guid id)
        {
            var result = checkIns.Any(ch => ch.Attendee_Id == id);
            return result;
        }

        public CheckIn registerCheckIn(CheckIn ch)
        {
            checkIns.Add(ch);

            return ch;
        }
    }
}
