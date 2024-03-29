// Data/DataContext.cs
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagerAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        // DbSet para cada entidad
        // public DbSet<Employee> Employees { get; set; }
        // public DbSet<Department> Departments { get; set; }
        // public DbSet<Project> Projects { get; set; }
        // public DbSet<Dependent> Dependents { get; set; }
    }
}