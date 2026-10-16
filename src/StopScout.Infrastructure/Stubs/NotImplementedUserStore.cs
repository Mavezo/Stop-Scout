using StopScout.Application.Abstractions;
using StopScout.Domain.Entities;

namespace StopScout.Infrastructure.Stubs;

public sealed class NotImplementedUserStore : IUserStore
{
    public Task<User?> FindByUsernameAsync(string username, CancellationToken cancellationToken = default)
        => throw new NotImplementedException();

    public Task CreateAsync(User user, CancellationToken cancellationToken = default)
        => throw new NotImplementedException();
}
