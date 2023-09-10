using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Views.InputMethods;
using Android.Views;
using Android.Widget;

namespace CutZone;

[Activity(Theme = "@style/Maui.SplashTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize | ConfigChanges.Density)]
public class MainActivity : MauiAppCompatActivity
{
    //Actualizamos el funcionamiento de Android con los entry, al pulsar fuera del elemento con el Foco, se pierde el foco del mismo.
    public override bool DispatchTouchEvent(MotionEvent e)
    {
        if (e.Action == MotionEventActions.Down)
        {
            var view = CurrentFocus;
            if (view is EditText editText)
            {
                editText.ClearFocus();
                InputMethodManager imm = (InputMethodManager)GetSystemService(Context.InputMethodService);
                imm.HideSoftInputFromWindow(view.WindowToken, 0);
            }
        }

        return base.DispatchTouchEvent(e);
    }
}
