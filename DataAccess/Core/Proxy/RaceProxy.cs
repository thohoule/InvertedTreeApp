﻿using CommunityToolkit.Mvvm.ComponentModel;
using DataAccess.Models;
using System.Collections.ObjectModel;

namespace DataAccess
{
    public partial class RaceProxy : ElementProxy
    {
        private RaceModel model;
        protected override IElementModel element { get => model; }

        public ObservableCollection<HeritageModel> HeritageOptions { get; private set; }
        public ObservableCollection<HeritageModel> HeritageOptionPool { get; private set; }

        protected override bool onModelSet(IElementModel model)
        {
            if (model is RaceModel)
            {
                this.model = (RaceModel)model;

                HeritageOptions = new ObservableCollection<HeritageModel>(
                    DataManager.RaceData.GetHeritageOptions(Id));
                HeritageOptionPool = new ObservableCollection<HeritageModel>(
                    DataManager.RaceData.GetExcludedHeritageOptions(Id));

                return true;
            }

            return false;
        }

        protected internal override void OnInsert()
        {
            DataManager.RaceData.Insert(model);
        }

        protected override void onSave()
        {
            DataManager.RaceData.Update(model);

            //Update Heritage Options
            DataManager.RaceData.UpdateHeritageOptions(model, HeritageOptions);
        }

        protected override bool onDelete()
        {
            DataManager.RaceData.Delete(model);
            return true;
        }

        public static implicit operator RaceModel(RaceProxy proxy)
        {
            return proxy.model;
        }
    }
}
