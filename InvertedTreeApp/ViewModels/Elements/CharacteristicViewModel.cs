using DataAccess.Models;
using System;
using System.Collections.Generic;
using DataAccess;
using DataAccess.DBAccess;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;

namespace InvertedTreeApp.ViewModels
{
    public partial class CharacteristicViewModel : ObservableObject, IElementViewModel
    {
        private ProxySet<CharacteristicModel, CharacteristicProxy> elementSet;
        IProxySet IElementViewModel.ElementSet => elementSet;

        public CharacteristicProxy SelectedItem { get; private set; }

        public CharacteristicViewModel()
        {
            elementSet = DataManager.GetAllCharacteristics();

            if (elementSet.Items.Count > 0)
                elementSet.SelectedItem = elementSet.Items[0];
        }
    }
}