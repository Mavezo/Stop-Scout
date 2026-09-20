namespace StopScout.Domain.Entities;

public sealed class Stop
{
    public required int Id { get; init; }

    public required string Name { get; init; }

    public string? PoleCode { get; init; }

    public double? Latitude { get; init; }

    public double? Longitude { get; init; }
}
