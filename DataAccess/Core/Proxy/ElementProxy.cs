using CommunityToolkit.Mvvm.ComponentModel;
using DataAccess.Models;

namespace DataAccess
{
    public abstract partial class ElementProxy : ObservableObject, IElementProxy
    {
        internal IProxySet Set { get; private set; }

        protected abstract IElementModel element { get; }

        public bool IsEdited { get; private set; }
        public bool IsNewRecord { get; internal set; }
        public bool IsDeletedRecord { get; internal set; }
        public int Id
        {
            get => element.Id;
            set => throw new InvalidOperationException("Id shouldn't be set in proxy.");
        }

        public string Name
        {
            get => element.Name;
            set
            {
                if (element.Name != value)
                {
                    OnEdit(nameof(Name));
                    SetProperty(element.Name, value, this,
                    (item, v) => item.element.Name = v);
                }
            }
        }

        public string? Description
        {
            get => element.Description;
            set
            {
                if (element.Description != value)
                {
                    OnEdit(nameof(Description));
                    SetProperty(element.Description, value, this,
                    (item, v) => item.element.Description = v);
                }
            }
        }

        public int State
        {
            get => element.State;
            set
            {
                if (element.State != value)
                {
                    OnEdit(nameof(State));
                    SetProperty(element.State, value, this,
                        (item, v) => item.element.State = v);
                }
            }
        }

        public string DisplayName { get; private set; }

        internal bool SetModel(IProxySet proxySet, IElementModel model)
        {
            Set = proxySet;
            return onModelSet(model);
        }

        protected internal void OnEdit(string propertyName)
        {
            if (!IsEdited)
                DisplayName = Name + '*';
            IsEdited = true;
            Set.OnItemEdit(this, propertyName);
        }

        protected abstract bool onModelSet(IElementModel model);
    }
}
