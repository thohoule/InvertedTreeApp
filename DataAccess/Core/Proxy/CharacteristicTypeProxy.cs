using DataAccess.Models;
using System.Collections.ObjectModel;

namespace DataAccess
{
    public partial class CharacteristicTypeProxy : ElementProxy
    {
        private CharacteristicTypeModel model;
        protected override IElementModel element => model;

        protected override bool onModelSet(IElementModel model)
        {
            if (model is CharacteristicTypeModel)
            {
                this.model = (CharacteristicTypeModel)model;

                return true;
            }

            return false;
        }

        protected internal override void OnInsert()
        {
            DataManager.CharacteristicTypeData.Insert(model);
        }

        protected override void onSave()
        {
            DataManager.CharacteristicTypeData.Update(model);
        }

        protected override bool onDelete()
        {
            DataManager.CharacteristicTypeData.Delete(model);
            return true;
        }
    }
}
