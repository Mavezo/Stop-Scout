using StopScout.Maui.Models;

namespace StopScout.Maui.Views.Controls;

public partial class DepartureCard : ContentView
{
    public static readonly BindableProperty ItemProperty = BindableProperty.Create(
        nameof(Item),
        typeof(DepartureListItem),
        typeof(DepartureCard));

    public DepartureCard()
    {
        InitializeComponent();
    }

    public DepartureListItem? Item
    {
        get => (DepartureListItem?)GetValue(ItemProperty);
        set => SetValue(ItemProperty, value);
    }
}
