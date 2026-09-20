using StopScout.Domain.Entities;

namespace StopScout.Application.Abstractions;

/// <summary>
/// Milestone 2 — user accounts in SQLite.
/// </summary>
public interface IUserStore
{
    Task<User?> FindByEmailAsync(string email, CancellationToken cancellationToken = default);

    Task<User> CreateAsync(User user, CancellationToken cancellationToken = default);
}
