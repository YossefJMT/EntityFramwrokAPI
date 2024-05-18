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
    public class ManagesController(ManageService manageService) : ControllerBase
    {
        private readonly ManageService _manageService = manageService ?? throw new ArgumentNullException(nameof(manageService));

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Manage>>> GetManages()
        {
            var manages = await _manageService.GetManagesAsync();
            return Ok(manages);
        }

        [HttpGet("{employeeSSN}")]
        public async Task<ActionResult<Manage>> GetManage(string employeeSSN)
        {
            var manage = await _manageService.GetManageAsync(employeeSSN);
            if (manage == null)
            {
                return NotFound();
            }
            return Ok(manage);
        }

        [HttpPut("{employeeSSN}")]
        public async Task<IActionResult> PutManage(string employeeSSN, Manage manage)
        {
            try
            {
                await _manageService.UpdateManageAsync(employeeSSN, manage);
                return NoContent();
            }
            catch (ArgumentException)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public async Task<ActionResult<Manage>> PostManage(Manage manage)
        {
            try
            {
                await _manageService.AddManageAsync(manage);
                return CreatedAtAction(nameof(GetManage), new { employeeSSN = manage.EmployeeSSN }, manage);
            }
            catch (ArgumentException)
            {
                return Conflict();
            }
        }

        [HttpDelete("{employeeSSN}")]
        public async Task<IActionResult> DeleteManage(string employeeSSN)
        {
            try
            {
                await _manageService.DeleteManageAsync(employeeSSN);
                return NoContent();
            }
            catch (ArgumentException)
            {
                return NotFound();
            }
        }
    }
}
