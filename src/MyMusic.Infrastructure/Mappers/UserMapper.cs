using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyMusic.Domain.Entities;

namespace MyMusic.Infrastructure.Mappers
{
    public class UserMapper : IEntityTypeConfiguration<UserEntity>
    {
        public void Configure(EntityTypeBuilder<UserEntity> builder)
        {
            builder.ToTable("Usuarios");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                   .HasColumnName("Nome");

            builder.HasOne(x => x.Playlist)
                   .WithOne();
        }
    }
}