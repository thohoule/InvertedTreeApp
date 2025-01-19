using CommunityToolkit.Mvvm.ComponentModel;
using DataAccess;
using System.Collections.Generic;
using System.ComponentModel;

namespace InvertedTreeApp.ViewModels
{
    public interface IProxySetViewModel
    {
        IReadOnlyList<IElementProxy> Items { get; }
        IElementProxy SelectedItem { get; set; }
    }

    public partial class ProxySetViewModel : ObservableObject, IProxySetViewModel
    {
        private IProxySet elementSet;

        public bool IsEdited { get; private set; }
        public IProxySet ProxySet { get => elementSet; }

        public IReadOnlyList<IElementProxy> Items
        {
            get => elementSet.Items;
        }

        public IElementProxy SelectedItem
        {
            get => elementSet.SelectedItem;
            set => elementSet.SelectedItem = value;
        }

        //public ProxySetViewModel(IProxySet proxySet)
        //{
        //    elementSet = proxySet;
        //    elementSet.SelectedChanged += ElementSet_SelectedChanged;
        //    elementSet.ItemsChanged += ElementSet_ItemsChanged;
        //    elementSet.ItemEdited += ElementSet_ItemEdited;
        //}

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

        //public IProxySet ElementSet
        //{
        //    get => elementSet;
        //    set => SetProperty(elementSet, value, this,
        //        (model, v) => model.elementSet = v);
        //}

        //public IReadOnlyList<IElementProxy> Items
        //{
        //    get => elementSet.Items;
        //}

        //public IElementProxy SelectedItem
        //{
        //    get => elementSet.SelectedItem;
        //    set => SetProperty(elementSet.SelectedItem, value, this,
        //        (model, v) => model.elementSet.SelectedItem = v);
        //}
    }
}
