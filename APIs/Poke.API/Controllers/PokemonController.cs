using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Poke.API.Enum;
using Poke.API.Extensions;
using Poke.API.Interfaces;
using Poke.API.Models;

namespace Poke.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PokemonController : ControllerBase
    {
        private readonly IPokemonService pokemonService;

        public PokemonController(IPokemonService pokemonService)
        {
            this.pokemonService = pokemonService;
        }

        [HttpGet]
        [Route("list/{limit}")]
        public async Task<IActionResult> GetList([FromRoute] string limit)
        {
            var response = await pokemonService.GetPokemonsListOf(limit);
            response.results.ToList().Sort((a,b) => string.Compare(a.name,b.name));
            return Ok(response.results);
        }

        [HttpGet]
        public IActionResult GetList()
        {
            return Ok(EnumExtensions.GetValues<PokemonTop>());
            // var response = await pokemonService.GetTable();
            // return Ok(response);
        }

        //// https://github.com/domaindrivendev/Swashbuckle.AspNetCore/issues/1496
        //[HttpGet("Model")]
        //public IActionResult GetModel()
        //{
        //    var user = new User("Junior", ClientEnum.SOR);
        //    return Ok(user);
        //}

        [HttpPost("Model")]
        public IActionResult GetModel2([FromQuery] User user2)
        {
            return Ok(new { user2 });
        }

        [HttpGet("mapper")]
        public ActionResult GetModel3()
        {
            var unit = new User("Maria", ClientEnum.SOR);

            var json = JsonConvert.SerializeObject(unit);

            var novo = JsonConvert.DeserializeObject<User>(json);

            return Ok(novo);
        }
    }
}