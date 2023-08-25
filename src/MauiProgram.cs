using CommunityToolkit.Maui;
using CutZone.Handlers;
using CutZone.Models;
using Material.Components.Maui.Extensions;
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
        builder
            .UseMaterialComponents(new List<string>
            {
                //generally, we needs add 6 types of font families
                "OpenSans-Regular.ttf",
                "OpenSans-Semibold.ttf",
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