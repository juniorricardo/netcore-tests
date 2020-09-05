using Microsoft.Extensions.DependencyInjection;
using Poke.API.Helpers;
using Poke.API.Interfaces;
using Poke.Services;

namespace Poke.API.Middleware
{
    public static class IoC
    {
        public static IServiceCollection AddDependency(this IServiceCollection services)
        {
            services.AddTransient<IPokemonService, PokemonService>();
            services.AddTransient<IEnvironmentVariables, EnvironmentVariables>();

            return services;
        }
    }
}
