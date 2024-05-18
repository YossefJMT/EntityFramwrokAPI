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
    public class DepartmentsController(DepartmentService departmentService) : ControllerBase
    {
        private readonly DepartmentService _departmentService = departmentService ?? throw new ArgumentNullException(nameof(departmentService));

        // GET: api/Departments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Department>>> GetDepartments()
        {
            var departments = await _departmentService.GetDepartmentsAsync();
            return Ok(departments);
        }

        // GET: api/Departments/{name}/{number}
        [HttpGet("{name}/{number}")]
        public async Task<ActionResult<Department>> GetDepartment(string name, int number)
        {
            var department = await _departmentService.GetDepartmentAsync(name, number);
            if (department == null)
            {
                return NotFound();
            }
            return department;
        }

        // PUT: api/Departments/{name}/{number}
        [HttpPut("{name}/{number}")]
        public async Task<IActionResult> PutDepartment(string name, int number, Department department)
        {
            try
            {
                await _departmentService.UpdateDepartmentAsync(name, number, department);
                return NoContent();
            }
            catch (ArgumentException)
            {
                return NotFound();
            }
        }

        // POST: api/Departments
        [HttpPost]
        public async Task<ActionResult<Department>> PostDepartment(Department department)
        {
            try
            {
                await _departmentService.CreateDepartmentAsync(department);
                return CreatedAtAction(nameof(GetDepartment), new { name = department.Name, number = department.Number }, department);
            }
            catch (ArgumentException)
            {
                return Conflict();
            }
        }

        // DELETE: api/Departments/{name}/{number}
        [HttpDelete("{name}/{number}")]
        public async Task<IActionResult> DeleteDepartment(string name, int number)
        {
            try
            {
                await _departmentService.DeleteDepartmentAsync(name, number);
                return NoContent();
            }
            catch (ArgumentException)
            {
                return NotFound();
            }
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
