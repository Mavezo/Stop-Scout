using StopScout.Application.Abstractions;

namespace StopScout.Infrastructure.Stubs;

/// <summary>Milestone 2 — optimistic favourites session. Not implemented in Milestone 1.</summary>
public sealed class NotImplementedFavoritesSession : IFavoritesSession
{
    public IReadOnlyList<int> FavoriteStopIds => throw new NotImplementedException("Milestone 2");

    public Task ToggleFavoriteAsync(int stopId, CancellationToken cancellationToken = default)
        => throw new NotImplementedException("Milestone 2");
}
