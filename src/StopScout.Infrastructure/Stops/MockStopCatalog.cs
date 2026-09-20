using StopScout.Application.Abstractions;
using StopScout.Domain.Entities;

namespace StopScout.Infrastructure.Stops;

public sealed class MockStopCatalog : IStopCatalog
{
    public const int GdanskGlownyStopId = 2072;

    private static readonly Stop GdanskGlowny = new()
    {
        Id = GdanskGlownyStopId,
        Name = "Dworzec Główny",
        PoleCode = "01",
        Latitude = 54.3558,
        Longitude = 18.6447
    };

    public Task<Stop?> GetByIdAsync(int stopId, CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();
        return Task.FromResult(stopId == GdanskGlownyStopId ? GdanskGlowny : null);
    }
}
