using Alabardos.Abstractions;
using System;

namespace Alabardos.App.Domain
{
    public abstract class Harcos : IHarcos, IHarcol
    {
        public Guid Id { get; protected set; }
        public string VezetekNeve { get; protected set; }
        public string KeresztNeve { get; protected set; }
        public int Allokepesseg { get; protected set; }

        public virtual void Tamadas(IHarcos vedekezo)
        {
            var allokepesseg = Allokepesseg;
            Harc();

            if (allokepesseg / 4 > Allokepesseg)
            {
                Allokepesseg = 0;
            }
        }
        public void Status(IHarcos tamado, IHarcos vedekezo)
        {
            Console.WriteLine($"{GetConsoleOutput(tamado)} megtámadta -> {GetConsoleOutput(vedekezo)}");
        }

        private string GetConsoleOutput(IHarcos harcos)
        {
            var tipus = WhoAreYou(harcos);
            var who = tipus.GetDisplayName();

            return $"{who} | {harcos.Id} - {harcos.VezetekNeve} {harcos.KeresztNeve} - {harcos.Allokepesseg}";
        }

        public virtual void Vedekezes(HarcosTipus harcosTipus)
        {
            Harc();
        }
        protected void Harc()
        {
            Allokepesseg %= 2;
        }
        public bool IsDeath()
        {
            return Allokepesseg == 0;
        }

        public HarcosTipus WhoAreYou(IHarcos harcos)
        {
            if (harcos is ILovag)
            {
                return HarcosTipus.Lovag;
            }
            if (harcos is IIjjasz)
            {
                return HarcosTipus.Ijjasz;
            }
            if (harcos is IAlabardos)
            {
                return HarcosTipus.Alabardos;
            }
            throw new NotImplementedException();
        }

        public void Kimarad()
        {
            var newAllokepesseg = Allokepesseg + 20;
            Allokepesseg = newAllokepesseg > 100 ? 100 : newAllokepesseg;
        }
    }
}
