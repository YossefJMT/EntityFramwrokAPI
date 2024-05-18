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
    public class DepartmentsController : ControllerBase
    {
        private readonly DepartmentService _departmentService;

        public DepartmentsController(DepartmentService departmentService)
        {
            _departmentService = departmentService ?? throw new ArgumentNullException(nameof(departmentService));
        }

        // GET: api/Departments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Department>>> GetDepartments()
        {
            var departments = await _departmentService.GetDepartmentsAsync();
            return Ok(departments);
        }

        // GET: api/Departments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Department>> GetDepartment(string id)
        {
            var department = await _departmentService.GetDepartmentAsync(id);
            if (department == null)
            {
                return NotFound();
            }
            return department;
        }

        // PUT: api/Departments/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDepartment(string id, Department department)
        {
            if (id != department.Name)
            {
                return BadRequest();
            }
            try
            {
                await _departmentService.UpdateDepartmentAsync(id, department);
            }
            catch (ArgumentException)
            {
                return NotFound();
            }
            return NoContent();
        }

        // POST: api/Departments
        [HttpPost]
        public async Task<ActionResult<Department>> PostDepartment(Department department)
        {
            try
            {
                await _departmentService.CreateDepartmentAsync(department);
            }
            catch (ArgumentException)
            {
                return Conflict();
            }
            return CreatedAtAction(nameof(GetDepartment), new { id = department.Name }, department);
        }

        // DELETE: api/Departments/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDepartment(string id)
        {
            try
            {
                await _departmentService.DeleteDepartmentAsync(id);
            }
            catch (ArgumentException)
            {
                return NotFound();
            }
            return NoContent();
        }

        // GET: api/Departments/{departmentName}/{departmentNumber}/TotalSalary
        [HttpGet("{departmentName}/{departmentNumber}/TotalSalary")]
        public async Task<ActionResult<decimal>> GetTotalSalary(string departmentName, int departmentNumber)
        {
            try
            {
                var totalSalary = await _departmentService.GetTotalSalaryAsync(departmentName, departmentNumber);
                return Ok(totalSalary);
            }
            catch (ArgumentException)
            {
                return NotFound();
            }
        }
    }
}
