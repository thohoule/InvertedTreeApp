using DataAccess.Models;
using System.Collections.ObjectModel;

namespace DataAccess
{
    public partial class AttributeProxy : ElementProxy
    {
        private AttributeModel model;
        protected override IElementModel element => element;

        protected override bool onModelSet(IElementModel model)
        {
            if (model is AttributeModel)
            {
                model = (AttributeModel)model;
                return true;
            }

            return false;
        }

        protected internal override void OnInsert()
        {
            DataManager.AttributeData.Insert(model);
        }

        protected override void onSave()
        {
            DataManager.AttributeData.Update(model);
        }

        protected override bool onDelete()
        {
            DataManager.AttributeData.Delete(model);
            return true;
        }
    }
}
