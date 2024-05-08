using LogicLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfPresentation.Pages.Security
{
    /// <summary>
    /// Creator:            Andrew Larson
    /// Created:            04/16/2024
    /// Summary:            xaml.cs for the add confiscated items page
    /// Last Updated By:    Andrew Larson
    /// Last Updated:       04/16/2024
    /// What Was Changed:   Initial Creation
    /// </summary>
    public partial class pgAddConfiscatedItem : Page
    {
        MainManager _mainManager;
        public pgAddConfiscatedItem()
        {
            InitializeComponent();
            _mainManager = MainManager.GetMainManager();
        }

        /// <summary>
        /// Creator:            Andrew Larson
        /// Created:            04/16/2024
        /// Summary:            Navigation to exit the add confiscated item page
        /// Last Updated By:    Andrew Larson
        /// Last Updated:       04/16/2024
        /// What Was Changed:   Initial Creation
        /// </summary>
        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        /// <summary>
        /// Creator:            Andrew Larson
        /// Created:            04/16/2024
        /// Summary:            Logic for validating and adding confiscated item
        /// Last Updated By:    Andrew Larson
        /// Last Updated:       04/16/2024
        /// What Was Changed:   Initial Creation
        /// </summary>
        private void btnAddConfiscatedItem_Click(object sender, RoutedEventArgs e)
        {
            if(txtConfiscatedItems.Text.Trim().Equals(string.Empty) || txtConfiscatedItems.Text.Equals("Confiscated Item(s) Here"))
            {
                MessageBox.Show("Please input a valid item", "Invalid Item", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (txtReasonForConfiscation.Text.Trim().Equals(string.Empty) || txtReasonForConfiscation.Text.Equals("Please enter reason for confiscation"))
            {
                MessageBox.Show("Please input a valid reason", "Invalid Reason", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }


            string itemsConfiscated = txtConfiscatedItems.Text;
            string reasonForConfiscation = txtReasonForConfiscation.Text;
            try
            {
                if(_mainManager.ConfiscatedItemManager.AddConfiscatedItem(itemsConfiscated, reasonForConfiscation))
                {
                    MessageBox.Show("Item Successfully Added", "Item Added", MessageBoxButton.OK, MessageBoxImage.Information);
                    NavigationService.GoBack();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n\n" + ex.InnerException?.Message);
            }
        }

        /// <summary>
        /// Creator:            Andrew Larson
        /// Created:            04/16/2024
        /// Summary:            Removes existing text inside the textbox if it's equal to the default values
        /// Last Updated By:    Andrew Larson
        /// Last Updated:       04/16/2024
        /// What Was Changed:   Initial Creation
        /// </summary>
        private void txtConfiscatedItems_GotFocus(object sender, RoutedEventArgs e)
        {
            if(txtConfiscatedItems.Text == "Confiscated Item(s) Here")
            {
                txtConfiscatedItems.Text = string.Empty;
            }
        }

        /// <summary>
        /// Creator:            Andrew Larson
        /// Created:            04/16/2024
        /// Summary:            Removes existing text inside the textbox if it's equal to the default values
        /// Last Updated By:    Andrew Larson
        /// Last Updated:       04/16/2024
        /// What Was Changed:   Initial Creation
        /// </summary>
        private void txtReasonForConfiscation_GotFocus(object sender, RoutedEventArgs e)
        {
            if (txtReasonForConfiscation.Text == "Please enter reason for confiscation")
            {
                txtReasonForConfiscation.Text = string.Empty;
            }
        }
    }
}
