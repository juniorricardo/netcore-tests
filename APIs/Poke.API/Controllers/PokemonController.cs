using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Poke.API.Interfaces;

namespace Poke.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PokemonController : ControllerBase
    {
        private readonly IPokemonService pokemonService;

        public PokemonController(IPokemonService pokemonService)
        {
            this.pokemonService = pokemonService;
        }

        [HttpGet, Route("list/{limit}")]
        public async Task<IActionResult> GetList([FromRoute] string limit)
        {
            var response = await pokemonService.GetPokemonsListOf(limit);
            return Ok(response.results);
        }
        
        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            var response = await pokemonService.GetTable();
            return Ok(response);
        }
    }
}
