using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ToDo.Domain.Entities;

namespace ToDo.Infra.Mapping
{
    public class UserMap : IEntityTypeConfiguration<UserEntity>
    {
        public void Configure(EntityTypeBuilder<UserEntity> builder)
        {
            builder.HasKey(user => user.Id);

            builder.HasIndex(user => user.Email)
                    .IsUnique();

            builder.Property(user => user.Name)
                    .IsRequired()
                    .HasMaxLength(60);

            builder.Property(user => user.Email)
                    .IsRequired()
                    .HasMaxLength(100);

            builder.Property(user => user.Password)
                    .IsRequired()
                    .HasMaxLength(60);                    
        }
    }
}