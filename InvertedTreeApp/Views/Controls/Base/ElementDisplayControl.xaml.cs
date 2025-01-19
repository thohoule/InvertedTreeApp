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
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace InvertedTreeApp.Views
{
    public sealed partial class ElementDisplayControl : UserControl
    {
        private ElementDisplayViewModel viewModel;

        public ProxySetViewModel ProxyViewModel { get; set; }

        public IProxySet ElementSet
        {
            get;
            set;
        }

        //public IElementProxy SelectedItem
        //{
        //    get => viewModel.SelectedItem;
        //    set => viewModel.SelectedItem = value;
        //}

        public UIElement ElementControl
        {
            get => ElementCanvas.Child;
            set => ElementCanvas.Child = value;
        }

        public ElementDisplayControl()
        {
            viewModel = new ElementDisplayViewModel();

            this.InitializeComponent();
        }

        private partial class ElementDisplayViewModel : ObservableObject
        {
            private IElementProxy selectedItem;

            public IElementProxy SelectedItem
            {
                get => selectedItem;
                set => SetProperty(selectedItem, value, this,
                    (model, v) => model.selectedItem = v);
            }
        }
    }
}
