using DataAccess.Models;
using System.Collections.ObjectModel;

namespace DataAccess
{
    public partial class MaterialProxy : ElementProxy
    {
        private MaterialModel model;
        protected override IElementModel element => model;

        protected override bool onModelSet(IElementModel model)
        {
            if (model is MaterialModel)
            {
                this.model = (MaterialModel)model;

                return true;
            }

            return false;
        }

        protected internal override void OnInsert()
        {
            DataManager.MaterialData.Insert(model);
        }

        protected override void onSave()
        {
            DataManager.MaterialData.Update(model);
        }

        protected override bool onDelete()
        {
            DataManager.MaterialData.Delete(model);
            return true;
        }
    }
}
