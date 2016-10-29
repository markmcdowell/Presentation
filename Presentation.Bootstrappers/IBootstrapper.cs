using System;

namespace Presentation.Bootstrappers
{
    public interface IBootstrapper : IDisposable
    {
        void Initialize();
    }
}
