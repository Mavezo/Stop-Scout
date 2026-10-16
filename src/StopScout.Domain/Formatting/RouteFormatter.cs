using System.Text.RegularExpressions;

namespace StopScout.Domain.Formatting;

public static partial class RouteFormatter
{
    public const string Fallback = "—";

    public static string Format(string? raw)
    {
        if (string.IsNullOrWhiteSpace(raw))
        {
            return Fallback;
        }

        var value = raw.Trim();

        var tristar = TristarPrefix().Match(value);
        if (tristar.Success)
        {
            return tristar.Groups[1].Value;
        }

        return LineToken().IsMatch(value) ? value : Fallback;
    }

    [GeneratedRegex(@"^10(\d{1,3})$", RegexOptions.CultureInvariant)]
    private static partial Regex TristarPrefix();

    [GeneratedRegex(@"^[A-Za-z0-9]+$", RegexOptions.CultureInvariant)]
    private static partial Regex LineToken();
}
