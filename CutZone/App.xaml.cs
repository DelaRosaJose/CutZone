using CutZone.Helper;
using CutZone.Models;
using CutZone.ViewModels;
using SQLiteService;

namespace CutZone;

public partial class App : Application
{

    public App ( LoginViewModel _loginViewModel, SQLiteRepository sqliteRepository )
    {
        InitializeComponent();

#if DEBUG

        sqliteRepository.CreateNotExists<User>(x => x.Name == "Admin",
            () => new User
            {
                Name = "Admin",
                Password = Hasher.ComputeHash("520210")
            });

        sqliteRepository.CreateNotExists<Article>(x => x.Name == "Vape",
            () => new Article
            {
                Name = "Vape",
                Modelo = "Brand New",
                Precio = 250
            });
#endif

        MainPage = new AppShell();
    }
}
