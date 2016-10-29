using System;
using System.Windows;
using System.Windows.Threading;
using Presentation.Interfaces;

namespace Presentation.Bootstrappers
{
    public sealed class UnhandledDispatcherExceptionBootstrapper : IBootstrapper
    {
        private readonly IBootstrapper _bootstrapper;
        private readonly Func<Exception, bool> _handler;

        public UnhandledDispatcherExceptionBootstrapper(IBootstrapper bootstrapper, Func<Exception, bool> handler)
        {
            _bootstrapper = bootstrapper;
            _handler = handler;
        }

        public void Dispose()
        {
            Application.Current.DispatcherUnhandledException -= CurrentOnDispatcherUnhandledException;

            _bootstrapper.Dispose();
        }

        public void Initialize()
        {
            Application.Current.DispatcherUnhandledException += CurrentOnDispatcherUnhandledException;

            _bootstrapper.Initialize();
        }

        private void CurrentOnDispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
        {
            if (_handler(e.Exception))
                e.Handled = true;
        }
    }
}