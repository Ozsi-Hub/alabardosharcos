using System.Collections.Generic;

namespace HarcosApp.Abstractions
{
    public interface ILogic
    {
        void Play(IList<string> lastNames, IList<string> firstNames);
    }
}
