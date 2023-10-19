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

    private async void Button_Clicked(object sender, EventArgs e)
    {


        IconState.IconKind = 
        LabelState.IsVisible= true;
        await LabelState.ScaleTo(1, 3000, Easing.CubicInOut);
        LabelState.Scale = 0.5;
        LabelState.IsVisible = false;




        //State.TranslateTo()
        //await State.TranslateTo(15,15,2000,Easing.Linear);

        //await to
        //await State.TranslateTo(-100, -100, 1000);
        //State.AnchorX = 150;

        //var animation = new Animation(x => { this.State.AnchorX = x; }, 0, 60);

        //animation.Commit(this, "OpenFlyout", length: 250);

    }
}