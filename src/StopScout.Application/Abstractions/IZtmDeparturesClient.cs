using StopScout.Application.Dtos;

namespace StopScout.Application.Abstractions;

public interface IZtmDeparturesClient
{
    Task<ZtmDeparturesResponseDto> GetDeparturesAsync(int stopId, CancellationToken cancellationToken = default);
}
