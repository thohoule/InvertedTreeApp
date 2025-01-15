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
        //private List<HeritageModel> elements;
        private HeritageModel selected;

        public ObservableCollection<IElementModel> Elements { get; private set; }
        public IElementModel SelectedElement
        {
            get => selected;
            set
            {
                SetProperty(selected, validateSetElement(value), this,
                (model, v) => model.selected = v);
                OnPropertyChanged(nameof(SelectedRace));
            }
        }
        public HeritageModel SelectedRace { get => selected; }

        public HeritageViewModel()
        {
            //elements = new List<HeritageModel>(DataManager.HeritageData.GetAll());
            Elements = new ObservableCollection<IElementModel>(DataManager.HeritageData.GetAll());

            if (Elements.Count > 0)
                SelectedElement = Elements[0];
        }

        public void AddRecord()
        {
            HeritageModel heritage = new HeritageModel()
            {
                Name = "New Heritage"
            };

            DataManager.HeritageData.Insert(heritage);
            Elements.Add(heritage);
            SelectedElement = heritage;
        }

        public void DeleteSelected()
        {

        }

        private HeritageModel validateSetElement(IElementModel model)
        {
            if (model == null)
                return null;

            if (model is HeritageModel)
            {
                var heritage = model as HeritageModel;

                //option loading goes here

                return heritage;
            }

            throw new ArgumentException("Model was unexpected type.");
        }
    }
}
