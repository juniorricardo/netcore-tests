using System.Collections.Generic;
using System.Threading.Tasks;
using Poke.API.Models.Pokemon;

namespace Poke.API.Interfaces
{
    public interface IPokemonRepository
    {
        Task<IEnumerable<PokemonEntity>> GetAll();
        Task<IEnumerable<PokemonEntity>> GetById(long id);
    }
}