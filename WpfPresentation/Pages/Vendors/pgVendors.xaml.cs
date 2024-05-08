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
using WpfPresentation.Pages.Housekeeping;
using WpfPresentation.Pages.Supplier;

namespace WpfPresentation.Pages.Vendors
{
    /// <summary>
    /// Creator: Anthony Talamantes
    /// Created: 02/07/2024
    /// Summary: Interaction logic for pgVendors.xaml
    /// Last Updated By: Anthony Talamantes
    /// Last Updated: 02/07/2024
    /// What Was Changed: Initial Creation
    /// </summary>
    public partial class pgVendors : Page
    {
        private MainManager _manager = MainManager.GetMainManager();

        /// <summary>
        /// Creator: Anthony Talamantes
        /// Created: 02/07/2024
        /// Summary: Constructor for pgVendor.xaml
        /// Last Updated By: Anthony Talamantes
        /// Last Updated: 02/07/2024
        /// What Was Changed: Initial Creation
        /// </summary>
        public pgVendors()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Creator: Mitchell Stirmel
        /// Created: 03/05/2024
        /// Summary: Navigation static class
        /// Last Updated By: Mitchell Stirmel
        /// Last Updated: 03/05/2024
        /// What Was Changed: Initial Creation
        /// </summary>
        private static pgVendors instance = null;
        public static pgVendors GetVendorsPage()
        {
            return instance ?? (instance = new pgVendors());
        }

        /// <summary>
        /// Creator: Anthony Talamantes
        /// Created: 02/07/2024
        /// Summary: This method is for populating the datVendor DataGrid with items retrieved from the VendorManager.
        /// Last Updated By: Anthony Talamantes
        /// Last Updated: 02/07/2024
        /// What Was Changed: Initial Creation
        /// </summary>
        private void datVendor_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                if (datVendor.ItemsSource == null)
                {
                    datVendor.ItemsSource = _manager.VendorDataManager.GetAllVendors();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n\n" + ex.InnerException.Message);
            }
        }

        private static pgVendors vendorsPage = null;
        public static pgVendors GetVendorPage()
        {
            return vendorsPage ?? (vendorsPage = new pgVendors());
        }

        /// <summary>
        /// Creator: Mitchell Stirmel
        /// Created: 03/04/2024
        /// Summary: This method deletes the vendor selected and refreshes the page if deletion was processed successfully.
        ///Last Updated By:    Mitchell Stirmel
        ///Last Updated:       04/11/2024
        ///What Was changed:   Added try catch
        /// </summary>
        private void btnDeleteItem_Click(object sender, RoutedEventArgs e)
        {
            if (datVendor.SelectedItems.Count != 1)
            {
                MessageBox.Show("Please select one vendor to delete.", "Select one", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            if (datVendor.SelectedItem != null)
            {
                try
                {
                    Vendor selectedVendor = datVendor.SelectedItem as Vendor;
                    if (_manager.VendorDataManager.DeleteVendor(selectedVendor.VendorId) == true)
                    {
                        MessageBox.Show("Vendor deleted successfully.", "Success", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                        datVendor.ItemsSource = _manager.VendorDataManager.GetAllVendors();
                    }
                    else
                    {
                        MessageBox.Show("Vendor delete failure", "Failure", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Vendor delete failure", "Failure", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                }

            }
        }

        private void btnEditItem_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new pgRetrieveSupplierWithName());
        }

        private void btnAddItem_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new pgAddSuppliers());
        }

        /// <summary>
        /// Creator: Andrew Larson
        /// Created: 03/04/2024
        /// Summary: Gets all vendor data and refreshes the current datagrid with current data.
        /// Last Updated By: Andrew Larson
        /// Last Updated: 04/15/2024
        /// What Was Changed: Initial Creation
        /// </summary>
        private void refreshVendorList()
        {
            try
            {
                datVendor.ItemsSource = _manager.VendorDataManager.GetAllVendors();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n\n" + ex.InnerException.Message);
            }
        }



        /// <summary>
        /// Creator: Andrew Larson
        /// Created: 03/04/2024
        /// Summary: Calls the refreshVendorList() method to make sure when the user is met with the 
        ///          data it's current (if they have just added)
        /// Last Updated By: Andrew Larson
        /// Last Updated: 04/15/2024
        /// What Was Changed: Initial Creation
        /// </summary>
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            refreshVendorList();
        }
    }
}
