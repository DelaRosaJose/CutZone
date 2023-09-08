
using CommunityToolkit.Maui.Alerts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CutZone.Services;
public class Toaster
{
    public enum Duration
    {
        Short = CommunityToolkit.Maui.Core.ToastDuration.Short,
        Long = CommunityToolkit.Maui.Core.ToastDuration.Long
    }
    public static void MakeToast(string message, Duration duration = Duration.Short, int TextSize = 20)
    {
        Toast.Make(message, (CommunityToolkit.Maui.Core.ToastDuration)duration, TextSize).Show();
    }
}
