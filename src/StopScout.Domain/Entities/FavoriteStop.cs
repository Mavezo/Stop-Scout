namespace StopScout.Domain.Entities;

public sealed class FavoriteStop
{
    public int UserId { get; init; }

    public int StopId { get; init; }

    public string? Note { get; init; }
}
