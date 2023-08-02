using CommunityToolkit.Maui.Views;

namespace CutZone;

public partial class MainPage : ContentPage
{
    int count = 0;

    public MainPage()
    {
        InitializeComponent();
    }


    private void OnCounterClicked(object sender, EventArgs e)
    {
        //count++;

        //if (count == 1)
        //    CounterBtn.Text = $"Clicked {count} time";
        //else
        //    CounterBtn.Text = $"Clicked {count} timesww";

        this.ShowPopup(new Popups.LoginPopup());

        //SemanticScreenReader.Announce(CounterBtn.Text);
    }

    private void BtnCerrar_Clicked(object sender, EventArgs e) { }

    private void BtnLogin_Clicked(object sender, EventArgs e)
    {

    }
}

