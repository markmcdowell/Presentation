using System;
using System.Diagnostics;
using System.Globalization;
using System.Windows.Data;

namespace Presentation.Converters
{
    /// <summary>
    /// Breaks the attached debugger when converting.
    /// </summary>
    public sealed class DebuggerConverter : IValueConverter
    {
        /// <inheritdoc />
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (Debugger.IsAttached)
                Debugger.Break();

            return value;
        }

        /// <inheritdoc />
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (Debugger.IsAttached)
                Debugger.Break();

            return value;
        }
    }
}