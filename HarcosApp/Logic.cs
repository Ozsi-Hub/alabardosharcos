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
        public void Play(IList<string> lastNames, IList<string> firstNames)
        {
            Validator(lastNames, firstNames);
            GenerateData(lastNames, firstNames);
            Play();
            CheckResult();
        }

        private void Play()
        {
            do
            {
                var tamado = GetPlayer();
                var vedekezo = GetPlayer();
                var tamadoOriginalLife = tamado.Life;
                var vedekezoOriginalLife = vedekezo.Life;

                tamado.Tamadas(vedekezo);
                vedekezo.Vedekezes(tamado);

                if (tamado.Life > vedekezo.Life)
                {
                    tamado.Winner(tamadoOriginalLife);
                }
                else
                {
                    vedekezo.Winner(vedekezoOriginalLife);
                }

                Status(tamado, vedekezo);

                var kimaradnak = harcosok.Where(x => x.Id != tamado.Id && x.Id != vedekezo.Id).ToList();
                kimaradnak.ForEach(x => x.Kimarad());

            }
            while (CheckLife());
        }
        private void Status(IHarcos tamado, IHarcos vedekezo)
        {
            Console.WriteLine($"{tamado.GetResult(tamado.WhoAreYou(tamado))} megtámadta -> {vedekezo.GetResult(vedekezo.WhoAreYou(vedekezo))}-t");
        }

        private IHarcos GetPlayer()
        {
            var rnd = new Random();
            int r = rnd.Next(harcosok.Count);
            var player = harcosok[r];

            if (player.Life == 0 && harcosok.Where(x => x.Life > 0).Count() > 0)
            {
                return GetPlayer();
            }
            return player;
        }

        private void CheckResult()
        {
            if (harcosok.Exists(x => x.Life > 0))
            {
                var winner = harcosok.First(x => x.Life > 0);
                Console.WriteLine();
                harcosok.ForEach(x => Console.WriteLine(x.GetStatus()));
                Console.WriteLine();
                Console.WriteLine($"{winner.LastName} {winner.FirstName} nyerte a játékot!");
            }
            else
            {
                Console.WriteLine("Senki sem nyert!");
            }
        }

        private bool CheckLife()
        {
            var res =  harcosok.Exists(x => x.Life > 0) && harcosok.Where(x => x.Life > 0).Count() > 1;
            return res;
        }

        private void Validator(IList<string> lastNames, IList<string> firstNames)
        {
            if (lastNames.Count != firstNames.Count)
                throw new ArgumentOutOfRangeException("Nem egyenlő a két lista elemszáma!");
        }

        private void GenerateData(IList<string> lastNames, IList<string> firstNames)
        {
            int x = firstNames.Count - 1;
            for (int i = 0; i < lastNames.Count; i++)
            {
                harcosok.Add(harcosFactory.Create(lastNames[i], firstNames[x]));
                x--;
            }

        }
    }
}
