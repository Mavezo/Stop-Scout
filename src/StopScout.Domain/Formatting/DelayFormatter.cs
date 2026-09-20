using StopScout.Domain.ValueObjects;

namespace StopScout.Domain.Formatting;

public static class DelayFormatter
{
    public const string OnTimeText = "Na czas";

    public static DelayStatus Format(int? delayInSeconds)
    {
        if (delayInSeconds is null || delayInSeconds.Value <= 0)
        {
            return new DelayStatus(DelayCategory.OnTime, OnTimeText, ShouldAnimate: false);
        }

        var seconds = delayInSeconds.Value;
        if (seconds < 120)
        {
            return new DelayStatus(DelayCategory.Minor, $"+{seconds}s", ShouldAnimate: false);
        }

        var minutes = (int)Math.Round(seconds / 60.0, MidpointRounding.AwayFromZero);
        return new DelayStatus(DelayCategory.Major, $"+{minutes} min", ShouldAnimate: true);
    }
}
