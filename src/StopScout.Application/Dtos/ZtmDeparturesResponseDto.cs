using System.Text.Json.Serialization;

namespace StopScout.Application.Dtos;

public sealed class ZtmDeparturesResponseDto
{
    [JsonPropertyName("lastUpdate")]
    public string? LastUpdate { get; init; }

    [JsonPropertyName("departures")]
    public IReadOnlyList<ZtmDepartureDto> Departures { get; init; } = [];
}
