using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EmployeeManagerAPI.Data;
using EmployeeManagerAPI.Models;

namespace EmployeeManagerAPI.Services
{
    public class WorksOnService(DataContext context)
    {
        private readonly DataContext _context = context ?? throw new ArgumentNullException(nameof(context));

        public async Task<IEnumerable<WorksOn>> GetWorksOnsAsync()
        {
            return await _context.WorksOns
                                    .Include(w => w.Employee) // Incluir la propiedad de navegación Employee
                                    .Include(w => w.Project) // Incluir la propiedad de navegación Project
                                    .ToListAsync();
        }

        public async Task<WorksOn?> GetWorksOnAsync(string employeeSSN, string projectName, int projectNumber)
        {
            return await _context.WorksOns
                                    .Include(w => w.Employee) // Incluir la propiedad de navegación Employee
                                    .Include(w => w.Project) // Incluir la propiedad de navegación Project
                                    .FirstOrDefaultAsync(w => w.EmployeeSSN == employeeSSN && w.ProjectName == projectName && w.ProjectNumber == projectNumber);
        }

        public async Task UpdateWorksOnAsync(string employeeSSN, string projectName, int projectNumber, WorksOn worksOn)
        {
            if (employeeSSN != worksOn.EmployeeSSN || projectName != worksOn.ProjectName || projectNumber != worksOn.ProjectNumber)
            {
                throw new ArgumentException("WorksOn IDs mismatch");
            }
            _context.Entry(worksOn).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task AddWorksOnAsync(WorksOn worksOn)
        {
            _context.WorksOns.Add(worksOn);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteWorksOnAsync(string employeeSSN, string projectName, int projectNumber)
        {
            var worksOn = await _context.WorksOns.FindAsync(employeeSSN, projectName, projectNumber) ?? throw new ArgumentException("WorksOn not found");
            _context.WorksOns.Remove(worksOn);
            await _context.SaveChangesAsync();
        }
    }
}
