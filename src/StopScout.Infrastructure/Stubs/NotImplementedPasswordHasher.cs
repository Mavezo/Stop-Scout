using StopScout.Application.Abstractions;

namespace StopScout.Infrastructure.Stubs;

public sealed class NotImplementedPasswordHasher : IPasswordHasher
{
    public string Hash(string password) => throw new NotImplementedException();

    public bool Verify(string password, string passwordHash) => throw new NotImplementedException();
}
