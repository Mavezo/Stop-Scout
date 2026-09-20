using StopScout.Application.Abstractions;
using StopScout.Application.Dtos;
using StopScout.Domain.Entities;
using StopScout.Domain.Formatting;
using StopScout.Domain.Rules;

namespace StopScout.Application.UseCases;

public sealed class GetLiveDeparturesUseCase
{
    private readonly IDepartureFeed _feed;
    private readonly IClock _clock;

    public GetLiveDeparturesUseCase(IDepartureFeed feed, IClock clock)
    {
        _feed = feed;
        _clock = clock;
    }

    public async Task<IReadOnlyList<Departure>> ExecuteAsync(int stopId, CancellationToken cancellationToken = default)
    {
        var response = await _feed.GetDeparturesAsync(stopId, cancellationToken);
        var now = _clock.UtcNow;

        return response.Departures
            .Select(Map)
            .Where(departure => DepartureVisibilityRule.IsVisible(departure.EffectiveTime, now))
            .OrderBy(departure => departure.EffectiveTime)
            .ToList();
    }

    private static Departure Map(ZtmDepartureDto dto)
    {
        var rawRoute = dto.RouteShortName;
        return new Departure
        {
            Id = dto.Id ?? Guid.NewGuid().ToString("N"),
            RouteId = dto.RouteId,
            RawRoute = rawRoute ?? string.Empty,
            Line = RouteFormatter.Format(rawRoute),
            Headsign = string.IsNullOrWhiteSpace(dto.Headsign) ? RouteFormatter.Fallback : dto.Headsign.Trim(),
            TheoreticalTime = ParseIso8601(dto.TheoreticalTime),
            EstimatedTime = ParseIso8601(dto.EstimatedTime),
            DelayInSeconds = dto.DelayInSeconds,
            VehicleCode = dto.VehicleCode,
            Delay = DelayFormatter.Format(dto.DelayInSeconds)
        };
    }

    private static DateTimeOffset? ParseIso8601(string? value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            return null;
        }

        return DateTimeOffset.TryParse(
            value,
            System.Globalization.CultureInfo.InvariantCulture,
            System.Globalization.DateTimeStyles.AssumeUniversal | System.Globalization.DateTimeStyles.AdjustToUniversal,
            out var parsed)
            ? parsed
            : null;
    }
}
