using AutoMapper;
using Timelogger.BLL.DTO;
using Timelogger.BLL.Exceptions;
using Timelogger.BLL.Services.Base;
using Timelogger.BLL.Services.Interfaces;
using Timelogger.DAL.Entities;
using Timelogger.DAL.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ProjectTask = Timelogger.BLL.DTO.ProjectTask;
using System.Reflection;
using Timelogger.BLL.Helper;

namespace Timelogger.BLL.Services
{
    public class ProjectTaskService : BaseService, IProjectTaskService
    {
        public ProjectTaskService(IUnitOfWork unitOfWork, IMapper mapper)
            : base(unitOfWork, mapper) { }        

        public async Task<ProjectTask> AddTaskAsync(ProjectTask projectTask)
        {
            var projectNotFound= await _unitOfWork.ProjectRepository
                .GetSingleOrDefaultByCriteriaAsync(x => x.Id == projectTask.ProjectId) == null;

            if (projectNotFound) throw new NotFoundException($"Project having Id = {projectTask.ProjectId} not found");

            //var taskExist = await _unitOfWork.ProjectTaskRepository
            //    .GetSingleOrDefaultByCriteriaAsync(x => (x.ProjectId == projectTask.ProjectId && x.Name == projectTask.Name)) != null;

            //if (taskExist) throw new EntityDuplicateException($"Task \"{projectTask.Name}\" already exist");

            var mappedTask = _mapper.Map<DAL.Entities.ProjectTask>(projectTask);

            mappedTask.Project = null;

            return _mapper.Map<ProjectTask>(await _unitOfWork.ProjectTaskRepository.AddAsync(mappedTask));
        }

        public async Task UpdateTaskAsync(ProjectTask projectTask)
        {
            var storedTask = await _unitOfWork.ProjectTaskRepository
                .GetByIdAsync(projectTask.Id);

            if (storedTask == null) throw new NotFoundException($"Task '{projectTask.Name}' Id = {projectTask.Id} not found");

            bool isAnyUpdated = ServiceHelper<ProjectTask, DAL.Entities.ProjectTask>.UpdateDataByDTO(projectTask,
                                                                                                 ref storedTask);

            if (isAnyUpdated) await _unitOfWork.ProjectTaskRepository.UpdateAsync(storedTask);
        }


        public async Task DeleteTaskAsync(int id)
        {
            var storedTask = await _unitOfWork.ProjectTaskRepository.GetByIdAsync(id);

            if (storedTask == null) throw new NotFoundException($"Task having Id = {id} not found");

            await _unitOfWork.ProjectTaskRepository.DeleteAsync(storedTask);
        }


        public async Task<IEnumerable<ProjectTask>> GetAllTasksByProjectIdAsync(int id)
        {
            var taskOfProject = await _unitOfWork.ProjectTaskRepository
                .GetAllByCriteriaAsync(x => x.ProjectId == id);

            if (taskOfProject == null) return new List<ProjectTask>();

            return _mapper.Map<IEnumerable<DAL.Entities.ProjectTask>, IEnumerable<ProjectTask>>(taskOfProject);
        }

        public async Task<ProjectTask> GetTaskByIdAsync(int id)
        {
            var storedTask = await _unitOfWork.ProjectTaskRepository.GetByIdAsync(id);

            if (storedTask == null) throw new NotFoundException($"Task having Id = {id} not found");

            return _mapper.Map<ProjectTask>(storedTask);
        }
    }
}
