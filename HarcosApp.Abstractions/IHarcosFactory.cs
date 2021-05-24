namespace HarcosApp.Abstractions
{
    public interface IHarcosFactory
    {
        IHarcos Create(string vezeteknev, string keresztnev);
    }
}
