using System;
using System.Linq;
using System.Reactive.Concurrency;
using System.Reactive.Linq;

namespace Presentation.Reactive
{
    public static class RetryObservableExtensions
    {
        public static IObservable<T> RetryAfter<T>(this IObservable<T> source, TimeSpan period, IScheduler scheduler = null)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            return RepeatObservableExtensions.RepeatInfinite(source, period, scheduler).Catch();
        }

        public static IObservable<T> RetryAfter<T>(this IObservable<T> source, TimeSpan period, int count, IScheduler scheduler = null)
        {
            if (source == null)
                throw new ArgumentNullException("source");

            return RepeatObservableExtensions.RepeatFinite(source, i => period, count, scheduler).Catch();
        }

        public static IObservable<T> RetryAfter<T>(this IObservable<T> source, TimeSpan period, int count, Action<Exception> onError, IScheduler scheduler = null)
        {
            if (source == null)
                throw new ArgumentNullException("source");

            return RepeatObservableExtensions.RepeatFinite(source, i => period, count, scheduler).Do(_ => { }, onError).Catch();
        }
    }
}