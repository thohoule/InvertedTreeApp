using System;
using CommunityToolkit.Mvvm.ComponentModel;
using DataAccess;
using InvertedTreeApp.Views;
using InvertedTreeApp.Views.Controls.Elements;
using Microsoft.UI.Xaml;

namespace InvertedTreeApp.ViewModels.Pages
{
    public partial class EditViewModel : ObservableObject
    {
        //private IElementViewModel elementViewModel;
        //private IProxySet elementSet;
        //private ProxySetViewModel proxyViewModel;
        //private ProxySetViewModel proxyViewModel;

        public ProxySetViewModel ProxyViewModel { get; private set; }
        //public ProxySetViewModel ProxyViewModel
        //{
        //    get => proxyViewModel;
        //    private set => SetProperty(proxyViewModel, value, this,
        //        (model, v) => model.proxyViewModel = v);
        //}

        //public IElementViewModel ElementViewModel
        //{
        //    get => elementViewModel;
        //    private set => SetProperty(elementViewModel, value, this,
        //        (model, v) => model.elementViewModel = v);
        //}

        //public IProxySet ElementSet
        //{
        //    get => elementSet;
        //    set => SetProperty(elementSet, value, this,
        //        (model, v) => model.elementSet = v);
        //}

        public EditViewModel()
        {
            ProxyViewModel = new ProxySetViewModel();
        }

        public UIElement ChangeType(int typeIndex)
        {
            return ChangeType(DataManager.ElementTypes[typeIndex]);
        }

        public UIElement ChangeType(string typeName)
        {
            switch (typeName)
            {
                case "Race":
                    var raceControl = new RaceControl();
                    ProxyViewModel.SetProxySet(raceControl.ViewModel.ElementSet);
                    //ElementViewModel = raceControl.ViewModel;
                    //ProxyViewModel.ElementSet = raceControl.ViewModel.ElementSet;
                    //ProxyViewModel = raceControl.ViewModel.ProxyViewModel;
                    return raceControl;
                case "Heritage":
                    var heritageControl = new HeritageControl();
                    ProxyViewModel.SetProxySet(heritageControl.ViewModel.ElementSet);
                    //ElementViewModel = heritageControl.ViewModel;
                    //ProxyViewModel = heritageControl.ViewModel.ProxyViewModel;
                    return heritageControl;
            }

            throw new NotSupportedException();
        }
    }
}
