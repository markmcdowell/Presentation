using System.Windows;
using System.Windows.Input;
using System.Windows.Interactivity;

namespace Presentation.Behaviors
{
    /// <summary>
    /// Attached behavior to handle the mouse down event on a <see cref="UIElement"/>
    /// </summary>
    public sealed class HandleMouseDownBehavior : Behavior<UIElement>
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
            e.Handled = true;
        }
    }
}