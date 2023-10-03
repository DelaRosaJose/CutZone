using CommunityToolkit.Maui.Core;
using CutZone.Handlers;
using CutZone.ViewModels;
using CutZone.Views;
using Microsoft.Extensions.Logging;
using SQLiteService;

namespace CutZone;

public static class MauiProgram
{
    private static readonly Type[] tableTypes = new Type[]
    {
        typeof(Models.User),
        typeof(Models.Article),
    };

    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
#pragma warning disable MCT001 // `.UseMauiCommunityToolkit()` Not Found on MauiAppBuilder
        builder.UseMauiApp<App>();
#pragma warning restore MCT001 // `.UseMauiCommunityToolkit()` Not Found on MauiAppBuilder

        builder
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("MaterialIcons-Regular.ttf", "GoogleFont");
                fonts.AddFont("MaterialIconsOutlined-Regular.otf", "GoogleFontOutline");
                fonts.AddFont("Roboto-Regular.ttf", "RobotoRegular");
                fonts.AddFont("Roboto-Medium.ttf", "RobotoMedium");
            })
            .ConfigureMauiHandlers(Handlers => Handlers.AddPlainer());

#if DEBUG
        builder.Logging.AddDebug();
#endif


        #region Services DI

        builder.Services.AddSingleton(new SQLiteRepository(tableTypes));
        builder.Services.AddSingleton<IConnectivity>((e) => Connectivity.Current);
  

        #endregion


        #region ViewModels DI
        builder.Services.AddSingleton<LoginViewModel>();
        builder.Services.AddSingleton<ArticleViewModel>();
        #endregion


        #region Views DI
        builder.Services.AddSingleton<LoginPage>();
        builder.Services.AddSingleton<ArticlePage>();

        #endregion



        return builder.Build();
    }



}
