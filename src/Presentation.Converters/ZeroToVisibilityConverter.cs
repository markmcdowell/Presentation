﻿using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace Presentation.Converters
{
    /// <summary>
    /// Convert between between zero and <see cref="Visibility"/>.
    /// </summary>
    public sealed class ZeroToVisibilityConverter : IValueConverter
    {
        /// <summary>
        /// Gets or sets the value to return when zero. Defaults to Collapsed.
        /// </summary>
        public Visibility ZeroState { get; set; } = Visibility.Collapsed;

        /// <summary>
        /// Gets or sets the value to return when non-zero. Defaults to Visible.
        /// </summary>
        public Visibility NonZeroState { get; set; } = Visibility.Visible;

        /// <inheritdoc />
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var isZero = false;
            if (value is int)
            {
                var intValue = (int) value;
                isZero = intValue == 0;
            }

            if (value is long)
            {
                var longValue = (long) value;
                isZero = longValue == 0L;
            }

            if (value is decimal)
            {
                var decimalValue = (decimal) value;
                isZero = decimalValue == 0M;
            }

            if (value is string)
            {
                var stringValue = (string) value;
                isZero = stringValue == "0";
            }

            return isZero ? ZeroState : NonZeroState;
        }

        /// <inheritdoc />
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}