namespace StopScout.Domain.Entities;

/// <summary>
/// Milestone 2 — stored account. Unused in Milestone 1 UI.
/// </summary>
public sealed class User
{
    public int Id { get; init; }

    public string Email { get; init; } = string.Empty;

    public string PasswordHash { get; init; } = string.Empty;

    public string DisplayName { get; init; } = string.Empty;
}
