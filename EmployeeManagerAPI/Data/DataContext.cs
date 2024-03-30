using Microsoft.EntityFrameworkCore;
using EmployeeManagerAPI.Models;
using EmployeeManagerAPI.Data.Configurations;

namespace EmployeeManagerAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Manage> Manages { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<WorksOn> WorksOns { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new EmployeeConfiguration());
            modelBuilder.ApplyConfiguration(new DepartmentConfiguration());
            modelBuilder.ApplyConfiguration(new ManageConfiguration());
            modelBuilder.ApplyConfiguration(new ProjectConfiguration());
            modelBuilder.ApplyConfiguration(new WorksOnConfiguration());
        }
    }
}
