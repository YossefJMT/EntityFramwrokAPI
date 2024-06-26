using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EmployeeManagerAPI.Models;

namespace EmployeeManagerAPI.Data.Configurations
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.HasKey(e => e.SSN);

            builder.HasOne(e => e.Supervisor)
                    .WithMany()
                    .HasForeignKey(e => e.SupervisorSSN)
                    .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(e => e.Department)
                    .WithMany(d => d.Employees)
                    .HasForeignKey(e => new { e.DepartmentName, e.DepartmentNumber })
                    .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(e => e.Dependents)
                    .WithOne(d => d.Employee)
                    .HasForeignKey(d => d.EmployeeSSN)
                    .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
