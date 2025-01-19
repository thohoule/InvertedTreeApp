using DataAccess.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Security.AccessControl;

namespace DataAccess
{
    public delegate void CollectionItemEventHandler(object sender, object edited, string propertyChanged);

    public sealed class ProxySet<TModel, TProxy> : IProxySet<TModel, TProxy>
        where TModel : class, IElementModel, new()
        where TProxy : ElementProxy, new()
    {
        private List<TProxy> items;
        private TProxy? selectedItem;

        public IReadOnlyList<TProxy> Items => items;
        public TProxy? SelectedItem
        {
            get => selectedItem;
            set => setSelected(value);
        }

        IReadOnlyList<IElementProxy> IProxySet.Items => items;

        IElementProxy? IProxySet.SelectedItem { get => selectedItem; set => setSelected(validateValue(value)); }

        /// <summary>
        /// Event triggers when the selected item is changed.
        /// </summary>
        public event PropertyChangedEventHandler SelectedChanged;
        /// <summary>
        /// Event triggers when the Items collection chanages.
        /// </summary>
        public event CollectionChangeEventHandler ItemsChanged;
        /// <summary>
        /// Event triggers when the selected item is edited.
        /// </summary>
        public event CollectionItemEventHandler ItemEdited;

        public ProxySet()
        {
            items = new List<TProxy>();
        }

        public ProxySet(IEnumerable<TModel> models)
        {
            items = new List<TProxy>();
            AddModelRange(models);

            if (items.Count > 0)
                triggerItemChange(CollectionChangeAction.Add);
        }

        #region Add Model
        internal void AddModelRange(IEnumerable<TModel> models)
        {
            foreach (var model in models)
                AddModel(model);
        }

        internal void AddModel(TModel model)
        {
            var proxy = new TProxy();
            if (proxy.SetModel(this, model))
                items.Add(proxy);
            else
                throw new ArgumentException("Model type provided didn't match expected proxy type.");
        }

        internal void triggerItemChange(CollectionChangeAction action)
        {
            ItemsChanged?.Invoke(this,
                new CollectionChangeEventArgs(action, items));
        }
        #endregion

        public void AddNewRecord(string name = "New Element")
        {
            var model = new TModel()
            {
                Name = name,
            };

            var proxy = new TProxy();
            proxy.SetModel(this, model);
            proxy.OnEdit("New");
            proxy.IsNewRecord = true;

            items.Add(proxy);
            triggerItemChange(CollectionChangeAction.Add);
        }

        public bool DeleteSelectedRecord()
        {
            throw new NotImplementedException();
        }

        public void OnItemEdit(ElementProxy proxy, string propertyChanged)
        {
            if (proxy != null && proxy.Set == this)
                ItemEdited?.Invoke(this, proxy, propertyChanged);
        }

        private void setSelected(TProxy? value)
        {
            if (selectedItem != value)
            {
                selectedItem = value;
                SelectedChanged?.Invoke(this,
                    new PropertyChangedEventArgs(nameof(SelectedItem)));
            }
        }

        private TProxy? validateValue(IElementProxy? value)
        {
            return value as TProxy;
        }
    }
}
