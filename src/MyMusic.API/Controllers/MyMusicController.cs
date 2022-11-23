using Microsoft.AspNetCore.Mvc;
using MyMusic.Infrastructure.DataProviders.Repositories;
using MyMusic.Application.Models;
using MyMusic.Application.UseCases;
using MyMusic.Application.UseCases.Abstratcs;

namespace MyMusic.API.Controllers
{
    [ApiController]
    [Route("api/v1/musics")]
    public class MyMusicController : Controller
    {
        private readonly ISearchAllMusicsUseCase _searchAllMusicsUseCase;
        private readonly ISearchMusicsByNameUseCase _searchMusicsUseCase;
        private readonly ICasesValidationUseCase _validationUseCase;

        public MyMusicController(
            ISearchAllMusicsUseCase searchAllMusicsUseCase,
            ISearchMusicsByNameUseCase searchMusicsUseCase,
            ICasesValidationUseCase validationUseCase)
        {
            _searchAllMusicsUseCase = searchAllMusicsUseCase;
            _searchMusicsUseCase = searchMusicsUseCase;
            _validationUseCase = validationUseCase;
        }

        [HttpGet]
        public ActionResult<List<AcquiredMusicsResponse>> GetAllMusics() 
        {
            return Ok(_searchAllMusicsUseCase.Execute());
        }


        [HttpGet("filtro={name}")]
        [ProducesResponseType(typeof(List<AcquiredMusicsResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult<List<AcquiredMusicsResponse>> GetMusicsByName(string name)
        {
            var validationInput = _validationUseCase.ValidationSearchMusic(name);

            if (!validationInput) return BadRequest();

            var resultSearch = _searchMusicsUseCase.Execute(name);
            var checkListValidation = _validationUseCase.ValidationCheckListMusic(resultSearch);

            if (!checkListValidation) return NoContent();

            return Ok(resultSearch);
        }
    }
}
