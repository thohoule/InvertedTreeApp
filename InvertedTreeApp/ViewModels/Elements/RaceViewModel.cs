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
        private List<RaceModel> elements;
        private RaceModel selected;
        private ObservableCollection<HeritageModel> heritageOptionPool;

        public IReadOnlyList<IElementModel> Elements { get => elements; /*private set;*/ }
        public IElementModel SelectedElement 
        { 
            get => selected;
            set
            {
                SetProperty(selected, validateSetElement(value), this,
                (model, v) => model.selected = v);
                OnPropertyChanged(nameof(SelectedRace));
                OnPropertyChanged(nameof(HeritageOptionPool));
            }
        }
        public RaceModel SelectedRace { get => selected; }
        public ObservableCollection<HeritageModel> HeritageOptionPool { get => heritageOptionPool; }

        public RaceViewModel()
        {
            heritageOptionPool = new ObservableCollection<HeritageModel>();
            elements = new List<RaceModel>(DataManager.RaceData.GetAll());
            if (elements.Count > 0)
                SelectedElement = elements[0];
        }

        public void DeleteSelected()
        {

        }

        private RaceModel validateSetElement(IElementModel model)
        {
            if (model is RaceModel)
            {
                var race = model as RaceModel;

                heritageOptionPool.Clear();
                //heritageOptionPool.AddRange(
                //    DataManager.RaceData.GetExcludedHeritageOptions(race.Id));
                foreach (var item in DataManager.RaceData.GetExcludedHeritageOptions(race.Id))
                    heritageOptionPool.Add(item);

                return race;
            }

            throw new ArgumentException("Model was unexpected type.");
        }
    }
}
