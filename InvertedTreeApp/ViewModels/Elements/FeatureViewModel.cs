using CommunityToolkit.Mvvm.ComponentModel;
using DataAccess;
using DataAccess.Models;

namespace InvertedTreeApp.ViewModels
{
    public partial class FeatureViewModel : ObservableObject, IElementViewModel
    {
        private ProxySet<FeatureModel, FeatureProxy> elementSet;
        IProxySet IElementViewModel.ElementSet => elementSet;

        public FeatureViewModel()
        {
            elementSet = DataManager.GetAllFeatures();
            //ProxyViewModel = new ProxySetViewModel(ElementSet);

            if (elementSet.Items.Count > 0)
                elementSet.SelectedItem = elementSet.Items[0];
        }
    }
}
