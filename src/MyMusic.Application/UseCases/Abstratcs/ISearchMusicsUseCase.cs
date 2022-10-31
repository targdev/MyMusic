using MyMusic.Application.Models;
using MyMusic.Infrastructure.DataProviders.Repositories;

namespace MyMusic.Application.UseCases.Abstratcs
{
    public  interface ISearchMusicsUseCase
    {
        List<AcquiredMusics> SearchingByMusicName(AppDbContext _context, string resquetedMusic);
    }
}
