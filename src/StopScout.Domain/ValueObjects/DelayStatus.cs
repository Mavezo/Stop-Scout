namespace StopScout.Domain.ValueObjects;

public sealed record DelayStatus(
    DelayCategory Category,
    string DisplayText,
    bool ShouldAnimate);
