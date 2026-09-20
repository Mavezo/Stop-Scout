using StopScout.Application.Abstractions;

namespace StopScout.Infrastructure.Stubs;

/// <summary>Milestone 3 — device GPS. Not implemented in Milestone 1.</summary>
public sealed class NotImplementedLocationService : ILocationService
{
    public Task<(double Latitude, double Longitude)?> GetCurrentAsync(CancellationToken cancellationToken = default)
        => throw new NotImplementedException("Milestone 3");
}
