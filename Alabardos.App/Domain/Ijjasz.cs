using Alabardos.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Alabardos.App.Domain
{
    public class Ijjasz : Harcos, IIjjasz
    {
        public static Ijjasz Create(string vezetekneve, string keresztneve)
        {
            return new Ijjasz { Allokepesseg = 100, Id = Guid.NewGuid(), KeresztNeve = keresztneve, VezetekNeve = vezetekneve };
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
                    Allokepesseg = 0;
                    break;
                case HarcosTipus.Ijjasz:
                    Allokepesseg = 0;
                    break;
                    throw new NotImplementedException(nameof(harcosTipus));
            }
        }
    }
}
