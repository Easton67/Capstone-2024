using DataObjects;
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

namespace WpfPresentation.Pages.Donations
{
    /// <summary>
    /// Creator: Andrew Larson
    /// Created: 02/19/2024
    /// Summary: xaml.cs for adding ResourcesNeeded
    /// Last Updated By: Andrew Larson
    /// Last Updated: 02/19/2024
    /// What Was Changed: Initial Creation
    /// </summary>
    public partial class pgAddResourcesNeeded : Page
    {
        private IResourcesNeededManager _resourcesNeededManager;
        public pgAddResourcesNeeded()
        {
            InitializeComponent();
            _resourcesNeededManager = new ResourcesNeededManager();
        }

        /// <summary>
        /// Creator: Andrew Larson
        /// Created: 02/19/2024
        /// Summary: added functionality and validation for btnSave click event
        /// Last Updated By: Andrew Larson
        /// Last Updated: 02/19/2024
        /// What Was Changed: Initial Creation
        /// </summary>
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string itemName = txtItemName.Text;
                string category = cmbCategory.Text;

                if(string.IsNullOrWhiteSpace(itemName) || string.IsNullOrWhiteSpace(category))
                {
                MessageBox.Show("Please enter both item name and category", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
                }
                if (itemName.Length > 50) 
                {
                    MessageBox.Show("Item name exceeds maximum length (50 characters).", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                    txtItemName.Text = "";
                    return;
                }

                bool result = _resourcesNeededManager.AddResourcesNeeded(itemName, category);
                if(result) 
                {
                    MessageBox.Show("Item successfully added.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else 
                {
                    MessageBox.Show("Failed to add item", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButton.OK , MessageBoxImage.Error);
            }

            NavigationService.Navigate(new pgViewResourcesNeeded());
        }

        /// <summary>
        /// Creator: Andrew Larson
        /// Created: 02/19/2024
        /// Summary: added functionality for btnBack click event
        /// Last Updated By: Andrew Larson
        /// Last Updated: 02/19/2024
        /// What Was Changed: Initial Creation
        /// </summary>
        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new pgViewResourcesNeeded());
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                var resourcesNeededManager = new ResourcesNeededManager();
                cmbCategory.ItemsSource = resourcesNeededManager.GetResourceCategoriesForDropDown();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n\n" + ex.InnerException.Message);
            }
        }
    }
}
