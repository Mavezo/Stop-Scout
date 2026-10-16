using StopScout.Application.Dtos;

namespace StopScout.Application.Abstractions;

public interface IDepartureFeed
{
    Task<ZtmDeparturesResponseDto> GetDeparturesAsync(int stopId, CancellationToken cancellationToken = default);
}
