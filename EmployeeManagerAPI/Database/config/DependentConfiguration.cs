using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EmployeeManagerAPI.Models;

namespace EmployeeManagerAPI.Data.Configurations
{
    public class DependentConfiguration : IEntityTypeConfiguration<Dependent>
    {
        public void Configure(EntityTypeBuilder<Dependent> builder)
        {
            builder.HasKey(d => d.DependentId);

            builder.HasOne(d => d.Employee)
                    .WithMany(e => e.Dependents)
                    .HasForeignKey(d => d.EmployeeSSN)
                    .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
