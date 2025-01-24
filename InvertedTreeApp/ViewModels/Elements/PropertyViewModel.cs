using CommunityToolkit.Mvvm.ComponentModel;
using DataAccess;
using DataAccess.Models;

namespace InvertedTreeApp.ViewModels
{
    public partial class PropertyViewModel : ObservableObject, IElementViewModel
    {
        private ProxySet<PropertyModel, PropertyProxy> elementSet;
        IProxySet IElementViewModel.ElementSet => elementSet;

        public PropertyViewModel()
        {
            elementSet = DataManager.GetAllProperties();
            //ProxyViewModel = new ProxySetViewModel(ElementSet);

            if (elementSet.Items.Count > 0)
                elementSet.SelectedItem = elementSet.Items[0];
        }
    }
}
