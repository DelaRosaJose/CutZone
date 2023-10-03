using CutZone.ViewModels;

namespace CutZone.Views;

public partial class ArticlePage : ContentPage
{
    public ArticlePage(ArticleViewModel vm)
    {
        BindingContext = vm;
        InitializeComponent();
        //ListArticles.ItemsSource = vm.Viewmodel;

    }

}