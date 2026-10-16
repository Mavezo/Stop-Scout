using System.Globalization;
using StopScout.Application;
using StopScout.Application.Abstractions;
using StopScout.Application.Dtos;

namespace StopScout.Infrastructure.Feeds;

public sealed class MockDepartureFeed : IDepartureFeed
{
    public const int ErrorStopId = 0;

    private readonly IClock _clock;

    public MockDepartureFeed(IClock clock)
    {
        _clock = clock;
    }

    public async Task<ZtmDeparturesResponseDto> GetDeparturesAsync(int stopId, CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();

        // Short delay so the loading overlay is visible on device.
        await Task.Delay(350, cancellationToken);

        if (stopId == ErrorStopId)
        {
            throw new DepartureFeedException("Nie udało się pobrać odjazdów z mockowego źródła.");
        }

        var now = _clock.UtcNow;

        return new ZtmDeparturesResponseDto
        {
            LastUpdate = now.ToString("O", CultureInfo.InvariantCulture),
            Departures =
            [
                Create(
                    id: "on-time-9",
                    routeShortName: "9",
                    headsign: "Strzyża PKM",
                    delayInSeconds: 0,
                    estimated: now.AddMinutes(3),
                    theoretical: now.AddMinutes(3)),
                Create(
                    id: "early-199",
                    routeShortName: "199",
                    headsign: "Oliwa",
                    delayInSeconds: -30,
                    estimated: now.AddMinutes(6),
                    theoretical: now.AddMinutes(6).AddSeconds(30)),
                Create(
                    id: "minor-tristar",
                    routeShortName: "10177",
                    headsign: "Osowa PKM",
                    delayInSeconds: 90,
                    estimated: now.AddMinutes(8),
                    theoretical: now.AddMinutes(6).AddSeconds(30)),
                Create(
                    id: "major-n1",
                    routeShortName: "N1",
                    headsign: "Lotnisko",
                    delayInSeconds: 180,
                    estimated: now.AddMinutes(12),
                    theoretical: now.AddMinutes(9)),
                Create(
                    id: "major-theoretical-only",
                    routeShortName: "T8",
                    headsign: "Brzeźno",
                    delayInSeconds: 240,
                    estimated: null,
                    theoretical: now.AddMinutes(15)),
                Create(
                    id: "left-under-two-minutes",
                    routeShortName: "6",
                    headsign: "Łostowice Świętokrzyska",
                    delayInSeconds: 0,
                    estimated: now.AddMinutes(-1),
                    theoretical: now.AddMinutes(-1)),
                Create(
                    id: "stale-over-two-minutes",
                    routeShortName: "12",
                    headsign: "Ujeścisko",
                    delayInSeconds: 45,
                    estimated: now.AddMinutes(-3),
                    theoretical: now.AddMinutes(-4))
            ]
        };
    }

    private static ZtmDepartureDto Create(
        string id,
        string routeShortName,
        string headsign,
        int? delayInSeconds,
        DateTimeOffset? estimated,
        DateTimeOffset? theoretical)
    {
        return new ZtmDepartureDto
        {
            Id = id,
            DelayInSeconds = delayInSeconds,
            EstimatedTime = estimated?.ToString("O", CultureInfo.InvariantCulture),
            TheoreticalTime = theoretical?.ToString("O", CultureInfo.InvariantCulture),
            Headsign = headsign,
            RouteId = 1,
            RouteShortName = routeShortName,
            TripId = 1,
            Status = estimated is null ? "SCHEDULED" : "PREDICTED",
            VehicleCode = "3001"
        };
    }
}
