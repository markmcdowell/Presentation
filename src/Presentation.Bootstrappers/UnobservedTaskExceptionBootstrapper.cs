﻿using System;
using System.Threading.Tasks;
using Presentation.Interfaces;

namespace Presentation.Bootstrappers
{
    /// <summary>
    /// Bootstrapper to handle any unobserved <see cref="Task"/> exceptions.
    /// </summary>
    public sealed class UnobservedTaskExceptionBootstrapper : IBootstrapper
    {
        private readonly IBootstrapper _bootstrapper;
        private readonly Func<AggregateException, bool> _handler;

        public UnobservedTaskExceptionBootstrapper(IBootstrapper bootstrapper, Func<AggregateException, bool> handler)
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
            TaskScheduler.UnobservedTaskException -= TaskSchedulerOnUnobservedTaskException;

            _bootstrapper.Dispose();
        }

        public void Initialize()
        {
            TaskScheduler.UnobservedTaskException += TaskSchedulerOnUnobservedTaskException;

            _bootstrapper.Initialize();
        }

        private void TaskSchedulerOnUnobservedTaskException(object sender, UnobservedTaskExceptionEventArgs e)
        {
            if (_handler(e.Exception))
                e.SetObserved();
        }
    }
}