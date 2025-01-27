using CommunityToolkit.Mvvm.ComponentModel;
using DataAccess;
using DataAccess.Models;

namespace InvertedTreeApp.ViewModels
{
    public partial class CharacteristicTypeViewModel : ObservableObject, IElementViewModel
    {
        private ProxySet<CharacteristicTypeModel, CharacteristicTypeProxy> elementSet;
        IProxySet IElementViewModel.ElementSet => elementSet;

        public CharacteristicTypeProxy SelectedItem { get => elementSet.SelectedItem; }

        public CharacteristicTypeViewModel()
        {
            elementSet = DataManager.GetAllCharacteristicTypes();
            //ProxyViewModel = new ProxySetViewModel(ElementSet);

            if (elementSet.Items.Count > 0)
                elementSet.SelectedItem = elementSet.Items[0];
        }
    }
}
