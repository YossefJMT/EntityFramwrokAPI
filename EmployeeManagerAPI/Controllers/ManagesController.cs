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
    public class ManagesController : ControllerBase
    {
        private readonly DataContext _context;

        public ManagesController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Manages
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Manage>>> GetManages()
        {
            return await _context.Manages.ToListAsync();
        }

        // GET: api/Manages/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Manage>> GetManage(string id)
        {
            var manage = await _context.Manages.FindAsync(id);

            if (manage == null)
            {
                return NotFound();
            }

            return manage;
        }

        // PUT: api/Manages/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutManage(string id, Manage manage)
        {
            if (id != manage.EmployeeSSN)
            {
                return BadRequest();
            }

            _context.Entry(manage).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ManageExists(id))
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

        // POST: api/Manages
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Manage>> PostManage(Manage manage)
        {
            manage.Employee ??= null;
            manage.Department ??= null;

            _context.Manages.Add(manage);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ManageExists(manage.EmployeeSSN))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetManage", new { id = manage.EmployeeSSN }, manage);
        }

        // DELETE: api/Manages/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteManage(string id)
        {
            var manage = await _context.Manages.FindAsync(id);
            if (manage == null)
            {
                return NotFound();
            }

            _context.Manages.Remove(manage);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ManageExists(string id)
        {
            return _context.Manages.Any(e => e.EmployeeSSN == id);
        }
    }
}
