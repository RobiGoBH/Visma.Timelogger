using Timelogger.DAL.Base;
using Timelogger.DAL.Entities;
using Timelogger.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Timelogger.DAL.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        public UnitOfWork(TimeloggerContext context) =>
            _context = context;

        readonly TimeloggerContext _context;

        IRepository<Project> projectRepository;
        IRepository<ProjectTask> projectTaskRepository;

        public IRepository<Project> ProjectRepository => 
            projectRepository ??= new Repository<Project>(_context);

        public IRepository<ProjectTask> ProjectTaskRepository =>
            projectTaskRepository ??= new Repository<ProjectTask>(_context);

        
        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
             await _context.SaveChangesAsync();
        }

        bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }

            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        ~UnitOfWork()
        {
            Dispose(false);
        }
    }
}
