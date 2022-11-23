using MyMusic.Application.Models;
using MyMusic.Application.UseCases.Abstratcs;

namespace MyMusic.Application.UseCases
{
    public class CasesValidationUseCase : ICasesValidationUseCase
    {
        public bool ValidationSearchMusic(string name)
        {
            if (name.Length < 3)
            {
                return false;
            }

            return true;
        }
        public bool ValidationCheckListMusic(List<AcquiredMusicsResponse> musicList)
        {
            if (musicList.Count == 0)
            {
                return false;
            }

            return true;
        }
    }
}
