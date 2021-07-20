using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Net.Mime;
using System.Text.Json;
using System.Threading.Tasks;
using Timelogger.BLL.DTO;
using Timelogger.BLL.Services.Interfaces;

namespace Timelogger.Api.Controllers
{
	[Produces("application/json")]
	[Route("api/[controller]")]
	public class ProjectsController : ControllerBase
	{
		public ProjectsController(IProjectService projectService) =>
			_projectService = projectService;

		readonly IProjectService _projectService;

		// GET api/projects
		[HttpGet]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		public async Task<IActionResult> GetAllProjectsAsync()
		{
			try
            {
				var projects = await _projectService.GetAllProjectsAsync();
				return Ok(value: projects);
			}
			catch (System.Exception ex)
			{
				return BadRequest(new { Error = ex.Message });
			}
		}

		// GET api/projects/{id}
		[HttpGet]
		[Route("{id}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		public async Task<IActionResult> GetProjectByIdAsync(int id)
		{
			try
            {
				return Ok(value: await _projectService.GetProjectByIdAsync(id));
			}
			catch (System.Exception ex)
			{
				return BadRequest(new { Error = ex.Message });
			}
		}


		/// <summary>
		/// Creates a Project.
		/// </summary>
		/// <remarks>
		/// Sample request:
		///
		///     POST api/projects
		///     {
		///		  "id": 0,
		///		  "name": "A New Project",
		///		  "deadline": "2021-07-20T14:08:32.293Z",
		///		  "status": 0,
		///		  "startDate": "2021-07-19T15:08:32.293Z",
		///       "endDate": null
		///     }
		///
		/// </remarks>
		/// <param name="item"></param>
		/// <returns>A newly created Project Id</returns>
		/// <response code="201">Returns the newly created item id</response>
		/// <response code="400">If the item is null</response>         
		// POST api/projects
		[HttpPost]
		[Consumes(MediaTypeNames.Application.Json)]
		[ProducesResponseType(StatusCodes.Status201Created)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AddProjectAsync([FromBody] Project project)
		{			
            try
            {
				var savedProject = await _projectService.CreateProjectAsync(project);
				return Created($"api/projects/{savedProject.Id}", value: savedProject.Id);
			}
            catch (System.Exception ex)
            {
				return BadRequest(new { Error = ex.Message });
			}
		}

		// PUT api/projects
		[HttpPut]
		[Consumes(MediaTypeNames.Application.Json)]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		public async Task<IActionResult> UpdateProjectAsync([FromBody] Project project)
		{
            try
            {
				await _projectService.UpdateProjectAsync(project);
				return Ok();
			}
            catch (System.Exception ex)
            {
				return BadRequest(new { Error = ex.Message });
            }
		}

		// DELETE api/projects/{id}
		[HttpDelete]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		public async Task<IActionResult> DeleteProjectAsync(int id)
		{			
            try
            {
				await _projectService.DeleteProjectAsync(id);
				return Ok(value: new { Message = "Project Deleted" });
			}
			catch (System.Exception ex)
			{
				return BadRequest(new { Error = ex.Message });
			}
		}		
	}
} 
