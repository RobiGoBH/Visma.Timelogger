using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;
using Timelogger.DAL.Configurations;
using Timelogger.DAL.Entities;
using Timelogger.DAL.Entities.Abstract;

namespace Timelogger.DAL.Base
{
	public class TimeloggerContext : DbContext
	{
		public TimeloggerContext(DbContextOptions<TimeloggerContext> options)
			: base(options)
		{
		}

		public DbSet<Project> Projects { get; set; }

		public DbSet<Entities.ProjectTask> Tasks { get; set; }

        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
        }

        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            OnBeforeSaving();
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }

        public override async Task<int> SaveChangesAsync(
           bool acceptAllChangesOnSuccess,
           CancellationToken cancellationToken = default(CancellationToken)
        )
        {
            OnBeforeSaving();
            return (await base.SaveChangesAsync(acceptAllChangesOnSuccess,
                          cancellationToken));
        }

        private void OnBeforeSaving()
        {
            var entries = ChangeTracker.Entries();
            var utcNow = DateTime.UtcNow;

            foreach (var entry in entries)
            {
                if (entry.Entity is BaseEntity entity)
                {
                    switch (entry.State)
                    {
                        case EntityState.Modified:
                            entity.ModifiedDate = utcNow;

                            entry.Property("CreatedOn").IsModified = false;
                            break;

                        case EntityState.Added:
                            entity.CreatedDate = utcNow;
                            entity.ModifiedDate = utcNow;
                            break;
                    }
                }
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProjectConfiguration());

            modelBuilder.ApplyConfiguration(new TaskConfiguration());
        }


        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Entities.Task>(entity =>
        //    {
        //        entity.Property(p => p.Name)
        //        .HasMaxLength(5)
        //        .IsRequired();

        //        entity.HasOne(p => p.Project)
        //                .WithMany(b => b.Tasks)
        //                .HasForeignKey(p => p.ProjectId)
        //                .OnDelete(DeleteBehavior.Cascade);
        //    });

        //    modelBuilder.Entity<Project>(entity =>
        //    {
        //        entity.Property(p => p.Name)
        //        .HasMaxLength(5)
        //        .IsRequired();
        //    });
        //}
    }
}
