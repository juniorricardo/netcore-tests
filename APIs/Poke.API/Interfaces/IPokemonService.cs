using System.Threading.Tasks;
using Poke.API.Models;

namespace Poke.API.Interfaces
{
    public interface IPokemonService
    {
        Task<PokemonListWithLimit> GetListPokemonsOf(string limit);
    }
}
