using StopScout.Application.Abstractions;
using StopScout.Domain.Entities;

namespace StopScout.Infrastructure.Stubs;

/// <summary>Milestone 2 — SQLite user store. Not implemented in Milestone 1.</summary>
public sealed class NotImplementedUserStore : IUserStore
{
    public Task<User?> FindByEmailAsync(string email, CancellationToken cancellationToken = default)
        => throw new NotImplementedException("Milestone 2");

    public Task<User> CreateAsync(User user, CancellationToken cancellationToken = default)
        => throw new NotImplementedException("Milestone 2");
}
