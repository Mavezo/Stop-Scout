namespace StopScout.Domain.Entities;

/// <summary>
/// Milestone 2 — per-user favourite stop + optional note. Unused in Milestone 1 UI.
/// </summary>
public sealed class FavoriteStop
{
    public int UserId { get; init; }

    public int StopId { get; init; }

    public string? Note { get; init; }
}
