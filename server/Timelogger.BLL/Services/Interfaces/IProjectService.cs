using Timelogger.BLL.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Timelogger.BLL.Services.Interfaces
{
    public interface IProjectService
    {
        public Task<Project> CreateProjectAsync(Project Project);
        public Task UpdateProjectAsync(Project Project);
        public Task DeleteProjectAsync(int id);
        public Task<IEnumerable<Project>> GetAllProjectsAsync();
        public Task<Project> GetProjectByIdAsync(int id);
    }
}
