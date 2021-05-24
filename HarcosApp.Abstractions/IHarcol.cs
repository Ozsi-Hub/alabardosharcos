namespace HarcosApp.Abstractions
{
    public interface IHarcol
    {
        void Tamadas(IHarcos vedekezo);

        void Vedekezes(HarcosTipus harcosTipus);

        void Kimarad();

        HarcosTipus WhoAreYou(IHarcos harcos);
    }
}
