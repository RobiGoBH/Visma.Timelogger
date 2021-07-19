using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using Timelogger.BLL.DTO;
using Timelogger.BLL.Services.Interfaces;


namespace Timelogger.Api.Controllers
{
	[Route("api/[controller]")]
	public class TasksController : ControllerBase
	{
		public TasksController(IProjectTaskService projectTaskService) =>
			_projectTaskService = projectTaskService;

		readonly IProjectTaskService _projectTaskService;
		

		// POST api/tasks
		[HttpPost]
		public async Task<IActionResult> AddTaskAsync([FromBody] ProjectTask projectTask)
		{
			await _projectTaskService.AddTaskAsync(projectTask);

			return Ok();
		}

		// PUT api/tasks
		[HttpPut]
		public async Task<IActionResult> UpdateProjectAsync([FromBody] ProjectTask projectTask)
		{
			await _projectTaskService.UpdateTaskAsync(projectTask);

			return Ok();
		}

		// DELETE api/tasks/{id}
		[HttpDelete]
		public async Task<IActionResult> DeleteProjectAsync(int id)
		{
			await _projectTaskService.DeleteTaskAsync(id);

			return Ok();
		}

		// GET api/tasks?projectId=1
		[HttpGet]
		public async Task<IActionResult> GetAllTasksByProjectIdAsync(int projectId)
		{
			return Ok(value: await _projectTaskService.GetAllTasksByProjectIdAsync(projectId));
		}

		// GET api/tasks/{id}
		[HttpGet]
		[Route("{id}")]
		public async Task<IActionResult> GetTaskByIdAsync(int id)
		{
			return Ok(value: await _projectTaskService.GetTaskByIdAsync(id));
		}
	}
}
