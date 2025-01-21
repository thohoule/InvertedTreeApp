using CommunityToolkit.Mvvm.ComponentModel;
using DataAccess;
using DataAccess.Models;

namespace InvertedTreeApp.ViewModels
{
    public partial class TraitViewModel : ObservableObject, IElementViewModel
    {
        private ProxySet<TraitModel, TraitProxy> elementSet;
        IProxySet IElementViewModel.ElementSet => elementSet;

        public TraitViewModel()
        {
            elementSet = DataManager.GetAllTraits();
            //ProxyViewModel = new ProxySetViewModel(ElementSet);

            if (elementSet.Items.Count > 0)
                elementSet.SelectedItem = elementSet.Items[0];
        }
    }
}
