using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyMusic.Domain.Entities;

namespace MyMusic.Infrastructure.Mappers
{
    public class PlaylistMapper : IEntityTypeConfiguration<PlaylistEntity>
    {
        public void Configure(EntityTypeBuilder<PlaylistEntity> builder)
        {
            builder.ToTable("Playlist");

            builder.HasKey(x => x.Id);

            builder.HasMany(x => x.PlaylistMusic)
                   .WithOne(c => c.Playlist);
        }
    }
}