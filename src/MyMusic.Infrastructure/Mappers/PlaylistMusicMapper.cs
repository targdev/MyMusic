using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyMusic.Domain.Entities;

namespace MyMusic.Infrastructure.Mappers
{
    public class PlaylistMusicMapper : IEntityTypeConfiguration<PlaylistMusicEntity>
    {
        public void Configure(EntityTypeBuilder<PlaylistMusicEntity> builder)
        {
            builder.ToTable("PlaylistMusicas");

            builder.HasKey(pm => new { pm.PlaylistId, pm.MusicId });

            builder.Property(x => x.PlaylistId)
                   .HasColumnName("PlaylistId");

            builder.Property(x => x.MusicId)
                   .HasColumnName("MusicaId");

            builder.HasOne(x => x.Playlist)
                   .WithMany(c => c.PlaylistMusic);

            builder.HasOne(x => x.Music)
                   .WithMany(c => c.PlaylistMusic)
                   .HasForeignKey(z => z.MusicId);
        }
    }
}