using HarcosApp.Abstractions;
using System;

namespace HarcosApp.Domain
{
    public abstract class Harcos : IHarcos, IHarcol
    {
        public Guid Id { get; protected set; }
        public string LastName { get; protected set; } = default!;
        public string FirstName { get; protected set; } = default!;
        public int Life { get; protected set; }

        public virtual void Tamadas(IHarcos vedekezo)
        {
            Harc();
        }

        public void Winner(int originalAllokepesseg)
        {
            var life = originalAllokepesseg / 4;
            if (life > this.Life)
            {
                this.Life = 0;
            }
        }

        public string GetResult(HarcosTipus tipus)
        {
            var who = tipus.GetDisplayName();
            return $"{GetStatus()} | {who}";
        }

        public string GetStatus()
        {
            return $"{Id} - {LastName} {FirstName} - {Life}";
        }

        public virtual void Vedekezes(IHarcos vedekezo)
        {
            Harc();
        }
        protected void Harc()
        {
            Life /= 2;
        }
        public bool IsDeath()
        {
            return Life == 0;
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
                var newAllokepesseg = Life + 20;
                Life = newAllokepesseg > 100 ? 100 : newAllokepesseg;
            }
        }
    }
}
