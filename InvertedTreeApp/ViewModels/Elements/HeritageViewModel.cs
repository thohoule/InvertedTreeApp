using CommunityToolkit.Mvvm.ComponentModel;
using DataAccess;
using DataAccess.Models;

namespace InvertedTreeApp.ViewModels
{
    public partial class HeritageViewModel : ObservableObject, IElementViewModel
    {
        private ProxySet<HeritageModel, HeritageProxy> elementSet;

        //public ProxySet<HeritageModel, HeritageProxy> ElementSet { get; private set; }
        IProxySet IElementViewModel.ElementSet => elementSet;

        public HeritageProxy SelectedItem { get => elementSet.SelectedItem; }

        public HeritageViewModel()
        {
            elementSet = DataManager.GetAllHeritages();
            elementSet.SelectedChanged += ElementSet_SelectedChanged;
            //ProxyViewModel = new ProxySetViewModel(ElementSet);

            if (elementSet.Items.Count > 0)
                elementSet.SelectedItem = elementSet.Items[0];
        }

        private void ElementSet_SelectedChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            OnPropertyChanged(nameof(SelectedItem));
        }
    }
}
