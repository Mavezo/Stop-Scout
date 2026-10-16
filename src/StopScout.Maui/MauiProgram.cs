using StopScout.Application.DependencyInjection;
using StopScout.Infrastructure.DependencyInjection;
using StopScout.Maui.ViewModels;
using Microsoft.Extensions.Logging;

namespace StopScout.Maui;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

#if DEBUG
        builder.Logging.AddDebug();
#endif

        builder.Services.AddStopScoutApplication();
        builder.Services.AddStopScoutInfrastructure();

        builder.Services.AddTransient<DeparturesViewModel>();

        return builder.Build();
    }
}
