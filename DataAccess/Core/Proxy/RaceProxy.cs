using CommunityToolkit.Mvvm.ComponentModel;
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

        public static implicit operator RaceModel(RaceProxy proxy)
        {
            return proxy.model;
        }
    }
}
