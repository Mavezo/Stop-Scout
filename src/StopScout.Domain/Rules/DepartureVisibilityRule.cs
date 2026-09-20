namespace StopScout.Domain.Rules;

public static class DepartureVisibilityRule
{
    public static readonly TimeSpan MaxPastAge = TimeSpan.FromMinutes(2);

    public static bool IsVisible(DateTimeOffset? effectiveTime, DateTimeOffset now)
    {
        if (effectiveTime is null)
        {
            return false;
        }

        return now - effectiveTime.Value <= MaxPastAge;
    }
}
