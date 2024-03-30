using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EmployeeManagerAPI.Data;
using EmployeeManagerAPI.Models;

namespace EmployeeManagerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorksOnsController : ControllerBase
    {
        private readonly DataContext _context;

        public WorksOnsController(DataContext context)
        {
            _context = context;
        }

        // GET: api/WorksOns
        [HttpGet]
        public async Task<ActionResult<IEnumerable<WorksOn>>> GetWorksOns()
        {
            return await _context.WorksOns.ToListAsync();
        }

        // GET: api/WorksOns/5
        [HttpGet("{id}")]
        public async Task<ActionResult<WorksOn>> GetWorksOn(string id)
        {
            var worksOn = await _context.WorksOns.FindAsync(id);

            if (worksOn == null)
            {
                return NotFound();
            }

            return worksOn;
        }

        // PUT: api/WorksOns/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWorksOn(string id, WorksOn worksOn)
        {
            if (id != worksOn.EmployeeSSN)
            {
                return BadRequest();
            }

            _context.Entry(worksOn).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WorksOnExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/WorksOns
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<WorksOn>> PostWorksOn(WorksOn worksOn)
        {
            _context.WorksOns.Add(worksOn);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (WorksOnExists(worksOn.EmployeeSSN))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetWorksOn", new { id = worksOn.EmployeeSSN }, worksOn);
        }

        // DELETE: api/WorksOns/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWorksOn(string id)
        {
            var worksOn = await _context.WorksOns.FindAsync(id);
            if (worksOn == null)
            {
                return NotFound();
            }

            _context.WorksOns.Remove(worksOn);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool WorksOnExists(string id)
        {
            return _context.WorksOns.Any(e => e.EmployeeSSN == id);
        }
    }
}
