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
using Timelogger.BLL.Helper;

namespace Timelogger.BLL.Services
{
    
    public class ProjectService : BaseService, IProjectService
    {
        public ProjectService(IUnitOfWork unitOfWork, IMapper mapper)
            : base(unitOfWork, mapper) { }

        public async Task<Project> CreateProjectAsync(Project project)
        {
            var projectExist = await _unitOfWork.ProjectRepository
                .GetSingleOrDefaultByCriteriaAsync(p => p.Name == project.Name) != null;

            if (projectExist) throw new EntityDuplicateException($"Project '{project.Name}' already exist");

            var mappedProject = _mapper.Map<DAL.Entities.Project> (project);

            return _mapper.Map<Project>(await  _unitOfWork.ProjectRepository.AddAsync(mappedProject));
        }

        public async Task UpdateProjectAsync(Project project)
        {
            var storedProject = await _unitOfWork.ProjectRepository
                .GetByIdAsync(project.Id);

            if (storedProject == null) throw new NotFoundException($"Project '{project.Name}' (Id = {project.Id}) not found");

            bool isAnyUpdated = ServiceHelper<Project, DAL.Entities.Project>.UpdateDataByDTO(project,
                                                                                                 ref storedProject);

            if (isAnyUpdated) await _unitOfWork.ProjectRepository.UpdateAsync(storedProject);            
        }


        public async Task DeleteProjectAsync(int id)
        {            
            var storedProject = await _unitOfWork.ProjectRepository.GetByIdAsync(id);

            if (storedProject == null) throw new NotFoundException($"Project having Id = {id} not found");

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
