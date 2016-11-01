using System;
using System.Globalization;
using System.Windows.Data;

namespace Presentation.Converters
{
    /// <summary>
    /// Converts null to <see cref="Binding.DoNothing"/>
    /// </summary>
    public sealed class NullToDoNothingConverter : IValueConverter
    {
        /// <inheritdoc />
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value ?? Binding.DoNothing;
        }

        /// <inheritdoc />
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value ?? Binding.DoNothing;
        }
    }
}