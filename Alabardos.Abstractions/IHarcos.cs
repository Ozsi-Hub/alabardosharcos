using System;
using System.Collections.Generic;
using System.Text;

namespace Alabardos.Abstractions
{
    public interface IHarcos: IHarcol
    {
        Guid Id { get; }
        string VezetekNeve { get; }
        string KeresztNeve { get; }
        int Allokepesseg { get; }
    }
}
