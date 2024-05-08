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
using System.Windows.Shapes;

namespace WpfPresentation.Pages.Transportation
{
    /// <summary>
    /// Creator:            Ibrahim Albashair
    /// Created:            04/19/2024
    /// Summary:            Initial creation of the pgCreateOrder page.
    /// Last Updated By:    Ibrahim Albashair
    /// Last Updated:       04/19/2024
    /// What Was Changed:   Initial creation of the pgCreateOrder page.
    /// </summary>
    public partial class pgCreateOrder : Window
    {
        TransportationOrderManager _orderManager = null;
        public pgCreateOrder()
        {
            InitializeComponent();

            _orderManager = new TransportationOrderManager();
        }

        /// <summary>
        /// Creator:            Ibrahim Albashair
        /// Created:            04/19/2024
        /// Summary:            Initial creation of the btnCancel_Click method.
        /// Last Updated By:    Ibrahim Albashair
        /// Last Updated:       04/19/2024
        /// What Was Changed:   Initial creation of the btnCancel_Click method.
        /// </summary>
        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }      

        /// <summary>
        /// Creator:            Ibrahim Albashair
        /// Created:            04/19/2024
        /// Summary:            Initial creation of the CreateOrder method.
        /// Last Updated By:    Ibrahim Albashair
        /// Last Updated:       04/19/2024
        /// What Was Changed:   Initial creation of the createOrder method.
        /// </summary>
        private TransportationOrder CreateOrder() 
        {
            TransportationOrder order = new TransportationOrder()
            {
                ClientID = txtClientID.Text,
                LocationID = Int32.Parse(txtLocationID.Text),
                DayPosted = datePickerDayPosted.DisplayDate,
                DayDroppedOff = datePickerDayDroppedOff.DisplayDate,
                DayToPickUp = datePickerDayToPickUp.DisplayDate,
                AssignedDriver = txtAssignedDriver.Text,
                Fulfilled = false
            };
            return order;
        }
        
        /// <summary>
        /// Creator:            Ibrahim Albashair
        /// Created:            04/19/2024
        /// Summary:            Initial creation of the btnCreate_Click method.
        /// Last Updated By:    Ibrahim Albashair
        /// Last Updated:       04/19/2024
        /// What Was Changed:   Initial creation of the btnCreate_Click method.
        /// </summary>
        private void btnCreate_Click_1(object sender, RoutedEventArgs e)
        {
            if (checkFields())
            {
                try
                {
                    _orderManager.CreateTransportOrder(CreateOrder());
                    MessageBox.Show("Order Created!");
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Could not Create Order");
                }
            }
            else { MessageBox.Show("Invalid Inputs"); }
        }


        /// <summary>
        /// Creator:            Ibrahim Albashair
        /// Created:            04/19/2024
        /// Summary:            Initial creation of the Regex methods.
        /// Last Updated By:    Ibrahim Albashair
        /// Last Updated:       04/19/2024
        /// What Was Changed:   Initial creation of the Regex methods.
        /// </summary>
        #region Regex and Validation

        private bool checkFields()
        {
            if (txtClientID.Text != null && txtLocationID.Text != null && datePickerDayDroppedOff != null && datePickerDayPosted != null && datePickerDayToPickUp != null &&
                    txtAssignedDriver.Text != null) 
            {
                if (txtClientID.Text != "Enter Client ID (Email)" && txtLocationID.Text != "Enter Location ID (Number)" &&
                    txtAssignedDriver.Text != "Enter Driver ID (Email)")
                {
                    return true;
                }
                else { return false; }
            }
            else { return false; }
        }
        private void txtLocationID_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void txtClientID_GotFocus(object sender, RoutedEventArgs e)
        {
            txtClientID.Clear();
        }

        private void txtLocationID_GotFocus(object sender, RoutedEventArgs e)
        {
            txtLocationID.Clear();
        }

        private void txtAssignedDriver_GotFocus(object sender, RoutedEventArgs e)
        {
            txtAssignedDriver.Clear();
        }

        private void txtClientID_LostFocus(object sender, RoutedEventArgs e)
        {
            if (txtClientID.Text.Replace(" ", "") == null) 
            {
                txtClientID.Text = "Enter Client ID (Email)";
            }
        }

        private void txtLocationID_LostFocus(object sender, RoutedEventArgs e)
        {
            if (txtLocationID.Text.Replace(" ", "") == null)
            {
                txtLocationID.Text = "Enter LocationID (Number)";
            }
        }

        private void txtAssignedDriver_LostFocus(object sender, RoutedEventArgs e)
        {
            if (txtAssignedDriver.Text.Replace(" ", "") == null)
            {
                txtAssignedDriver.Text = "Enter Driver ID (Email)";
            }
        }
        #endregion
    }
}