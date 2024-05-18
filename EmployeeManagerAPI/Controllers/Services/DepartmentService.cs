using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EmployeeManagerAPI.Models;
using Microsoft.EntityFrameworkCore;
using EmployeeManagerAPI.Data;

namespace EmployeeManagerAPI.Services
{
    public class DepartmentService(DataContext context)
    {
        private readonly DataContext _context = context ?? throw new ArgumentNullException(nameof(context));

        public async Task<IEnumerable<Department>> GetDepartmentsAsync()
        {
            return await _context.Departments
                                    .Include(d => d.Employees) // Incluir la propiedad de navegación Employees
                                    .Include(d => d.Manages)   // Incluir la propiedad de navegación Manages
                                    .Include(d => d.ControlledProjects) // Incluir la propiedad de navegación ControlledProjects
                                    .ToListAsync();
        }

        public async Task<Department?> GetDepartmentAsync(string name, int number)
        {
            return await _context.Departments
                                    .Include(d => d.Employees) // Incluir la propiedad de navegación Employees
                                    .Include(d => d.Manages)   // Incluir la propiedad de navegación Manages
                                    .Include(d => d.ControlledProjects) // Incluir la propiedad de navegación ControlledProjects
                                    .FirstOrDefaultAsync(d => d.Name == name && d.Number == number);
        }


        public async Task UpdateDepartmentAsync(string name, int number, Department department)
        {
            if (name != department.Name || number != department.Number)
            {
                throw new ArgumentException("Department ID mismatch");
            }
            _context.Entry(department).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task CreateDepartmentAsync(Department department)
        {
            _context.Departments.Add(department);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                throw new ArgumentException("Department already exists");
            }
        }

        public async Task DeleteDepartmentAsync(string name, int number)
        {
            var department = await _context.Departments.FindAsync(name, number);
            if (department == null)
            {
                throw new ArgumentException("Department not found");
            }
            _context.Departments.Remove(department);
            await _context.SaveChangesAsync();
        }

        public async Task<decimal> GetTotalSalaryAsync(string departmentName, int departmentNumber)
        {
            var department = await _context.Departments
                .Include(d => d.Employees)
                .FirstOrDefaultAsync(d => d.Name == departmentName && d.Number == departmentNumber);
            if (department == null)
            {
                throw new ArgumentException("Department not found");
            }
            decimal totalSalary = 0;
            foreach (var employee in department.Employees)
            {
                totalSalary += employee.Salary;
            }
            return totalSalary;
        }
    }
}
