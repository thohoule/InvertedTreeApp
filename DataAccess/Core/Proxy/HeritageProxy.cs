using DataAccess.Models;
using System.Collections.ObjectModel;

namespace DataAccess
{
    public partial class HeritageProxy : ElementProxy
    {
        private HeritageModel model;
        protected override IElementModel element => model;

        public ObservableCollection<CharacteristicTypeModel> CharacteristicTypeOptions { get; private set; }
        public ObservableCollection<CharacteristicTypeModel> CharacteristicTypeOptionPool { get; private set;  }

        public ObservableCollection<PropertyModel> PropertyOptions { get; private set; }
        public ObservableCollection<PropertyModel> PropertyOptionPool { get; private set; }

        public ObservableCollection<FeatureModel> FeatureOptions { get; private set; }
        public ObservableCollection<FeatureModel> FeatureOptionPool { get; private set; }

        protected override bool onModelSet(IElementModel model)
        {
            if (model is HeritageModel)
            {
                this.model = (HeritageModel)model;

                CharacteristicTypeOptions = 
                    new ObservableCollection<CharacteristicTypeModel>(
                    DataManager.HeritageData.GetCharacteristicTypeOptions(model.Id));
                CharacteristicTypeOptionPool =
                    new ObservableCollection<CharacteristicTypeModel>(
                        DataManager.HeritageData.GetExcludedCharacteristicTypeOptions(
                            model.Id));

                PropertyOptions = new ObservableCollection<PropertyModel>(
                    DataManager.HeritageData.GetPropertyOptions(model.Id));
                PropertyOptionPool = new ObservableCollection<PropertyModel>(
                    DataManager.HeritageData.GetExcludedPropertyOptions(model.Id));

                FeatureOptions = new ObservableCollection<FeatureModel>(
                    DataManager.HeritageData.GetFeatureOptions(model.Id));
                FeatureOptionPool = new ObservableCollection<FeatureModel>(
                    DataManager.HeritageData.GetExcludedFeatureOptions(model.Id));

                return true;
            }

            return false;
        }

        protected internal override void OnInsert()
        {
            DataManager.HeritageData.Insert(model);
        }

        protected override void onSave()
        {
            DataManager.HeritageData.Update(model);

            DataManager.HeritageData.UpdateCharacteristicTypeOptions(model,
                CharacteristicTypeOptions);
            DataManager.HeritageData.UpdateFeatureOptions(model,
                FeatureOptions);
            DataManager.HeritageData.UpdatePropertyOptions(model,
                PropertyOptions);
        }

        protected override bool onDelete()
        {
            DataManager.HeritageData.Delete(model);
            return true;
        }
    }
}
