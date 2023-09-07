using CommunityToolkit.Maui.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CutZone.ViewModels;
using System.ComponentModel;

namespace CutZone.Popups;

public partial class LoadingPopug : Popup, INotifyPropertyChanged
{
    //Test test;
    public LoadingPopug()
    {
        InitializeComponent();

      
    }

    //public AsyncRelayCommand IsBusy
    //{
    //    get => (AsyncRelayCommand)GetValue(IsBusyProperty);
    //    set => SetValue(IsBusyProperty, value);
    //}

    //public static readonly BindableProperty IsBusyProperty =
    //    BindableProperty.Create(
    //        nameof(IsBusy),
    //        typeof(AsyncRelayCommand),
    //        typeof(LoadingPopug)
    //        //propertyChanged: OnIsBusyChanged
    //        );

    //private static void OnIsBusyChanged(BindableObject bindable, object oldValue, object newValue)
    //{
    //    //throw new NotImplementedException();
    //}

    //private AsyncRelayCommand isBusy;

    //public AsyncRelayCommand IsBusy
    //{
    //    get => isBusy;
    //    set
    //    {
    //        if (isBusy != value)
    //        {
    //            isBusy = value;
    //            OnPropertyChanged(nameof(IsBusy));
    //        }
    //    }
    //}

    //public event PropertyChangedEventHandler PropertyChanged;

    //protected virtual void OnPropertyChanged(string propertyName)
    //{
    //    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    //}

}