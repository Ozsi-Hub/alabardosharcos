using HarcosApp.Abstractions;
using System;

namespace HarcosApp.Domain
{
    public class Alabardos : Harcos, IAlabardos
    {
        public static Alabardos Create(string vezetekneve, string keresztneve)
        {
            return new Alabardos { Life = 90, Id = Guid.NewGuid(), FirstName = keresztneve, LastName = vezetekneve };
        }

        public override void Tamadas(IHarcos vedekezo)
        {
            base.Tamadas(vedekezo);
        }

        public override void Vedekezes(IHarcos tamado)
        {
            var harcosTipus = WhoAreYou(tamado);
            base.Vedekezes(tamado);
            switch (harcosTipus)
            {
                case HarcosTipus.Alabardos:
                    Life = 0;
                    break;
                case HarcosTipus.Lovag:
                    break;
                case HarcosTipus.Ijjasz:
                    this.Life = 0;
                    break;
                throw new NotImplementedException(nameof(harcosTipus));
            }
        }
    }
}
