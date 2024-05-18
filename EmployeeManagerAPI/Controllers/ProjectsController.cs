using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EmployeeManagerAPI.Models;
using EmployeeManagerAPI.Services;

namespace EmployeeManagerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectsController(ProjectService projectService) : ControllerBase
    {
        private readonly ProjectService _projectService = projectService ?? throw new ArgumentNullException(nameof(projectService));

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Project>>> GetProjects()
        {
            var projects = await _projectService.GetProjectsAsync();
            return Ok(projects);
        }

        [HttpGet("{name}/{number}")]
        public async Task<ActionResult<Project>> GetProject(string name, int number)
        {
            var project = await _projectService.GetProjectAsync(name, number);
            if (project == null)
            {
                return NotFound();
            }
            return Ok(project);
        }

        [HttpPut("{name}/{number}")]
        public async Task<IActionResult> PutProject(string name, int number, Project project)
        {
            try
            {
                await _projectService.UpdateProjectAsync(name, number, project);
                return NoContent();
            }
            catch (ArgumentException)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public async Task<ActionResult<Project>> PostProject(Project project)
        {
            try
            {
                await _projectService.AddProjectAsync(project);
                return CreatedAtAction(nameof(GetProject), new { name = project.Name, number = project.Number }, project);
            }
            catch (ArgumentException)
            {
                return Conflict();
            }
        }

        [HttpDelete("{name}/{number}")]
        public async Task<IActionResult> DeleteProject(string name, int number)
        {
            try
            {
                await _projectService.DeleteProjectAsync(name, number);
                return NoContent();
            }
            catch (ArgumentException)
            {
                return NotFound();
            }
        }

        [HttpGet("{projectName}/{projectNumber}/totalCost")]
        public async Task<ActionResult<decimal>> GetProjectTotalCost(string projectName, int projectNumber)
        {
            try
            {
                var totalCost = await _projectService.GetProjectTotalCostAsync(projectName, projectNumber);
                return Ok(totalCost);
            }
            catch (ArgumentException)
            {
                return NotFound();
            }
        }
    }
}
