using StopScout.Application.Abstractions;

namespace StopScout.Infrastructure.Stubs;

/// <summary>Milestone 2 — BCrypt.Net-Next. Not implemented in Milestone 1.</summary>
public sealed class NotImplementedPasswordHasher : IPasswordHasher
{
    public string Hash(string password) => throw new NotImplementedException("Milestone 2");

    public bool Verify(string password, string passwordHash) => throw new NotImplementedException("Milestone 2");
}
