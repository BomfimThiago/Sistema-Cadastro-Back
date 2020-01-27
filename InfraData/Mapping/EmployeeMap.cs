using Domain.Entities;
using InfraData.Mapping.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InfraData
{
    public class EmployeeMap : EntityMap, IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.Property(x => x.Name).HasMaxLength(255).IsRequired();
            builder.Property(x => x.Contact).HasMaxLength(30).IsRequired();
            builder.Property(x => x.Cpf).HasMaxLength(11).IsRequired();
            builder.Property(x => x.Email).HasMaxLength(255).IsRequired();
            builder.Property(x => x.Age).IsRequired();
            builder.Property(x => x.JoinDate).IsRequired();
            

            builder.Property(x => x.DepartmentId).IsRequired();

            builder.HasOne(x => x.Department).WithMany(x => x.Employees);
        }
    }
}
