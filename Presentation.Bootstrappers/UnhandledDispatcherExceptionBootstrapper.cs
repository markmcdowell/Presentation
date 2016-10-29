using System;
using System.Windows;
using System.Windows.Threading;
using Presentation.Interfaces;

namespace Presentation.Bootstrappers
{
    /// <summary>
    /// Bootstrapper to handle any unhandled <see cref="Dispatcher"/> exceptions.
    /// </summary>
    public sealed class UnhandledDispatcherExceptionBootstrapper : IBootstrapper
    {
        private readonly IBootstrapper _bootstrapper;
        private readonly Application _application;
        private readonly Func<Exception, bool> _handler;

        public UnhandledDispatcherExceptionBootstrapper(IBootstrapper bootstrapper, Application application, Func<Exception, bool> handler)
        {
            if (bootstrapper == null)
                throw new ArgumentNullException(nameof(bootstrapper));
            if (application == null)
                throw new ArgumentNullException(nameof(application));
            if (handler == null)
                throw new ArgumentNullException(nameof(handler));

            _bootstrapper = bootstrapper;
            _application = application;
            _handler = handler;
        }

        public void Dispose()
        {
            _application.DispatcherUnhandledException -= CurrentOnDispatcherUnhandledException;

            _bootstrapper.Dispose();
        }

        public void Initialize()
        {
            _application.DispatcherUnhandledException += CurrentOnDispatcherUnhandledException;

            _bootstrapper.Initialize();
        }

        private void CurrentOnDispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
        {
            if (_handler(e.Exception))
                e.Handled = true;
        }
    }
}