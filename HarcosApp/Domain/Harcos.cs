using HarcosApp.Abstractions;
using System;

namespace HarcosApp.Domain
{
    public abstract class Harcos : IHarcos, IHarcol
    {
        public Guid Id { get; protected set; }
        public string VezetekNeve { get; protected set; } = default!;
        public string KeresztNeve { get; protected set; } = default!;
        public int Allokepesseg { get; protected set; }

        public virtual void Tamadas(IHarcos vedekezo)
        {
            Harc();
        }

        public void Winner(int originalAllokepesseg)
        {
            var life = originalAllokepesseg / 4;
            if (life > this.Allokepesseg)
            {
                this.Allokepesseg = 0;
            }
        }

        public string GetResult(HarcosTipus tipus)
        {
            var who = tipus.GetDisplayName();
            return $"{who} | {GetStatus()}";
        }

        public string GetStatus()
        {
            return $"{Id} - {VezetekNeve} {KeresztNeve} - {Allokepesseg}";
        }

        public virtual void Vedekezes(IHarcos vedekezo)
        {
            Harc();
        }
        protected void Harc()
        {
            Allokepesseg /= 2;
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
            if (!IsDeath())
            {
                var newAllokepesseg = Allokepesseg + 20;
                Allokepesseg = newAllokepesseg > 100 ? 100 : newAllokepesseg;
            }
        }
    }
}
