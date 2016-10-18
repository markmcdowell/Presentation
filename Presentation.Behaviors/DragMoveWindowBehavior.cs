using System.Windows;
using System.Windows.Input;
using System.Windows.Interactivity;

namespace Presentation.Behaviors
{
    /// <summary>
    /// Attached behavior to drag a window when the left mouse button is down.
    /// </summary>
    public sealed class DragMoveWindowBehavior : Behavior<Window>
    {
        protected override void OnAttached()
        {
            AssociatedObject.MouseLeftButtonDown += AssociatedObjectOnMouseLeftButtonDown;
        }

        protected override void OnDetaching()
        {
            AssociatedObject.MouseLeftButtonDown -= AssociatedObjectOnMouseLeftButtonDown;
        }

        private void AssociatedObjectOnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            AssociatedObject.DragMove();
        }
    }
}