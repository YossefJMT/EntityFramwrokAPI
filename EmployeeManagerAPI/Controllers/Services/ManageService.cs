using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EmployeeManagerAPI.Models;
using EmployeeManagerAPI.Data;

namespace EmployeeManagerAPI.Services
{
    public class ManageService(DataContext context)
    {
        private readonly DataContext _context = context ?? throw new ArgumentNullException(nameof(context));

        public async Task<IEnumerable<Manage>> GetManagesAsync()
        {
            return await _context.Manages.ToListAsync();
        }

        public async Task<Manage?> GetManageAsync(string employeeSSN)
        {
            return await _context.Manages.FindAsync(employeeSSN);
        }

        public async Task UpdateManageAsync(string employeeSSN, Manage manage)
        {
            if (employeeSSN != manage.EmployeeSSN)
            {
                throw new ArgumentException("Manage SSN mismatch");
            }
            _context.Entry(manage).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task AddManageAsync(Manage manage)
        {
            _context.Manages.Add(manage);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteManageAsync(string employeeSSN)
        {
            var manage = await _context.Manages.FindAsync(employeeSSN);
            if (manage == null)
            {
                throw new ArgumentException("Manage not found");
            }
            _context.Manages.Remove(manage);
            await _context.SaveChangesAsync();
        }
    }
}
