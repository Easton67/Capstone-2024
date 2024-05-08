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
using WpfPresentation.Pages.Vendors;

namespace WpfPresentation.Pages.Supplier
{
    /// <summary>
    ///Creator:            Ethan McElree
    ///Created:            02/24/2024
    ///Summary:            Code behind file for the page where the user can edit information about the vendor.
    ///Last Updated By:    Ethan McElree
    ///Last Updated:       02/24/2024
    ///What Was Changed:   Initial Creation
    /// </summary> 
    public partial class pgEditSuppliers : Page
    {
        private IVendorDataManager vendorDataManager;

        /// <summary>
        ///Creator:            Ethan McElree
        ///Created:            02/28/2024
        ///Summary:            Creation of the pgEditSuppliers constructor.
        ///Last Updated By:    Ethan McElree
        ///Last Updated:       02/28/2024
        ///What Was Changed:   Initial Creation
        /// </summary> 
        public pgEditSuppliers(DataObjects.Vendor chosenSupplier)
        {
            InitializeComponent();
            tbxSupplierName.Text = chosenSupplier.Name;
            tbxSupplierContactName.Text = chosenSupplier.ContactName;
            tbxSupplierAddr.Text = chosenSupplier.Address;
            tbxSupplierPhone.Text = chosenSupplier.PhoneNumber;
            tbxSupplierEmail.Text = chosenSupplier.Email;
            vendorDataManager = new VendorDataManager();
        }

        /// <summary>
        ///Creator:            Ethan McElree
        ///Created:            02/28/2024
        ///Summary:            Code for getting the cancel button to work.
        ///Last Updated By:    Ethan McElree
        ///Last Updated:       03/22/2024
        ///What Was Changed:   This cancel button now navigates to the Retrieve supplier with name page.
        /// </summary> 
        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new pgRetrieveSupplierWithName());
        }

        /// <summary>
        ///Creator:            Ethan McElree
        ///Created:            02/28/2024
        ///Summary:            Code for getting the update supplier button to work.
        ///Last Updated By:    Ethan McElree
        ///Last Updated:       02/28/2024
        ///What Was Changed:   Initial Creation
        /// </summary> 
        private void btnEditSupplier_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string supplierName = tbxSupplierName.Text;
                string supplierContactName = tbxSupplierContactName.Text;
                string supplierAddress = tbxSupplierAddr.Text;
                string supplierPhone = tbxSupplierPhone.Text;
                string supplierEmail = tbxSupplierEmail.Text;
                vendorDataManager.UpdateSupplierInformation(supplierName, supplierAddress, supplierEmail, supplierPhone, supplierContactName);
                MessageBox.Show("Supplier has been updated.");
                NavigationService.Navigate(new pgVendors());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Creator: Ethan McElree
        /// Created: 03/1/2024
        /// Summary: Logic for navigation in the pgEditSuppliers file.
        /// Last Updated By: Ethan McElree
        /// Last Updated: 03/1/2024
        /// What Was Changed: Initial Creation
        /// </summary>
        private static pgEditSuppliers instance = null;
        public static pgEditSuppliers GetpgEditSuppliers(Vendor vendor)
        {
            return instance ?? (instance = new pgEditSuppliers(vendor));
        }
    }
}
