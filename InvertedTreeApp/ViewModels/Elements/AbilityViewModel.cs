using CommunityToolkit.Mvvm.ComponentModel;
using DataAccess;
using DataAccess.Models;

namespace InvertedTreeApp.ViewModels
{
    public partial class AbilityViewModel : ObservableObject, IElementViewModel
    {
        private ProxySet<AbilityModel, AbilityProxy> elementSet;
        IProxySet IElementViewModel.ElementSet => elementSet;

        public AbilityViewModel()
        {
            elementSet = DataManager.GetAllAbilities();
            //ProxyViewModel = new ProxySetViewModel(ElementSet);

            if (elementSet.Items.Count > 0)
                elementSet.SelectedItem = elementSet.Items[0];
        }
    }
}
