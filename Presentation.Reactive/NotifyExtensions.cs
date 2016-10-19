using System;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Reactive.Linq;

namespace Presentation.Reactive
{
    public static class NotifyExtensions
    {
        public static IObservable<T> Observe<T>(this T source, string propertyName) where T : INotifyPropertyChanged
        {
            return Observable.FromEventPattern<PropertyChangedEventHandler, PropertyChangedEventArgs>(h => source.PropertyChanged += h, h => source.PropertyChanged -= h)
                             .Where(_ => _.EventArgs.PropertyName == propertyName)
                             .Select(_ => (T)_.Sender);
        }

        public static IObservable<T> Observe<T>(this INotifyPropertyChanging source, string propertyName)
        {
            return Observable.FromEventPattern<PropertyChangingEventHandler, PropertyChangingEventArgs>(h => source.PropertyChanging += h, h => source.PropertyChanging -= h)
                             .Where(_ => _.EventArgs.PropertyName == propertyName)
                             .Select(_ => (T)_.Sender);
        }

        public static IObservable<T> Observe<T>(this T source, NotifyCollectionChangedAction action) where T : INotifyCollectionChanged
        {
            return Observable.FromEventPattern<NotifyCollectionChangedEventHandler, NotifyCollectionChangedEventArgs>(h => source.CollectionChanged += h, h => source.CollectionChanged -= h)
                             .Where(_ => _.EventArgs.Action == action)
                             .Select(_ => (T)_.Sender);
        }
    }
}