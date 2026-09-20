using Microsoft.Extensions.DependencyInjection;
using StopScout.Maui.ViewModels;

namespace StopScout.Maui.Views;

public partial class DeparturesPage : ContentPage
{
    public DeparturesPage()
    {
        InitializeComponent();
    }

    protected override void OnHandlerChanged()
    {
        base.OnHandlerChanged();
        if (BindingContext is null && Handler?.MauiContext?.Services is { } services)
        {
            BindingContext = services.GetRequiredService<DeparturesViewModel>();
        }

        _ = LoadIfNeededAsync();
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await LoadIfNeededAsync();
    }

    private async Task LoadIfNeededAsync()
    {
        if (BindingContext is DeparturesViewModel vm && vm.Departures.Count == 0 && !vm.HasError && !vm.IsLoading)
        {
            await vm.LoadCommand.ExecuteAsync(null);
        }
    }
}
