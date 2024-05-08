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
    /// Creator: Anthony Talamantes
    /// Created: 02/12/2024
    /// Summary: Interaction logic for pgAddEditPartsInventory.xaml
    /// Last Updated By: Anthony Talamantes
    /// Last Updated: 02/12/2024
    /// What Was Changed: Initial Creation
    /// </summary>
    public partial class pgAddEditPartsInventory : Page
    {
        private MainManager _manager = MainManager.GetMainManager();
        private static pgAddEditPartsInventory instance = null;

        public static pgAddEditPartsInventory GetAddEditPartsPage()
        {
            return instance ?? (instance = new pgAddEditPartsInventory());
        }

        public pgAddEditPartsInventory()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Creator: Anthony Talamantes
        /// Created: 02/12/2024
        /// Summary: The event when btnAdd is clicked to add a part that uses ValidateInputs() for error checking.
        /// Last Updated By: Anthony Talamantes
        /// Last Updated: 02/12/2024
        /// What Was Changed: Initial Creation
        /// </summary>
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (!ValidateInputs())
            {
                MessageBox.Show("Please fill out all fields with valid data.");
                return;
            }

            var newPart = new PartsInventory()
            {
                _itemID = txtPartName.Text,
                _category = cboCategory.Text,
                _quantity = int.Parse(txtQuantity.Text),
                _stockType = cboStockType.Text,
            };

            try
            {
                bool result = _manager.PartsInventoryManager.AddPartsInventory(newPart);
                MessageBox.Show("Part Successfully Added.", "Success");
                txtPartName.Text = "";
                cboCategory.SelectedIndex = -1;
                txtQuantity.Text = "";
                cboStockType.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n\n" + ex.InnerException.Message);
            }
        }

        /// <summary>
        /// Creator: Anthony Talamantes
        /// Created: 02/12/2024
        /// Summary: Method used to validate inputs for PartsInventory
        /// Last Updated By: Anthony Talamantes
        /// Last Updated: 02/12/2024
        /// What Was Changed: Initial Creation
        /// </summary>
        private bool ValidateInputs()
        {
            if (string.IsNullOrWhiteSpace(txtPartName.Text) ||
                string.IsNullOrWhiteSpace(cboCategory.Text) ||
                string.IsNullOrWhiteSpace(txtQuantity.Text) ||
                string.IsNullOrWhiteSpace(cboStockType.Text))
            {
                return false;
            }
            if (!int.TryParse(txtQuantity.Text, out _))
            {
                MessageBox.Show("Please enter a valid numeric value for Quantity. e.g. 1");
                return false;
            }
            return true;
        }

        /// <summary>
        /// Creator: Anthony Talamantes
        /// Created: 02/12/2024
        /// Summary: Event for when the page is loaded.
        /// Last Updated By: Anthony Talamantes
        /// Last Updated: 02/12/2024
        /// What Was Changed: Initial Creation
        /// </summary>
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                cboCategory.ItemsSource = _manager.PartsInventoryManager.GetCategoriesForDropDown();
                cboStockType.ItemsSource = _manager.PartsInventoryManager.GetStockTypeForDropDown();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message + "\n\n" + ex.InnerException.Message);
            }
        }

        /// <summary>
        /// Creator: Anthony Talamantes
        /// Created: 02/12/2024
        /// Summary: The event when btnCancel is clicked that asks user to confirm if they want to cancel or not.
        /// Last Updated By: Anthony Talamantes
        /// Last Updated: 02/12/2024
        /// What Was Changed: Initial Creation
        /// </summary>
        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Are you sure you want to cancel?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                try
                {
                    if (NavigationService.CanGoBack)
                    {
                        NavigationService.GoBack();
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
