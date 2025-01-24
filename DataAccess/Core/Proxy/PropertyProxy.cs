using DataAccess.Models;
using System.Collections.ObjectModel;

namespace DataAccess
{
    public partial class PropertyProxy : ElementProxy
    {
        private PropertyModel model;
        protected override IElementModel element => model;

        protected override bool onModelSet(IElementModel model)
        {
            if (model is PropertyModel)
            {
                this.model = (PropertyModel)model;

                return true;
            }

            return false;
        }

        protected internal override void OnInsert()
        {
            DataManager.PropertyData.Insert(model);
        }

        protected override void onSave()
        {
            DataManager.PropertyData.Update(model);
        }

        protected override bool onDelete()
        {
            DataManager.PropertyData.Delete(model);
            return true;
        }
    }
}
