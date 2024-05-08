using DataAccessInterfaces;
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

namespace WpfPresentation.Pages.Inventory
{
    /// <summary>
    ///Creator:            Mitchell Stirmel
	///Created:            02/01/2024
    ///Summary:            This page supports the maintenance inventory functions.
    ///Last Updated By:    Anthony Talamantes
    ///Last Updated:       02/25/2024
	///What Was Changed:   Implemented MainManager
    /// </summary>
    public partial class pgPartsInventory : Page
    {
        private static pgPartsInventory instance = null;
        public static pgPartsInventory GetPartsInventoryPage()
        {
            return instance ?? (instance = new pgPartsInventory());
        }

        /// <summary>
        /// Creator: Darryl Shirley
        /// created: 02/07/2024
        /// Summary: pgPartsInventory() method
        /// Last Updated By: Anthony Talamantes
        /// Last Updated: 04/18/2024
        /// What Was Changed: Removed filter logic from constructor and put it in a PopulateFilter() method
        /// </summary>
        private MainManager _mainManager;

        public pgPartsInventory()
        {
            InitializeComponent();
            _mainManager = MainManager.GetMainManager();  
            GetPartsInventory();
            PopulateFilter();

        }

        /// <summary>
        /// Creator:            Anthony Talamantes
        /// Created:            04/05/2024
        /// Summary:            Method used to filter the parts Inventory
        /// Last Updated By:    Anthony Talamantes
        /// Last Updated:       04/18/2024
        /// What Was Changed:   Initial Creation
        /// </summary>
        private void PopulateFilter()
        {
            try
            {
                List<string> stockTypeList = new List<string> { "All Parts" };
                stockTypeList.AddRange(selectionOptions);
                cboMaintenanceFilter.ItemsSource = stockTypeList;
                cboMaintenanceFilter.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error populating filter: " + ex.Message);

            }
        }

        /// <summary>
        /// Creator:            Mitchell Stirmel
        /// Created:            02/01/2024
        /// Summary:            This allows the PartsInventory page to show the list of Maintenance inventory from the DB.
        /// Last Updated By:    Anthony Talamantes
        /// Last Updated:       02/25/2024
        /// What Was Changed:   Implemented MainManager
        /// </summary>
        public void GetPartsInventory()
        {
            try
            {
                dgdPartList.ItemsSource = _mainManager.PartsInventoryManager.GetPartsInventory();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to get parts inventory \n" + ex.ToString(), "Failure", MessageBoxButton.OK);
            }
            GetUpdatedDate();
        }

        /// <summary>
        /// Creator:            Mitchell Stirmel
        /// Created:            02/01/2024
        /// Summary:            This updates the updated date. Call this on every create, update or delete function.
        /// Last Updated By:    Anthony Talamantes
        /// Last Updated:       02/25/2024
        /// What Was Changed:   Implemented MainManager
        /// </summary>
        public void GetUpdatedDate()
        {
            try
            {
                lblUpdatedDate.Content = $"Last Updated: {_mainManager.PartsInventoryManager.GetUpdatedDate()}";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to get updated date \n" + ex.ToString(), "Failure", MessageBoxButton.OK);
            }
        }

        /// <summary>
        /// Last Updated By:    Tyler Barz
        /// Last Updated:       03/24/2024
        /// What Was Changed:   Shortened method body dramatically
        /// </summary>
        /// 
        private List<string> selectionOptions = new List<string>() {"In Stock", "Almost out of Stock", "Out of Stock" };
        private void cboMaintenanceFilter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                List<PartsInventory> maintenanceItems = _mainManager.PartsInventoryManager.GetPartsInventory();
                string selection = cboMaintenanceFilter.SelectedItem.ToString();
                dgdPartList.ItemsSource = null;
                if (selectionOptions.Contains(selection))
                {
                    dgdPartList.ItemsSource = maintenanceItems.FindAll(m => m._stockType == selection);
                }
                else
                {
                    dgdPartList.ItemsSource = _mainManager.PartsInventoryManager.GetPartsInventory();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n\n" + ex);
            }
        }


        /// <summary>
        /// Creator: Darryl Shirley
        /// created: 02/07/2024
        /// Summary: Exit Button Method
        /// Last Updated By:    Tyler Barz
        /// Last Updated:       03/24/2024
        /// What Was Changed:   Go back
        /// </summary>
        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                NavigationService.GoBack();
            }
            catch { /* If fails, do nothing */ }
        }

        /// <summary>
        /// Creator:           Anthony Talamantes
        /// Created:           02/12/2024
        /// Summary:           The event that is used to open up the pgAddPartInventory.xaml
        ///Last Updated By:    Tyler Barz
        ///Last Updated:       03/24/2024
        ///What Was Changed:   Singleton page call
        /// </summary>
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                NavigationService.Navigate(pgAddEditPartsInventory.GetAddEditPartsPage());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n\n" + ex.InnerException?.Message);
            }
        }

        /// <summary>
        /// Creator:            Anthony Talamantes
        /// Created:            02/12/2024
        /// Summary:            The event that is used to delete a part from the PartsInventory which provides confirmation dialogs to the user.
        // /Last Updated By:    Tyler Barz
        /// Last Updated:       03/24/2024
        /// What Was Changed:   Small changes
        /// </summary>
        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Are you sure you want to delete this part?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                try
                {
                    PartsInventory selectedPart = (PartsInventory)dgdPartList.SelectedItem;
                    if (selectedPart == null)
                    {
                        MessageBox.Show("Please select a part to delete.", "Update Failed", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }

                    if (_mainManager.PartsInventoryManager.RemovePartsInventory(selectedPart))
                    {
                        MessageBox.Show("Part Deleted Successfully.", "Update Successful", MessageBoxButton.OK, MessageBoxImage.Information);
                        GetPartsInventory();
                    }
                    else
                    {
                        MessageBox.Show("Unable to Delete Successfully.", "Update Failed", MessageBoxButton.OK, MessageBoxImage.Error);
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message + "\n\n" + ex.InnerException?.Message);
                }
            }
        }
    }
}
