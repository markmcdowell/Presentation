using System;
using System.Collections.Generic;
using System.Reactive.Concurrency;
using System.Reactive.Linq;

namespace Presentation.Reactive
{
    public static class RepeatObservableExtensions
    {
        internal static IEnumerable<IObservable<T>> RepeatFinite<T>(IObservable<T> source, Func<int, TimeSpan> dueTime, int count, IScheduler scheduler = null)
        {
            yield return source;

            for (var i = 1; i <= count; i++)
                yield return source.DelaySubscription(dueTime(i), scheduler ?? DefaultScheduler.Instance);
        }

        internal static IEnumerable<IObservable<T>> RepeatInfinite<T>(IObservable<T> source, TimeSpan dueTime, IScheduler scheduler = null)
        {
            yield return source;

            while (true)
                yield return source.DelaySubscription(dueTime, scheduler ?? DefaultScheduler.Instance);
        }

        public static IObservable<T> RepeatAfter<T>(this IObservable<T> source, TimeSpan period, IScheduler scheduler = null)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            return RepeatInfinite(source, period, scheduler).Concat();
        }

        public static IObservable<T> RepeatAfter<T>(this IObservable<T> source, TimeSpan period, int count, IScheduler scheduler = null)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            return RepeatFinite(source, i => period, count, scheduler).Concat();
        }
    }
}