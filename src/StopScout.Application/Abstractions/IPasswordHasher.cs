namespace StopScout.Application.Abstractions;

/// <summary>
/// Milestone 2 — BCrypt.Net-Next counterpart of bcryptjs.
/// </summary>
public interface IPasswordHasher
{
    string Hash(string password);

    bool Verify(string password, string passwordHash);
}
