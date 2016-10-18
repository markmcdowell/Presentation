using System.Windows;
using Xunit;

namespace Presentation.Converters.Tests
{
    public sealed class BooleanToVisibilityConverterTests
    {
        [Fact]
        public void ShouldConvertNullNullableBoolToHidden()
        {
            var converter = new BooleanToVisibilityConverter();

            var visibility = converter.Convert((bool?) null, null, null, null);

            Assert.Equal(Visibility.Hidden, visibility);
        }

        [Fact]
        public void ShouldConvertFalseNullableBoolToHidden()
        {
            var converter = new BooleanToVisibilityConverter();

            var visibility = converter.Convert((bool?)false, null, null, null);

            Assert.Equal(Visibility.Hidden, visibility);
        }

        [Fact]
        public void ShouldConvertTrueNullableBoolToVisible()
        {
            var converter = new BooleanToVisibilityConverter();

            var visibility = converter.Convert((bool?)true, null, null, null);

            Assert.Equal(Visibility.Visible, visibility);
        }

        [Fact]
        public void ShouldConvertFalseBoolToHidden()
        {
            var converter = new BooleanToVisibilityConverter();

            var visibility = converter.Convert(false, null, null, null);

            Assert.Equal(Visibility.Hidden, visibility);
        }

        [Fact]
        public void ShouldConvertTrueBoolToVisible()
        {
            var converter = new BooleanToVisibilityConverter();

            var visibility = converter.Convert(true, null, null, null);

            Assert.Equal(Visibility.Visible, visibility);
        }
    }
}