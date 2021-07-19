using AutoMapper;
using Timelogger.BLL.DTO;
using Timelogger.BLL.Exceptions;
using Timelogger.BLL.Services.Base;
using Timelogger.BLL.Services.Interfaces;
using Timelogger.DAL.Entities;
using Timelogger.DAL.Entities.Enums;
using Timelogger.DAL.UnitOfWork;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Project = Timelogger.BLL.DTO.Project;
using System.Reflection;

namespace Timelogger.BLL.Services
{
    
    public class ProjectService : BaseService, IProjectService
    {
        public ProjectService(IUnitOfWork unitOfWork, IMapper mapper)
            : base(unitOfWork, mapper) { }

              
        

        public async Task CreateProjectAsync(Project project)
        {
            var projectExist = await _unitOfWork.ProjectRepository
                .GetAllByCriteriaAsync(p => p.Name == project.Name) != null;

            if (projectExist) throw new EntityDuplicateException($"Project \"{project.Name}\" already exist");

            var mappedProject = _mapper.Map<Timelogger.DAL.Entities.Project> (project);

            await _unitOfWork.ProjectRepository.AddAsync(mappedProject);
        }

        public async Task UpdateProjectAsync(Project project)
        {
            var storedProject = await _unitOfWork.ProjectRepository
                .GetByIdAsync(project.Id);

            if (storedProject == null) throw new NotFoundException($"Project \"{project.Name}\" not found");

            PropertyInfo[] properties = typeof(Project).GetProperties();
            foreach (var prop in properties)
            {
                if (prop.Name.ToLowerInvariant() == "id")
                    continue;

                if (prop.GetValue(project) != prop.GetValue(storedProject))
                {
                    prop.SetValue(storedProject, prop.GetValue(project));
                }
            }

            await _unitOfWork.ProjectRepository.UpdateAsync(storedProject);
        }


        public async Task DeleteProjectAsync(int id)
        {            
            var storedProject = await _unitOfWork.ProjectRepository.GetByIdAsync(id);

            if (storedProject == null) throw new NotFoundException($"Project having id = {id} not found");

            await _unitOfWork.ProjectRepository.DeleteAsync(storedProject);
        }

        public async Task<IEnumerable<Project>> GetAllProjectsAsync()
        {
            var allProjects = await _unitOfWork.ProjectRepository.GetAllAsync();

            if (allProjects == null) return new List<Project>();

            return _mapper.Map<IEnumerable<DAL.Entities.Project>, IEnumerable<Project>>(allProjects);
        }

        public async Task<Project> GetProjectByIdAsync(int id)
        {
            var storedProject = await _unitOfWork.ProjectRepository.GetByIdAsync(id);

            if (storedProject == null) throw new NotFoundException($"Project having Id = {id} not found");

            return _mapper.Map<Project>(storedProject);
        }
    }
}
