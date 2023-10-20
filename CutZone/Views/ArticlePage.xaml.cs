using CutZone.ViewModels;

namespace CutZone.Views;

public partial class ArticlePage : ContentPage
{
    public ArticlePage(ArticleViewModel vm)
    {
        BindingContext = vm;
        InitializeComponent();
    }

    private void AddButton_Clicked(object sender, EventArgs e) => WindowsModeAnimation("\ue145", "Modo Agregar");

    private void ListArticles_ItemSelected(object sender, SelectedItemChangedEventArgs e) => WindowsModeAnimation("\ue3c9","Modo Editar");
  

    async void WindowsModeAnimation(string IconKind, string Modo) 
    {
        IconState.IconKind = IconKind;
        ToolTipProperties.SetText(IconState, Modo);
        LabelState.Text = Modo;
        LabelState.IsVisible = true;
        LabelState.TranslationX = 100;
        await LabelState.TranslateTo(0, 0, 3000);
        await Task.Delay(1000);
        LabelState.IsVisible = false;
    }

}