using StopScout.Domain.Entities;

namespace StopScout.Application.Abstractions;

public interface IStopCatalog
{
    Task<Stop?> GetByIdAsync(int stopId, CancellationToken cancellationToken = default);
}
