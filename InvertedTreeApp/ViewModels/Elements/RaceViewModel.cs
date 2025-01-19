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
        //private RaceModel selected;
        //private ObservableCollection<HeritageModel> heritageOptionPool;

        //public ProxySetViewModel ProxyViewModel { get; private set; }
        public ProxySet<RaceModel, RaceProxy> ElementSet { get; private set; }
        IProxySet IElementViewModel.ElementSet => ElementSet;

        //public ObservableCollection<IElementModel> Elements { get; private set; } // { get => elements; /*private set;*/ }
        //public IElementModel SelectedElement
        //{
        //    get => selected;
        //    set
        //    {
        //        SetProperty(selected, validateSetElement(value), this,
        //        (model, v) => model.selected = v);
        //        OnPropertyChanged(nameof(SelectedRace));
        //    }
        //}
        //public RaceModel SelectedRace { get => selected; }
        //public ObservableCollection<HeritageModel> HeritageOptionPool { get => heritageOptionPool; }

        public RaceViewModel()
        {
            ElementSet = DataManager.GetAllRaces();
            //ProxyViewModel = new ProxySetViewModel(ElementSet);

            if (ElementSet.Items.Count > 0)
                ElementSet.SelectedItem = ElementSet.Items[0];

            //heritageOptionPool = new ObservableCollection<HeritageModel>();
            //Elements = new ObservableCollection<IElementModel>(
            //    DataManager.RaceData.GetAll());

            //if (Elements.Count > 0)
            //    SelectedElement = Elements[0];
        }

        //public void AddRecord()
        //{
        //    RaceModel race = new RaceModel()
        //    {
        //        Name = "New Race"
        //    };

        //    DataManager.RaceData.Insert(race);
        //    Elements.Add(race);
        //    SelectedElement = race;
        //}

        //public void DeleteSelected()
        //{

        //}

        //private RaceModel validateSetElement(IElementModel model)
        //{
        //    if (model == null)
        //        return null;

        //    if (model is RaceModel)
        //    {
        //        var race = model as RaceModel;

        //        heritageOptionPool.Clear();
        //        foreach (var item in DataManager.RaceData.
        //            GetExcludedHeritageOptions(race.Id))
        //            heritageOptionPool.Add(item);

        //        return race;
        //    }

        //    throw new ArgumentException("Model was unexpected type.");
        //}
    }
}
