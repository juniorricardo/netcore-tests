using System;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using System.Text;
using Microsoft.Extensions.Configuration;

namespace ClassLibrary1
{
    public class EnvironmentVariable : IEnvironmentVariable
    {
        private readonly IHostingEnvironment _environment; //microsoft.aspnetcore.hosting

        public EnvironmentVariable(IHostingEnvironment environment)
        {
            _environment = environment;
        }

        public string GetService(string service)
        {
            string appsettingName = "appsettings";
            
            if (_environment.IsDevelopment())
                appsettingName = $"{appsettingName}.Development";
            
            IConfigurationBuilder builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory()) //microsoft.extensions.configuration
                .AddJsonFile($"{appsettingName}.json"); //microsoft.extensions.configuration.json
            
            IConfigurationRoot configuration = builder.Build();
            string serve = configuration[service];
            
            return _environment.IsProduction()
                ? Environment.GetEnvironmentVariable(serve)
                : serve;
        }
    }

    public interface IEnvironmentVariable
    {
        string GetService(string service);
    }
}