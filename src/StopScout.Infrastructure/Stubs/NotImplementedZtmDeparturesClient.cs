using StopScout.Application.Abstractions;
using StopScout.Application.Dtos;

namespace StopScout.Infrastructure.Stubs;

/// <summary>Milestone 2 — HttpClient ZTM client. Not called in Milestone 1.</summary>
public sealed class NotImplementedZtmDeparturesClient : IZtmDeparturesClient
{
    public Task<ZtmDeparturesResponseDto> GetDeparturesAsync(int stopId, CancellationToken cancellationToken = default)
        => throw new NotImplementedException("Milestone 2");
}
