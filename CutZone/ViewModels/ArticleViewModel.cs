using CommunityToolkit.Maui.Core;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CutZone.Helper;
using CutZone.Services;
using CutZone.Views;
using SQLiteService;
using System.Runtime.CompilerServices;
using System.Xml.Linq;
using Model = CutZone.Models.Article;

namespace CutZone.ViewModels;

public partial class ArticleViewModel : Model
{
    private readonly SQLiteRepository _sqliteRepository;
    private readonly IConnectivity _connectivity;

    [ObservableProperty]
    List<Model> viewmodel;

    public ArticleViewModel(IConnectivity connectivity, SQLiteRepository sqliteRepository)
    {
        _connectivity = connectivity;
        _sqliteRepository = sqliteRepository;
        GetAllArticles();

    }

    void GetAllArticles() => Viewmodel = _sqliteRepository.GetTableAll<Model>().ToList();


    [RelayCommand]
    async void SaveArticle()
    {
        if (new string[] { Name, Modelo, Precio.ToString() }.Any(string.IsNullOrWhiteSpace))
            Toaster.MakeToast("No puede guardar el registro con campos vacios");
        else
        {
            this.Save();
            GetAllArticles();
            ClearSelectedArticle();
        }
    }

    [RelayCommand]
    private void ClearSelectedArticle()
    {
        Id = Guid.NewGuid().ToString("n");
        Name = default;
        Modelo = default;
        Precio = 0;
    }

    [RelayCommand]
    private void SelectedArticle(object item)
    {
        var _element = item as Model;
        Id = _element.Id;
        Name = _element.Name;
        Modelo = _element.Modelo;
        Precio = _element.Precio;
    }

}

