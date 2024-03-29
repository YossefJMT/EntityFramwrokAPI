// Data/DataContext.cs
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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configurar la relación de supervisión
            modelBuilder.Entity<Employee>()
                .HasMany(e => e.SupervisedEmployees) // Un empleado puede supervisar a muchos empleados
                .WithOne() // Un empleado supervisado no tiene un empleado supervisor explícito
                .HasForeignKey(e => e.SSN) // La clave foránea en la tabla Employee
                .IsRequired(false); // La relación es opcional (un empleado puede no tener supervisores)
        }
    }
}