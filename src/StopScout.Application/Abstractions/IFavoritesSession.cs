namespace StopScout.Application.Abstractions;

public interface IFavoritesSession
{
    IReadOnlyList<int> FavoriteStopIds { get; }

    Task ToggleFavoriteAsync(int stopId, CancellationToken cancellationToken = default);
}
