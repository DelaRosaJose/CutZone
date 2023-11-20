
using Microsoft.Maui;
using Microsoft.Maui.Controls.Shapes;
using System.ComponentModel;

namespace CutZone.Controls;

public enum KeyboardEnum
{
    Plain,
    Chat,
    Default,
    Email,
    Numeric,
    Telephone,
    Text,
    Url
}


public class FloatingEntry : ContentView
{
    private const int _placeholderFontSize = 18;
    private const int _titleFontSize = 15;
    private const int _topMargin = -24;

    //Grid padre que envuele todo el control.
    private readonly Grid GridBody = new();

    //Grid hijo aqui solo va el icono y el FloatingEntry.
    private readonly Grid GridControls = new()
    {
        ColumnDefinitions = new ColumnDefinitionCollection()
        {
            new ColumnDefinition(new GridLength(1, GridUnitType.Auto)),
            new ColumnDefinition(new GridLength(1, GridUnitType.Star))
        }
    };

    //Borde del floatingEntry control.
    private readonly Border borderEntry = new();

    //Grid que envuelve el label y el entry.
    private readonly Grid GridFloatingEntry = new();

    //Icon que lleva el Entry.
    private readonly Icon IconFloatingEntry = new();


    private readonly Entry Field = new Entry();
    readonly Label LabelTitle = new Label() { VerticalOptions = LayoutOptions.Center };
    TapGestureRecognizer tapGestureRecognizer = new TapGestureRecognizer();

    private Color LastStrokeBorder;


    public FloatingEntry()
    {
        #region AddEvents
        Field.Focused += Handle_Focused;
        Field.Unfocused += Handle_Unfocused;
        tapGestureRecognizer.Tapped += (s, e) => Field.Focus();
        LabelTitle.GestureRecognizers.Add(tapGestureRecognizer);
        #endregion

        #region Field SetBindings
        Field.SetBinding(Entry.TextProperty, new Binding(nameof(Text), BindingMode.TwoWay, source: this));
        Field.SetBinding(Entry.IsPasswordProperty, new Binding(nameof(IsPassword), BindingMode.TwoWay, source: this));
        //Field.SetBinding(Entry.KeyboardProperty, new Binding(nameof(KeyBoard), BindingMode.TwoWay, source: this));
        #endregion
        #region Label SetBindings
        LabelTitle.SetBinding(Label.TextProperty, new Binding(nameof(Title), BindingMode.TwoWay, source: this));
        #endregion
        #region Border SetBindings
        borderEntry.SetBinding(BackgroundColorProperty, new Binding(nameof(BackgroundColor_Border), BindingMode.TwoWay, source: this));
        borderEntry.SetBinding(Border.StrokeProperty, new Binding(nameof(Stroke_Border), BindingMode.TwoWay, source: this));
        borderEntry.SetBinding(Border.StrokeThicknessProperty, new Binding(nameof(StrokeThickness_Border), BindingMode.TwoWay, source: this));
        borderEntry.SetBinding(Border.PaddingProperty, new Binding(nameof(Padding_Border), BindingMode.TwoWay, source: this));
        #endregion

        #region SettingGridsColumns

        GridFloatingEntry.Children.Add(Field);
        GridFloatingEntry.Children.Add(LabelTitle);

        GridControls.Children.Add(IconFloatingEntry);
        GridControls.Children.Add(GridFloatingEntry);


        GridControls.SetColumn(IconFloatingEntry, 0);
        GridControls.SetColumn(GridFloatingEntry, 1);

        GridBody.Children.Add(borderEntry);
        GridBody.Children.Add(GridControls);

        #endregion

        Content = GridBody;
    }



    #region Entry Properties

    public string Text
    {
        get => (string)GetValue(TextProperty);
        set => SetValue(TextProperty, value);
    }
    public bool IsPassword
    {
        get => (bool)GetValue(IsPasswordProperty);
        set => SetValue(IsPasswordProperty, value);
    }
    public KeyboardEnum KeyBoard
    {
        get => (KeyboardEnum)GetValue(KeyBoardProperty);
        set => SetValue(KeyBoardProperty, value);
    }

