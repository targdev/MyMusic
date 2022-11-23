using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Moq;
using MyMusic.Application.Models;
using MyMusic.Application.UseCases;
using MyMusic.Domain.Abstractions.Gateways;
using MyMusic.Infrastructure.DataProviders.Repositories;
using Xunit;

namespace MyMusic.UnitTests.Application.UseCases
{
    public class SearchingByMusicNameTests
    {
        private readonly Mock<IMusicGateway> _musicGateway;
        private readonly SearchMusicsByNameUseCase _searchMusicsUseCase;

        public SearchingByMusicNameTests()
        {
            _musicGateway = new Mock<IMusicGateway>();
            _searchMusicsUseCase = new SearchMusicsByNameUseCase(_musicGateway.Object);
        }

        [Fact(DisplayName = "Execute: Should return mapped database information")]
        public void SearchingByMusicName_Should_Return_Mapped_Database_Information()
        {
            //-----------------------------------------------------------------------------------
            // Arrange 
            //-----------------------------------------------------------------------------------
            var expectedReult = new List<AcquiredMusicsResponse>
            {
                new AcquiredMusicsResponse
                {
                    Id = new Guid("006452da-c25b-4cfa-bc91-2ce4b5e528dc"),
                    Name = "- Human",
                    ArtistId = new Guid("bf870f08-4fd3-4b00-98a7-3997996cd306"),
                    Artist = new AcquiredArtistsResponse
                    {
                        Id = new Guid("bf870f08-4fd3-4b00-98a7-3997996cd306"),
                        Name = "Metallica"
                    }
                }
            };

            //-----------------------------------------------------------------------------------
            // Act
            //-----------------------------------------------------------------------------------
            var result = _searchMusicsUseCase.Execute("- Human");

            //-----------------------------------------------------------------------------------
            // Assert
            //-----------------------------------------------------------------------------------
            result.Should().BeEquivalentTo(expectedReult);
        }
    }
}
