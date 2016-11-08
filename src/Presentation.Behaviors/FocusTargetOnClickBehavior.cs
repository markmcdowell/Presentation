using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Interactivity;

namespace Presentation.Behaviors
{
    /// <summary>
    /// Attached behavior to focus the target <see cref="UIElement"/> on <see cref="ButtonBase.Click"/>.
    /// </summary>
    public sealed class FocusTargetOnClickBehavior : Behavior<ButtonBase>
    {
        public static readonly DependencyProperty TargetProperty = DependencyProperty.Register("Target", typeof(UIElement), typeof(FocusTargetOnClickBehavior), new PropertyMetadata(default(UIElement)));

        /// <summary>
        /// Makes the specified Target the focus on click.
        /// </summary>
        public UIElement Target
        {
            get { return (UIElement)GetValue(TargetProperty); }
            set { SetValue(TargetProperty, value); }
        }

        protected override void OnAttached()
        {
            AssociatedObject.Click += OnClick;
        }

        protected override void OnDetaching()
        {
            AssociatedObject.Click -= OnClick;
        }

        private void OnClick(object sender, RoutedEventArgs e)
        {
            if (Target.IsKeyboardFocusWithin)
                return;

            Target.Focus();
        }
    }
}
