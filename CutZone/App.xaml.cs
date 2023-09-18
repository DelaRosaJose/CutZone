using CutZone.Helper;
using CutZone.Models;
using SQLiteService;

namespace CutZone;

public partial class App : Application
{

    private readonly SQLiteRepository _sqliteRepository;
    public App(SQLiteRepository sqliteRepository)
    {
        InitializeComponent();
        _sqliteRepository = sqliteRepository;

        _sqliteRepository.CreateNotExists<User>(x => x.Name == "Admin",
            () => new User
            {
                Name = "Admin",
                Password = Hasher.ComputeHash("520210")
            });

        _sqliteRepository.CreateNotExists<Article>(x => x.Name == "Vape",
            () => new Article
            {
                Name = "Vape",
                Modelo = "Brand New",
                Precio = 250
            });

        MainPage = new AppShell();
    }
}
