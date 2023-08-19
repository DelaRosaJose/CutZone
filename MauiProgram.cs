using CommunityToolkit.Maui;
using CutZone.Handlers;
using CutZone.Models;
using Microsoft.Extensions.Logging;
using SQLiteService;

namespace CutZone;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        Type[] Models =
        {
            typeof(User),
        };

        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .UseMauiCommunityToolkit()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

#if DEBUG
        builder.Logging.AddDebug();
#endif
        builder.Services.AddSingleton(new SQLiteRepository(Models));
        builder.Services.AddSingleton<MainPage>();

        builder.ConfigureMauiHandlers(handlers =>
        {
            handlers.AddPlainer();
        });

        return builder.Build();
    }
}