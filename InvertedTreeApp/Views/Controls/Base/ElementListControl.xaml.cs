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
        //private IReadOnlyList<IElementModel> itemSource;
        public event SelectionChangedEventHandler SelectionChanged;

        public IReadOnlyList<IElementModel> ItemsSource
        {
            get;
            set;
        }

        public IElementModel SelectedItem
        {
            get;
            set;
        }

        //public ElementListViewModel ViewModel { get; private set; }

        public ElementListControl()
        {
            //ViewModel = new ElementListViewModel();

            this.InitializeComponent();
        }

        private void ElementListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SelectionChanged?.Invoke(this, e);
        }

        //private void setItemSource(IReadOnlyList<IElementModel> list)
        //{
        //    itemSource = list;

        //    if (itemSource.Count > 0)
        //        SelectedItem = itemSource[0];
        //}
    }
}
