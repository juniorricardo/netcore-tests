using System.Collections.Generic;
using System.Threading.Tasks;
using Poke.API.Entities;
using Poke.API.Models;
using Poke.API.Models.Pokemon;

namespace Poke.API.Interfaces
{
    public interface IPokemonService
    {
        Task<PokemonListWithLimit> GetPokemonsListOf(string limit);
        Task<IEnumerable<PokemonEntity>> GetTable();
    }
}
