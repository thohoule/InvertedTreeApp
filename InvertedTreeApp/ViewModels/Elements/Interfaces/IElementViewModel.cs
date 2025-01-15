﻿using System.Collections.Generic;
using System.Collections.ObjectModel;
using DataAccess.Models;

namespace InvertedTreeApp.ViewModels
{
    public interface IElementViewModel
    {
        ObservableCollection<IElementModel> Elements { get; }
        IElementModel SelectedElement { get; set; }

        void AddRecord();
        void DeleteSelected();
    }
}
