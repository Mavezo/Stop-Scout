using StopScout.Domain.ValueObjects;

namespace StopScout.Domain.Entities;

public sealed class Departure
{
    public required string Id { get; init; }

    public int? RouteId { get; init; }

    public required string RawRoute { get; init; }

    public required string Line { get; init; }

    public required string Headsign { get; init; }

    public DateTimeOffset? TheoreticalTime { get; init; }

    public DateTimeOffset? EstimatedTime { get; init; }

    public DateTimeOffset? EffectiveTime => EstimatedTime ?? TheoreticalTime;

    public int? DelayInSeconds { get; init; }

    public string? VehicleCode { get; init; }

    public required DelayStatus Delay { get; init; }
}
