using System;

namespace HarcosApp.Abstractions
{
    public interface IHarcos: IHarcol
    {
        Guid Id { get; }
        string LastName { get; }
        string FirstName { get; }
        int Life { get; }
    }
}
