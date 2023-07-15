using System.Reflection;

using CommunityToolkit.Mvvm.ComponentModel;

using Microsoft.UI.Xaml;

using Windows.ApplicationModel;

using WinUIApp.Contracts.Services;
using WinUIApp.Helpers;

namespace WinUIApp.ViewModels;

public partial class SettingsViewModel : ObservableRecipient
{
    [ObservableProperty]
    private IThemeSelectorService _themeSelectorService;

    [ObservableProperty]
    private ElementTheme _elementTheme;

    [ObservableProperty]
    private string _version;

    [ObservableProperty]
    private string _appName;

    public SettingsViewModel(IThemeSelectorService themeSelectorService)
    {
        _version = GetVersion();
        _appName = GetAppName();

        _themeSelectorService = themeSelectorService;
        _elementTheme = _themeSelectorService.Theme;
    }

    private static string GetVersion()
    {
        Version version;

        if (RuntimeHelper.IsMSIX)
        {
            var packageVersion = Package.Current.Id.Version;

            version = new(packageVersion.Major, packageVersion.Minor, packageVersion.Build, packageVersion.Revision);
        }
        else
        {
            version = Assembly.GetExecutingAssembly().GetName().Version!;
        }

        return $"{version.Major}.{version.Minor}.{version.Build}.{version.Revision}";
    }

    private static string GetAppName()
    {
        return $"{"AppDisplayName".GetLocalized()}";
    }
}
