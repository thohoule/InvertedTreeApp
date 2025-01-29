using DataAccess.Models;
using System.Collections.ObjectModel;

namespace DataAccess
{
    public partial class TraitProxy : ElementProxy
    {
        private TraitModel model;
        protected override IElementModel element => model;

        public ObservableCollection<RequirementModel> Requirements { get; private set; }

        protected override bool onModelSet(IElementModel model)
        {
            if (model is TraitModel)
            {
                this.model = (TraitModel)model;

                Requirements = new ObservableCollection<RequirementModel>(
                    DataManager.TraitData.GetRequirements(model.Id));

                return true;
            }

            return false;
        }

        protected internal override void OnInsert()
        {
            DataManager.TraitData.Insert(model);
        }

        protected override void onSave()
        {
            DataManager.TraitData.Update(model);
        }

        protected override bool onDelete()
        {
            DataManager.TraitData.Delete(model);
            return true;
        }
    }
}
