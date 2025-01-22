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
using System.Reflection;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace InvertedTreeApp.Views
{
    public sealed partial class StateDropDown : UserControl
    {
        private int state;
        private List<string> stateOptions;
        private MenuFlyout flyoutMenu;

        public int State
        {
            get => state;
            set => setState(value);
        }

        public StateDropDown()
        {
            stateOptions = tempOptions();

            this.InitializeComponent();

            buildOptions();
        }

        private List<string> tempOptions()
        {
            return new List<string>()
            {
                "None",
                "Stable",
                "WIP"
            };
        }

        private void buildOptions()
        {
            flyoutMenu = new MenuFlyout();

            for (int index = 0; index < stateOptions.Count; index++)
            {
                var option = stateOptions[index];
                var toggleItem = new ToggleMenuFlyoutItem()
                {
                    Tag = index == 0 ? 0 : (1 << index) - index,
                    Text = option,
                };
                toggleItem.Click += ToggleItem_Click;

                flyoutMenu.Items.Add(toggleItem);
            }

            StateDropButton.Flyout = flyoutMenu;
        }

        private void ToggleItem_Click(object sender, RoutedEventArgs e)
        {
            var tag = (int)(sender as ToggleMenuFlyoutItem).Tag;

            if (tag == 0)
                State = 0;
            else
                State ^= tag;
        }

        private void setState(int value)
        {
            if (value == 0 || stateOptions.Count <= 1)
            {
                state = 0;
                StateDropButton.Content = stateOptions[0];

                (flyoutMenu.Items[0] as ToggleMenuFlyoutItem).IsChecked = true;
                for (int index = 1; index < flyoutMenu.Items.Count; index++)
                    (flyoutMenu.Items[index] as ToggleMenuFlyoutItem).IsChecked = false;

                return;
            }

            state = value;
            var contentBuilder = new StringBuilder();
            (flyoutMenu.Items[0] as ToggleMenuFlyoutItem).IsChecked = false;

            for (int index = 1; index < stateOptions.Count; index++)
            {
                int bit = (1 << index) - index;
                if ((state & bit) != 0)
                {
                    if (contentBuilder.Length != 0)
                        contentBuilder.Append(", ");
                    contentBuilder.Append(stateOptions[index]);
                    (flyoutMenu.Items[index] as ToggleMenuFlyoutItem).IsChecked = true;
                }
            }

            StateDropButton.Content = contentBuilder.ToString();
        }
    }
}
