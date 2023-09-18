using CommunityToolkit.Maui.Core;
using CommunityToolkit.Mvvm.Input;
using CutZone.Helper;
using CutZone.Services;
using CutZone.Views;
using SQLiteService;
using System.Runtime.CompilerServices;
using Model = CutZone.Models.Article;

namespace CutZone.ViewModels;

public partial class ArticleViewModel : Model
{
    private readonly SQLiteRepository _sqliteRepository;
    private readonly IConnectivity _connectivity;
    public List<Model> viewmodel;

    public ArticleViewModel(IConnectivity connectivity, SQLiteRepository sqliteRepository)
    {
        _connectivity = connectivity;
        _sqliteRepository = sqliteRepository;
        methis();
    }

    void methis() => viewmodel = _sqliteRepository.GetTableAll<Model>().ToList();


    [RelayCommand]
    async void Login()
    {

    }

}

