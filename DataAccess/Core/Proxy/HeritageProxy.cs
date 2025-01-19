﻿using DataAccess.Models;
using System.Collections.ObjectModel;

namespace DataAccess
{
    public partial class HeritageProxy : ElementProxy
    {
        private HeritageModel model;
        protected override IElementModel element => model;

        protected override bool onModelSet(IElementModel model)
        {
            if (model is HeritageModel)
            {
                this.model = (HeritageModel)model;

                return true;
            }

            return false;
        }
    }
}
