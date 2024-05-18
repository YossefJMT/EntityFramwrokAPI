using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EmployeeManagerAPI.Models;
using Microsoft.EntityFrameworkCore;
using EmployeeManagerAPI.Data;

namespace EmployeeManagerAPI.Services
{
    public class DepartmentService
    {
        private readonly DataContext _context;

        public DepartmentService(DataContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<IEnumerable<Department>> GetDepartmentsAsync()
        {
            return await _context.Departments.ToListAsync();
        }

        public async Task<Department?> GetDepartmentAsync(string id)
        {
            return await _context.Departments.FindAsync(id);
        }

        public async Task UpdateDepartmentAsync(string id, Department department)
        {
            if (id != department.Name)
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

        public async Task DeleteDepartmentAsync(string id)
        {
            var department = await _context.Departments.FindAsync(id);
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
