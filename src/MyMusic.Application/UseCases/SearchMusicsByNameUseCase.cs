using Microsoft.EntityFrameworkCore;
using MyMusic.Application.Models;
using MyMusic.Application.UseCases.Abstratcs;
using MyMusic.Domain.Abstractions.Gateways;
using MyMusic.Infrastructure.DataProviders.Repositories;
using System.Xml.Linq;

namespace MyMusic.Application.UseCases
{
    public class SearchMusicsByNameUseCase : ISearchMusicsByNameUseCase
    {
        private readonly IMusicGateway _musicGateway;

        public SearchMusicsByNameUseCase(IMusicGateway musicGateway)
        {
            _musicGateway = musicGateway;
        }

        public List<AcquiredMusicsResponse> Execute(string resquetedMusic)
        {
            var getMusics = _musicGateway.GetMusicsByName(resquetedMusic);
            var mappingMusics = getMusics.Select(musics => new AcquiredMusicsResponse
            {
                Id = musics.Id,
                Name = musics.Name,
                ArtistId = musics.ArtistId,
                Artist = new AcquiredArtistsResponse
                {
                    Id = musics.Artist.Id,
                    Name = musics.Artist.Name,
                }
            }).ToList();

            Console.WriteLine(mappingMusics);
            return mappingMusics;
        }
    }
}
