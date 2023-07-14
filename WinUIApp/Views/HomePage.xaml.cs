using Microsoft.UI.Xaml.Controls;

using WinUIApp.ViewModels;

namespace WinUIApp.Views;

public sealed partial class HomePage : Page
{
    public HomeViewModel ViewModel
    {
        get;
    }

    public HomePage()
    {
        ViewModel = App.GetService<HomeViewModel>();
        InitializeComponent();
    }
}
