using DataAccess.Models;
using System.Collections.ObjectModel;

namespace DataAccess
{
    public partial class FeatureProxy : ElementProxy
    {
        private FeatureModel model;
        protected override IElementModel element => model;

        protected override bool onModelSet(IElementModel model)
        {
            if (model is FeatureModel)
            {
                this.model = (FeatureModel)model;

                return true;
            }

            return false;
        }

        protected internal override void OnInsert()
        {
            DataManager.FeatureData.Insert(model);
        }

        protected override void onSave()
        {
            DataManager.FeatureData.Update(model);
        }

        protected override bool onDelete()
        {
            DataManager.FeatureData.Delete(model);
            return true;
        }
    }
}
