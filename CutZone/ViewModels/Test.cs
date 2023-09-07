using CommunityToolkit.Maui.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CutZone.Popups;

namespace CutZone.ViewModels
{
    public partial class Test : ObservableObject
    {
        private AsyncRelayCommand sCommand;

        [RelayCommand]
        async Task Login()
        {
            //Shell.Current.ShowPopup(new LoadingPopug() { IsBusy = loginCommand});
            //await Task.Delay(5000);
            ////await Shell.Current.DisplayAlert("Test", "Hello", "Aceptar");

            Shell.Current.IsBusy = true;//change the property
            //var esto = this;

            //Shell.Current.ShowPopup(new LoadingPopug(this));
            //var loadingPopUp = new LoadingPopug();
            //loadingPopUp.SetBinding(LoadingPopug.IsBusyProperty, new Binding(nameof(LoginCommand)));
            //Shell.Current.ShowPopup(loadingPopUp);

            await Task.Delay(5000);

            Shell.Current.IsBusy = false;
            Shell.Current.FlyoutIsPresented = false;
            // After the task completes, you can update IsBusy as needed.
            //loadingPopUp.IsBusy = null; // You may want to set it to null or another value.

        }

    }
}
