using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EmployeeManagerAPI.Models;
using EmployeeManagerAPI.Data;

namespace EmployeeManagerAPI.Services
{
    public class EmployeeService(DataContext context)
    {
        private readonly DataContext _context = context ?? throw new ArgumentNullException(nameof(context));

        public async Task<IEnumerable<Employee>> GetEmployeesAsync()
        {
            return await _context.Employees
                                    .Include(e => e.Department) // Incluir la propiedad de navegación Department
                                    .Include(e => e.Supervisor) // Incluir la propiedad de navegación Supervisor
                                    .Include(e => e.WorksOns) // Incluir la propiedad de navegación WorksOns
                                    .Include(e => e.Dependents) // Incluir la propiedad de navegación Dependents
                                    .Include(e => e.Manages) // Incluir la propiedad de navegación Manages
                                    .Include(e => e.Supervisor) // Incluir la propiedad de navegación Supervisor
                                    .ToListAsync();
        }

        public async Task<Employee?> GetEmployeeAsync(string id)
        {
            return await _context.Employees
                                    .Include(e => e.Department) // Incluir la propiedad de navegación Department
                                    .Include(e => e.Supervisor) // Incluir la propiedad de navegación Supervisor
                                    .Include(e => e.WorksOns) // Incluir la propiedad de navegación WorksOns
                                    .Include(e => e.Dependents) // Incluir la propiedad de navegación Dependents
                                    .Include(e => e.Manages) // Incluir la propiedad de navegación Manages
                                    .Include(e => e.Supervisor) // Incluir la propiedad de navegación Supervisor
                                    .FirstOrDefaultAsync(e => e.SSN == id);
        }

        public async Task UpdateEmployeeAsync(string id, Employee employee)
        {
            if (id != employee.SSN)
            {
                throw new ArgumentException("Employee SSN mismatch");
            }
            _context.Entry(employee).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task AddEmployeeAsync(Employee employee)
        {
            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteEmployeeAsync(string id)
        {
            var employee = await _context.Employees.FindAsync(id);
            if (employee == null)
            {
                throw new ArgumentException("Employee not found");
            }
            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();
        }
    }
}
