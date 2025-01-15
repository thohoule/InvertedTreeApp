using InvertedTreeApp.ViewModels.Pages;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace InvertedTreeApp.Views.Pages.MainPages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class EditPage : Page
    {
        public EditViewModel ViewModel { get; private set; }

        public EditPage()
        {
            ViewModel = new EditViewModel();

            this.InitializeComponent();
        }

        #region Add Record
        private void AddAppButton_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.ElementViewModel.AddRecord();
        }
        #endregion

        #region Remove Record
        private async void RemoveAppButton_Click(object sender, RoutedEventArgs e)
        {
            if (await confirmDeleteRecord())
                ViewModel.ElementViewModel.DeleteSelected();
        }

        private async Task<bool> confirmDeleteRecord()
        {
            if (ViewModel.ElementViewModel.SelectedElement == null)
                return false;

            ContentDialog dialog = new ContentDialog();
            dialog.XamlRoot = this.XamlRoot;
            dialog.Title = "Confirm";
            dialog.Content = string.Format("{0} record will be deleted, are you sure you wish to delete this record?",
                ViewModel.ElementViewModel.SelectedElement.Name);
            dialog.PrimaryButtonText = "Delete";
            dialog.SecondaryButtonText = "Cancel";
            dialog.DefaultButton = ContentDialogButton.Secondary;

            var dialogResult = await dialog.ShowAsync();
            return dialogResult == ContentDialogResult.Primary;
        }
        #endregion

        #region Save Records
        private void SaveAppButton_Click(object sender, RoutedEventArgs e)
        {

        }
        #endregion

        #region On Selection Change
        private void ElementTypeComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //Check if edited


            ElementDisplay.ElementControl =
                ViewModel.ChangeType(ElementTypeComboBox.SelectedIndex);
        }
        #endregion

        private void ElementList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ViewModel.ElementViewModel.SelectedElement = ElementList.SelectedItem;
            ElementDisplay.SelectedItem = ElementList.SelectedItem;
        }
    }
}
