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
using System.Windows.Shapes;

namespace WpfPresentation.UtilWindows {
    /// <summary>
    /// Interaction logic for CreateRequest.xaml
    /// </summary>
    public partial class CreateRequest : Window {
        private MainManager _manager;
        private Room _room;
        private List<string> requestTypes = new List<string>() { "Housekeeping", "Maintenance" };
        private List<string> urgencyList = new List<string>() { "Low", "Moderate", "High" };
        public CreateRequest(Room room) {
            _manager = MainManager.GetMainManager();
            _room = room;
            InitializeComponent();
            lblHeader.Content = lblHeader.Content.ToString() + _room.RoomNumber + ":";
            cbxRequestType.ItemsSource = requestTypes;
            cbxUrgency.ItemsSource = urgencyList;
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e) {
            this.Close();
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e) {
            if (cbxRequestType.SelectedItem == null) {
                MessageBox.Show("Please select what type of request you're making");
                return;
            }
            if (tbxReason.Text.Length == 0) {
                MessageBox.Show("Please provide a reason for making this request. Make it as descriptive as possible");
                return;
            }
            try {
                string requestType = cbxRequestType.SelectedItem.ToString();
                if (requestType == "Maintenance") {
                    if (cbxUrgency.SelectedItem == null) {
                        MessageBox.Show("Please choose an urgency that reflects the urgency of your request.");
                        return;
                    }
                    if (!ValidationHelpers.IsValidPhoneNumber(tbxPhone.Text)) {
                        MessageBox.Show("Please format your phone number accordingly\n xxx-xxx-xxxx");
                        return;
                    }
                    string urgency = cbxUrgency.SelectedItem.ToString();
                    // create a maintenance request
                    MaintenanceRequest request = new MaintenanceRequest() {
                        _roomID = _room.RoomID,
                        _phone = tbxPhone.Text,
                        _urgency = urgency,
                        _requestor = _manager.LoggedInUser.UserID,
                        _description = tbxReason.Text
                    };
                    if(_manager.MaintenanceRequestManager.CreateMaintenanceRequest(request)) {
                        DialogResult = true;
                    }
                } else if (requestType == "Housekeeping") {
                    // create a housekeeping task
                    HousekeepingTask task = new HousekeepingTask() {
                        RoomID = _room.RoomID,
                        Type = "Requested Cleaning",
                        Description = tbxReason.Text
                    };
                    if(_manager.HousekeepingTaskManager.CreateHousekeepingTask(task)) {
                        DialogResult = true;
                    }
                }
            } catch (Exception ex) {
                throw ex;
            }
        }

        private void cbxRequestType_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            if(cbxRequestType.SelectedItem != null) {
                string type = cbxRequestType.SelectedItem.ToString();
                if (type == "Maintenance") {
                    spUrgency.Visibility = Visibility.Visible;
                    spPhone.Visibility = Visibility.Visible;
                } else {
                    spUrgency.Visibility = Visibility.Collapsed;
                    spPhone.Visibility = Visibility.Collapsed;
                }
            }
        }
    }
}
