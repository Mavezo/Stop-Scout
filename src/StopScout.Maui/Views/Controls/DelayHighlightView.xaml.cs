using StopScout.Domain.ValueObjects;

namespace StopScout.Maui.Views.Controls;

/// <summary>
/// Coloured delay label with a looping opacity pulse for major delays.
/// </summary>
public partial class DelayHighlightView : ContentView
{
    public static readonly BindableProperty StatusProperty = BindableProperty.Create(
        nameof(Status),
        typeof(DelayStatus),
        typeof(DelayHighlightView),
        propertyChanged: OnStatusChanged);

    private CancellationTokenSource? _pulseCts;

    public DelayHighlightView()
    {
        InitializeComponent();
        Loaded += OnLoaded;
        Unloaded += OnUnloaded;
    }

    public DelayStatus? Status
    {
        get => (DelayStatus?)GetValue(StatusProperty);
        set => SetValue(StatusProperty, value);
    }

    private static void OnStatusChanged(BindableObject bindable, object oldValue, object newValue)
    {
        ((DelayHighlightView)bindable).ApplyStatus();
    }

    private void OnLoaded(object? sender, EventArgs e) => ApplyStatus();

    private void OnUnloaded(object? sender, EventArgs e) => StopPulse();

    private void ApplyStatus()
    {
        var status = Status;
        if (status is null)
        {
            DelayLabel.Text = string.Empty;
            DelayLabel.FontAttributes = FontAttributes.None;
            StopPulse();
            return;
        }

        DelayLabel.Text = status.DisplayText;
        DelayLabel.FontAttributes = status.Category == DelayCategory.Major
            ? FontAttributes.Bold
            : FontAttributes.None;
        DelayLabel.TextColor = status.Category switch
        {
            DelayCategory.OnTime => GetThemeColor("DelayOnTime", "DelayOnTimeDark"),
            DelayCategory.Minor => GetThemeColor("DelayMinor", "DelayMinorDark"),
            DelayCategory.Major => GetThemeColor("DelayMajor", "DelayMajorDark"),
            _ => DelayLabel.TextColor
        };

        if (status.ShouldAnimate)
        {
            StartPulse();
        }
        else
        {
            StopPulse();
        }
    }

    private static Color GetThemeColor(string lightKey, string darkKey)
    {
        var key = Microsoft.Maui.Controls.Application.Current?.RequestedTheme == AppTheme.Dark ? darkKey : lightKey;
        if (Microsoft.Maui.Controls.Application.Current?.Resources.TryGetValue(key, out var value) == true && value is Color color)
        {
            return color;
        }

        return Colors.Gray;
    }

    private void StartPulse()
    {
        StopPulse();
        DelayLabel.Opacity = 1.0;
        _pulseCts = new CancellationTokenSource();
        _ = StartPulsingAsync(_pulseCts.Token);
    }

    private async Task StartPulsingAsync(CancellationToken token)
    {
        try
        {
            while (!token.IsCancellationRequested)
            {
                await DelayLabel.FadeToAsync(0.2, 700, Easing.SinInOut);
                token.ThrowIfCancellationRequested();
                await DelayLabel.FadeToAsync(1.0, 700, Easing.SinInOut);
            }
        }
        catch (TaskCanceledException)
        {
        }
        finally
        {
            if (!token.IsCancellationRequested)
            {
                DelayLabel.Opacity = 1.0;
            }
        }
    }

    private void StopPulse()
    {
        _pulseCts?.Cancel();
        _pulseCts?.Dispose();
        _pulseCts = null;
        DelayLabel.CancelAnimations();
        DelayLabel.Opacity = 1.0;
    }
}
