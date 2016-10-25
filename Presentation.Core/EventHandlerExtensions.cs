using System;
using System.Collections;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Presentation.Core
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

        public static void Raise(this PropertyChangedEventHandler handler, INotifyPropertyChanged source, [CallerMemberName]string propertyName = null)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));
            if (propertyName == null)
                throw new ArgumentNullException(nameof(propertyName));

            var args = new PropertyChangedEventArgs(propertyName);
            handler?.Invoke(source, args);
        }

        public static void Raise(this PropertyChangingEventHandler handler, INotifyPropertyChanging source, [CallerMemberName]string propertyName = null)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));
            if (propertyName == null)
                throw new ArgumentNullException(nameof(propertyName));

            var args = new PropertyChangingEventArgs(propertyName);
            handler?.Invoke(source, args);
        }

        public static void Raise(this NotifyCollectionChangedEventHandler handler, INotifyCollectionChanged source, NotifyCollectionChangedAction action, IList changedItems)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            var args = new NotifyCollectionChangedEventArgs(action, changedItems);
            handler?.Invoke(source, args);
        }

        public static void Raise<T>(this NotifyCollectionChangedEventHandler handler, INotifyCollectionChanged source, NotifyCollectionChangedAction action, T item)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            var args = new NotifyCollectionChangedEventArgs(action, item);
            handler?.Invoke(source, args);
        }

        public static void Raise<T>(this NotifyCollectionChangedEventHandler handler, INotifyCollectionChanged source, NotifyCollectionChangedAction action, T item, int index)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            var args = new NotifyCollectionChangedEventArgs(action, item, index);
            handler?.Invoke(source, args);
        }

        public static void Raise<T>(this NotifyCollectionChangedEventHandler handler, INotifyCollectionChanged source, NotifyCollectionChangedAction action, T oldItem, T newItem, int index)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            var args = new NotifyCollectionChangedEventArgs(action, oldItem, newItem, index);
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