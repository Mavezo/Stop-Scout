namespace StopScout.Application;

public sealed class DepartureFeedException : Exception
{
    public DepartureFeedException(string message)
        : base(message)
    {
    }

    public DepartureFeedException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}
