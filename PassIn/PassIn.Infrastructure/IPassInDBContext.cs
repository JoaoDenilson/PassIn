using Microsoft.EntityFrameworkCore;
using PassIn.Infrastructure.Entities;

namespace PassIn.Infrastructure
{
    public interface IPassInDBContext
    {
        DbSet<Concert> Concerts { get; set; }
        DbSet<Attendee> Attendees { get; set; }
        DbSet<CheckIn> CheckIns { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
