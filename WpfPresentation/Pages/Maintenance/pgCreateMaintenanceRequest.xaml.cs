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
using WpfPresentation.Pages.Rooms;

namespace WpfPresentation.Pages.Maintenance
{
    /// <summary>
    /// Interaction logic for pgCreateMaintenanceRequest.xaml
    /// </summary>
    public partial class pgCreateMaintenanceRequest : Page
    {
        private IMaintenanceRequestManager maintenanceRequestManager;
        private IRoomManager _roomManager;
        private List<RoomVM> rooms = new List<RoomVM>();
        private List<int> roomsIds = new List<int>();

        public pgCreateMaintenanceRequest()
        {
            _roomManager = new RoomManager();
            InitializeComponent();
            maintenanceRequestManager = new MaintenanceRequestManager();
            getRoomIds();

        }
        public void getRoomIds()
        {
            rooms = _roomManager.GetRoomList();

            for (int i = 0; i < rooms.Count; i++)
            {
                roomsIds.Add(rooms[i].RoomID);
            }
            cmbRoomID.ItemsSource = roomsIds;
        }

        ///Last Updated By:    Mitchell Stirmel
        ///Last Updated:       04/11/2024
        ///What Was changed:   Added try catch
        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            if (!IsFormValid())
            {
                return;
            }
            MaintenanceRequest maintenanceRequest = new MaintenanceRequest();
            maintenanceRequest._roomID = (int)cmbRoomID.SelectedValue;
            maintenanceRequest._status = txtStatus.Text;
            maintenanceRequest._requestor = txtRequester.Text;
            maintenanceRequest._phone = txtPhone.Text;
            maintenanceRequest._dateCreated = DateTime.Now;
            maintenanceRequest._description = txtDescription.Text;
            try
            {
                bool result = maintenanceRequestManager.CreateMaintenanceRequest(maintenanceRequest);
                if (result)
                {
                    MessageBox.Show("Create Maintenance Request done Correctly");
                    NavigationService.Navigate(new pgMaintenanceRequests());
                }
                else
                {
                    MessageBox.Show("Maintenance Request created incorrectly ");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to create request \n" + ex.ToString(), "Failure", MessageBoxButton.OK);
            }

        }

        private bool IsFormValid()
        {
            if (cmbRoomID.SelectedValue == null)
            {
                lblErrorMessage.Content = "RoomID is required";
                return false;
            }
            if (txtStatus.Text.Length == 0)
            {
                lblErrorMessage.Content = "Status is required";
                return false;
            }
            if (txtRequester.Text.Length == 0)
            {
                lblErrorMessage.Content = "Requester is required";
                return false;
            }
            if (txtPhone.Text.Length == 0)
            {
                lblErrorMessage.Content = "Phone is required";
                return false;
            }


            if (txtDescription.Text.Length == 0)
            {
                lblErrorMessage.Content = "Description is required";
                return false;
            }

            lblErrorMessage.Content = string.Empty;
            return true;
        }
    }
}
