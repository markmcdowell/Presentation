using System;
using System.Windows;
using Xunit;

namespace Presentation.Converters.Tests
{
    public sealed class ZeroToVisibilityConverterTests
    {
        [Theory]
        [InlineData(0)]
        [InlineData(0L)]
        [InlineData("0")]
        public void ShouldConvertZeroToCollapsed(object zero)
        {
            var converter = new ZeroToVisibilityConverter();

            var visibility = converter.Convert(zero, null, null, null);

            Assert.Equal(Visibility.Collapsed, visibility);
        }

        [Fact]
        public void ShouldConvertDecimalZeroToCollapsed()
        {
            var converter = new ZeroToVisibilityConverter();

            var visibility = converter.Convert(0M, null, null, null);

            Assert.Equal(Visibility.Collapsed, visibility);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(1L)]
        [InlineData("1")]
        public void ShouldConvertNonZeroToVisible(object zero)
        {
            var converter = new ZeroToVisibilityConverter();

            var visibility = converter.Convert(zero, null, null, null);

            Assert.Equal(Visibility.Visible, visibility);
        }

        [Fact]
        public void ShouldConvertNonZeroDecimalToCollapsed()
        {
            var converter = new ZeroToVisibilityConverter();

            var visibility = converter.Convert(1M, null, null, null);

            Assert.Equal(Visibility.Visible, visibility);
        }

        [Fact]
        public void ConvertBackShouldThrowNotSupportException()
        {
            var converter = new ZeroToVisibilityConverter();

            Assert.Throws<NotSupportedException>(() => converter.ConvertBack(null, null, null, null));
        }
    }
}