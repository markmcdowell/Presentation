using System;
using Presentation.Interfaces;

namespace Presentation.Bootstrappers
{
    public sealed class UnhandledAppDomainExceptionBootstrapper : IBootstrapper
    {
        private readonly IBootstrapper _bootstrapper;
        private readonly Action<Exception, bool> _handler;

        public UnhandledAppDomainExceptionBootstrapper(IBootstrapper bootstrapper, Action<Exception, bool> handler)
        {
            if (bootstrapper == null)
                throw new ArgumentNullException(nameof(bootstrapper));
            if (handler == null)
                throw new ArgumentNullException(nameof(handler));

            _bootstrapper = bootstrapper;
            _handler = handler;
        }

        public void Dispose()
        {
            AppDomain.CurrentDomain.UnhandledException -= CurrentDomainOnUnhandledException;

            _bootstrapper.Dispose();
        }

        public void Initialize()
        {
            AppDomain.CurrentDomain.UnhandledException += CurrentDomainOnUnhandledException;

            _bootstrapper.Initialize();
        }

        private void CurrentDomainOnUnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            var exception = e.ExceptionObject as Exception;

            _handler(exception, e.IsTerminating);
        }
    }
}