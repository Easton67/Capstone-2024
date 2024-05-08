using DataObjects;
using LogicLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace WpfPresentation.Pages.Vendors
{
    /// <summary>
    ///Creator:            Andrew Larson
    ///Created:            02/26/2024
    ///Summary:            This contains the interaction logic for pgAddSuppliers
    ///Last Updated By:    Andrew Larson
    ///Last Updated:       02/26/2024
    ///What Was Changed:   Initial Creation
    ///Last Updated By:    Andrew Larson
    ///Last Updated:       03/01/2024
    ///What Was Changed:   Implemented MainManager
    /// </summary>
    public partial class pgAddSuppliers : Page
    {
        IVendorDataManager _vendorDataManager = new VendorDataManager();
        private MainManager _mainManager;
        public pgAddSuppliers()
        {
            InitializeComponent();
            _mainManager = MainManager.GetMainManager();
        }

        /// <summary>
        ///Creator:            Andrew Larson
        ///Created:            02/26/2024
        ///Summary:            Removes existing text inside the textbox if it's equal to the default values
        ///Last Updated By:    Andrew Larson
        ///Last Updated:       02/26/2024
        ///What Was Changed:   Initial Creation
        /// </summary>
        private void txtSupplierName_GotFocus(object sender, RoutedEventArgs e)
        {
            if (txtSupplierName.Text == "Supplier Name")
            { 
                txtSupplierName.Text = string.Empty;
            }
        }

        /// <summary>
        ///Creator:            Andrew Larson
        ///Created:            02/26/2024
        ///Summary:            Removes existing text inside the textbox if it's equal to the default values
        ///Last Updated By:    Andrew Larson
        ///Last Updated:       02/26/2024
        ///What Was Changed:   Initial Creation
        /// </summary>
        private void txtPhoneNumber_GotFocus(object sender, RoutedEventArgs e)
        {
            if (txtPhoneNumber.Text == "Phone Number")
            { 
                txtPhoneNumber.Text = string.Empty;
            }
        }

        /// <summary>
        ///Creator:            Andrew Larson
        ///Created:            02/26/2024
        ///Summary:            Removes existing text inside the textbox if it's equal to the default values
        ///Last Updated By:    Andrew Larson
        ///Last Updated:       02/26/2024
        ///What Was Changed:   Initial Creation
        /// </summary>
        private void txtContactName_GotFocus(object sender, RoutedEventArgs e)
        {
            if (txtContactName.Text == "Contact Name")
            { 
                txtContactName.Text = string.Empty;
            }
        }

        /// <summary>
        ///Creator:            Andrew Larson
        ///Created:            02/26/2024
        ///Summary:            Removes existing text inside the textbox if it's equal to the default values
        ///Last Updated By:    Andrew Larson
        ///Last Updated:       02/26/2024
        ///What Was Changed:   Initial Creation
        /// </summary>
        private void txtSupplierEmail_GotFocus(object sender, RoutedEventArgs e)
        {
            if (txtSupplierEmail.Text == "Supplier Email")
            { 
                txtSupplierEmail.Text = string.Empty;
            }
        }

        /// <summary>
        ///Creator:            Andrew Larson
        ///Created:            02/26/2024
        ///Summary:            Removes existing text inside the textbox if it's equal to the default values
        ///Last Updated By:    Andrew Larson
        ///Last Updated:       02/26/2024
        ///What Was Changed:   Initial Creation
        /// </summary>
        private void txtAddress_GotFocus(object sender, RoutedEventArgs e)
        {
            if (txtAddress.Text == "Address")
            { 
            txtAddress.Text = string.Empty;
            }
        }

        /// <summary>
        ///Creator:            Andrew Larson
        ///Created:            02/26/2024
        ///Summary:            Removes existing text inside the textbox if it's equal to the default values
        ///Last Updated By:    Andrew Larson
        ///Last Updated:       02/26/2024
        ///What Was Changed:   Initial Creation
        /// </summary>
        private void txtZip_GotFocus(object sender, RoutedEventArgs e)
        {
            if (txtZip.Text == "Zip Code")
            { 
                txtZip.Text = string.Empty;
            }
        }

        /// <summary>
        ///Creator:            Andrew Larson
        ///Created:            02/26/2024
        ///Summary:            Removes existing text inside the textbox if it's equal to the default values
        ///Last Updated By:    Andrew Larson
        ///Last Updated:       02/26/2024
        ///What Was Changed:   Initial Creation
        /// </summary>
        private void txtCity_GotFocus(object sender, RoutedEventArgs e)
        {
            if (txtCity.Text == "City")
            { 
                txtCity.Text = string.Empty;
            }
        }

        /// <summary>
        ///Creator:            Andrew Larson
        ///Created:            02/26/2024
        ///Summary:            Adding state values to combo box to limit user input.
        ///Last Updated By:    Andrew Larson
        ///Last Updated:       02/26/2024
        ///What Was Changed:   Initial Creation
        /// </summary>
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            cboState.SelectedIndex = 0;
            cboState.Items.Add("State");
            cboState.Items.Add("AL");
            cboState.Items.Add("AK");
            cboState.Items.Add("AZ");
            cboState.Items.Add("AR");
            cboState.Items.Add("CA");
            cboState.Items.Add("CO");
            cboState.Items.Add("CT");
            cboState.Items.Add("DE");
            cboState.Items.Add("FL");
            cboState.Items.Add("GA");
            cboState.Items.Add("HI");
            cboState.Items.Add("ID");
            cboState.Items.Add("IL");
            cboState.Items.Add("IN");
            cboState.Items.Add("IA");
            cboState.Items.Add("KS");
            cboState.Items.Add("KY");
            cboState.Items.Add("LA");
            cboState.Items.Add("ME");
            cboState.Items.Add("MD");
            cboState.Items.Add("MA");
            cboState.Items.Add("MI");
            cboState.Items.Add("MN");
            cboState.Items.Add("MS");
            cboState.Items.Add("MO");
            cboState.Items.Add("MT");
            cboState.Items.Add("NE");
            cboState.Items.Add("NV");
            cboState.Items.Add("NH");
            cboState.Items.Add("NJ");
            cboState.Items.Add("NM");
            cboState.Items.Add("NY");
            cboState.Items.Add("NC");
            cboState.Items.Add("ND");
            cboState.Items.Add("OH");
            cboState.Items.Add("OK");
            cboState.Items.Add("OR");
            cboState.Items.Add("PA");
            cboState.Items.Add("RI");
            cboState.Items.Add("SC");
            cboState.Items.Add("SD");
            cboState.Items.Add("TN");
            cboState.Items.Add("TX");
            cboState.Items.Add("UT");
            cboState.Items.Add("VT");
            cboState.Items.Add("VA");
            cboState.Items.Add("WA");
            cboState.Items.Add("WV");
            cboState.Items.Add("WI");
            cboState.Items.Add("WY");
        }

        /// <summary>
        ///Creator:            Andrew Larson
        ///Created:            02/26/2024
        ///Summary:            Validates user input, concatenates address details into one field
        ///                    and creates a new Supplier/Vendor in the DB.
        ///Last Updated By:    Andrew Larson
        ///Last Updated:       02/26/2024
        ///What Was Changed:   Initial Creation
        ///Last Updated By:    Andrew Larson
        ///Last Updated:       03/01/2024
        ///What Was Changed:   Implemented MainManager
        ///Last Updated By:    Mitchell Stirmel
        ///Last Updated:       04/11/2024
        ///What Was changed:   Added try catch
        /// </summary>
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (txtSupplierName.Text.Equals(string.Empty) || txtSupplierName.Text.Equals("Supplier Name"))
            {
                MessageBox.Show("Please input a valid supplier name", "Invalid Supplier", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (txtPhoneNumber.Text.Equals(string.Empty) || txtPhoneNumber.Text.Equals("Phone Number"))
            {
                MessageBox.Show("Please input a valid phone number", "Invalid Phone Number", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (txtContactName.Text.Equals(string.Empty) || txtContactName.Text.Equals("Contact Name"))
            {
                MessageBox.Show("Please input a contact name", "Invalid Contact Name", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (txtSupplierEmail.Text.Equals(string.Empty) || txtSupplierEmail.Text.Equals("Supplier Email") || !txtSupplierEmail.Text.Contains("@") || !txtSupplierEmail.Text.Contains("."))
            {
                MessageBox.Show("Please input a supplier email", "Invalid Supplier Email", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (txtAddress.Text.Equals(string.Empty) || txtAddress.Text.Equals("Address"))
            {
                MessageBox.Show("Please input an address", "Invalid Address", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (txtCity.Text.Equals(string.Empty) || txtCity.Text.Equals("City"))
            {
                MessageBox.Show("Please input a city", "Invalid City", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (cboState.Text.Equals(string.Empty) || cboState.Text.Equals("State"))
            {
                MessageBox.Show("Please input a state", "Invalid State", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (txtZip.Text.Equals(string.Empty) || txtZip.Text.Equals("Zip Code"))
            {
                MessageBox.Show("Please input a zip code", "Invalid Zip Code", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            Vendor vendor = new Vendor
            { 
                Name = txtSupplierName.Text,
                PhoneNumber = txtPhoneNumber.Text,
                ContactName = txtContactName.Text,
                Email = txtSupplierEmail.Text,
                Address = txtAddress.Text + " " + txtCity.Text + ", " + cboState.Text + " " + txtZip.Text
            };
            try
            {
                if (_mainManager.VendorDataManager.AddVendor(vendor))
                {
					MessageBox.Show("Supplier successfully added.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
					NavigationService.Navigate(new pgVendors());
                }
                else
                {
                    MessageBox.Show("Supplier failed to be added.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Supplier failed to be added.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        /// <summary>
        ///Creator:            Andrew Larson
        ///Created:            02/26/2024
        ///Summary:            Resets all values of text boxes to default values.
        ///Last Updated By:    Andrew Larson
        ///Last Updated:       02/26/2024
        ///What Was Changed:   Initial Creation
        /// </summary>
        public void Reset()
        {
            txtSupplierName.Text = "Supplier Name";
            txtPhoneNumber.Text = "Phone Number";
            txtContactName.Text = "Contact Name";
            txtSupplierEmail.Text = "Supplier Email";
            txtAddress.Text = "Address";
            txtCity.Text = "City";
            cboState.Text = "State";
            txtZip.Text = "Zip Code";
        }

        /// <summary>
        ///Creator:            Andrew Larson
        ///Created:            02/26/2024
        ///Summary:            Cancels the addition of the current supplier, and will navigate 
        ///                    back to the Supplier view.
        ///Last Updated By:    Andrew Larson
        ///Last Updated:       02/26/2024
        ///What Was Changed:   Initial Creation
        ///Last Updated By:    Andrew Larson
        ///Last Updated:       04/15/2024
        ///What Was Changed:   Updated navigation
        /// </summary>
        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
