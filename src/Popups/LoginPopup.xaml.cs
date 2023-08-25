using CommunityToolkit.Maui.Views;

namespace CutZone.Popups;

public partial class LoginPopup : Popup
{
    public LoginPopup()
    {
        InitializeComponent();
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        Close();
    }
}