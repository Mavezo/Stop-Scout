using StopScout.Domain.Formatting;
using StopScout.Domain.ValueObjects;

namespace StopScout.Tests;

public sealed class DelayFormatterTests
{
    [Fact]
    public void Format_Null_IsOnTimeWithoutAnimation()
    {
        var status = DelayFormatter.Format(null);

        Assert.Equal(DelayCategory.OnTime, status.Category);
        Assert.Equal("Na czas", status.DisplayText);
        Assert.False(status.ShouldAnimate);
    }

    [Theory]
    [InlineData(-30)]
    [InlineData(0)]
    public void Format_ZeroOrNegative_IsOnTime(int seconds)
    {
        var status = DelayFormatter.Format(seconds);

        Assert.Equal(DelayCategory.OnTime, status.Category);
        Assert.Equal("Na czas", status.DisplayText);
        Assert.False(status.ShouldAnimate);
    }

    [Theory]
    [InlineData(1, "+1s")]
    [InlineData(90, "+90s")]
    [InlineData(119, "+119s")]
    public void Format_BelowTwoMinutes_IsMinorSeconds(int seconds, string expected)
    {
        var status = DelayFormatter.Format(seconds);

        Assert.Equal(DelayCategory.Minor, status.Category);
        Assert.Equal(expected, status.DisplayText);
        Assert.False(status.ShouldAnimate);
    }

    [Fact]
    public void Format_120Seconds_IsMajorTwoMinutesAndAnimates()
    {
        var status = DelayFormatter.Format(120);

        Assert.Equal(DelayCategory.Major, status.Category);
        Assert.Equal("+2 min", status.DisplayText);
        Assert.True(status.ShouldAnimate);
    }

    [Fact]
    public void Format_180Seconds_IsMajorThreeMinutesAndAnimates()
    {
        var status = DelayFormatter.Format(180);

        Assert.Equal(DelayCategory.Major, status.Category);
        Assert.Equal("+3 min", status.DisplayText);
        Assert.True(status.ShouldAnimate);
    }
}
