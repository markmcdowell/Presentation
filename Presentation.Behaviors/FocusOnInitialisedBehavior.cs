using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Interactivity;
using System.Windows.Threading;

namespace Presentation.Behaviors
{
    /// <summary>
    /// Attached behavior to focus the associated object once initialized
    /// </summary>
    public sealed class FocusOnInitialisedBehavior : Behavior<FrameworkElement>
    {
        protected override void OnAttached()
        {
            AssociatedObject.Initialized += AssociatedObjectOnInitialized;
        }

        protected override void OnDetaching()
        {
            AssociatedObject.Initialized -= AssociatedObjectOnInitialized;
        }

        private void AssociatedObjectOnInitialized(object sender, EventArgs e)
        {
            Action focus = () =>
            {
                AssociatedObject.Focus();
                Keyboard.Focus(AssociatedObject);
            };

            Dispatcher.BeginInvoke(DispatcherPriority.Input, focus);
        }
    }
}