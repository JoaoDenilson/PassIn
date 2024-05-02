using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PassIn.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace PassIn.Infrastructure.Configuration
{
    public class AttendeesConfiguration : IEntityTypeConfiguration<Attendee>
    {
        public void Configure(EntityTypeBuilder<Attendee> builder)
        {
            builder.ToTable("Attendees").HasKey(p => p.Id);
            builder.Property(p => p.Id).HasColumnName("id").HasColumnType("TEXT");
            builder.Property(p => p.Name).HasColumnName("Name");
            builder.Property(p => p.Email).HasColumnName("Email");
            builder.Property(p => p.Created_At).HasColumnName("Created_At");
            builder.Property(p => p.Event_Id).HasColumnName("Event_Id");

            builder.HasOne(e => e.CheckIn).WithOne(e => e.Attendee).HasForeignKey<CheckIn>(e => e.Attendee_Id).IsRequired();
        }
    }
}
