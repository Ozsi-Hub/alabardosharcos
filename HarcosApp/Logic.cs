using HarcosApp.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HarcosApp
{
    public class Logic : ILogic
    {
        private readonly IHarcosFactory harcosFactory;
        private List<IHarcos> harcosok = new List<IHarcos>();
        public Logic(IHarcosFactory harcosFactory)
        {
            this.harcosFactory = harcosFactory ?? throw new ArgumentNullException(nameof(harcosFactory));
        }
        public void Play(IList<string> vezeteknev, IList<string> keresztnev)
        {
            Validator(vezeteknev, keresztnev);
            GenerateData(vezeteknev, keresztnev);
            Play();
            CheckResult();
        }

        private void Play()
        {
            do
            {
                var tamado = GetPlayer();
                var vedekezo = GetPlayer();
                var tamadoOriginalAllokepessege = tamado.Allokepesseg;
                var vedekezoOriginalAllokepessege = vedekezo.Allokepesseg;

                tamado.Tamadas(vedekezo);
                vedekezo.Vedekezes(tamado);

                if (tamado.Allokepesseg > vedekezo.Allokepesseg)
                {
                    tamado.Winner(tamadoOriginalAllokepessege);
                }
                else
                {
                    vedekezo.Winner(vedekezoOriginalAllokepessege);
                }

                Status(tamado, vedekezo);

                var kimaradnak = harcosok.Where(x => x.Id != tamado.Id && x.Id != vedekezo.Id).ToList();
                kimaradnak.ForEach(x => x.Kimarad());

            }
            while (CheckLife());
        }
        private void Status(IHarcos tamado, IHarcos vedekezo)
        {
            Console.WriteLine($"{tamado.GetResult(tamado.WhoAreYou(tamado))} megtámadta -> {vedekezo.GetResult(vedekezo.WhoAreYou(vedekezo))}");
        }

        private IHarcos GetPlayer()
        {
            var rnd = new Random();
            int r = rnd.Next(harcosok.Count);
            var player = harcosok[r];

            if (player.Allokepesseg == 0 && harcosok.Where(x => x.Allokepesseg > 0).Count() > 0)
            {
                return GetPlayer();
            }
            return player;
        }

        private void CheckResult()
        {
            if (harcosok.Exists(x => x.Allokepesseg > 0))
            {
                var winner = harcosok.First(x => x.Allokepesseg > 0);
                Console.WriteLine();
                harcosok.ForEach(x => Console.WriteLine(x.GetStatus()));
                Console.WriteLine();
                Console.WriteLine($"{winner.VezetekNeve} {winner.KeresztNeve} nyerte a játékot!");
            }
            else
            {
                Console.WriteLine("Senki sem nyert!");
            }
        }

        private bool CheckLife()
        {
            var res =  harcosok.Exists(x => x.Allokepesseg > 0) && harcosok.Where(x => x.Allokepesseg > 0).Count() > 1;
            return res;
        }

        private void Validator(IList<string> vezeteknev, IList<string> keresztnev)
        {
            if (vezeteknev.Count != keresztnev.Count)
                throw new ArgumentOutOfRangeException("Nem egyenlő a két lista elemszáma!");
        }

        private void GenerateData(IList<string> vezeteknev, IList<string> keresztnev)
        {
            int x = keresztnev.Count - 1;
            for (int i = 0; i < vezeteknev.Count; i++)
            {
                harcosok.Add(harcosFactory.Create(vezeteknev[i], keresztnev[x]));
                x--;
            }

        }
    }
}
