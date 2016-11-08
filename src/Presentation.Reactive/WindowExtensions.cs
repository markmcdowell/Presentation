using System;
using System.Reactive.Linq;
using System.Windows;
using Presentation.Interfaces;

namespace Presentation.Reactive
{
    public static class WindowExtensions
    {
        public static IObservable<T> OnActivated<T>(this T window) where T : IWindow
        {
            if (window == null)
                throw new ArgumentNullException(nameof(window));

            return Observable.FromEventPattern(h => window.Activated += h, h => window.Activated -= h)
                             .Select(_ => (T)_.Sender);
        }

        public static IObservable<T> OnClosed<T>(this T window) where T : IWindow
        {
            if (window == null)
                throw new ArgumentNullException(nameof(window));

            return Observable.FromEventPattern(h => window.Closed += h, h => window.Closed -= h)
                             .Select(_ => (T)_.Sender);
        }

        public static IObservable<T> OnDeactived<T>(this T window) where T : IWindow
        {
            if (window == null)
                throw new ArgumentNullException(nameof(window));

            return Observable.FromEventPattern(h => window.Deactivated += h, h => window.Deactivated -= h)
                             .Select(_ => (T)_.Sender);
        }

        public static IObservable<T> OnLocationChanged<T>(this T window) where T : IWindow
        {
            if (window == null)
                throw new ArgumentNullException(nameof(window));

            return Observable.FromEventPattern(h => window.LocationChanged += h, h => window.LocationChanged -= h)
                             .Select(_ => (T)_.Sender);
        }

        public static IObservable<T> OnSizeChanged<T>(this T window) where T : IWindow
        {
            if (window == null)
                throw new ArgumentNullException(nameof(window));

            return Observable.FromEventPattern<SizeChangedEventHandler, SizeChangedEventArgs>(h => window.SizeChanged += h, h => window.SizeChanged -= h)
                             .Select(_ => (T)_.Sender);
        }
    }
}