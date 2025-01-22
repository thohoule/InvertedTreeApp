using CommunityToolkit.Mvvm.ComponentModel;
using DataAccess;
using System.Collections.Generic;
using System.ComponentModel;
using System.Collections.ObjectModel;

namespace InvertedTreeApp.ViewModels
{
    public interface IProxySetViewModel
    {
        IReadOnlyCollection<ElementProxy> Items { get; }
        ElementProxy SelectedItem { get; set; }
    }

    public partial class ProxySetViewModel : ObservableObject, IProxySetViewModel
    {
        private IProxySet elementSet;
        private bool isEdited;

        public bool IsEdited
        {
            get => isEdited;
            set => SetProperty(isEdited, value, this,
                (model, v) => model.isEdited = v);
        }
        public IProxySet ProxySet { get => elementSet; }

        public IReadOnlyCollection<ElementProxy> Items
        {
            get => elementSet?.Items;
        }

        public ElementProxy SelectedItem
        {
            get => elementSet.SelectedItem;
            set => elementSet.SelectedItem = value;
        }

        public void SetProxySet(IProxySet set)
        {
            if (elementSet != null)
            {
                elementSet.SelectedChanged -= ElementSet_SelectedChanged;
                elementSet.ItemsChanged -= ElementSet_ItemsChanged;
                elementSet.ItemEdited -= ElementSet_ItemEdited;
            }

            IsEdited = false;
            elementSet = set;
            elementSet.SelectedChanged += ElementSet_SelectedChanged;
            elementSet.ItemsChanged += ElementSet_ItemsChanged;
            elementSet.ItemEdited += ElementSet_ItemEdited;
            OnPropertyChanged(nameof(Items));
            OnPropertyChanged(nameof(SelectedItem));
        }

        private void ElementSet_SelectedChanged(object sender, PropertyChangedEventArgs e)
        {            
            OnPropertyChanged(nameof(SelectedItem));
        }

        private void ElementSet_ItemsChanged(object sender, CollectionChangeEventArgs e)
        {
            IsEdited = true;
            OnPropertyChanged(nameof(Items));
        }

        private void ElementSet_ItemEdited(object sender, object edited, string propertyChanged)
        {
            IsEdited = true;
        }

        public void SaveChanges()
        {
            ProxySet.SaveChanges();
            IsEdited = false;
        }
    }
}
