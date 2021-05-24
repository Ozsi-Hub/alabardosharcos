using System.Collections.Generic;

namespace HarcosApp.Abstractions
{
    public interface ILogic
    {
        void Play(IList<string> vezeteknev, IList<string> keresztnev);
    }
}
