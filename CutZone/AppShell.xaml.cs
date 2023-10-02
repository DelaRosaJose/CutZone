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
    protected override void OnAppearing()
    {
        base.OnAppearing();

        this.FlyoutIsPresented = true;
        this.FlyoutBackgroundColor = Color.FromArgb("#f3f3f3");

        var animation = new Animation(x => { this.FlyoutWidth = x; }, 0, 60);

        animation.Commit(this, "OpenFlyout", length: 250, finished: (d, b) => this.FlyoutBehavior = FlyoutBehavior.Locked);
    }

    private void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {
        Services.Toaster.MakeToast("Comming soon!");
    }
}
