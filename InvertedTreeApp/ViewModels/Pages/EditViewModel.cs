using System;
using CommunityToolkit.Mvvm.ComponentModel;
using InvertedTreeApp.Views;
using Microsoft.UI.Xaml;

namespace InvertedTreeApp.ViewModels.Pages
{
    public partial class EditViewModel : ObservableObject
    {
        private IElementViewModel elementViewModel;

        public IElementViewModel ElementViewModel
        {
            get => elementViewModel;
            private set => SetProperty(elementViewModel, value, this,
                (model, v) => model.elementViewModel = v);
        }

        public UIElement ChangeType(int typeIndex)
        {
            return ChangeType(DataManager.ElementTypes[typeIndex]);
        }

        public UIElement ChangeType(string typeName)
        {
            switch (typeName)
            {
                case "Race":
                    var control = new RaceControl();
                    ElementViewModel = control.ViewModel;
                    return control;
            }

            throw new NotSupportedException();
        }
    }
}
