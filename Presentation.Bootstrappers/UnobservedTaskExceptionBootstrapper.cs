using System;
using System.Threading.Tasks;

namespace Presentation.Bootstrappers
{
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