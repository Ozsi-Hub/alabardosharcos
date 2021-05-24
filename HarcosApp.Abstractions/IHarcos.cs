using System;

namespace HarcosApp.Abstractions
{
    public interface IHarcos: IHarcol
    {
        Guid Id { get; }
        string VezetekNeve { get; }
        string KeresztNeve { get; }
        int Allokepesseg { get; }
    }
}
