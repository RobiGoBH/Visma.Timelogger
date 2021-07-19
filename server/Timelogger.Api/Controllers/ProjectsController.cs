using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using Timelogger.BLL.DTO;
using Timelogger.BLL.Services.Interfaces;

namespace Timelogger.Api.Controllers
{
	[Route("api/[controller]")]
	public class ProjectsController : ControllerBase
	{
		public ProjectsController(IProjectService projectService) =>
			_projectService = projectService;

		readonly IProjectService _projectService;

		// POST api/projects
		[HttpPost]
		public async Task<IActionResult> AddProjectAsync([FromBody] Project project)
		{
			await _projectService.CreateProjectAsync(project);

			return Ok();
		}

		// PUT api/projects
		[HttpPut]
		public async Task<IActionResult> UpdateProjectAsync([FromBody] Project project)
		{
			await _projectService.UpdateProjectAsync(project);

			return Ok();
		}

		// DELETE api/projects/{id}
		[HttpDelete]
		public async Task<IActionResult> DeleteProjectAsync(int id)
		{
			await _projectService.DeleteProjectAsync(id);

			return Ok();
		}

		// GET api/projects
		[HttpGet]
		public async Task<IActionResult> GetAllProjectsAsync()
		{
			var projects = await _projectService.GetAllProjectsAsync();
			return Ok(value: projects);
        }

		// GET api/projects/{id}
		[HttpGet]
		[Route("{id}")]
		public async Task<IActionResult> GetProjectByIdAsync(int id)
		{
			return Ok(value: await _projectService.GetProjectByIdAsync(id));
		}
	}
} 
