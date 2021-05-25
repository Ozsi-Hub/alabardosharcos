namespace HarcosApp.Abstractions
{
    public interface IHarcosFactory
    {
        IHarcos Create(string lastName, string firstName);
    }
}