    public static readonly BindableProperty TextProperty = BindableProperty.Create(nameof(Text), typeof(string), typeof(FloatingEntry), string.Empty, BindingMode.TwoWay, null, HandleBindingPropertyChangedDelegate);
    public static readonly BindableProperty IsPasswordProperty = BindableProperty.Create(nameof(IsPassword), typeof(bool), typeof(FloatingEntry), default, BindingMode.TwoWay, null);
    public static readonly BindableProperty KeyBoardProperty = BindableProperty.Create(nameof(KeyBoard), typeof(KeyboardEnum), typeof(FloatingEntry), KeyboardEnum.Text, BindingMode.OneWay, null, FieldKeyboardPropertyChangedDelegate);

    #endregion

    #region Label Properties

    public string Title
    {
        get => (string)GetValue(TitleProperty);
        set => SetValue(TitleProperty, value);
    }

    public static readonly BindableProperty TitleProperty = BindableProperty.Create(nameof(Title), typeof(string), typeof(FloatingEntry), "SetTheTitle", BindingMode.TwoWay, null);

    #endregion

    #region Border Properties

    public Color BackgroundColor_Border
    {
        get => (Color)GetValue(BackgroundColor_BorderProperty);
        set => SetValue(BackgroundColor_BorderProperty, value);
    }
    public Color Stroke_Border
    {
        get => (Color)GetValue(Stroke_BorderProperty);
        set => SetValue(Stroke_BorderProperty, value);
    }
    public double StrokeThickness_Border
    {
        get => (double)GetValue(StrokeThickness_BorderProperty);
        set => SetValue(StrokeThickness_BorderProperty, value);
    }
    public Thickness StrokeShape_Border
    {
        get => (Thickness)GetValue(StrokeShape_BorderProperty);
        set => SetValue(StrokeShape_BorderProperty, value);
    }
    public Thickness Padding_Border
    {
        get => (Thickness)GetValue(Padding_BorderProperty);
        set => SetValue(Padding_BorderProperty, value);
    }
    public bool FocusActive_Border
    {
        get => (bool)GetValue(FocusActive_BorderProperty);
        set => SetValue(FocusActive_BorderProperty, value);
    }

    public Color StrokeFocusActive_Border
    {
        get => (Color)GetValue(StrokeFocusActive_BorderProperty);
        set => SetValue(StrokeFocusActive_BorderProperty, value);
    }


    public static readonly BindableProperty BackgroundColor_BorderProperty = BindableProperty.Create(nameof(BackgroundColor_Border), typeof(Color), typeof(FloatingEntry), default, BindingMode.TwoWay);
    public static readonly BindableProperty Stroke_BorderProperty = BindableProperty.Create(nameof(Stroke_Border), typeof(Color), typeof(FloatingEntry), Color.Parse("LightGray"), BindingMode.TwoWay);
    public static readonly BindableProperty StrokeThickness_BorderProperty = BindableProperty.Create(nameof(StrokeThickness_Border), typeof(double), typeof(FloatingEntry), 1.0, BindingMode.TwoWay);
    public static readonly BindableProperty StrokeShape_BorderProperty = BindableProperty.Create(nameof(StrokeShape_Border), typeof(Thickness), typeof(FloatingEntry), default, BindingMode.TwoWay, null, StrokeShapePropertyChangedDelegate);
    public static readonly BindableProperty Padding_BorderProperty = BindableProperty.Create(nameof(Padding_Border), typeof(Thickness), typeof(FloatingEntry), default, BindingMode.TwoWay);
    public static readonly BindableProperty FocusActive_BorderProperty = BindableProperty.Create(nameof(FocusActive_Border), typeof(bool), typeof(FloatingEntry), default, BindingMode.TwoWay);
    public static readonly BindableProperty StrokeFocusActive_BorderProperty = BindableProperty.Create(nameof(StrokeFocusActive_Border), typeof(Color), typeof(FloatingEntry), Color.Parse("DimGray"), BindingMode.TwoWay);


