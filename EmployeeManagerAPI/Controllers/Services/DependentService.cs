using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EmployeeManagerAPI.Models;
using EmployeeManagerAPI.Data;

namespace EmployeeManagerAPI.Services
{
    public class DependentService(DataContext context)
    {
        private readonly DataContext _context = context ?? throw new ArgumentNullException(nameof(context));

        public async Task<IEnumerable<Dependent>> GetDependentsAsync()
        {
            return await _context.Dependents.ToListAsync();
        }

        public async Task<Dependent?> GetDependentAsync(int id)
        {
            return await _context.Dependents.FindAsync(id);
        }

        public async Task UpdateDependentAsync(int id, Dependent dependent)
        {
            if (id != dependent.DependentId)
            {
                throw new ArgumentException("Dependent ID mismatch");
            }
            _context.Entry(dependent).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task AddDependentAsync(Dependent dependent)
        {
            _context.Dependents.Add(dependent);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteDependentAsync(int id)
        {
            var dependent = await _context.Dependents.FindAsync(id) ?? throw new ArgumentException("Dependent not found");
            _context.Dependents.Remove(dependent);
            await _context.SaveChangesAsync();
        }
    }
}
