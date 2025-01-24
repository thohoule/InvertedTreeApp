using CommunityToolkit.Mvvm.ComponentModel;
using DataAccess.Models;

namespace DataAccess
{
    public abstract partial class ElementProxy : ObservableObject, IElementProxy
    {
        internal IProxySetInternal Set { get; private set; }

        private string displayName;
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

        public string DisplayName
        {
            get => displayName;
            set => SetProperty(displayName, value, this,
                (model, v) => model.displayName = v);
        }

        internal void SaveToModel()
        {
            DisplayName = Name;
            onSave();
            IsEdited = false;
        }

        internal bool SetModel(IProxySetInternal proxySet, IElementModel model)
        {
            Set = proxySet;
            DisplayName = model.Name;
            return onModelSet(model);
        }

        internal bool DeleteModel()
        {
            return onDelete();
        }

        protected internal void OnEdit(string propertyName)
        {
            if (!IsEdited)
            {
                DisplayName = Name + '*';
                OnPropertyChanged(nameof(DisplayName));
            }
            IsEdited = true;
            Set.OnItemEdit(this, propertyName);
        }

        internal protected abstract void OnInsert();

        protected abstract bool onModelSet(IElementModel model);        
        protected abstract void onSave();
        protected abstract bool onDelete();
    }
}
