using Microsoft.EntityFrameworkCore;
using MyMusic.Domain.Entities;

namespace MyMusic.Infrastructure.DataProviders.Repositories
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        { }

        public DbSet<ArtistEntity> Artists { get; set; }
        public DbSet<MusicEntity> Musics { get; set; }
        public DbSet<PlaylistEntity> Playlists { get; set; }
        public DbSet<PlaylistMusicEntity> PlaylistMusics { get; set; }
        public DbSet<UserEntity> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);

        }
    }
}