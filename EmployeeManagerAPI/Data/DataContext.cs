using Microsoft.EntityFrameworkCore;
using EmployeeManagerAPI.Models;

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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuración de la relación reflexiva Supervisor con Employee
            modelBuilder.Entity<Employee>()
                .HasOne(e => e.Supervisor)
                .WithMany()
                .HasForeignKey(e => e.SupervisorSSN)
                .OnDelete(DeleteBehavior.Restrict); // Evitar la eliminación en cascada
                

            // Configuración de la relación WorksFor con Department
            modelBuilder.Entity<Employee>()
                .HasOne(e => e.Department)
                .WithMany(d => d.Employees)
                .HasForeignKey(e => new { e.DepartmentName, e.DepartmentNumber })
                .OnDelete(DeleteBehavior.Restrict); // Evitar la eliminación en cascada
            
            // Configuracion de key compuesta para Department
            modelBuilder.Entity<Department>()
                .HasKey(d => new { d.Name, d.Number });


            // Configuración de la relación Manages entre Employee y Department
            modelBuilder.Entity<Manage>()
                .HasKey(m => new { m.EmployeeSSN, m.DepartmentName, m.DepartmentNumber });

            modelBuilder.Entity<Manage>()
                .HasOne(m => m.Employee)
                .WithOne(e => e.Manages)
                .HasForeignKey<Manage>(m => m.EmployeeSSN)
                .OnDelete(DeleteBehavior.Restrict); // Evitar la eliminación en cascada

            modelBuilder.Entity<Manage>()
                .HasOne(m => m.Department)
                .WithOne(d => d.Manages)
                .HasForeignKey<Manage>(m => new { m.DepartmentName, m.DepartmentNumber })
                .OnDelete(DeleteBehavior.Restrict); // Evitar la eliminación en cascada


            base.OnModelCreating(modelBuilder);
        }
    }
}
