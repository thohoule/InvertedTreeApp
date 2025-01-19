using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using InvertedTreeApp.ViewModels;
using DataAccess.Models;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace InvertedTreeApp.Views
{
    public sealed partial class RaceControl : UserControl, IElementControl
    {
        private RaceViewModel raceViewModel;

        public IElementViewModel ViewModel { get => raceViewModel; }

        public RaceControl()
        {
            raceViewModel = new RaceViewModel();

            this.InitializeComponent();
        }

        #region Add Click Handling
        private void AddHeritageButton_Click(object sender, RoutedEventArgs e)
        {
            foreach (HeritageModel model in HeritagePoolListBox.SelectedItems)
                addItemToOptions(model);
        }

        private void addItemToOptions(HeritageModel heritage)
        {
            if (raceViewModel.ElementSet.SelectedItem.HeritageOptionPool.Remove(heritage))
                raceViewModel.ElementSet.SelectedItem.HeritageOptions.Add(heritage);
            //if (raceViewModel.HeritageOptionPool.Remove(heritage))
            //    raceViewModel.SelectedRace.HeritageOptions.Add(heritage);
        }
        #endregion

        #region Remove Click Handling
        private void RemoveHeritageButton_Click(object sender, RoutedEventArgs e)
        {
            foreach (HeritageModel model in HeritageOtionsListBox.SelectedItems)
                removeItemToOptions(model);
        }

        private void removeItemToOptions(HeritageModel heritage)
        {
            if (raceViewModel.ElementSet.SelectedItem.HeritageOptions.Remove(heritage))
                raceViewModel.ElementSet.SelectedItem.HeritageOptionPool.Add(heritage);
            //if (raceViewModel.SelectedRace.HeritageOptions.Remove(heritage))
            //    raceViewModel.HeritageOptionPool.Add(heritage);
        }
        #endregion
    }
}
