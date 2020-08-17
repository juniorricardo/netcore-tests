using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Poke.API.Helpers;
using Poke.API.Interfaces;
using Poke.API.Models;
using Poke.API.Models.Pokemon;

namespace Poke.Services
{
    public class PokemonService : IPokemonService
    {
        //https://pokeapi.co/api/v2/pokemon?offset=0&limit=10

        private readonly IEnvironmentVariables environmentVariables;

        public PokemonService(IEnvironmentVariables environmentVariables)
        {
            this.environmentVariables = environmentVariables;
        }
        public async Task<PokemonListWithLimit> GetListPokemonsOf(string limit)
        {
            PokemonListWithLimit pokemonList = new PokemonListWithLimit();
            try
            {
                string url = $"{environmentVariables.GetUrl("URL_POKEAPI")}/pokemon?offset=0&limit={limit}";
                Uri _Uri = new Uri(url);

                using (HttpClient client = new HttpClient())
                {
                    var response = await client.GetAsync(_Uri);
                    string result = await response.Content.ReadAsStringAsync();
                    pokemonList = JsonConvert.DeserializeObject<PokemonListWithLimit>(result);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al intentar obtener lista de pokemones. \nDetalle:" + ex.Message + "\n" + ex.StackTrace);
            }
            return pokemonList;
        }
    }
}
