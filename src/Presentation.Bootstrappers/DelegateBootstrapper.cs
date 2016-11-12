using System;
using Presentation.Interfaces;

namespace Presentation.Bootstrappers
{
    /// <summary>
    /// Bootstrapper that delegates initialize and dispose to the given <see cref="Action"/>.
    /// </summary>
    public sealed class DelegateBootstrapper : IBootstrapper
    {
        private readonly Action _onInitialize;
        private readonly Action _onDispose;

        public DelegateBootstrapper(Action onInitialize, Action onDispose)
        {
            if (onInitialize == null)
                throw new ArgumentNullException(nameof(onInitialize));
            if (onDispose == null)
                throw new ArgumentNullException(nameof(onDispose));            

            _onInitialize = onInitialize;
            _onDispose = onDispose;
        }

        public void Dispose()
        {
            _onDispose();
        }

        public void Initialize()
        {
            _onInitialize();
        }
    }
}