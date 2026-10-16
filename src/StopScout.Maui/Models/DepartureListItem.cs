using StopScout.Domain.Entities;
using StopScout.Domain.ValueObjects;

namespace StopScout.Maui.Models;

public sealed class DepartureListItem
{
    public required string Id { get; init; }

    public required string Line { get; init; }

    public required string Headsign { get; init; }

    public required string TimeText { get; init; }

    public required string RelativeText { get; init; }

    public required DelayStatus Status { get; init; }

    public static DepartureListItem From(Departure departure, DateTimeOffset now)
    {
        var effective = departure.EffectiveTime;
        var timeText = effective?.ToLocalTime().ToString("HH:mm") ?? "—";
        var relativeText = FormatRelative(effective, now);

        return new DepartureListItem
        {
            Id = departure.Id,
            Line = departure.Line,
            Headsign = departure.Headsign,
            TimeText = timeText,
            RelativeText = relativeText,
            Status = departure.Delay
        };
    }

    private static string FormatRelative(DateTimeOffset? effective, DateTimeOffset now)
    {
        if (effective is null)
        {
            return string.Empty;
        }

        var delta = effective.Value - now;
        if (delta <= TimeSpan.Zero)
        {
            return "odjechał";
        }

        if (delta.TotalMinutes < 1)
        {
            return $"za {(int)Math.Ceiling(delta.TotalSeconds)} s";
        }

        return $"za {(int)Math.Round(delta.TotalMinutes, MidpointRounding.AwayFromZero)} min";
    }
}
