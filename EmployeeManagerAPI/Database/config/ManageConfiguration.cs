using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EmployeeManagerAPI.Models;

namespace EmployeeManagerAPI.Data.Configurations
{
    public class ManageConfiguration : IEntityTypeConfiguration<Manage>
    {
        public void Configure(EntityTypeBuilder<Manage> builder)
        {
            builder.HasKey(m => new { m.EmployeeSSN, m.DepartmentName, m.DepartmentNumber });

            builder.HasOne(m => m.Employee)
                    .WithOne(e => e.Manages)
                    .HasForeignKey<Manage>(m => m.EmployeeSSN)
                    .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(m => m.Department)
                    .WithOne(d => d.Manages)
                    .HasForeignKey<Manage>(m => new { m.DepartmentName, m.DepartmentNumber })
                    .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
