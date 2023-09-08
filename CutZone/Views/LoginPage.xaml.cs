using CutZone.ViewModels;

namespace CutZone.Views;

public partial class LoginPage : ContentPage
{
	public LoginPage(LoginViewModel vm)
	{
		BindingContext = vm;
		InitializeComponent();

	}

}