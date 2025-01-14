using InvertedTreeApp.Views.Pages.MainPages;
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
using Windows.UI.ApplicationSettings;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace InvertedTreeApp
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : Window
    {
        public MainWindow()
        {
            this.InitializeComponent();
        }

        private void NavView_ItemInvoked(NavigationView sender, NavigationViewItemInvokedEventArgs args)
        {
            //if ((string)args.InvokedItemContainer.Tag == "CharacterSheet")
            //    ContentFrame.Navigate(typeof(CharacterSteetPage), null, args.RecommendedNavigationTransitionInfo);
            //else if ((string)args.InvokedItemContainer.Tag == "BoosterScreen")
            //    ContentFrame.Navigate(typeof(BoosterScreenPage), null, args.RecommendedNavigationTransitionInfo);
            //else if ((string)args.InvokedItemContainer.Tag == "Settings")
            //    ContentFrame.Navigate(typeof(SettingsPage), null, args.RecommendedNavigationTransitionInfo);
            if ((string)args.InvokedItemContainer.Tag == "EditScreen")
                ContentFrame.Navigate(typeof(EditPage), null, args.RecommendedNavigationTransitionInfo);
        }
    }
}
