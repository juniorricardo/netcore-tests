using Microsoft.Extensions.DependencyInjection;
using Poke.API.Business;
using Poke.API.Helpers;
using Poke.API.Interfaces;
using Poke.API.Interfaces.Provider;
using Poke.API.Provider;
using Poke.API.Services;
using RestSharp;

namespace Poke.API.Middleware
{
    public static class Despendecies
    {
        public static IServiceCollection AddDependency(this IServiceCollection services)
        {
            services.AddTransient<IPokemonService, PokemonService>();
            services.AddTransient<IEnvironmentVariables, EnvironmentVariables>();

            services.AddTransient<IEmployeeService, EmployeeService>();
            services.AddTransient<IEmployeeBusiness, EmployeeBusiness>();

            services.AddTransient<IRestClient, RestClient>();
            services.AddTransient<IDbManager, DbManager>();

            return services;
        }
    }
}