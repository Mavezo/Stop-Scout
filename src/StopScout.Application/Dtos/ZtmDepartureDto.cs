using System.Text.Json.Serialization;

namespace StopScout.Application.Dtos;

public sealed class ZtmDepartureDto
{
    [JsonPropertyName("id")]
    public string? Id { get; init; }

    [JsonPropertyName("delayInSeconds")]
    public int? DelayInSeconds { get; init; }

    [JsonPropertyName("estimatedTime")]
    public string? EstimatedTime { get; init; }

    [JsonPropertyName("theoreticalTime")]
    public string? TheoreticalTime { get; init; }

    [JsonPropertyName("headsign")]
    public string? Headsign { get; init; }

    [JsonPropertyName("routeId")]
    public int? RouteId { get; init; }

    [JsonPropertyName("routeShortName")]
    public string? RouteShortName { get; init; }

    [JsonPropertyName("tripId")]
    public int? TripId { get; init; }

    [JsonPropertyName("status")]
    public string? Status { get; init; }

    [JsonPropertyName("vehicleCode")]
    public string? VehicleCode { get; init; }
}
