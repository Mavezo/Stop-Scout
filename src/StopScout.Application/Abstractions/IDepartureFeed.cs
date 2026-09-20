using StopScout.Application.Dtos;

namespace StopScout.Application.Abstractions;

/// <summary>
/// Live departures source. Milestone 1: mock fixtures. Milestone 2: HTTP ZTM client.
/// </summary>
public interface IDepartureFeed
{
    Task<ZtmDeparturesResponseDto> GetDeparturesAsync(int stopId, CancellationToken cancellationToken = default);
}
