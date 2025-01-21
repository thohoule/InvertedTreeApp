using DataAccess.Models;
using System.Collections.ObjectModel;

namespace DataAccess
{
    public partial class CharacteristicProxy : ElementProxy
    {
        private CharacteristicModel model;
        protected override IElementModel element => model;

        protected override bool onModelSet(IElementModel model)
        {
            if (model is RaceModel)
            {
                this.model = (CharacteristicModel)model;

                return true;
            }

            return false;
        }
    }
}
