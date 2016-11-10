using System.Reactive.Concurrency;

namespace Presentation.Reactive.Concurrency
{
    public interface ISchedulerProvider
    {
        IScheduler TaskPool { get; }

        IScheduler Immediate { get; } 
        
        IScheduler Dispatcher { get; }          
    }
}