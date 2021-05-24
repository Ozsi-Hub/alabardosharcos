namespace Alabardos.Abstractions
{
    public interface IHarcoyFactory
    {
        IHarcos Create(string vezeteknev, string keresztnev);
    }
}
