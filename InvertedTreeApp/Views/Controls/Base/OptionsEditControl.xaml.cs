using DataAccess;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace InvertedTreeApp.Views
{
    public sealed partial class OptionsEditControl : UserControl
    {
        public string Text { get; set; }
        public object OptionItemsSource
        {
            get => OptionsListBox.ItemsSource;
            set
            {
                OptionsListBox.ItemsSource = value;
            }
        }
        public object PoolItemsSource
        {
            get => PoolListBox.ItemsSource;
            set
            {
                PoolListBox.ItemsSource = value;
            }
        }

        public OptionsEditControl()
        {
            this.InitializeComponent();
        }

        private void AddOptionButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void RemoveOptionButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
