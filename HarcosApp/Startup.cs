using HarcosApp.Abstractions;
using Microsoft.Extensions.DependencyInjection;
using System;

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

            services.AddScoped<IHarcosFactory, HarcosFactory>();
            services.AddScoped<ILogic, Logic>();

            return services.BuildServiceProvider();
        }
    }
}
