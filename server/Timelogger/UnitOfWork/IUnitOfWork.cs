using Timelogger.DAL.Entities;
using Timelogger.DAL.Repository;
using System.Threading.Tasks;

namespace Timelogger.DAL.UnitOfWork
{
    public interface IUnitOfWork
    {
        IRepository<Project> ProjectRepository { get; }
        IRepository<ProjectTask> ProjectTaskRepository { get; }
        
        void SaveChanges();
        Task SaveChangesAsync();
    }
}
