using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyMusic.Domain.Entities;

namespace MyMusic.Infrastructure.Mappers
{
    public class MusicMapper : IEntityTypeConfiguration<MusicEntity>
    {
        public void Configure(EntityTypeBuilder<MusicEntity> builder)
        {
            builder.ToTable("Musicas");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                   .HasColumnName("Nome");

            builder.Property(x => x.ArtistId)
                   .HasColumnName("ArtistaId");

            builder.HasOne(x => x.Artist)
                   .WithMany(c => c.Musics)
                   .HasForeignKey(z => z.Id);

        }
    }
}