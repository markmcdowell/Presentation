using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Interactivity;

namespace Presentation.Behaviors
{
    /// <summary>
    /// Attached behavior to change the controls fontsize with a key modifier and mouse wheel
    /// </summary>
    public sealed class ChangeFontSizeWithModifierAndMouseWheelBehavior : Behavior<Control>
    {
        /// <summary>
        /// Gets or sets the <see cref="Key"/> modifier to check if it's pressed.
        /// </summary>
        public Key Modifier { get; set; } = Key.LeftCtrl;

        protected override void OnAttached()
        {
            AssociatedObject.MouseWheel += AssociatedObjectOnMouseWheel;
        }

        protected override void OnDetaching()
        {
            AssociatedObject.MouseWheel -= AssociatedObjectOnMouseWheel;
        }

        private void AssociatedObjectOnMouseWheel(object sender, MouseWheelEventArgs e)
        {
            if (!Keyboard.IsKeyDown(Modifier))
                return;

            if (e.Delta > 0)
                AssociatedObject.FontSize++;
            else
                AssociatedObject.FontSize--;
        }
    }
}