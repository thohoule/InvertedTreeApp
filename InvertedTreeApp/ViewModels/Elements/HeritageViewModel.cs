using CommunityToolkit.Mvvm.ComponentModel;
using DataAccess;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace InvertedTreeApp.ViewModels
{
    public partial class HeritageViewModel : ObservableObject, IElementViewModel
    {
        private ProxySet<HeritageModel, HeritageProxy> elementSet;

        //public ProxySet<HeritageModel, HeritageProxy> ElementSet { get; private set; }
        IProxySet IElementViewModel.ElementSet => elementSet;

        public HeritageViewModel()
        {
            elementSet = DataManager.GetAllHeritages();
            //ProxyViewModel = new ProxySetViewModel(ElementSet);

            if (elementSet.Items.Count > 0)
                elementSet.SelectedItem = elementSet.Items[0];
        }
    }
}
