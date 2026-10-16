using Microsoft.Extensions.DependencyInjection;
using StopScout.Application.Abstractions;
using StopScout.Infrastructure.Feeds;
using StopScout.Infrastructure.Stops;
using StopScout.Infrastructure.Stubs;
using StopScout.Infrastructure.Time;

namespace StopScout.Infrastructure.DependencyInjection;

public static class InfrastructureServiceCollectionExtensions
{
    public static IServiceCollection AddStopScoutInfrastructure(this IServiceCollection services)
    {
        services.AddSingleton<IClock, SystemClock>();
        services.AddSingleton<IDepartureFeed, MockDepartureFeed>();
        services.AddSingleton<IStopCatalog, MockStopCatalog>();
        services.AddSingleton<IFavoriteStore, NotImplementedFavoriteStore>();
        services.AddSingleton<IUserStore, NotImplementedUserStore>();
        services.AddSingleton<IPasswordHasher, NotImplementedPasswordHasher>();
        services.AddSingleton<ILocationService, NotImplementedLocationService>();
        services.AddSingleton<IZtmDeparturesClient, NotImplementedZtmDeparturesClient>();
        services.AddSingleton<IFavoritesSession, NotImplementedFavoritesSession>();

        return services;
    }
}
