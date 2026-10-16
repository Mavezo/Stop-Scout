using StopScout.Application.Abstractions;
using StopScout.Application.Dtos;

namespace StopScout.Infrastructure.Stubs;

public sealed class NotImplementedZtmDeparturesClient : IZtmDeparturesClient
{
    public Task<ZtmDeparturesResponseDto> GetDeparturesAsync(int stopId, CancellationToken cancellationToken = default)
        => throw new NotImplementedException();
}
