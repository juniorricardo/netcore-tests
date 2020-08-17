using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Poke.API.Interfaces;
using Poke.API.Models.Pokemon;

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
            var response = await pokemonService.GetListPokemonsOf(limit);
            return Ok(response.results);
        }
    }
}
