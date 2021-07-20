using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using Timelogger.BLL.DTO;
using Timelogger.BLL.Services.Interfaces;
using System.Net.Mime;
using Microsoft.AspNetCore.Http;

namespace Timelogger.Api.Controllers
{
	[Produces("application/json")]
	[Route("api/[controller]")]
	public class TasksController : ControllerBase
	{
		public TasksController(IProjectTaskService projectTaskService) =>
			_projectTaskService = projectTaskService;

		readonly IProjectTaskService _projectTaskService;

		// GET api/tasks?projectId=1
		[HttpGet]
		[ProducesResponseType(StatusCodes.Status201Created)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		public async Task<IActionResult> GetAllTasksByProjectIdAsync(int projectId)
		{
			try
            {
				return Ok(value: await _projectTaskService.GetAllTasksByProjectIdAsync(projectId));
			}
			catch (System.Exception ex)
			{
				return BadRequest(new { Error = ex.Message });
			}
		}

		// GET api/tasks/{id}
		[HttpGet]
		[Route("{id}")]
		[ProducesResponseType(StatusCodes.Status201Created)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		public async Task<IActionResult> GetTaskByIdAsync(int id)
		{
			try
            {
				return Ok(value: await _projectTaskService.GetTaskByIdAsync(id));
			}
			catch (System.Exception ex)
			{
				return BadRequest(new { Error = ex.Message });
			}
		}

		/// <summary>
		/// Create and add a new Task to a Project.
		/// </summary>
		/// <remarks>
		/// Sample request:
		///
		///     POST api/tasks
		///     {
		///		  "id": 0,
		///		  "name": "A New Task",
		///		  "type": "Meeting",
		///		  "projectId": 2,
		///		  "startDate": "2021-07-19T15:08:32.293Z",
		///       "endDate": null
		///     }
		/// 
		/// </remarks>
		/// <param name="item"></param>
		/// <returns>A the newly created Task id</returns>
		/// <response code="201">Returns the newly created item id</response>
		/// <response code="400">If the item is null</response>      

		// POST api/tasks
		[HttpPost]
		[Consumes(MediaTypeNames.Application.Json)]
		[ProducesResponseType(StatusCodes.Status201Created)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		public async Task<IActionResult> AddTaskAsync([FromBody] ProjectTask projectTaskJson)
		{
			try
            {
				var savedTask = await _projectTaskService.AddTaskAsync(projectTaskJson);
				return Ok(value: savedTask.Id);
			}
			catch (System.Exception ex)
			{
				return BadRequest(new { Error = ex.Message });
			}
		}
		
		// PUT api/tasks
		[HttpPut]
		[Consumes(MediaTypeNames.Application.Json)]
		[ProducesResponseType(StatusCodes.Status201Created)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		public async Task<IActionResult> UpdateProjectAsync([FromBody] ProjectTask projectTaskJson)
		{			
			try
            {
				await _projectTaskService.UpdateTaskAsync(projectTaskJson);
				return Ok();
			}
			catch (System.Exception ex)
			{
				return BadRequest(new { Error = ex.Message });
			}
		}

		// DELETE api/tasks/{id}
		[HttpDelete]
		[ProducesResponseType(StatusCodes.Status201Created)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		public async Task<IActionResult> DeleteProjectAsync(int id)
		{			
            try
            {
				await _projectTaskService.DeleteTaskAsync(id);
				return Ok();
			}
			catch (System.Exception ex)
			{
				return BadRequest(new { Error = ex.Message });
			}
		}		
	}
}
