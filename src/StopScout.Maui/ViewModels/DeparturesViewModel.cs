using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using StopScout.Application;
using StopScout.Application.Abstractions;
using StopScout.Application.UseCases;
using StopScout.Infrastructure.Feeds;
using StopScout.Infrastructure.Stops;
using StopScout.Maui.Models;

namespace StopScout.Maui.ViewModels;

public partial class DeparturesViewModel : ObservableObject
{
    public const int DefaultStopId = MockStopCatalog.GdanskGlownyStopId;

    private readonly GetLiveDeparturesUseCase _getLiveDepartures;
    private readonly GetStopUseCase _getStop;
    private readonly IClock _clock;

    public DeparturesViewModel(
        GetLiveDeparturesUseCase getLiveDepartures,
        GetStopUseCase getStop,
        IClock clock)
    {
        _getLiveDepartures = getLiveDepartures;
        _getStop = getStop;
        _clock = clock;
        StopId = DefaultStopId;
    }

    public ObservableCollection<DepartureListItem> Departures { get; } = [];

    [ObservableProperty]
    private bool isLoading;

    [ObservableProperty]
    private bool isRefreshing;

    [ObservableProperty]
    private bool hasError;

    [ObservableProperty]
    private string errorMessage = string.Empty;

    [ObservableProperty]
    private bool isEmpty;

    [ObservableProperty]
    private bool showList;

    [ObservableProperty]
    private string stopName = "Przystanek";

    [ObservableProperty]
    private string stopPole = string.Empty;

    [ObservableProperty]
    private int stopId;

    [ObservableProperty]
    private string lastUpdatedText = string.Empty;

    [RelayCommand]
    public Task LoadAsync() => LoadInternalAsync(DefaultStopId, showRefresh: false);

    [RelayCommand]
    public Task RefreshAsync() => LoadInternalAsync(DefaultStopId, showRefresh: true);

    [RelayCommand]
    public Task SimulateErrorAsync() => LoadInternalAsync(MockDepartureFeed.ErrorStopId, showRefresh: false);

    private async Task LoadInternalAsync(int stopId, bool showRefresh)
    {
        if (IsLoading)
        {
            return;
        }

        IsLoading = !showRefresh;
        IsRefreshing = showRefresh;
        HasError = false;
        ErrorMessage = string.Empty;
        ShowList = false;

        try
        {
            var stop = await _getStop.ExecuteAsync(DefaultStopId);
            if (stop is not null)
            {
                StopId = stop.Id;
                StopName = stop.Name;
                StopPole = string.IsNullOrWhiteSpace(stop.PoleCode) ? string.Empty : $"Słupek {stop.PoleCode}";
            }

            var now = _clock.UtcNow;
            var rows = await _getLiveDepartures.ExecuteAsync(stopId);

            Departures.Clear();
            foreach (var departure in rows)
            {
                Departures.Add(DepartureListItem.From(departure, now));
            }

            IsEmpty = Departures.Count == 0;
            ShowList = true;
            LastUpdatedText = $"Aktualizacja: {now.ToLocalTime():HH:mm:ss}";
        }
        catch (DepartureFeedException ex)
        {
            Departures.Clear();
            IsEmpty = false;
            ShowList = false;
            HasError = true;
            ErrorMessage = ex.Message;
        }
        catch (Exception)
        {
            Departures.Clear();
            IsEmpty = false;
            ShowList = false;
            HasError = true;
            ErrorMessage = "Nie udało się pobrać odjazdów.";
        }
        finally
        {
            IsLoading = false;
            IsRefreshing = false;
        }
    }
}
