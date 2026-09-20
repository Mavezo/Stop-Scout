using StopScout.Domain.Entities;

namespace StopScout.Application.Abstractions;

/// <summary>
/// Stop catalogue. Milestone 1: in-memory mock. Milestone 2: SQLite cache of CKAN stops.json.
/// </summary>
public interface IStopCatalog
{
    Task<Stop?> GetByIdAsync(int stopId, CancellationToken cancellationToken = default);
}
