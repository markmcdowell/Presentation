using System.Windows;
using System.Windows.Input;
using System.Windows.Interactivity;

namespace Presentation.Behaviors
{
    /// <summary>
    /// Attached behavior to focus the <see cref="UIElement"/> on mouse down.
    /// </summary>
    public sealed class FocusOnMouseDownBehavior : Behavior<UIElement>
    {
        protected override void OnAttached()
        {
            AssociatedObject.MouseDown += AssociatedObjectOnMouseDown;
        }

        protected override void OnDetaching()
        {
            AssociatedObject.MouseDown -= AssociatedObjectOnMouseDown;
        }

        private void AssociatedObjectOnMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (AssociatedObject.IsKeyboardFocusWithin)
                return;

            AssociatedObject.Focus();
            e.Handled = true;
        }
    }
}