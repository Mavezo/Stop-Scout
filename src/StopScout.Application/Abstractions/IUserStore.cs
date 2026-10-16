using StopScout.Domain.Entities;

namespace StopScout.Application.Abstractions;

public interface IUserStore
{
    Task<User?> FindByUsernameAsync(string username, CancellationToken cancellationToken = default);

    Task CreateAsync(User user, CancellationToken cancellationToken = default);
}
