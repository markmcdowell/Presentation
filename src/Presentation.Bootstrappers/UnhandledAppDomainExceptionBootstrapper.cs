using System;
using Presentation.Interfaces;

namespace Presentation.Bootstrappers
{
    /// <summary>
    /// Bootstrapper to handle any <see cref="AppDomain"/> exceptions.
    /// </summary>
    public sealed class UnhandledAppDomainExceptionBootstrapper : IBootstrapper
    {
        private readonly IBootstrapper _bootstrapper;
        private readonly AppDomain _appDomain;
        private readonly Action<Exception, bool> _handler;

        public UnhandledAppDomainExceptionBootstrapper(IBootstrapper bootstrapper, AppDomain appDomain, Action<Exception, bool> handler)
        {
            if (bootstrapper == null)
                throw new ArgumentNullException(nameof(bootstrapper));
            if (appDomain == null)
                throw new ArgumentNullException(nameof(appDomain));
            if (handler == null)
                throw new ArgumentNullException(nameof(handler));

            _bootstrapper = bootstrapper;
            _appDomain = appDomain;
            _handler = handler;
        }

        public void Dispose()
        {
            _appDomain.UnhandledException -= CurrentDomainOnUnhandledException;

            _bootstrapper.Dispose();
        }

        public void Initialize()
        {
            _appDomain.UnhandledException += CurrentDomainOnUnhandledException;

            _bootstrapper.Initialize();
        }

        private void CurrentDomainOnUnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            var exception = e.ExceptionObject as Exception;

            _handler(exception, e.IsTerminating);
        }
    }
}