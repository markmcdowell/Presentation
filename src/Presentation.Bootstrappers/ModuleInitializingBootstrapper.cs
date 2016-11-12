using System;
using System.ComponentModel.Composition.Hosting;
using Presentation.Interfaces;

namespace Presentation.Bootstrappers
{
    /// <summary>
    /// Bootstrapper to initialize all instances of <see cref="IModule"/>.
    /// </summary>
    public sealed class ModuleInitializingBootstrapper : IBootstrapper
    {
        private readonly IBootstrapper _bootstrapper;
        private readonly ExportProvider _exportProvider;

        public ModuleInitializingBootstrapper(IBootstrapper bootstrapper, ExportProvider exportProvider)
        {
            if (bootstrapper == null)
                throw new ArgumentNullException(nameof(bootstrapper));            
            if (exportProvider == null)
                throw new ArgumentNullException(nameof(exportProvider));

            _bootstrapper = bootstrapper;
            _exportProvider = exportProvider;
        }

        public void Dispose()
        {
            var modules = _exportProvider.GetExports<IModule>();
            foreach (var lazyModule in modules)
            {
                lazyModule.Value.Dispose();
            }

            _bootstrapper.Dispose();
        }

        public void Initialize()
        {
            var modules = _exportProvider.GetExports<IModule>();
            foreach (var lazyModule in modules)
            {
                lazyModule.Value.Initialize();
            }

            _bootstrapper.Initialize();
        }
    }
}