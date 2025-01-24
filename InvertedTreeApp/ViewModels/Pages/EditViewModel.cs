using System;
using CommunityToolkit.Mvvm.ComponentModel;
using DataAccess;
using InvertedTreeApp.Views;
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
                    return heritageControl;
                case "CharacteristicType":
                    var characteristicTypeControl = new CharacteristicTypeControl();
                    ProxyViewModel.SetProxySet(characteristicTypeControl.ViewModel.ElementSet);
                    return characteristicTypeControl;
                case "Characteristic":
                    var characteristicControl = new CharacteristicControl();
                    ProxyViewModel.SetProxySet(characteristicControl.ViewModel.ElementSet);
                    return characteristicControl;
                case "Property":
                    var propertyControl = new PropertyControl();
                    ProxyViewModel.SetProxySet(propertyControl.ViewModel.ElementSet);
                    return propertyControl;
                case "Feature":
                    var featureControl = new FeatureControl();
                    ProxyViewModel.SetProxySet(featureControl.ViewModel.ElementSet);
                    return featureControl;
                case "Trait":
                    var traitControl = new TraitControl();
                    ProxyViewModel.SetProxySet(traitControl.ViewModel.ElementSet);
                    return traitControl;
                case "Ability":
                    var abilityControl = new AbilityControl();
                    ProxyViewModel.SetProxySet(abilityControl.ViewModel.ElementSet);
                    return abilityControl;
                case "Material":
                    var materialControl = new MaterialControl();
                    ProxyViewModel.SetProxySet(materialControl.ViewModel.ElementSet);
                    return materialControl;
            }

            throw new NotSupportedException();
        }
    }
}
