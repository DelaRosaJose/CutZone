using CommunityToolkit.Maui.Core;
using CutZone.Handlers;
using CutZone.ViewModels;
using CutZone.Views;
using Microsoft.Maui.Platform;
using Microsoft.Extensions.Logging;
using Microsoft.Maui.LifecycleEvents;
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

        builder.ConfigureLifecycleEvents(events =>
        {
#if WINDOWS
            events.AddWindows(lifeCycleBuilder =>
            {
                lifeCycleBuilder.OnWindowCreated(window =>
                {
                    var handle = WinRT.Interop.WindowNative.GetWindowHandle(window);
                    var id = Microsoft.UI.Win32Interop.GetWindowIdFromWindow(handle);
                    var appWindow = Microsoft.UI.Windowing.AppWindow.GetFromWindowId(id);
                    var titleBar = appWindow.TitleBar;
                    //var favoriteColor = new Windows.UI.Color()
                    //{
                    //    R = 243,
                    //    G = 243,
                    //    B = 243,
                    //};
                    var favoriteColor = Color.FromArgb("#f3f3f3").ToWindowsColor();

                    titleBar.BackgroundColor = favoriteColor;
                    titleBar.ButtonBackgroundColor = favoriteColor;
                    titleBar.ButtonForegroundColor = Colors.Black.ToWindowsColor();
                    titleBar.InactiveBackgroundColor = favoriteColor;
                    titleBar.InactiveForegroundColor = Colors.Black.ToWindowsColor();
                    titleBar.ButtonInactiveBackgroundColor = favoriteColor;
                    titleBar.ButtonInactiveForegroundColor = Colors.Black.ToWindowsColor();
                    titleBar.ButtonForegroundColor = Color.FromArgb("#2a2a2a").ToWindowsColor();
                    titleBar.ButtonPressedBackgroundColor = Colors.DarkGray.ToWindowsColor();
                    titleBar.ButtonHoverBackgroundColor = Color.FromArgb("#e6e6e6").ToWindowsColor();

                });
            });
#endif
        });


#if DEBUG
        builder.Logging.AddDebug();
#endif


        #region Services DI

        builder.Services.AddSingleton(new SQLiteRepository(tableTypes));
        builder.Services.AddSingleton<IConnectivity>((e) => Connectivity.Current);
  

        #endregion


        #region ViewModels DI
        builder.Services.AddTransient<LoginViewModel>();
        builder.Services.AddSingleton<ArticleViewModel>();
        #endregion


        #region Views DI
        //builder.Services.AddSingleton<App>();
        builder.Services.AddTransient<LoginPage>();
        builder.Services.AddTransient<HomePage>();
        builder.Services.AddSingleton<ArticlePage>();

        #endregion




        return builder.Build();
    }



}
