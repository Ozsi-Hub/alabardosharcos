using Alabardos.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Alabardos.App.Domain
{
    public class Alabardos : Harcos, IAlabardos
    {
        public static Alabardos Create(string vezetekneve, string keresztneve)
        {
            return new Alabardos { Allokepesseg = 90, Id = Guid.NewGuid(), KeresztNeve = keresztneve, VezetekNeve = vezetekneve };
        }

        public override void Tamadas(IHarcos vedekezo)
        {
            base.Tamadas(vedekezo);
        }

        public override void Vedekezes(HarcosTipus harcosTipus)
        {
            base.Vedekezes(harcosTipus);
            switch (harcosTipus)
            {
                case HarcosTipus.Alabardos:
                    Allokepesseg = 0;
                    break;
                case HarcosTipus.Lovag:
                    break;
                case HarcosTipus.Ijjasz:
                    this.Allokepesseg = 0;
                    break;
                throw new NotImplementedException(nameof(harcosTipus));
            }
        }
    }
}
