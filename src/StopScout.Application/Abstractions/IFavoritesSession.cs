using StopScout.Domain.Entities;

namespace StopScout.Application.Abstractions;

/// <summary>
/// Milestone 2 — session for optimistic favourite UI (immediate list update, async persist, rollback on failure).
/// </summary>
public interface IFavoritesSession
{
    IReadOnlyList<int> FavoriteStopIds { get; }

    Task ToggleFavoriteAsync(int stopId, CancellationToken cancellationToken = default);
}
