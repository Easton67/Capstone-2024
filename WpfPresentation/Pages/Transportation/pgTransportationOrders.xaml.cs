using DataObjects;
using LogicLayer;
using Microsoft.VisualBasic.ApplicationServices;
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
using WpfPresentation.Pages.Security;

namespace WpfPresentation.Pages.Transportation
{
    /// <summary>
    /// Interaction logic for pgTransportationOrders.xaml
    /// </summary>
    public partial class pgTransportationOrders : Page
    {
        private MainManager _manager = MainManager.GetMainManager();
        private MainManager _mainManager;
        InternalUser _user;

        public pgTransportationOrders()
        {
            InitializeComponent();

            _mainManager = MainManager.GetMainManager();
            _user = _mainManager.LoggedInUser as InternalUser;
        }

        /// <Summary>
        /// Creator: Liam Easton
        /// created: 04/04/2024
        /// Summary: creation of the instance of the page
        /// Last updated By: Liam Easton
        /// Last Updated: 04/04/2024
        /// What was changed/updated: creation of the instance of the page
        /// </Summary>
        private static pgTransportationOrders TransportationOrders = null;

        public static pgTransportationOrders GetPgTransportationOrders()
        {
            return TransportationOrders ?? (TransportationOrders = new pgTransportationOrders());
        }

        /// <summary>
        /// Creator:            Liam Easton
        /// Created:            04/04/2024
        /// Summary:            Initial creation of the TransportationOrder Page_Loaded method.
        /// Last Updated By:    Liam Easton
        /// Last Updated:       04/04/2024
        /// What Was Changed:   Initial creation of the TransportationOrder Page_Loaded method.
        /// </summary>
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            RepopulateOrders();
        }

        /// <summary>
        /// Creator:            Liam Easton
        /// Created:            04/04/2024
        /// Summary:            Initial creation of the RepopulateOrders helper method.
        /// Last Updated By:    Liam Easton
        /// Last Updated:       04/04/2024
        /// What Was Changed:   Initial creation
        /// Last Updated By:    Ibrahim Albashair
        /// Last Updated:       04/19/2024
        /// What Was Changed:   Added Order By Driver
        /// </summary>
        private void RepopulateOrders()
        {
            try
            {
                grdOrders.ItemsSource = _manager.TransportationOrderManager.ViewAllTransportationOrders().Where(x => x.Fulfilled != true);
                grdOrdersByDriver.ItemsSource = _manager.TransportationOrderManager.ViewTransportationOrdersByDriver(_user.UserID);
            }
            catch (Exception)
            {
                MessageBox.Show("Unable to find orders, please try again", "Error");
            }
        }
        /// <summary>
        /// Creator:            Ibrahim Albashair
        /// Created:            04/04/2024
        /// Summary:            Initial creation of the btnCreateOrder_Click method.
        /// Last Updated By:    Ibrahim Albashair
        /// Last Updated:       04/04/2024
        /// What Was Changed:   Initial creation of the btnCreateOrder_Click method.
        /// </summary>

        private void btnCreateOrder_Click(object sender, RoutedEventArgs e)
        {
            var window =  new pgCreateOrder();
            window.ShowDialog();
            RepopulateOrders();
        }

        /// <summary>
        /// Creator:            Liam Easton
        /// Created:            04/04/2024
        /// Summary:            Initial creation of the txtSearchItem_GotFocus method.
        /// Last Updated By:    Liam Easton
        /// Last Updated:       04/04/2024
        /// What Was Changed:   Initial creation of the txtSearchItem_GotFocus method.
        /// </summary>
        private void txtSearchItem_GotFocus(object sender, RoutedEventArgs e)
        {
            if (txtSearchItem.Text.Equals("Search Item"))
            {
                txtSearchItem.Text = "";
            }
        }

        /// <summary>
        /// Creator:            Liam Easton
        /// Created:            04/04/2024
        /// Summary:            Initial creation of the txtSearchItem_LostFocus method.
        /// Last Updated By:    Liam Easton
        /// Last Updated:       04/04/2024
        /// What Was Changed:   Initial creation of the txtSearchItem_LostFocus method.
        /// </summary>
        private void txtSearchItem_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSearchItem.Text))
            {
                txtSearchItem.Text = "Search Item";
                RepopulateOrders();
            }
        }

        /// <summary>
        /// Creator:            Liam Easton
        /// Created:            04/04/2024
        /// Summary:            Initial creation of the txtSearchItem_TextChanged method
        /// Last Updated By:    Liam Easton
        /// Last Updated:       04/04/2024
        /// What Was Changed:   Initial creation of the txtSearchItem_TextChanged method
        /// </summary>
        private void txtSearchItem_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSearchItem.Text) || txtSearchItem.Text == "Search Item")
            {
                return;
            }
            else
            {
                grdOrders.ItemsSource = _manager.TransportationOrderManager
                                                .ViewAllTransportationOrders()
                                                .Where(x => x.TransportItem.ToLower().Contains(txtSearchItem.Text.ToLower()))
                                                .ToList();
            }
        }

        /// <summary>
        /// Creator:            Miyada Abas
        /// Created:            04/11/2024
        /// Summary:            Initial creation of the  method
        /// Last Updated By:    Miyada Abas
        /// Last Updated:       04/11/2024
        /// What Was Changed:   Initial creation of the Delete Transportation Order method
        /// </summary>
        private void btnDeleteOrder_Click(object sender, RoutedEventArgs e)
        {
            if (grdOrders.SelectedItem == null)
            {
                MessageBox.Show("Please Select An Order");
                return;
            }
            TransportationOrderVM transportation = grdOrders.SelectedItem as TransportationOrderVM;
            bool result = _manager.TransportationOrderManager.deleteOrder(transportation);
            if (result == true)
            {
                MessageBox.Show("Delete Order Is Done");
                RepopulateOrders();
            }
            else
            {
                MessageBox.Show("Delete Order Is Not Done");
            }
        }

        private void btnMyOrders_Click(object sender, RoutedEventArgs e)
        {
            if (grdOrdersByDriver.Visibility == Visibility.Visible)
            {
                btnMyOrders.Content = "My Orders";
                grdOrders.Visibility = Visibility.Visible;
                grdOrdersByDriver.Visibility = Visibility.Hidden;
            }
            else
            {
                btnMyOrders.Content = "All Orders";
                grdOrders.Visibility = Visibility.Hidden;
                grdOrdersByDriver.Visibility = Visibility.Visible;
                btnDeleteOrder.Visibility = Visibility.Visible;
            }
        }
        /// <summary>
        /// Creator:            Ibrahim Albashair
        /// Created:            04/04/2024
        /// Summary:            Initial creation of the btnDeleteOrder_Click method.
        /// Last Updated By:    Ibrahim Albashair
        /// Last Updated:       04/04/2024
        /// What Was Changed:   Initial creation of the btnDeleteOrder_Click method.
        /// </summary>

        private void btnDeleteMyOrder_Click(object sender, RoutedEventArgs e)
        {
            if (grdOrders.Visibility == Visibility.Visible)
            {
                MessageBox.Show("You may only delete orders from 'My Orders'");
                return;
            }
            if (grdOrdersByDriver.SelectedItem != null)
            {
                if (MessageBox.Show("Are you sure you want to delete this order?", "Confirmation", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    var order = grdOrdersByDriver.SelectedItem as TransportationOrder;

                    try
                    {
                        _manager.TransportationOrderManager.DeleteTransportOrder(order.TransportItemID);
                        RepopulateOrders();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Could not Delete Order");
                    }
                }
            }
            else { MessageBox.Show("Please Select an Order to Delete"); }
        }
    }
}
