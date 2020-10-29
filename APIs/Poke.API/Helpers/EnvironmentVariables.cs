using System;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Poke.API.Enum;
using Poke.API.Interfaces;

namespace Poke.API.Helpers
{
    public class EnvironmentVariables: IEnvironmentVariables
    {
        private readonly IHostingEnvironment _hostingEnvironment;
        public EnvironmentVariables(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        public string GetUrl(EnvironmentSection section, EnvironmentService service)
        {
            var serviceName = $"{section}:{service}";
            
            string appSettingsName = "appsettings";
            if (_hostingEnvironment.IsDevelopment())
                appSettingsName = $"{appSettingsName}.Development";

            IConfigurationBuilder builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile($"{appSettingsName}.json");
            
            var configuration = builder.Build();
            var url = configuration[serviceName];

            return _hostingEnvironment.IsProduction()
                ? Environment.GetEnvironmentVariable(url)
                : url;
        }
    }
}
