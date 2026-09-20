using StopScout.Application.Dtos;

namespace StopScout.Application.Abstractions;

/// <summary>
/// Milestone 2 — real HttpClient ZTM departures adapter. Unused in Milestone 1.
/// </summary>
public interface IZtmDeparturesClient
{
    Task<ZtmDeparturesResponseDto> GetDeparturesAsync(int stopId, CancellationToken cancellationToken = default);
}
