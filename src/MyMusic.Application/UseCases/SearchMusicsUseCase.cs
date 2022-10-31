using Microsoft.EntityFrameworkCore;
using MyMusic.Application.Models;
using MyMusic.Application.UseCases.Abstratcs;
using MyMusic.Infrastructure.DataProviders.Repositories;

namespace MyMusic.Application.UseCases
{
    public class SearchMusicsUseCase : ISearchMusicsUseCase
    {
        public List<AcquiredMusics> SearchingByMusicName(AppDbContext _context, string resquetedMusic)
        {
            return (from artist in _context.Artists.ToList()
                    join musics in _context.Musics.ToList()
                    on artist.Id equals musics.ArtistId
                    where artist.Name.Contains($"{resquetedMusic}")
                          || musics.Name.Contains($"{resquetedMusic}")
                    orderby artist.Name, musics.Name
                    select new AcquiredMusics
                    {
                        Id = musics.Id,
                        Name = musics.Name,
                        ArtistId = musics.ArtistId,
                        Artist = new AcquiredArtists
                        {
                            Id = artist.Id,
                            Name = artist.Name
                        }
                    }).ToList();
        }
    }
}
