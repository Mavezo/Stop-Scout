using StopScout.Domain.Formatting;

namespace StopScout.Tests;

public sealed class RouteFormatterTests
{
    [Theory]
    [InlineData("10177", "177")]
    [InlineData("9", "9")]
    [InlineData("199", "199")]
    [InlineData("N1", "N1")]
    [InlineData("T8", "T8")]
    public void Format_KnownLines_ReturnsExpected(string raw, string expected)
    {
        Assert.Equal(expected, RouteFormatter.Format(raw));
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("   ")]
    [InlineData("???")]
    [InlineData("12 3")]
    public void Format_NullEmptyOrGarbage_ReturnsFallback(string? raw)
    {
        Assert.Equal(RouteFormatter.Fallback, RouteFormatter.Format(raw));
    }
}
