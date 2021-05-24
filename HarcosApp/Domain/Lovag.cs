using HarcosApp.Abstractions;
using System;

namespace HarcosApp.Domain
{
    public class Lovag : Harcos, ILovag
    {
        public static Lovag Create(string vezetekneve, string keresztneve)
        {
            return new Lovag { Allokepesseg = 80, Id = Guid.NewGuid(), KeresztNeve = keresztneve, VezetekNeve = vezetekneve };
        }

        public override void Tamadas(IHarcos vedekezo)
        {           
            var vedekezoTipus = WhoAreYou(vedekezo);
            switch (vedekezoTipus)
            {
                case HarcosTipus.Alabardos:
                    Allokepesseg = 0;
                    break;
                case HarcosTipus.Lovag:
                    break;
                case HarcosTipus.Ijjasz:
                    break;
                    throw new NotImplementedException(nameof(vedekezoTipus));
            }
            base.Tamadas(vedekezo);
        }

        public override void Vedekezes(IHarcos tamado)
        {
            var harcosTipus = WhoAreYou(tamado);
            base.Vedekezes(tamado);
            switch (harcosTipus)
            {
                case HarcosTipus.Alabardos:
                    break;
                case HarcosTipus.Lovag:
                    Allokepesseg = 0;
                    break;
                case HarcosTipus.Ijjasz:

                    var random = new Random();
                    var number = random.Next(0, 1000);
                    if (number % 2 == 0)
                    {
                        Allokepesseg = 0;
                    }

                    break;
                    throw new NotImplementedException(nameof(harcosTipus));
            }
        }
    }
}
