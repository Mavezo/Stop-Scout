using StopScout.Domain.Entities;

namespace StopScout.Application.Abstractions;

/// <summary>
/// Milestone 2 — persisted per-user favourite stops.
/// </summary>
public interface IFavoriteStore
{
    Task<IReadOnlyList<FavoriteStop>> GetForUserAsync(int userId, CancellationToken cancellationToken = default);

    Task AddAsync(FavoriteStop favorite, CancellationToken cancellationToken = default);

    Task RemoveAsync(int userId, int stopId, CancellationToken cancellationToken = default);
}
