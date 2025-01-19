using DataAccess.Models;
using System;
using System.Collections.Generic;
using DataAccess;
using DataAccess.DBAccess;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;

namespace InvertedTreeApp.ViewModels
{
    public partial class RaceViewModel : ObservableObject, IElementViewModel
    {
        private ProxySet<RaceModel, RaceProxy> elementSet;

        //public ProxySet<RaceModel, RaceProxy> ElementSet { get; private set; }
        IProxySet IElementViewModel.ElementSet => elementSet;

        public RaceProxy SelectedItem { get; private set; }

        public RaceViewModel()
        {
            elementSet = DataManager.GetAllRaces();
            elementSet.SelectedChanged += ElementSet_SelectedChanged;
            //ProxyViewModel = new ProxySetViewModel(ElementSet);

            if (elementSet.Items.Count > 0)
                elementSet.SelectedItem = elementSet.Items[0];
        }

        private void ElementSet_SelectedChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            SelectedItem = elementSet.SelectedItem;
            OnPropertyChanged(nameof(SelectedItem));
        }
    }
}
