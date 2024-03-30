using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EmployeeManagerAPI.Models;

namespace EmployeeManagerAPI.Data.Configurations
{
    public class ProjectConfiguration : IEntityTypeConfiguration<Project>
    {
        public void Configure(EntityTypeBuilder<Project> builder)
        {
            builder.HasKey(p => new { p.Name, p.Number });

            builder.HasOne(p => p.ControllingDepartment)
                    .WithMany(d => d.ControlledProjects)
                    .HasForeignKey(p => new { p.ControllingDepartmentName, p.ControllingDepartmentNumber })
                    .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
