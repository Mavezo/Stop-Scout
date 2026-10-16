using StopScout.Application.Abstractions;
using StopScout.Domain.Entities;

namespace StopScout.Infrastructure.Stubs;

public sealed class NotImplementedFavoriteStore : IFavoriteStore
{
    public Task<IReadOnlyList<FavoriteStop>> GetForUserAsync(int userId, CancellationToken cancellationToken = default)
        => throw new NotImplementedException();

    public Task AddAsync(FavoriteStop favorite, CancellationToken cancellationToken = default)
        => throw new NotImplementedException();

    public Task RemoveAsync(int userId, int stopId, CancellationToken cancellationToken = default)
        => throw new NotImplementedException();
}
