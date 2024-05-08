using DataObjects;
using LogicLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using WpfPresentation.Pages.Vendors;

namespace WpfPresentation.Pages.Supplier
{
    /// <summary>
    ///Creator:            Ethan McElree
    ///Created:            02/24/2024
    ///Summary:            Code behind file for the page where the user retrieves a vendor by its name.
    ///Last Updated By:    Ethan McElree
    ///Last Updated:       02/24/2024
    ///What Was Changed:   Initial Creation
    /// </summary> 
    public partial class pgRetrieveSupplierWithName : Page
    {
        VendorDataManager _vendorDataManager;

        /// <summary>
        /// Creator: Ethan McElree
        /// Created: 02/28/2024
        /// Summary: Creation of the pgRetrieveSupplierWithName constructor method.
        /// Last Updated By: Ethan McElree
        /// Last Updated: 02/28/2024
        /// What Was Changed: Initial Creation
        /// </summary>
        public pgRetrieveSupplierWithName()
        {
            InitializeComponent();
            _vendorDataManager = new VendorDataManager();
            PopulateSupplierNames();
        }

        /// <summary>
        /// Creator: Ethan McElree
        /// Created: 02/28/2024
        /// Summary: Method for populating the supplierNameComboBox.
        /// Last Updated By: Ethan McElree
        /// Last Updated: 02/28/2024
        /// What Was Changed: Initial Creation
        /// </summary>
        private void PopulateSupplierNames()
        {
            try
            {
                List<string> suppliers = _vendorDataManager.getSupplierNames();
                supplierNameComboBox.ItemsSource = suppliers;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading supplier names " + ex.Message);
            }
        }

        /// <summary>
        /// Creator: Ethan McElree
        /// Created: 02/28/2024
        /// Summary: Click method for the submit button.
        /// Last Updated By: Ethan McElree
        /// Last Updated: 02/28/2024
        /// What Was Changed: Initial Creation
        /// </summary>
        private void submitButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string supplier = (string)supplierNameComboBox.SelectedValue;
                List<Vendor> suppliers = _vendorDataManager.RetrieveSupplier(supplier);
                Vendor chosenSupplier = suppliers.FirstOrDefault();
                NavigationService.Navigate(new pgEditSuppliers(chosenSupplier));
            }
            catch
            {
                MessageBox.Show("There was a problem retrieveing the food menu.");
            }
        }

        /// <summary>
        /// Creator: Ethan McElree
        /// Created: 02/28/2024
        /// Summary: Click method for the cancel button.
        /// Last Updated By: Ethan McElree
        /// Last Updated: 03/22/2024
        /// What Was Changed: This cancel button now navigates to the Vendors page.
        /// </summary>
        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new pgVendors());
        }

        /// <summary>
        /// Creator: Ethan McElree
        /// Created: 02/28/2024
        /// Summary: Logic for navigation in the pgRetrieveSupplierWithName file.
        /// Last Updated By: Ethan McElree
        /// Last Updated: 02/28/2024
        /// What Was Changed: Initial Creation
        /// </summary>
        private static pgRetrieveSupplierWithName instance = null;
        public static pgRetrieveSupplierWithName GetpgRetrieveSupplierWithName()
        {
            return instance ?? (instance = new pgRetrieveSupplierWithName());
        }
    }
}
