using FluentAssertions;
using MyMusic.Application.Models;
using MyMusic.Application.UseCases;
using Xunit;

namespace MyMusic.UnitTests.Application.UseCases
{
    public class CasesValidationUseCaseTests
    {
        private readonly CasesValidationUseCase _casesValidationUseCase;

        public CasesValidationUseCaseTests()
        {
            _casesValidationUseCase = new CasesValidationUseCase();
        }

        [Fact(DisplayName = "ValidationSearchMusic: Should return false when input is less than 3 characters")]
        public void ValidationSearchMusic_Should_Return_False_When_Input_Less_Than_3_Characters()
        {
            //-----------------------------------------------------------------------------------
            // Arrange - Act
            //-----------------------------------------------------------------------------------
            var result = _casesValidationUseCase.ValidationSearchMusic("me");

            //-----------------------------------------------------------------------------------
            // Assert
            //-----------------------------------------------------------------------------------
            result.Should().BeFalse();
        }

        [Fact(DisplayName = "ValidationSearchMusic: Should return false when input is empty")]
        public void ValidationSearchMusic_Should_Return_False_When_Input_Empty()
        {
            //-----------------------------------------------------------------------------------
            // Arrange - Act
            //-----------------------------------------------------------------------------------
            var result = _casesValidationUseCase.ValidationSearchMusic("");

            //-----------------------------------------------------------------------------------
            // Assert
            //-----------------------------------------------------------------------------------
            result.Should().BeFalse();
        }

        [Fact(DisplayName = "ValidationSearchMusic: Should return true when input is valid")]
        public void ValidationSearchMusic_Should_Return_True_When_Input_Valid()
        {
            //-----------------------------------------------------------------------------------
            // Arrange - Act
            //-----------------------------------------------------------------------------------
            var result = _casesValidationUseCase.ValidationSearchMusic("The Beatles");

            //-----------------------------------------------------------------------------------
            // Assert
            //-----------------------------------------------------------------------------------
            result.Should().BeTrue();
        }

        [Fact(DisplayName = "ValidationCheckListMusic: Should return false when no obtain informations")]
        public void ValidationCheckListMusic_Should_Return_False_When_No_Obtain_Informations()
        {
            //-----------------------------------------------------------------------------------
            // Arrange
            //-----------------------------------------------------------------------------------
            var listEmpty = new List<AcquiredMusicsResponse> { };

            //-----------------------------------------------------------------------------------
            // Act
            //-----------------------------------------------------------------------------------
            var result = _casesValidationUseCase.ValidationCheckListMusic(listEmpty);

            //-----------------------------------------------------------------------------------
            // Assert
            //-----------------------------------------------------------------------------------
            result.Should().BeFalse();
        }

        [Fact(DisplayName = "ValidationCheckListMusic: Should return true when obtain list of the musics")]
        public void ValidationCheckListMusic_Should_Return_True_When_Obtain_List_Musics()
        {
            //-----------------------------------------------------------------------------------
            // Arrange
            //-----------------------------------------------------------------------------------
            var listMusics = new List<AcquiredMusicsResponse> 
            {
               new AcquiredMusicsResponse
               {
                   Id = Guid.NewGuid(),
                   Name = "Here Comes The Sunrise",
                   ArtistId = Guid.NewGuid(),
                   Artist = new AcquiredArtistsResponse
                   {
                       Id = Guid.NewGuid(),
                       Name = "The Beatles"
                   }
               },
               new AcquiredMusicsResponse
               {
                   Id = Guid.NewGuid(),
                   Name = "One",
                   ArtistId = Guid.NewGuid(),
                   Artist = new AcquiredArtistsResponse
                   {
                       Id = Guid.NewGuid(),
                       Name = "Metallica"
                   }
               },
            };

            //-----------------------------------------------------------------------------------
            // Act
            //-----------------------------------------------------------------------------------
            var result = _casesValidationUseCase.ValidationCheckListMusic(listMusics);

            //-----------------------------------------------------------------------------------
            // Assert
            //-----------------------------------------------------------------------------------
            result.Should().BeTrue();
        }
    }
}
