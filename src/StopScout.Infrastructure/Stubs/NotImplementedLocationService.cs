using StopScout.Application.Abstractions;

namespace StopScout.Infrastructure.Stubs;

public sealed class NotImplementedLocationService : ILocationService
{
    public Task<(double Latitude, double Longitude)?> GetCurrentAsync(CancellationToken cancellationToken = default)
        => throw new NotImplementedException();
}
