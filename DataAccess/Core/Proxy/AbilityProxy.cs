using DataAccess.Models;
using System.Collections.ObjectModel;

namespace DataAccess
{
    public partial class AbilityProxy : ElementProxy
    {
        private AbilityModel model;
        protected override IElementModel element => model;

        protected override bool onModelSet(IElementModel model)
        {
            if (model is AbilityModel)
            {
                this.model = (AbilityModel)model;

                return true;
            }

            return false;
        }
    }
}
