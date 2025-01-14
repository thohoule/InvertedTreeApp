using DataAccess.Models;
using System;
using System.Collections.Generic;
using DataAccess;
using DataAccess.DBAccess;
using CommunityToolkit.Mvvm.ComponentModel;

namespace InvertedTreeApp.ViewModels
{
    public partial class RaceViewModel : ObservableObject, IElementViewModel
    {
        private List<RaceModel> elements;
        private RaceModel selected;

        public IReadOnlyList<IElementModel> Elements { get => elements; /*private set;*/ }
        public IElementModel SelectedElement 
        { 
            get => selected; 
            set => SetProperty(selected, validateElement(value), this,
                (model, v) => model.selected = v);
        }

        public RaceViewModel()
        {
            elements = new List<RaceModel>(DataManager.RaceData.GetAll());
            if (elements.Count > 0)
                SelectedElement = elements[0];
        }

        public void DeleteSelected()
        {

        }

        private RaceModel validateElement(IElementModel model)
        {
            if (model is RaceModel)
                return model as RaceModel;

            throw new ArgumentException("Model was unexpected type.");
        }
    }
}
