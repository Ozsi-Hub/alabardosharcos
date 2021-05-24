using HarcosApp.Abstractions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace HarcosApp
{
    public class Startup
    {
        public Startup()
        {

        }

        public IServiceProvider ConfigureServices()
        {
            var services = new ServiceCollection();
            var configurationBuilder = new ConfigurationBuilder();

            services.AddScoped<IHarcosFactory, HarcosFactory>();
            services.AddScoped<ILogic, Logic>();

            return services.BuildServiceProvider();
        }
    }
}
