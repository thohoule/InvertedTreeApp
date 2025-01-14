using CommunityToolkit.Mvvm.ComponentModel;
using DataAccess.Models;
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

        public IElementModel Selected 
        { 
            get => viewModel.Selected; 
            set => viewModel.Selected = value; 
        }

        public UIElement ElementControl
        {
            get => viewModel.ElementControl;
            set => viewModel.ElementControl = value;
        }

        public ElementDisplayControl()
        {
            viewModel = new ElementDisplayViewModel();

            this.InitializeComponent();
        }
    }

    public class ElementDisplayViewModel : ObservableObject
    {
        private IElementModel selected;
        private UIElement elementControl;

        public IElementModel Selected
        {
            get => selected;
            set => SetProperty(selected, value, this,
                (model, v) => model.selected = v);
        }

        public UIElement ElementControl
        {
            get => elementControl;
            set => SetProperty(elementControl, value, this,
                (model, v) => model.elementControl = v);
        }
    }
}
