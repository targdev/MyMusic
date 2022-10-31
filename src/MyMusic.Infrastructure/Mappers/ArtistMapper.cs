using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyMusic.Domain.Entities;

namespace MyMusic.Infrastructure.Mappers
{
    public class ArtistMapper : IEntityTypeConfiguration<ArtistEntity>
    {
        public void Configure(EntityTypeBuilder<ArtistEntity> builder)
        {
            builder.ToTable("Artistas");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                   .HasColumnName("Nome");

            builder.HasMany(x => x.Musics)
                   .WithOne(x => x.Artist);
        }
    }
}