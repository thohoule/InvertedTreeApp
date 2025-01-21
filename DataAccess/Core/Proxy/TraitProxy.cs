using DataAccess.Models;
using System.Collections.ObjectModel;

namespace DataAccess
{
    public partial class TraitProxy : ElementProxy
    {
        private TraitModel model;
        protected override IElementModel element => model;

        protected override bool onModelSet(IElementModel model)
        {
            if (model is TraitModel)
            {
                this.model = (TraitModel)model;

                return true;
            }

            return false;
        }
    }
}
