using CommunityToolkit.Mvvm.ComponentModel;
using DataAccess;
using DataAccess.Models;

namespace InvertedTreeApp.ViewModels
{
    public partial class MaterialViewModel : ObservableObject, IElementViewModel
    {
        private ProxySet<MaterialModel, MaterialProxy> elementSet;
        IProxySet IElementViewModel.ElementSet => elementSet;

        public MaterialViewModel()
        {
            elementSet = DataManager.GetAllMaterials();
            //ProxyViewModel = new ProxySetViewModel(ElementSet);

            if (elementSet.Items.Count > 0)
                elementSet.SelectedItem = elementSet.Items[0];
        }
    }
}
