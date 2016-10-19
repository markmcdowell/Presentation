using System;
using System.Collections;
using System.Collections.Specialized;
using System.ComponentModel;

namespace Presentation.Extensions
{
    /// <summary>
    /// Event handler extensions.
    /// </summary>
    public static class EventHandlerExtensions
    {
        public static void Raise<TSource>(this EventHandler handler, TSource source)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            handler?.Invoke(source, EventArgs.Empty);
        }

        public static void Raise<TSource, TEventArgs>(this EventHandler<TEventArgs> handler, TSource source, TEventArgs args)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            handler?.Invoke(source, args);
        }

        public static void Raise(this PropertyChangedEventHandler handler, INotifyPropertyChanged source, string eventName)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));
            if (eventName == null)
                throw new ArgumentNullException(nameof(eventName));

            var args = new PropertyChangedEventArgs(eventName);
            handler?.Invoke(source, args);
        }

        public static void Raise(this PropertyChangingEventHandler handler, INotifyPropertyChanging source, string eventName)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));
            if (eventName == null)
                throw new ArgumentNullException(nameof(eventName));

            var args = new PropertyChangingEventArgs(eventName);
            handler?.Invoke(source, args);
        }

        public static void Raise(this NotifyCollectionChangedEventHandler handler, INotifyCollectionChanged source, NotifyCollectionChangedAction action, IList changedItems)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            var args = new NotifyCollectionChangedEventArgs(action, changedItems);
            handler?.Invoke(source, args);
        }

        public static void Reset(this NotifyCollectionChangedEventHandler handler, INotifyCollectionChanged source)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            var args = new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset);
            handler?.Invoke(source, args);
        }
    }
}