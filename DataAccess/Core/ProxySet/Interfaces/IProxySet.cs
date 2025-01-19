using DataAccess.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace DataAccess
{
    public interface IProxySet
    {
        IReadOnlyList<IElementProxy> Items { get; }
        IElementProxy? SelectedItem { get; set; }

        event PropertyChangedEventHandler SelectedChanged;
        event CollectionChangeEventHandler ItemsChanged;
        event CollectionItemEventHandler ItemEdited;

        void AddNewRecord(string name = "New Element");
        bool DeleteSelectedRecord();
        void OnItemEdit(ElementProxy proxy, string propertyChanged);
    }

    public interface IProxySet<TProxy>
        where TProxy : ElementProxy
    {
        IReadOnlyList<TProxy> Items { get; }
        TProxy? SelectedItem { get; set; }
    }

    public interface IProxySet<TModel, TProxy> : IProxySet<TProxy>, IProxySet
        where TModel : class, IElementModel, new()
        where TProxy : ElementProxy, new()
    {
    }
}
