using MyMusic.Application.Models;

namespace MyMusic.Application.UseCases.Abstratcs
{
    public interface ICasesValidationUseCase
    {
        bool ValidationSearchMusic(string name);
        public bool ValidationCheckListMusic(List<AcquiredMusics> musicList);
    }
}
