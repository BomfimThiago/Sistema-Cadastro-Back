using Domain.Entities;
using InfraData.Mapping.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InfraData.Mapping
{
    public class UserMap : EntityMap, IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(x => x.Username).HasMaxLength(255).IsRequired();
            builder.Property(x => x.PasswordHash).HasMaxLength(255).IsRequired();
            builder.Property(x => x.PasswordSalt).HasMaxLength(255).IsRequired();
        }
    }
}
