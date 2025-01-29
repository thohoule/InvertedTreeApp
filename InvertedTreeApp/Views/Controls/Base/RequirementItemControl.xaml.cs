using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using DataAccess;
using DataAccess.Models;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace InvertedTreeApp.Views
{
    public sealed partial class RequirementItemControl : UserControl
    {
        public RequirementModel Item { get; set; }

        public RequirementItemControl()
        {
            this.InitializeComponent();
        }

        private void TypeSelectionComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (TypeSelectionComboBox.SelectedValue as string)
            {
                case "Property":
                    setAsProperty();
                    break;
                case "Attribute":
                    setAsAttribute();
                    break;
                case "Quality":
                    setAsQuality();
                    break;
                case "Feature":
                    setAsFeature();
                    break;
            }
        }

        private void setAsProperty()
        {
            var proxy = DataManager.GetAllProperties();

            ItemSelectionComboBox.ItemsSource = proxy.Items;
        }

        private void setAsAttribute()
        {

        }

        private void setAsQuality()
        {

        }

        private void setAsFeature()
        {

        }
    }
}
