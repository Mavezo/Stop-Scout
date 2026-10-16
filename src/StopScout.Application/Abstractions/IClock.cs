namespace StopScout.Application.Abstractions;

public interface IClock
{
    DateTimeOffset UtcNow { get; }
}
