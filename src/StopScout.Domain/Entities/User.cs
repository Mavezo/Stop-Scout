namespace StopScout.Domain.Entities;

public sealed class User
{
    public string Id { get; init; } = Guid.NewGuid().ToString();

    public string Username { get; init; } = string.Empty;

    public string PasswordHash { get; init; } = string.Empty;
}
