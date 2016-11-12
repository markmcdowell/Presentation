using System.ComponentModel.Composition;
using System.Reactive.Concurrency;

namespace Presentation.Reactive.Concurrency
{
    [Export(typeof(ISchedulerProvider))]
    public sealed class DefaultSchedulerProvider : ISchedulerProvider
    {
        public IScheduler TaskPool => TaskPoolScheduler.Default;

        public IScheduler Immediate => ImmediateScheduler.Instance;

        public IScheduler Dispatcher => DispatcherScheduler.Current;
    }
}