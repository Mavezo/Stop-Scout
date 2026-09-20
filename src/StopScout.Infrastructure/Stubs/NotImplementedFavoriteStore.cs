using StopScout.Application.Abstractions;
using StopScout.Domain.Entities;

namespace StopScout.Infrastructure.Stubs;

/// <summary>Milestone 2 — SQLite favourite store. Not implemented in Milestone 1.</summary>
public sealed class NotImplementedFavoriteStore : IFavoriteStore
{
    public Task<IReadOnlyList<FavoriteStop>> GetForUserAsync(int userId, CancellationToken cancellationToken = default)
        => throw new NotImplementedException("Milestone 2");

    public Task AddAsync(FavoriteStop favorite, CancellationToken cancellationToken = default)
        => throw new NotImplementedException("Milestone 2");

    public Task RemoveAsync(int userId, int stopId, CancellationToken cancellationToken = default)
        => throw new NotImplementedException("Milestone 2");
}
