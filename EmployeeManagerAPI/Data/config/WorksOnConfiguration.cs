using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EmployeeManagerAPI.Models;

namespace EmployeeManagerAPI.Data.Configurations
{
    public class WorksOnConfiguration : IEntityTypeConfiguration<WorksOn>
    {
        public void Configure(EntityTypeBuilder<WorksOn> builder)
        {
            builder.HasKey(w => new { w.EmployeeSSN, w.ProjectName, w.ProjectNumber });

            builder.HasOne(w => w.Employee)
                    .WithMany(e => e.WorksOns)
                    .HasForeignKey(w => w.EmployeeSSN);

            builder.HasOne(w => w.Project)
                    .WithMany(p => p.WorksOns)
                    .HasForeignKey(w => new { w.ProjectName, w.ProjectNumber });
        }
    }
}
