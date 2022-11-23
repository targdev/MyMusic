using MyMusic.Application.Models;

namespace MyMusic.Application.UseCases.Abstratcs
{
    public  interface ISearchMusicsByNameUseCase
    {
        List<AcquiredMusicsResponse> Execute(string resquetedMusic);
    }
}
