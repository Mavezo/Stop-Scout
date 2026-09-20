using StopScout.Domain.ValueObjects;

namespace StopScout.Maui.Views.Controls;

public partial class DelayHighlight : ContentView
{
    public const string PulseAnimationName = "DelayPulse";

    public static readonly BindableProperty StatusProperty = BindableProperty.Create(
        nameof(Status),
        typeof(DelayStatus),
        typeof(DelayHighlight),
        propertyChanged: OnStatusChanged);

    public DelayHighlight()
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

    protected override void OnHandlerChanged()
    {
        base.OnHandlerChanged();
        if (Handler is null)
        {
            StopPulse();
        }
        else
        {
            ApplyStatus();
        }
    }

    private static void OnStatusChanged(BindableObject bindable, object oldValue, object newValue)
    {
        ((DelayHighlight)bindable).ApplyStatus();
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

    private Color GetThemeColor(string lightKey, string darkKey)
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
        Opacity = 1;

        var animation = new Animation();
        animation.Add(0, 0.5, new Animation(v => Opacity = v, 1.0, 0.35, Easing.SinInOut));
        animation.Add(0.5, 1, new Animation(v => Opacity = v, 0.35, 1.0, Easing.SinInOut));
        animation.Commit(
            this,
            PulseAnimationName,
            16,
            700,
            Easing.Linear,
            finished: (_, _) => Opacity = 1,
            repeat: () => Status?.ShouldAnimate == true);
    }

    private void StopPulse()
    {
        this.AbortAnimation(PulseAnimationName);
        Opacity = 1;
    }
}
