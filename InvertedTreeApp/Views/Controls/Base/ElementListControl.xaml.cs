using CommunityToolkit.Mvvm.ComponentModel;
using DataAccess;
using DataAccess.Models;
using InvertedTreeApp.ViewModels;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
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
    public sealed partial class ElementListControl : UserControl
    {
        public event SelectionChangedEventHandler SelectionChanged;

        public ProxySetViewModel ProxyViewModel 
        { 
            get; 
            set; 
        }

        //public IReadOnlyList<IElementProxy> ItemsSource
        //{
        //    get => ElementListBox.ItemsSource as IReadOnlyList<IElementProxy>;
        //    set => ElementListBox.ItemsSource = value;
        //}

        //public IElementProxy SelectedItem
        //{
        //    get => ElementListBox.SelectedItem as IElementProxy;
        //    set => ElementListBox.SelectedItem = value;
        //}

        public IProxySet ElementSet
        {
            get;
            set;
        }

        public ElementListControl()
        {
            this.InitializeComponent();
        }

        private void ElementListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SelectionChanged?.Invoke(this, e);
        }
    }
}
