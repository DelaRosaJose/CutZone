using CutZone.Controls;

namespace CutZone.Handlers;

public static class MauiHandlerCollectionExtensions
{
    public static IMauiHandlersCollection AddPlainer(this IMauiHandlersCollection handlers)
    {
        handlers
            .AddHandler(typeof(EntryView), typeof(EntryViewHandler))
            .AddHandler(typeof(EditorView), typeof(EditorViewHandler))
            .AddHandler(typeof(PickerView), typeof(PickerViewHandler))
            .AddHandler(typeof(DatePickerView), typeof(DatePickerViewHandler))
            .AddHandler(typeof(TimePickerView), typeof(TimePickerViewHandler));

        return handlers;
    }
}