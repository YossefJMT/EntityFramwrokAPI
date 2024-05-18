using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EmployeeManagerAPI.Models;
using EmployeeManagerAPI.Data;

namespace EmployeeManagerAPI.Services
{
    public class ProjectService(DataContext context)
    {
        private readonly DataContext _context = context ?? throw new ArgumentNullException(nameof(context));
        public async Task<IEnumerable<Project>> GetProjectsAsync()
        {
            return await _context.Projects
                                    .Include(p => p.ControllingDepartment) // Incluir la propiedad de navegación ControllingDepartment
                                    .Include(p => p.WorksOns) // Incluir la propiedad de navegación WorksOns
                                    .ToListAsync();
        }

        public async Task<Project?> GetProjectAsync(string name, int number)
        {
            return await _context.Projects
                                    .Include(p => p.ControllingDepartment) // Incluir la propiedad de navegación ControllingDepartment
                                    .Include(p => p.WorksOns) // Incluir la propiedad de navegación WorksOns
                                    .FirstOrDefaultAsync(p => p.Name == name && p.Number == number);
        }

        public async Task UpdateProjectAsync(string name, int number, Project project)
        {
            if (name != project.Name || number != project.Number)
            {
                throw new ArgumentException("Project name or number mismatch");
            }
            _context.Entry(project).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task AddProjectAsync(Project project)
        {
            _context.Projects.Add(project);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteProjectAsync(string name, int number)
        {
            var project = await _context.Projects.FindAsync(name, number);
            if (project == null)
            {
                throw new ArgumentException("Project not found");
            }
            _context.Projects.Remove(project);
            await _context.SaveChangesAsync();
        }

        public async Task<decimal> GetProjectTotalCostAsync(string projectName, int projectNumber)
        {
            var project = await _context.Projects
                .Include(p => p.WorksOns)
                    .ThenInclude(w => w.Employee)
                .FirstOrDefaultAsync(p => p.Name == projectName && p.Number == projectNumber) ?? throw new ArgumentException("Project not found");

            decimal totalCost = project.WorksOns
                .Where(w => w.Employee != null && w.Employee.Salary != null)
                .Sum(w => w.Employee.Salary);

            return totalCost;
        }
    }
}
