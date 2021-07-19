using Timelogger.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Timelogger.DAL.Configurations
{
    internal class TaskConfiguration : IEntityTypeConfiguration<ProjectTask>
    {
        public void Configure(EntityTypeBuilder<ProjectTask> builder)
        {
            builder.Property(p => p.Name)
                .HasMaxLength(150)
                .IsRequired();

            builder.Property(p => p.Type)
                .HasMaxLength(50);

            builder.Property(p => p.StartDate)
                .IsRequired();

            builder.Property(p => p.CreatedDate)
                .HasDefaultValue(DateTime.UtcNow)
                .IsRequired();

            builder.Property(p => p.ModifiedDate)
                .HasDefaultValue(DateTime.UtcNow)
                .IsRequired();

            builder.HasOne(p => p.Project)
                .WithMany(p => p.Tasks)
                .HasForeignKey(p=>p.ProjectId)
                .HasPrincipalKey(p=>p.Id)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
