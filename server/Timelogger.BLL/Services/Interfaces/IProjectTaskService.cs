using Timelogger.BLL.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Timelogger.BLL.Services.Interfaces
{
    public interface IProjectTaskService
    {
        public Task<ProjectTask> AddTaskAsync(ProjectTask projectTask);
        public Task UpdateTaskAsync(ProjectTask projectTask);
        public Task DeleteTaskAsync(int id);
        public Task<IEnumerable<ProjectTask>> GetAllTasksByProjectIdAsync(int id);
        public Task<ProjectTask> GetTaskByIdAsync(int id);
    }
}
