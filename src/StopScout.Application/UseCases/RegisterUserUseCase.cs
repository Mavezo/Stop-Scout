using StopScout.Application.Abstractions;
using StopScout.Domain.Entities;

namespace StopScout.Application.UseCases;

public sealed class RegisterUserUseCase
{
    public RegisterUserUseCase(IUserStore users, IPasswordHasher passwordHasher)
    {
        ArgumentNullException.ThrowIfNull(users);
        ArgumentNullException.ThrowIfNull(passwordHasher);
    }

    public Task<User> ExecuteAsync(string username, string password, CancellationToken cancellationToken = default)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(username);
        ArgumentException.ThrowIfNullOrWhiteSpace(password);
        cancellationToken.ThrowIfCancellationRequested();
        throw new NotImplementedException();
    }
}
