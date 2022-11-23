using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MyMusic.Domain.Abstractions.Gateways;
using MyMusic.Domain.Dto;
using MyMusic.Domain.Entities;

namespace MyMusic.Infrastructure.DataProviders.Repositories
{
    public class MusicRepository : IMusicGateway
    {
        private readonly AppDbContext _dBContext;

        MusicRepository(AppDbContext dBContext)
        {
            _dBContext = dBContext;
        }

        public List<AcquiredMusicsDto> GetAllMusics()
        {
            return (from artist in _dBContext.Artists.ToList()
                    join musics in _dBContext.Musics.ToList()
                    on artist.Id equals musics.ArtistId
                    orderby artist.Name, musics.Name
                    select new AcquiredMusicsDto
                    {
                        Id = musics.Id,
                        Name = musics.Name,
                        ArtistId = musics.ArtistId,
                        Artist = new AcquiredArtistsDto
                        {
                            Id = artist.Id,
                            Name = artist.Name
                        }
                    }).ToList();
        }

        public List<AcquiredMusicsDto> GetMusicsByName(string resquetedMusic)
        {
            return (from artist in _dBContext.Artists.ToList()
                    join musics in _dBContext.Musics.ToList()
                    on artist.Id equals musics.ArtistId
                    where artist.Name.Contains($"{resquetedMusic}", StringComparison.OrdinalIgnoreCase)
                          || musics.Name.Contains($"{resquetedMusic}", StringComparison.OrdinalIgnoreCase)
                    orderby artist.Name, musics.Name
                    select new AcquiredMusicsDto
                    {
                        Id = musics.Id,
                        Name = musics.Name,
                        ArtistId = musics.ArtistId,
                        Artist = new AcquiredArtistsDto
                        {
                            Id = artist.Id,
                            Name = artist.Name
                        }
                    }).ToList();
        }
    }
}
