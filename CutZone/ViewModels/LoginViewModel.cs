﻿using CommunityToolkit.Maui.Core;
using CommunityToolkit.Mvvm.Input;
using CutZone.Helper;
using CutZone.Services;
using CutZone.Views;
using SQLiteService;
using Model = CutZone.Models.User;

namespace CutZone.ViewModels;

public partial class LoginViewModel : Model
{
    private readonly SQLiteRepository _sqliteRepository;
    private readonly IConnectivity _connectivity;

    public LoginViewModel(IConnectivity connectivity, SQLiteRepository sqliteRepository)
    {
        _connectivity = connectivity;
        _sqliteRepository = sqliteRepository;

#if DEBUG
        this.Name = "Admin";
        this.Password = "520210";
#endif
    }

    [RelayCommand]
    async void Login()
    {
        string PassHash = Hasher.ComputeHash(Password);
        if (_sqliteRepository.Any<Model>(x => x.Name == Name && x.Password == PassHash))
            Application.Current.MainPage = new AppShell();
        //await Shell.Current.GoToAsync($"{nameof(HomePage)}");
        else
            Toaster.MakeToast("Credenciales Incorrectas");

    }

}

