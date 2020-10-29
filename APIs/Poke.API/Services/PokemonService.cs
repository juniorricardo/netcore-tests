using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Poke.API.Enum;
using Poke.API.Interfaces;
using Poke.API.Models;
using Poke.API.Models.Pokemon;
using RestSharp;

namespace Poke.API.Services
{
    public class PokemonService : IPokemonService 
    {
        private readonly IRestClient _restClient;

        public PokemonService(IEnvironmentVariables environmentVariables,
                              IRestClient restClient)
        {
            _restClient = restClient;
            _restClient.BaseUrl = new Uri(environmentVariables.GetUrl(EnvironmentSection.Services, EnvironmentService.PokeApi));
        }

        public async Task<PokemonListWithLimit> GetPokemonsListOf(string limit)
        {
            var pokemonList = new PokemonListWithLimit();
            try
            {
                var request = new RestRequest("/api/{versionApi}/pokemon", Method.GET)
                    .AddUrlSegment("versionApi", "v2")
                    .AddParameter("offset", "0", ParameterType.QueryString)
                    .AddParameter("limit", limit, ParameterType.QueryString);
                
                //https://pokeapi.co/api/v2/pokemon?offset=0&limit=10
                var response =  await _restClient.ExecuteAsync<PokemonListWithLimit>(request);
                TimeoutCheck(request, response);
                
                pokemonList = response.Data;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al intentar obtener lista de pokemones. \nDetalle:" + ex.Message + "\n" + ex.StackTrace);
            }
            return pokemonList;
        }
        
        private void TimeoutCheck(IRestRequest request, IRestResponse response)
        {
            if (response.StatusCode != 0) return;
            Console.WriteLine();
            LogError(_restClient.BaseUrl, request, response);
        }
        private void LogError(Uri BaseUrl, IRestRequest request, IRestResponse response)
        {
            //Get the values of the parameters passed to the API
            string parameters = string.Join(", ", request.Parameters.Select(x => x.Name.ToString() + "=" + ((x.Value == null) ? "NULL" : x.Value)).ToArray());

            //Set up the information message with the URL, 
            //the status code, and the parameters.
            string info = "Request to " + BaseUrl.AbsoluteUri 
                                        + request.Resource + " failed with status code " 
                                        + response.StatusCode + ", parameters: "
                                        + parameters + ", and content: " + response.Content;

            //Acquire the actual exception
            Exception ex;
            if (response != null && response.ErrorException != null)
            {
                ex = response.ErrorException;
            }
            else
            {
                ex = new Exception(info);
                info = string.Empty;
            }

            //Log the exception and info message
            //_errorLogger.LogError(ex,info);
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
