using HarcosApp.Abstractions;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HarcosApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var startup = new Startup();
            var services = startup.ConfigureServices();

            using (var scope = services.CreateScope())
            {
                Console.WriteLine("Start!");
                var game = scope.ServiceProvider.GetRequiredService<ILogic>();

                var vezeteknevek = new List<string>
                {
                    "Fel",
                    "Kelek",
                    "Russel",
                    "Pécsi",
                    "Polgár",
                    "Russel",
                    "Cruse",
                    "Vettel",
                    "Hamilton",
                    "Gasly",
                };

                var keresztnevek = new List<string>
                {
                    "Kelek",
                    "Jenő",
                    "George",
                    "Max",
                    "Carlos",
                    "Kimi",
                    "Mick",
                    "Seb",
                    "Lev",
                    "Gay",
                };



                game.Play(vezeteknevek, keresztnevek);
                Console.WriteLine($"The End!");
            }
            Console.WriteLine("Feladat vége");
            Console.ReadLine();

        }
    }
}
