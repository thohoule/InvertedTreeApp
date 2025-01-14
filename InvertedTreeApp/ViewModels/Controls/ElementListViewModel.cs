using CommunityToolkit.Mvvm.ComponentModel;
using DataAccess.Models;
using System.Collections.Generic;

namespace InvertedTreeApp.ViewModels
{
    public partial class ElementListViewModel : ObservableObject
    {
        private IReadOnlyList<IElementModel> itemSource;
        private IElementModel selectedElement;

        public IReadOnlyList<IElementModel> ItemsSource
        {
            get => itemSource;
            set
            {
                SetProperty(itemSource, value, this,
                    (model, v) => model.itemSource = v);

                if (value.Count > 0)
                    SelectedItem = value[0];
            }
        }

        public IElementModel SelectedItem
        {
            get => selectedElement;
            set => SetProperty(selectedElement, value, this,
                (model, v) => model.selectedElement = v);
        }
    }
}
