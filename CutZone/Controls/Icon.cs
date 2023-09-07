using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CutZone.Controls;

public class Icon : ContentView
{
    Label _icon = new()
    {
        FontFamily = "GoogleFont",
        Text = "\ue7fd",
        FontSize = 25,
        VerticalOptions = LayoutOptions.Center,
        TextColor = Color.Parse("DimGray")
    };

    public Icon()
    {
        Content = _icon;
    }


    #region Properties

    public string IconKind
    {
        get { return (string)GetValue(IconKindProperty); }
        set { SetValue(IconKindProperty, value); }
    }

    public double IconSize
    {
        get { return (double)GetValue(IconSizeProperty); }
        set { SetValue(IconSizeProperty, value); }
    }
    
    public Color IconColor
    {
        get { return (Color)GetValue(IconColorProperty); }
        set { SetValue(IconColorProperty, value); }
    }

    #endregion

    #region Bindable Properties

    public static readonly BindableProperty IconKindProperty =
        BindableProperty.Create(
            propertyName: nameof(IconKind),
            returnType: typeof(string),
            declaringType: typeof(Icon),
            defaultValue: "\ue7fd",
            propertyChanged: IconKindEventChanged);

    public static readonly BindableProperty IconSizeProperty =
        BindableProperty.Create(
            propertyName: nameof(IconSize),
            returnType: typeof(double),
            declaringType: typeof(Icon),
            defaultValue: 25.0,
            propertyChanged: IconSizeEventChanged);
    
    public static readonly BindableProperty IconColorProperty =
        BindableProperty.Create(
            propertyName: nameof(IconColor),
            returnType: typeof(Color),
            declaringType: typeof(Icon),
            defaultValue: Color.Parse("Black"),
            propertyChanged: IconColorEventChanged);


    #endregion

    #region Events Changed

    private static void IconKindEventChanged(BindableObject bindable, object oldValue, object newValue)
    {
        if (bindable is Icon icon && newValue is string IconKind)
            icon.UpdateIconKind(IconKind);
    }

    private static void IconSizeEventChanged(BindableObject bindable, object oldValue, object newValue)
    {
        if (bindable is Icon icon && newValue is double IconSize)
            icon.UpdateIconSize(IconSize);
    }
    private static void IconColorEventChanged(BindableObject bindable, object oldValue, object newValue)
    {
        if (bindable is Icon icon && newValue is Color IconColor)
            icon.UpdateIconColor(IconColor);
    }


    private void UpdateIconKind(string iconKind) => _icon.Text = iconKind;
    private void UpdateIconSize(double iconSize) => _icon.FontSize = iconSize;
    private void UpdateIconColor(Color iconColor) => _icon.TextColor = iconColor;

    #endregion

}

