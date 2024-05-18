using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EmployeeManagerAPI.Models;
using EmployeeManagerAPI.Services;

namespace EmployeeManagerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorksOnsController(WorksOnService worksOnService) : ControllerBase
    {
        private readonly WorksOnService _worksOnService = worksOnService ?? throw new ArgumentNullException(nameof(worksOnService));

        [HttpGet]
        public async Task<ActionResult<IEnumerable<WorksOn>>> GetWorksOns()
        {
            var worksOns = await _worksOnService.GetWorksOnsAsync();
            return Ok(worksOns);
        }

        [HttpGet("{employeeSSN}/{projectName}/{projectNumber}")]
        public async Task<ActionResult<WorksOn>> GetWorksOn(string employeeSSN, string projectName, int projectNumber)
        {
            var worksOn = await _worksOnService.GetWorksOnAsync(employeeSSN, projectName, projectNumber);
            if (worksOn == null)
            {
                return NotFound();
            }
            return Ok(worksOn);
        }

        [HttpPut("{employeeSSN}/{projectName}/{projectNumber}")]
        public async Task<IActionResult> PutWorksOn(string employeeSSN, string projectName, int projectNumber, WorksOn worksOn)
        {
            try
            {
                await _worksOnService.UpdateWorksOnAsync(employeeSSN, projectName, projectNumber, worksOn);
                return NoContent();
            }
            catch (ArgumentException)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public async Task<ActionResult<WorksOn>> PostWorksOn(WorksOn worksOn)
        {
            try
            {
                await _worksOnService.AddWorksOnAsync(worksOn);
                return CreatedAtAction(nameof(GetWorksOn), new { employeeSSN = worksOn.EmployeeSSN, projectName = worksOn.ProjectName, projectNumber = worksOn.ProjectNumber }, worksOn);
            }
            catch (ArgumentException)
            {
                return Conflict();
            }
        }

        [HttpDelete("{employeeSSN}/{projectName}/{projectNumber}")]
        public async Task<IActionResult> DeleteWorksOn(string employeeSSN, string projectName, int projectNumber)
        {
            try
            {
                await _worksOnService.DeleteWorksOnAsync(employeeSSN, projectName, projectNumber);
                return NoContent();
            }
            catch (ArgumentException)
            {
                return NotFound();
            }
        }
    }
}
