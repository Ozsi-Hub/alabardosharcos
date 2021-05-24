using HarcosApp.Abstractions;
using HarcosApp.Domain;
using System;

namespace HarcosApp
{
    public class HarcosFactory : IHarcosFactory
    {
        public IHarcos Create(string vezeteknev, string keresztnev)
        {
            var rnd = new Random();
            var counter = rnd.Next(0, 10000);
            var result = counter % 3;
            switch (result)
            {
                case 0: return Lovag.Create(vezeteknev, keresztnev);
                case 1: return Ijjasz.Create(vezeteknev, keresztnev);
                case 2: return Alabardos.Create(vezeteknev, keresztnev);
                default:
                    break;
            }
            throw new NotImplementedException();
        }
    }
}
