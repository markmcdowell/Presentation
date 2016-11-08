using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace Presentation.Converters
{
    /// <summary>
    /// Convert between a empty <see cref="string"/> and <see cref="Visibility"/>.
    /// </summary>
    [ValueConversion(typeof(string), typeof(Visibility))]
    public sealed class EmptyStringToVisibilityConverter : IValueConverter
    {
        /// <summary>
        /// Gets or sets the value to return when empty.
        /// </summary>
        public Visibility EmptyState { get; set; }

        /// <summary>
        /// Gets or sets the value to return when non-empty;
        /// </summary>
        public Visibility NonEmptyState { get; set; }

        /// <inheritdoc />
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var isEmpty = false;
            var stringValue = value as string;
            if (stringValue != null)
            {
                isEmpty = string.IsNullOrEmpty(stringValue);
            }

            return isEmpty ? EmptyState : NonEmptyState;
        }

        /// <inheritdoc />
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}