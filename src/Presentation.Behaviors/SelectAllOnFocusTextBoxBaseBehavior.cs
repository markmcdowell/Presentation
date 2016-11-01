using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Interactivity;

namespace Presentation.Behaviors
{
    /// <summary>
    /// Attached behavior to select all text on focus.
    /// </summary>
    public sealed class SelectAllOnFocusTextBoxBaseBehavior : Behavior<TextBoxBase>
    {
        protected override void OnAttached()
        {
            AssociatedObject.GotFocus += AssociatedObjectOnGotFocus;
        }

        protected override void OnDetaching()
        {
            AssociatedObject.GotFocus -= AssociatedObjectOnGotFocus;
        }

        private void AssociatedObjectOnGotFocus(object sender, RoutedEventArgs e)
        {
            AssociatedObject.SelectAll();
        }
    }
}