using Microsoft.AspNetCore.Mvc;
using MyMusic.Infrastructure.DataProviders.Repositories;
using MyMusic.Application.Models;
using MyMusic.Application.UseCases;
using MyMusic.Application.UseCases.Abstratcs;

namespace MyMusic.API.Controllers
{
    [ApiController]
    [Route("api")]
    public class MyMusicController : Controller
    {
        private readonly AppDbContext _context;

        public MyMusicController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<AcquiredMusics>), 400)]
        [ProducesResponseType(204)]
        [Route("musics/{name}")]
        public ActionResult<List<AcquiredMusics>> GetMusics(string name)
        {

            ISearchMusicsUseCase searchMusicsUseCase = new SearchMusicsUseCase();
            ICasesValidationUseCase validationUseCase = new CasesValidationUseCase();

            var validationInput = validationUseCase.ValidationSearchMusic(name);
            var resultSearch = searchMusicsUseCase.SearchingByMusicName(_context, name);
            var checkListValidation = validationUseCase.ValidationCheckListMusic(resultSearch);

            if (!validationInput) return StatusCode(400);
            if (!checkListValidation) return StatusCode(204);

            return resultSearch;
        }
    }
}