    #endregion


    #region EventHandlers

    static void StrokeShapePropertyChangedDelegate(BindableObject bindable, object oldValue, object newValue) => (bindable as FloatingEntry).SetterBorderEntryStrokeShape((Thickness)newValue);

    void SetterBorderEntryStrokeShape(Thickness value)
    {
        double Topleft = value.Left, Topright = value.Right, Bottomleft = value.Bottom, BottonRight = value.Top;

        borderEntry.StrokeShape = new RoundRectangle
        {
            CornerRadius = new CornerRadius(Topleft, Topright, Bottomleft, BottonRight)
        };
    }

    async void Handle_Focused(object sender, FocusEventArgs e)
    {
        if (FocusActive_Border)
        {
            LastStrokeBorder = Stroke_Border;
            Stroke_Border = StrokeFocusActive_Border;
        }

        if (string.IsNullOrEmpty(Text))
            await TransitionToTitle();

    }

    async void Handle_Unfocused(object sender, FocusEventArgs e)
    {
        if (FocusActive_Border)
        {
            Stroke_Border = LastStrokeBorder;
            LastStrokeBorder = default;
        }

        if (string.IsNullOrEmpty(Text))
            await TransitionToPlaceholder(true);

    }


    static async void HandleBindingPropertyChangedDelegate(BindableObject bindable, object oldValue, object newValue)
    {
        var control = bindable as FloatingEntry;
        if (!control.Field.IsFocused)
        {
            if (!string.IsNullOrEmpty((string)newValue))
            {
                await control.TransitionToTitle();
            }
            else
            {
                await control.TransitionToPlaceholder(false);
            }
        }

    }


    static void FieldKeyboardPropertyChangedDelegate(BindableObject bindable, object oldValue, object newValue) => (bindable as FloatingEntry).SetterFieldKeyboard((KeyboardEnum)newValue);

    void SetterFieldKeyboard(KeyboardEnum value)
    {
        Field.Keyboard = value switch
        {
            KeyboardEnum.Plain => Keyboard.Plain,
            KeyboardEnum.Numeric => Keyboard.Numeric,
            KeyboardEnum.Text => Keyboard.Text,
            KeyboardEnum.Url => Keyboard.Url,
            KeyboardEnum.Telephone => Keyboard.Telephone,
            KeyboardEnum.Chat => Keyboard.Chat,
            KeyboardEnum.Default => Keyboard.Default,
            _ => Field.Keyboard // handle default or unexpected cases
        };
    }

    #endregion

    #region Methods

    async Task TransitionToTitle()
    {
        var t1 = LabelTitle.TranslateTo(10, _topMargin, 100);
        var t2 = SizeTo(_titleFontSize);
        await Task.WhenAll(t1, t2);
        Field.Focus();
    }
    async Task TransitionToPlaceholder(bool animated)
    {
        var t1 = LabelTitle.TranslateTo(10, 0, 100);
        var t2 = SizeTo(_placeholderFontSize);
        await Task.WhenAll(t1, t2);
    }
    Task SizeTo(int fontSize)
    {
        var taskCompletionSource = new TaskCompletionSource<bool>();
        var startingHeight = LabelTitle.FontSize;
        var endingHeight = fontSize;
        var rate = 5u;
        var length = 100u;

        LabelTitle.Animate("size", callback, startingHeight, endingHeight, rate, length, Microsoft.Maui.Easing.Linear, (v, c) => taskCompletionSource.SetResult(c));

        return taskCompletionSource.Task;

        void callback(double input)
        {
            LabelTitle.FontSize = input;
        }
    }
    #endregion


}