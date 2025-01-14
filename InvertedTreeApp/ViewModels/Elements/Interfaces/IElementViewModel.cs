using System.Collections.Generic;
using DataAccess.Models;

namespace InvertedTreeApp.ViewModels
{
    public interface IElementViewModel
    {
        IReadOnlyList<IElementModel> Elements { get; }
        IElementModel SelectedElement { get; set; }

        void DeleteSelected();
    }
}
