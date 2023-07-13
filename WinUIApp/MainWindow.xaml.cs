using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using WinRT.Interop;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace WinUIApp;

/// <summary>
/// An empty window that can be used on its own or navigated to within a Frame.
/// </summary>
public sealed partial class MainWindow : Window
{
    internal static int windowWidth = 1280;
    internal static int windowHeight = 720;
    internal static string windowTitle = "WinUI App";

    internal static string appVersion = "v0.0.1";
    internal static string appResolution = string.Format("({0}x{1})", windowWidth, windowHeight);

    public MainWindow()
    {
        InitializeComponent();

        Title = windowTitle;

        var hWnd = WindowNative.GetWindowHandle(this);
        var windowId = Microsoft.UI.Win32Interop.GetWindowIdFromWindow(hWnd);
        var appWindow = Microsoft.UI.Windowing.AppWindow.GetFromWindowId(windowId);
        appWindow?.Resize(new Windows.Graphics.SizeInt32 { Width = windowWidth, Height = windowHeight });

        AppTitleTextBlock.Text = windowTitle;
        AppVersionTextBlock.Text = appVersion;
        ExtendsContentIntoTitleBar = true;
        SetTitleBar(AppTitleBar);
    }

    private void WindowSizeChanged(object sender, WindowSizeChangedEventArgs args)
    {
        var hWnd = WindowNative.GetWindowHandle(this);
        var windowId = Microsoft.UI.Win32Interop.GetWindowIdFromWindow(hWnd);
        var appWindow = Microsoft.UI.Windowing.AppWindow.GetFromWindowId(windowId);
        AppResolutionTextBlock.Text = string.Format("({0}x{1})", appWindow.Size.Width, appWindow.Size.Height);
    }
}
