using Microsoft.Extensions.DependencyInjection;
using StopScout.Application.UseCases;

namespace StopScout.Application.DependencyInjection;

public static class ApplicationServiceCollectionExtensions
{
    public static IServiceCollection AddStopScoutApplication(this IServiceCollection services)
    {
        services.AddTransient<GetLiveDeparturesUseCase>();
        services.AddTransient<GetStopUseCase>();
        services.AddTransient<RegisterUserUseCase>();
        services.AddTransient<LoginUserUseCase>();
        return services;
    }
}
