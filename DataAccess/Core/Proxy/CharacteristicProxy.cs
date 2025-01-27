using DataAccess.Models;
using System.Collections.ObjectModel;

namespace DataAccess
{
    public partial class CharacteristicProxy : ElementProxy
    {
        private CharacteristicModel model;
        protected override IElementModel element => model;

        public ObservableCollection<FeatureModel> FeatureOptions { get; private set; }
        public ObservableCollection<FeatureModel> FeatureOptionPool { get; private set; }

        protected override bool onModelSet(IElementModel model)
        {
            if (model is CharacteristicModel)
            {
                this.model = (CharacteristicModel)model;

                FeatureOptions = new ObservableCollection<FeatureModel>(
                    DataManager.CharacteristicData.GetFeatureOptions(model.Id));
                FeatureOptionPool = new ObservableCollection<FeatureModel>(
                    DataManager.CharacteristicData.GetExcludedFeatureOptions(model.Id));

                return true;
            }

            return false;
        }

        protected internal override void OnInsert()
        {
            DataManager.CharacteristicData.Insert(model);
        }

        protected override void onSave()
        {
            DataManager.CharacteristicData.Update(model);
        }

        protected override bool onDelete()
        {
            DataManager.CharacteristicData.Delete(model);
            return true;
        }
    }
}
