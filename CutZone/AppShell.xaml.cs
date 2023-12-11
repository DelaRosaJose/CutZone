using CutZone.Views;

namespace CutZone;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();

        Routing.RegisterRoute(nameof(HomePage), typeof(HomePage));
        Routing.RegisterRoute(nameof(ArticlePage), typeof(ArticlePage));
        Routing.RegisterRoute(nameof(SellsPage), typeof(SellsPage));
    }

    private void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {
        Services.Toaster.MakeToast("Comming soon!");
    }
}
