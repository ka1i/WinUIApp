using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Windows.System;
using WinUIApp.ViewModels;

namespace WinUIApp.Views;

public sealed partial class SettingsPage : Page
{
    public SettingsViewModel ViewModel
    {
        get;
    }

    public SettingsPage()
    {
        ViewModel = App.GetService<SettingsViewModel>();
        InitializeComponent();

        themeMode.SelectedIndex = ThtemeModeInit(ViewModel.ElementTheme);
    }

    private static int ThtemeModeInit(ElementTheme currentTheme)
    {
        var themeModeIdx = 0;
        switch (currentTheme)
        {
            case ElementTheme.Light:
                themeModeIdx = 0;
                break;
            case ElementTheme.Dark:
                themeModeIdx = 1;
                break;
            case ElementTheme.Default:
                themeModeIdx = 2;
                break;
        }
        return themeModeIdx;
    }

    private void ThemeMode_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        var selectedTheme = ((ComboBoxItem)themeMode.SelectedItem)?.Tag?.ToString();
        if (selectedTheme != null)
        {
            if (selectedTheme == "Dark")
            {
                ViewModel.ElementTheme = ElementTheme.Dark;
            }
            else if (selectedTheme == "Light")
            {
                ViewModel.ElementTheme = ElementTheme.Light;
            }
            else
            {
                ViewModel.ElementTheme = ElementTheme.Default;
            }
            ViewModel.ThemeSelectorService.SetThemeAsync(ViewModel.ElementTheme);
        }
    }

    private void SoundToggle_Toggled(object sender, RoutedEventArgs e)
    {
        if (soundToggle.IsOn == true)
        {
            SpatialAudioCard.IsEnabled = true;
            ElementSoundPlayer.State = ElementSoundPlayerState.On;
        }
        else
        {
            SpatialAudioCard.IsEnabled = false;
            spatialSoundBox.IsOn = false;

            ElementSoundPlayer.State = ElementSoundPlayerState.Off;
            ElementSoundPlayer.SpatialAudioMode = ElementSpatialAudioMode.Off;
        }
    }

    private void SpatialSoundBox_Toggled(object sender, RoutedEventArgs e)
    {
        if (soundToggle.IsOn == true)
        {
            ElementSoundPlayer.SpatialAudioMode = ElementSpatialAudioMode.Off;
        }
        else
        {
            ElementSoundPlayer.SpatialAudioMode = ElementSpatialAudioMode.On;
        }
    }

    private async void BugRequestCard_Click(object sender, RoutedEventArgs e)
    {
        await Launcher.LaunchUriAsync(new Uri("https://github.com/ka1i/WinUIApp/issues/new/choose"));
    }
}
