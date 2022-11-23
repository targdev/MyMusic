using MyMusic.Application.Models;
using MyMusic.Application.UseCases.Abstratcs;
using MyMusic.Domain.Abstractions.Gateways;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMusic.Application.UseCases
{
    public class SearchAllMusicsUseCase : ISearchAllMusicsUseCase
    {
        private readonly IMusicGateway _musicGateway;
        SearchAllMusicsUseCase(IMusicGateway musicGateway) 
        { 
            _musicGateway = musicGateway; 
        }

        public List<AcquiredMusicsResponse> Execute()
        {
            var getAllMusics = _musicGateway.GetAllMusics();

            return getAllMusics.Select(musics => new AcquiredMusicsResponse
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
        }
    }
}
