using Domain.Entities;
using InfraData.Mapping.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InfraData
{
    public class DepartmentMap : EntityMap, IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.Property(x => x.Name).HasMaxLength(255).IsRequired();
            builder.Property(x => x.Description).HasMaxLength(255).IsRequired();
            builder.Property(x => x.Imagem).HasMaxLength(255).IsRequired();

            builder.HasMany(x => x.Employees).WithOne(x => x.Department);

        }
    }
}
