using HarcosApp.Abstractions;
using System;

namespace HarcosApp.Domain
{
    public class Lovag : Harcos, ILovag
    {
        public static Lovag Create(string vezetekneve, string keresztneve)
        {
            return new Lovag { Life = 80, Id = Guid.NewGuid(), FirstName = keresztneve, LastName = vezetekneve };
        }

        public override void Tamadas(IHarcos vedekezo)
        {           
            var vedekezoTipus = WhoAreYou(vedekezo);
            switch (vedekezoTipus)
            {
                case HarcosTipus.Alabardos:
                    Life = 0;
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
                    Life = 0;
                    break;
                case HarcosTipus.Ijjasz:
                    if (DateTime.Now.Ticks % 2 == 0)
                    {
                        Life = 0;
                    }

                    break;
                    throw new NotImplementedException(nameof(harcosTipus));
            }
        }
    }
}
