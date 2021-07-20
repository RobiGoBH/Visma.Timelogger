using Timelogger.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Timelogger.DAL.Configurations
{
    internal class ProjectConfiguration : IEntityTypeConfiguration<Project>
    {
        public void Configure(EntityTypeBuilder<Project> builder)
        {
            builder.Property(p => p.Id)
                .UseIdentityColumn()
                .IsRequired();

            builder.Property(p => p.Name)
                .HasMaxLength(150)
                .IsRequired();

            builder.Property(p => p.CreatedDate)
                .HasDefaultValue(DateTime.UtcNow)
                .IsRequired();

            builder.Property(p => p.ModifiedDate)
                .HasDefaultValue(DateTime.UtcNow)
                .IsRequired();
            
        }
    }
}
