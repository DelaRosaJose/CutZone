﻿using CutZone.Handlers;
using CutZone.Views;
using Microsoft.Extensions.Logging;
using SQLiteService;

namespace CutZone;

public static class MauiProgram
{
    private static readonly Type[] tableTypes = new Type[]
        {
            typeof(Models.User)
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
        //builder.Services.AddSingleton<LoginView>();
        #endregion


        #region Views DI
        builder.Services.AddSingleton<LoginView>();

        #endregion


        return builder.Build();
    }
}
