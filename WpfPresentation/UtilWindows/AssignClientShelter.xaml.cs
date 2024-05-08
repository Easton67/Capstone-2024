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

namespace WpfPresentation.UtilWindows {
    /// <summary>
    /// Creator:            Jared Harvey
    /// Created:            02/23/2024
    /// Summary:            Creation of AssignClientShelter
    /// Last Updated By:    Jared Harvey
    /// Last Updated:       02/23/2024
    /// What Was Changed:   Creation of AssignClientShelter
    /// </summary>
    public partial class AssignClientShelter : Window {
        MainManager _manager = null;
        private Regex _numericalRegex = new Regex("[^0-9]+");
        private List<Client> _clients = new List<Client>();
        private Client _selectedClient;
        private int _roomID;
        public AssignClientShelter(int roomID) {
            _manager = MainManager.GetMainManager();
            InitializeComponent();
            _clients = _manager.UserManager.GetAllClients();
            _roomID = roomID;
        }

        #region Sanitizing Text Inputs

        /// <summary>
        /// Creator:            Liam Easton
        /// Created:            02/13/2024
        /// Summary:            Creation of txtShiftStartHour_PreviewTextInput method
        /// Last Updated By:    Liam Easton
        /// Last Updated:       02/13/2024
        /// What Was Changed:   Creation of txtShiftStartHour_PreviewTextInput method
        /// </summary>
        private void txtShiftStartHour_PreviewTextInput(object sender, TextCompositionEventArgs e) {
            e.Handled = _numericalRegex.IsMatch(e.Text);
        }

        /// <summary>
        /// Creator:            Liam Easton
        /// Created:            02/13/2024
        /// Summary:            Creation of txtShiftStartMinute_PreviewTextInput method
        /// Last Updated By:    Liam Easton
        /// Last Updated:       02/13/2024
        /// What Was Changed:   Creation of txtShiftStartMinute_PreviewTextInput method
        /// </summary>
        private void txtShiftStartMinute_PreviewTextInput(object sender, TextCompositionEventArgs e) {
            e.Handled = _numericalRegex.IsMatch(e.Text);
        }

        /// <summary>
        /// Creator:            Liam Easton
        /// Created:            02/13/2024
        /// Summary:            Creation of txtShiftEndHour_PreviewTextInput method
        /// Last Updated By:    Liam Easton
        /// Last Updated:       02/13/2024
        /// What Was Changed:   Creation of txtShiftEndHour_PreviewTextInput method
        /// </summary>
        private void txtShiftEndHour_PreviewTextInput(object sender, TextCompositionEventArgs e) {
            e.Handled = _numericalRegex.IsMatch(e.Text);
        }

        /// <summary>
        /// Creator:            Liam Easton
        /// Created:            02/13/2024
        /// Summary:            Creation of txtShiftEndMinute_PreviewTextInput method
        /// Last Updated By:    Liam Easton
        /// Last Updated:       02/13/2024
        /// What Was Changed:   Creation of txtShiftEndMinute_PreviewTextInput method
        /// </summary>
        private void txtShiftEndMinute_PreviewTextInput(object sender, TextCompositionEventArgs e) {
            e.Handled = _numericalRegex.IsMatch(e.Text);
        }
        #endregion

        #region Search methods
        /// <summary>
        /// Creator:            Liam Easton
        /// Created:            02/13/2024
        /// Summary:            Creation of txtSearch_GotFocus method
        /// Last Updated By:    Liam Easton
        /// Last Updated:       02/13/2024
        /// What Was Changed:   Creation of txtSearch_GotFocus method
        /// </summary>
        private void txtSearch_GotFocus(object sender, RoutedEventArgs e) {
            if (txtSearch.Text.Replace(" ", "").Equals("Search")) {
                txtSearch.Text = "";
                lbFilteredEmployees.Visibility = Visibility.Visible;
            }
        }
        /// <summary>
        /// Creator:            Liam Easton
        /// Created:            02/13/2024
        /// Summary:            Creation of txtSearch_LostFocus method
        /// Last Updated By:    Liam Easton
        /// Last Updated:       02/13/2024
        /// What Was Changed:   Creation of txtSearch_LostFocus method
        /// </summary>
        private void txtSearch_LostFocus(object sender, RoutedEventArgs e) {
            if (txtSearch.Text.Equals("")) {
                txtSearch.Text = "Search";
                lbFilteredEmployees.Visibility = Visibility.Collapsed;
            }
        }
        /// <summary>
        /// Creator:            Liam Easton
        /// Created:            02/14/2024
        /// Summary:            Creation of txtSearch_TextChanged method
        /// Last Updated By:    Liam Easton
        /// Last Updated:       02/14/2024
        /// What Was Changed:   Creation of txtSearch_TextChanged method
        /// </summary>
        private void txtSearch_TextChanged(object sender, TextChangedEventArgs e) {
            if (txtSearch.Text != "Search") {
                List<Client> filteredEmployees = new List<Client>();
                filteredEmployees = _clients.Where(x => x.FirstName.ToLower().Contains(txtSearch.Text.ToLower())).ToList();
                lbFilteredEmployees.ItemsSource = filteredEmployees;
            }
        }
        #endregion

        /// <summary>
        /// Creator:            Liam Easton
        /// Created:            02/14/2024
        /// Summary:            Creation of lbFilteredEmployees_SelectionChanged method
        /// Last Updated By:    Liam Easton
        /// Last Updated:       02/14/2024
        /// What Was Changed:   Creation of lbFilteredEmployees_SelectionChanged method
        /// </summary>
        private void lbFilteredEmployees_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            if (lbFilteredEmployees.SelectedItem != null) {
                _selectedClient = (Client)lbFilteredEmployees.SelectedItem;
                txtSearch.Text = _selectedClient.UserID;
            }
        }

        /// <summary>
        /// Creator:            Jared Harvey
        /// Created:            02/20/2024
        /// Summary:            Creation of btnSubmitShift_Click method
        /// Last Updated By:    Jared Harvey
        /// Last Updated:       02/20/2024
        /// What Was Changed:   Creation of btnSubmitShift_Click method
        /// </summary>
        private void btnSubmit_Click(object sender, RoutedEventArgs e) {
            if (!txtSearch.Text.Equals("")) {
                try {
                    if(_manager.StayManager.AddStay(_selectedClient.UserID, _roomID)) {
                        DialogResult = true;
                    }
                } catch (Exception ex) {
                    MessageBox.Show("Error:", ex.Message);
                }
            } else {
                MessageBox.Show("Please select a client to assign this room to.");
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e) {
            this.Close();
        }
    }
}