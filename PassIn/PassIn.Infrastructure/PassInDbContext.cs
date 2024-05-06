using Microsoft.EntityFrameworkCore;
using PassIn.Infrastructure.Configuration;
using PassIn.Infrastructure.Entities;

namespace PassIn.Infrastructure
{
    public sealed class PassInDbContext : DbContext , IPassInDBContext
    {
        public PassInDbContext(DbContextOptions<PassInDbContext> options) : base(options)
        {
            this.Concerts = this.Set<Concert>();
            this.Attendees = this.Set<Attendee>();
            this.CheckIns = this.Set<CheckIn>();
        }
        public DbSet<Concert> Concerts { get; set; }
        public DbSet<Attendee> Attendees { get; set; }
        public DbSet<CheckIn> CheckIns { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            if(modelBuilder != null)
            {
                _ = modelBuilder.ApplyConfiguration(new AttendeesConfiguration());
                _ = modelBuilder.ApplyConfiguration(new CheckInsConfiguration());
                _ = modelBuilder.ApplyConfiguration(new ConcertsConfiguration());

                base.OnModelCreating(modelBuilder);
            }
            else
            {
                throw new ArgumentNullException(nameof(modelBuilder));
            }
        }

    }
}
