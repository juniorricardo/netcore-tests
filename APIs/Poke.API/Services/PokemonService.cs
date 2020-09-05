using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Poke.API.Entities;
using Poke.API.Interfaces;
using Poke.API.Models;
using Poke.API.Models.Pokemon;
using RestSharp;

namespace Poke.Services
{
    public class PokemonService : IPokemonService
    {
        //https://pokeapi.co/api/v2/pokemon?offset=0&limit=10

        private readonly IEnvironmentVariables _environmentVariables;

        public PokemonService(IEnvironmentVariables environmentVariables)
        {
            this._environmentVariables = environmentVariables;
        }

        public async Task<PokemonListWithLimit> GetPokemonsListOf(string limit)
        {
            PokemonListWithLimit pokemonList = new PokemonListWithLimit();
            try
            {
                string url = $"{_environmentVariables.GetUrl("URL_POKEAPI")}/api/v2/pokemon?offset=0&limit={limit}";
                var client = new RestClient(url);
                var request = new RestRequest( Method.GET);
                var response = client.Execute(request);
                pokemonList = JsonConvert.DeserializeObject<PokemonListWithLimit>(response.Content);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al intentar obtener lista de pokemones. \nDetalle:" + ex.Message + "\n" + ex.StackTrace);
            }
            return pokemonList;
        }

        public Task<IEnumerable<PokemonEntity>> GetTable()
        {
            throw new NotImplementedException();
        }

        // public async Task<IEnumerable<PokemonEntity>> GetTable()
        // {
        //     return await _baseRepository.GetAll();
        // }
    }
}
