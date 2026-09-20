namespace StopScout.Application.Abstractions;

/// <summary>
/// Milestone 3 — GPS via Microsoft.Maui.Devices.Sensors / Geolocation.
/// </summary>
public interface ILocationService
{
    Task<(double Latitude, double Longitude)?> GetCurrentAsync(CancellationToken cancellationToken = default);
}
