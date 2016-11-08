using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace Presentation.Converters
{
    /// <summary>
    /// Convert between a <see cref="bool"/> and <see cref="Visibility"/>.
    /// </summary>
    [ValueConversion(typeof(bool), typeof(Visibility))]
    public sealed class BooleanToVisibilityConverter : IValueConverter
    {
        /// <summary>
        /// Gets or sets the value to return when true. Defaults to Visible.
        /// </summary>
        public Visibility TrueState { get; set; } = Visibility.Visible;

        /// <summary>
        /// Gets or sets the value to return when false. Defaults to Hidden.
        /// </summary>
        public Visibility FalseState { get; set; } = Visibility.Hidden;

        /// <inheritdoc />
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var isTrue = false;
            if (value is bool)
            {
                isTrue = (bool)value;
            }
            
            return isTrue ? TrueState : FalseState;
        }

        /// <inheritdoc />
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value as Visibility? == TrueState;
        }
    }
}
