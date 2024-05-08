using DataObjects;
using LogicLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    ///Creator:            Mitchell Stirmel
    ///Created:            02/13/2024
    ///Summary:            This contains the interaction logic for pgAddVendors
    ///Last Updated By:    Mitchell Stirmel
    ///Last Updated:       02/13/2024
    ///What Was Changed:   Initial Creation
    /// </summary>
    public partial class pgAddVendors : Page
    {
        private MainManager _mainManager;

        public pgAddVendors()
        {
            InitializeComponent();
            _mainManager = MainManager.GetMainManager();
        }


        /// <summary>
        ///Creator:            Mitchell Stirmel
        ///Created:            02/13/2024
        ///Summary:            Changes to an empty string when clicked if default info is present
        ///Last Updated By:    Mitchell Stirmel
        ///Last Updated:       02/13/2024
        ///What Was Changed:   Initial Creation
        /// </summary>
        private void tbxVendorName_GotFocus(object sender, RoutedEventArgs e)
        {
            if(tbxVendorName.Text == "Vendor Company Name")
            {
                tbxVendorName.Text = string.Empty;
            }
        }


        /// <summary>
        ///Creator:            Mitchell Stirmel
        ///Created:            02/13/2024
        ///Summary:            Changes an empty string to the default info
        ///Last Updated By:    Mitchell Stirmel
        ///Last Updated:       02/13/2024
        ///What Was Changed:   Initial Creation
        /// </summary>
        private void tbxVendorName_LostFocus(object sender, RoutedEventArgs e)
        {
            if(tbxVendorName.Text.Equals(string.Empty))
            {
                tbxVendorName.Text = "Vendor Company Name";
            }
            
        }


        /// <summary>
        ///Creator:            Mitchell Stirmel
        ///Created:            02/13/2024
        ///Summary:            Changes to an empty string when clicked if default info is present
        ///Last Updated By:    Mitchell Stirmel
        ///Last Updated:       02/13/2024
        ///What Was Changed:   Initial Creation
        /// </summary>
        private void tbxVendorContactName_GotFocus(object sender, RoutedEventArgs e)
        {
            if (tbxVendorContactName.Text == "Vendor Contact Name")
            {
                tbxVendorContactName.Text = string.Empty;
            }
        }


        /// <summary>
        ///Creator:            Mitchell Stirmel
        ///Created:            02/13/2024
        ///Summary:            Changes an empty string to the default info
        ///Last Updated By:    Mitchell Stirmel
        ///Last Updated:       02/13/2024
        ///What Was Changed:   Initial Creation
        /// </summary>
        private void tbxVendorContactName_LostFocus(object sender, RoutedEventArgs e)
        {
            if (tbxVendorContactName.Text.Equals(string.Empty))
            {
                tbxVendorContactName.Text = "Vendor Contact Name";
            }
        }


        /// <summary>
        ///Creator:            Mitchell Stirmel
        ///Created:            02/13/2024
        ///Summary:            Changes to an empty string when clicked if default info is present
        ///Last Updated By:    Mitchell Stirmel
        ///Last Updated:       02/13/2024
        ///What Was Changed:   Initial Creation
        /// </summary>
        private void tbxVendorAddr_GotFocus(object sender, RoutedEventArgs e)
        {
            if (tbxVendorAddr.Text == "Vendor Address")
            {
                tbxVendorAddr.Text = string.Empty;
            }
        }


        /// <summary>
        ///Creator:            Mitchell Stirmel
        ///Created:            02/13/2024
        ///Summary:            Changes an empty string to the default info
        ///Last Updated By:    Mitchell Stirmel
        ///Last Updated:       02/13/2024
        ///What Was Changed:   Initial Creation
        /// </summary>
        private void tbxVendorAddr_LostFocus(object sender, RoutedEventArgs e)
        {
            if (tbxVendorAddr.Text.Equals(string.Empty))
            {
                tbxVendorAddr.Text = "Vendor Address";
            }
        }


        /// <summary>
        ///Creator:            Mitchell Stirmel
        ///Created:            02/13/2024
        ///Summary:            Changes to an empty string when clicked to add info
        ///Last Updated By:    Mitchell Stirmel
        ///Last Updated:       02/13/2024
        ///What Was Changed:   Initial Creation
        /// </summary>
        private void tbxVendorPhone_GotFocus(object sender, RoutedEventArgs e)
        {
            if (tbxVendorPhone.Text == "Vendor Phone")
            {
                tbxVendorPhone.Text = string.Empty;
            }
        }


        /// <summary>
        ///Creator:            Mitchell Stirmel
        ///Created:            02/13/2024
        ///Summary:            Changes an empty string to the default info
        ///Last Updated By:    Mitchell Stirmel
        ///Last Updated:       02/13/2024
        ///What Was Changed:   Initial Creation
        /// </summary>
        private void tbxVendorPhone_LostFocus(object sender, RoutedEventArgs e)
        {
            if (tbxVendorPhone.Text.Equals(string.Empty))
            {
                tbxVendorPhone.Text = "Vendor Phone";
            }
        }


        /// <summary>
        ///Creator:            Mitchell Stirmel
        ///Created:            02/13/2024
        ///Summary:            Changes to an empty string when clicked if default info is present
        ///Last Updated By:    Mitchell Stirmel
        ///Last Updated:       02/13/2024
        ///What Was Changed:   Initial Creation
        /// </summary>
        private void tbxVendorEmail_GotFocus(object sender, RoutedEventArgs e)
        {
            if (tbxVendorEmail.Text == "Vendor Email")
            {
                tbxVendorEmail.Text = string.Empty;
            }
        }


        /// <summary>
        ///Creator:            Mitchell Stirmel
        ///Created:            02/13/2024
        ///Summary:            Changes an empty string to show what the box is for
        ///Last Updated By:    Mitchell Stirmel
        ///Last Updated:       02/13/2024
        ///What Was Changed:   Initial Creation
        /// </summary>
        private void tbxVendorEmail_LostFocus(object sender, RoutedEventArgs e)
        {
            if (tbxVendorEmail.Text.Equals(string.Empty))
            {
                tbxVendorEmail.Text = "Vendor Email";
            }
        }


        /// <summary>
        ///Creator:            Mitchell Stirmel
        ///Created:            02/13/2024
        ///Summary:            Sends the text if it is all valid to be created as a new vendor.
        ///Last Updated By:    Mitchell Stirmel
        ///Last Updated:       04/11/2024
        ///What Was changed:   Added try catch
        /// </summary>
        private void btnAddVendor_Click(object sender, RoutedEventArgs e)
        {
            if (tbxVendorName.Text.Equals(string.Empty) || tbxVendorName.Text.Equals("Vendor Company Name"))
            {
                MessageBox.Show("Please input a vendor name", "Invalid", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (tbxVendorContactName.Text.Equals(string.Empty) || tbxVendorContactName.Text.Equals("Vendor Contact Name"))
            {
                MessageBox.Show("Please input a vendor contact name", "Invalid", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (tbxVendorAddr.Text.Equals(string.Empty) || tbxVendorAddr.Text.Equals("Vendor Address"))
            {
                MessageBox.Show("Please input a vendor address", "Invalid", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (tbxVendorPhone.Text.Equals(string.Empty) || tbxVendorPhone.Text.Equals("Vendor Phone"))
            {
                MessageBox.Show("Please input a vendor phone number", "Invalid", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (tbxVendorEmail.Text.Equals(string.Empty) || tbxVendorEmail.Text.Equals("Vendor Email") || !tbxVendorEmail.Text.Contains("@") || !tbxVendorEmail.Text.Contains("."))
            {
                MessageBox.Show("Please input a valid vendor email address", "Invalid", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            //If all valid

            Vendor vendor = new Vendor
            {
                Address = tbxVendorAddr.Text,
                Email = tbxVendorEmail.Text,
                Name = tbxVendorName.Text,
                ContactName = tbxVendorContactName.Text,
                PhoneNumber = tbxVendorPhone.Text,
            };
            try
            {
                if (_mainManager.VendorDataManager.AddVendor(vendor))
                {
                    MessageBox.Show("Vendor successfully added.", "Added", MessageBoxButton.OK, MessageBoxImage.Information);
                    Reset();
                }
                else
                {
                    MessageBox.Show("Vendor failed to be added.", "Failure", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Vendor failed to be added.", "Failure", MessageBoxButton.OK, MessageBoxImage.Error);
            }



        }

        /// <summary>
        ///Creator:            Mitchell Stirmel
        ///Created:            02/14/2024
        ///Summary:            Sets everything to default text.
        ///Last Updated By:    Mitchell Stirmel
        ///Last Updated:       02/14/2024
        ///What Was Changed:   Initial Creation
        /// </summary>
        public void Reset()
        {
            tbxVendorName.Text = "Vendor Company Name";
            tbxVendorContactName.Text = "Vendor Contact Name";
            tbxVendorAddr.Text = "Vendor Address";
            tbxVendorPhone.Text = "Vendor Phone";
            tbxVendorEmail.Text = "Vendor Email";
        }
    }
}
