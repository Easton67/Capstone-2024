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
    /// Created:            03/01/2024
    /// Summary:            Creation of EditStay class
    /// Last Updated By:    Jared Harvey
    /// Last Updated:       03/01/2024
    /// What Was Changed:   Creation of EditStay class
    /// </summary>
    public partial class EditStay : Window {
        MainManager _manager = null;
        private Regex _numericalRegex = new Regex("[^0-9]+");
        private List<Client> _clients = new List<Client>();
        private Client _selectedClient;
        private StayVM _stay;
        string _shelterID;
        public EditStay(StayVM stay, string shelterID) {
            _manager = MainManager.GetMainManager();
            _shelterID = shelterID;
            _stay = stay;
            InitializeComponent();
            _clients = _manager.UserManager.GetAllClients();
            txtSearch.Text = _stay.ClientID;
            _selectedClient = _clients.Find(x => x.UserID == _stay.ClientID);
            lbFilteredClients.SelectedItem = _selectedClient;
            
            List<RoomVM> rooms = _manager.RoomManager.GetAvailableRooms(_shelterID);
            RoomVM room = new RoomVM() {
                RoomID = _stay.RoomID,
                RoomNumber = _stay.RoomNumber
            };
            rooms.Add(room);
            cbxRoom.ItemsSource = rooms;
            cbxRoom.SelectedItem = room;

            dpInDate.SelectedDate = _stay.InDate;
            dpOutDate.SelectedDate = _stay.OutDate;

            cbCheckedOut.IsChecked = _stay.CheckedOut;
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
                lbFilteredClients.Visibility = Visibility.Visible;
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
                lbFilteredClients.Visibility = Visibility.Collapsed;
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
                lbFilteredClients.ItemsSource = filteredEmployees;
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
        private void lbFilteredClients_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            if (lbFilteredClients.SelectedItem != null) {
                _selectedClient = (Client)lbFilteredClients.SelectedItem;
                txtSearch.Text = _selectedClient.UserID;
            }
        }

        /// <summary>
        /// Creator:            Jared Harvey
        /// Created:            02/20/2024
        /// Summary:            Creation of btnSubmit_Click method
        /// Last Updated By:    Jared Harvey
        /// Last Updated:       02/20/2024
        /// What Was Changed:   Creation of btnSubmit_Click method
        /// </summary>
        private void btnSubmit_Click(object sender, RoutedEventArgs e) {
            if (txtSearch.Text.Equals("")) {
                MessageBox.Show("You must select a client");
                return;
            }
            if (cbxRoom.SelectedItem == null) {
                MessageBox.Show("You must select a room");
                return;
            }
            if (dpInDate.SelectedDate == null) {
                MessageBox.Show("You must select a check-in date");
                return;
            }
            if (dpOutDate.SelectedDate == null) {
                MessageBox.Show("You must select a check-out date");
                return;
            }

            try {
                StayVM newStay = new StayVM() {
                    StayID = _stay.StayID,
                    ClientID = _selectedClient.UserID,
                    RoomID = ((RoomVM)cbxRoom.SelectedItem).RoomID,
                    InDate = (DateTime)dpInDate.SelectedDate,
                    OutDate = (DateTime)dpOutDate.SelectedDate,
                    CheckedOut = cbCheckedOut.IsChecked == null ? false : (bool)cbCheckedOut.IsChecked,
                };
                if (_manager.StayManager.EditStay(_stay, newStay)) {
                    DialogResult = true;
                }
            } catch (Exception ex) {
                MessageBox.Show("Error:", ex.Message);
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e) {
            this.Close();
        }
    }
}
