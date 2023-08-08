using CommunityToolkit.Maui.Views;
using CutZone.Models;
using static CutZone.Helpers.SQLiteConnector;

namespace CutZone;

public partial class MainPage : ContentPage
{
    int count = 0;
    User model;
    public MainPage()
    {
        InitializeComponent();
        BindingContext = model =  new User();
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

    private async void BtnLogin_Clicked(object sender, EventArgs e)
    {
        if (true)
        {
            var test = await db.Table<User>().CountAsync(x => x.Name == model.Name && x.Password == model.Password);
        }
    }
}

