using System.Collections.Generic;
using System.Collections.ObjectModel;
using DataAccess;
using DataAccess.Models;

namespace InvertedTreeApp.ViewModels
{
    public interface IElementViewModel
    {
        //ProxySetViewModel ProxyViewModel { get; }
        IProxySet ElementSet { get; }

        //ObservableCollection<IElementModel> Elements { get; }
        //IElementModel SelectedElement { get; set; }

        //void AddRecord();
        //void DeleteSelected();
    }
}
