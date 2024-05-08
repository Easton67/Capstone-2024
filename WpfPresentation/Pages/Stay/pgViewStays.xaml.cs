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
using WpfPresentation.UtilWindows;

namespace WpfPresentation.Pages.Stay {
    /// <summary>
    /// Creator: Jared Harvey          
    /// Created: 02/29/2024
    /// Summary: View the shelter stays
    /// Last Updated By: Jared Harvey 
    /// Last Updated: 02/29/2024
    /// What Was Changed: Inital creation
    /// </summary>
    public partial class pgViewStays : Page {
        MainManager _manager;
        List<StayVM> _stays = new List<StayVM>();
        string _shelterID;
        public pgViewStays(string shelterID) {
            _manager = MainManager.GetMainManager();
            _shelterID = shelterID;
            InitializeComponent();
            _stays = _manager.StayManager.GetAllStaysForShelter("Test Homeless Shelter");
            cbxClient.ItemsSource = _manager.UserManager.GetAllClients();
            cbxRoom.ItemsSource = _manager.RoomManager.GetRoomsByShelterID(shelterID);
        }

        private static pgViewStays pgViewStaysPage = null;

        public static pgViewStays GetViewStaysPage(string shelterID) {
            return pgViewStaysPage ?? (pgViewStaysPage = new pgViewStays(shelterID));
        }

        private void Page_Loaded(object sender, RoutedEventArgs e) {
            _stays = _manager.StayManager.GetAllStaysForShelter("Test Homeless Shelter");
            cbxClient.ItemsSource = _manager.UserManager.GetAllClients();
            cbxRoom.ItemsSource = _manager.RoomManager.GetRoomsByShelterID(_shelterID);
            UpdateStayList();
        }

        /// <summary>
        /// Creator: Jared Harvey          
        /// Created: 02/29/2024
        /// Summary: Removes the primary key ugliness
        /// Last Updated By: Jared Harvey 
        /// Last Updated: 02/29/2024
        /// What Was Changed: Inital creation
        /// </summary>
        private void FormatDataGrid() {
            if (dgViewStays.ItemsSource == null) {
                if (dgViewStays.Columns.Count != 5) {
                    dgViewStays.Columns.RemoveAt(1);
                    dgViewStays.Columns.RemoveAt(2);
                    dgViewStays.Columns[0].Header = "Room #";
                    dgViewStays.Columns[1].Header = "Client Email";
                    dgViewStays.Columns[2].Header = "In Date";
                    dgViewStays.Columns[3].Header = "Out Date";
                    dgViewStays.Columns[4].Header = "Is Checked Out";
                }
            }
        }

        /// <summary>
        /// Creator: Jared Harvey          
        /// Created: 02/29/2024
        /// Summary: Updates the stay list to meet the rules of the filters
        /// Last Updated By: Jared Harvey 
        /// Last Updated: 02/29/2024
        /// What Was Changed: Inital creation
        /// </summary>
        private void UpdateStayList() {
            List<StayVM> filteredStays = _stays;
            if(cbxClient.SelectedItem != null) {
                Client client = (Client)cbxClient.SelectedItem;
                filteredStays = filteredStays.Where(x => x.ClientID == client.UserID).ToList();
            }
            if(cbxRoom.SelectedItem != null) {
                RoomVM room = (RoomVM)cbxRoom.SelectedItem;
                filteredStays = filteredStays.Where(x => x.RoomID == room.RoomID).ToList();
            }
            if(dpInDate.SelectedDate != null) {
                DateTime? dt = dpInDate.SelectedDate;
                filteredStays = filteredStays.Where(x => x.InDate == dt).ToList();
            }
            if (dpOutDate.SelectedDate != null) {
                DateTime? dt = dpOutDate.SelectedDate;
                filteredStays = filteredStays.Where(x => x.OutDate == dt).ToList();
            }
            dgViewStays.ItemsSource = filteredStays;
            FormatDataGrid();
        }

        #region boringstuff

        private void cbxClient_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            UpdateStayList();
        }

        private void cbxRoom_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            UpdateStayList();
        }

        private void dpInDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e) {
            UpdateStayList();
        }

        private void dpOutDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e) {
            UpdateStayList();
        }

        private void btnClearClient_Click(object sender, RoutedEventArgs e) {
            cbxClient.SelectedItem = null;
        }

        private void btnClearRoom_Click(object sender, RoutedEventArgs e) {
            cbxRoom.SelectedItem = null;
        }

        private void btnClearInDate_Click(object sender, RoutedEventArgs e) {
            dpInDate.SelectedDate = null;
        }

        private void btnClearOutDate_Click(object sender, RoutedEventArgs e) {
            dpOutDate.SelectedDate = null;
        }

        #endregion boringstuff

        private void btnAddStay_Click(object sender, RoutedEventArgs e) {

        }

        /// <summary>
        /// Creator: Jared Harvey          
        /// Created: 02/29/2024
        /// Summary: btnEditStay click handler, opens EditStay util window
        /// Last Updated By: Jared Harvey 
        /// Last Updated: 02/29/2024
        /// What Was Changed: Inital creation
        /// </summary>
        private void btnEditStay_Click(object sender, RoutedEventArgs e) {
            if(dgViewStays.SelectedItem == null) {
                MessageBox.Show("You must select a stay to edit.");
                return;
            }
            StayVM stay = dgViewStays.SelectedItem as StayVM;
            try {
                EditStay editStay = new EditStay(stay, _shelterID);
                bool? result = editStay.ShowDialog();
                if(result == true) {
                    _stays = _manager.StayManager.GetAllStaysForShelter(_shelterID);
                    UpdateStayList();
                    MessageBox.Show("Successfully edited stay.");
                }
            } catch (Exception ex) {
                MessageBox.Show("Failed to edit stay.", ex.Message);
            }
        }

        /// <summary>
        /// Creator: Jared Harvey          
        /// Created: 02/29/2024
        /// Summary: btnRemoveStay click handler, prompts user just in case
        /// Last Updated By: Jared Harvey 
        /// Last Updated: 02/29/2024
        /// What Was Changed: Inital creation
        /// </summary>
        private void btnRemoveStay_Click(object sender, RoutedEventArgs e) {
            if(dgViewStays.SelectedItem == null) {
                MessageBox.Show("You must select a stay to remove.");
                return;
            }
            StayVM stay = dgViewStays.SelectedItem as StayVM;
            var result = MessageBox.Show("Are you sure that you want to permanently delete " + stay.ClientID + "'s stay?", "Confirm", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (result == MessageBoxResult.Yes) {
                try {
                    if (_manager.StayManager.RemoveStay(stay.StayID)) {
                        _stays = _manager.StayManager.GetAllStaysForShelter(_shelterID);
                        UpdateStayList();
                    }
                } catch (Exception ex) {
                    MessageBox.Show("Failed to remove stay.", ex.Message);
                }
            }
        }
    }
}
