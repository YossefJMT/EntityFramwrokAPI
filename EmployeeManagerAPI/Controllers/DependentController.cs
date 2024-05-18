using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EmployeeManagerAPI.Models;
using EmployeeManagerAPI.Services;

namespace EmployeeManagerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DependentController(DependentService dependentService) : ControllerBase
    {
        private readonly DependentService _dependentService = dependentService;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Dependent>>> GetDependents()
        {
            var dependents = await _dependentService.GetDependentsAsync();
            return Ok(dependents);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Dependent>> GetDependent(int id)
        {
            var dependent = await _dependentService.GetDependentAsync(id);
            if (dependent == null)
            {
                return NotFound();
            }
            return Ok(dependent);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutDependent(int id, Dependent dependent)
        {
            if (id != dependent.DependentId)
            {
                return BadRequest("Dependent ID mismatch");
            }

            await _dependentService.UpdateDependentAsync(id, dependent);
            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<Dependent>> PostDependent(Dependent dependent)
        {
            // Ignorar la validación de la propiedad de navegación 'Employee'
            ModelState.Remove(nameof(dependent.Employee));

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            dependent.Employee = await _dependentService.GetEmployeeBySSNAsync(dependent.EmployeeSSN);

            await _dependentService.AddDependentAsync(dependent);
            return CreatedAtAction(nameof(GetDependent), new { id = dependent.DependentId }, dependent);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDependent(int id)
        {
            await _dependentService.DeleteDependentAsync(id);
            return NoContent();
        }
    }
}