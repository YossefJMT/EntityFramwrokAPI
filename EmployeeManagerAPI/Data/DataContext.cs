using Microsoft.EntityFrameworkCore;
using ProyectoAPI.Models;

namespace EmployeeManagerAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuración de la relación reflexiva Supervisor con Employee
            modelBuilder.Entity<Employee>()
                .HasOne(e => e.Supervisor)
                .WithMany()
                .HasForeignKey(e => e.SupervisorSSN);


            // Configuración de la relación WorksFor entre Employee y Department
            modelBuilder.Entity<Employee>()
                .HasOne(e => e.Department)
                .WithMany(d => d.Employees)
                .HasForeignKey(e => new { e.DepartmentName, e.DepartmentNumber });


            modelBuilder.Entity<Department>()
                .HasKey(d => new { d.Name, d.Number });

            base.OnModelCreating(modelBuilder);
        }
    }
}
