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
    public class ConcertsConfiguration : IEntityTypeConfiguration<Concert>
    {
        public void Configure(EntityTypeBuilder<Concert> builder)
        {
            builder.ToTable("Concerts").HasKey(p => p.Id);
            builder.Property(p => p.Id).HasColumnName("id");
            builder.Property(p => p.Title).HasColumnName("Title");
            builder.Property(p => p.Details).HasColumnName("Details");
            builder.Property(p => p.Slug).HasColumnName("Slug");
            builder.Property(p => p.Maximum_Attendees).HasColumnName("Maximum_Attendees");

            builder.HasMany(e => e.Attendees).WithOne().HasForeignKey(e => e.Event_Id).IsRequired();
        }
    }
}
