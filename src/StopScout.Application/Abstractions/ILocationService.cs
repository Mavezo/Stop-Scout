namespace StopScout.Application.Abstractions;

public interface ILocationService
{
    Task<(double Latitude, double Longitude)?> GetCurrentAsync(CancellationToken cancellationToken = default);
}
