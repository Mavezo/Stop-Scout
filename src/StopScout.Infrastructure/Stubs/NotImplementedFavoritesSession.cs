using StopScout.Application.Abstractions;

namespace StopScout.Infrastructure.Stubs;

public sealed class NotImplementedFavoritesSession : IFavoritesSession
{
    public IReadOnlyList<int> FavoriteStopIds => throw new NotImplementedException();

    public Task ToggleFavoriteAsync(int stopId, CancellationToken cancellationToken = default)
        => throw new NotImplementedException();
}
