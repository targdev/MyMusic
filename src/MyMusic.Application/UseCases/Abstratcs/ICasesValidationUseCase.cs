using MyMusic.Application.Models;

namespace MyMusic.Application.UseCases.Abstratcs
{
    public interface ICasesValidationUseCase
    {
        bool ValidationSearchMusic(string name);
        bool ValidationCheckListMusic(List<AcquiredMusicsResponse> musicList);
    }
}
