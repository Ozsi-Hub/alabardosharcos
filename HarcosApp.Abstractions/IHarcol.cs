namespace HarcosApp.Abstractions
{
    public interface IHarcol
    {
        void Tamadas(IHarcos vedekezo);
        void Vedekezes(IHarcos tamado);
        void Kimarad();
        HarcosTipus WhoAreYou(IHarcos harcos);
        string GetResult(HarcosTipus tipus);
        string GetStatus();
        void Winner(int originalLife);
    }
}
