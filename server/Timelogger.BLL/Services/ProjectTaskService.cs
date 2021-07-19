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

namespace Timelogger.BLL.Services
{
    public class ProjectTaskService : BaseService, IProjectTaskService
    {
        public ProjectTaskService(IUnitOfWork unitOfWork, IMapper mapper)
            : base(unitOfWork, mapper) { }

        

        public async Task AddTaskAsync(ProjectTask projectTask)
        {
            var taskExist = await _unitOfWork.ProjectTaskRepository
                .GetAllByCriteriaAsync(x => x.ProjectId == projectTask.ProjectId && x.Name == projectTask.Name) != null;

            if (taskExist) throw new EntityDuplicateException($"Task \"{projectTask.Name}\" already exist");

            var mappedTask = _mapper.Map<Timelogger.DAL.Entities.ProjectTask>(projectTask);

            await _unitOfWork.ProjectTaskRepository
                .AddAsync(mappedTask);
        }

        public async Task UpdateTaskAsync(ProjectTask projectTask)
        {
            var storedTask = await _unitOfWork.ProjectTaskRepository
                .GetByIdAsync(projectTask.Id);

            if (storedTask == null) throw new NotFoundException($"Task \"{projectTask.Name}\" not found");

            PropertyInfo[] properties = typeof(ProjectTask).GetProperties();
            foreach (var prop in properties)
            {
                if (prop.Name.ToLowerInvariant() == "id") continue;

                if (prop.GetValue(projectTask) != prop.GetValue(storedTask))
                {
                    prop.SetValue(storedTask, prop.GetValue(projectTask));
                }
            }

            await _unitOfWork.ProjectTaskRepository.UpdateAsync(storedTask);
        }


        public async Task DeleteTaskAsync(int id)
        {
            var storedTask = await _unitOfWork.ProjectTaskRepository.GetByIdAsync(id);

            if (storedTask == null) throw new NotFoundException($"Task having id = {id} not found");

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
