using CommunityToolkit.Mvvm.Input;
using CutZone.Models;
using SQLiteService;

namespace CutZone.ViewModels;

public partial class LoginViewModel : User
{
    private readonly SQLiteRepository _sqliteRepository;
    private readonly IConnectivity _connectivity;

    public LoginViewModel(IConnectivity connectivity, SQLiteRepository sqliteRepository) 
    {
        _connectivity = connectivity;
        _sqliteRepository = sqliteRepository;
    }

    [RelayCommand]
    async void Login()
    {

    }

}

