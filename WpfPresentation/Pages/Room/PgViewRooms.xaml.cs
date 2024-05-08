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
using DataObjects;
using LogicLayer;
using WpfPresentation.UtilWindows;


namespace WpfPresentation.Pages.Rooms {

    /// <summary>
    ///Creator:Suliman Adam Suliman
    ///Created: 02/26/2024
    ///Summary: Created an Interaction logic for PgViewRooms.xaml.
    ///Last Updated By: Suliman Adam Suliman
    ///Last Updated: 01/26/2024
    ///What Was Changed: No changes.
    /// </summary>

    public partial class PgViewRooms : Page {
        public string status;
        List<string> statusList = new List<string>();

        public string _shelterID = null;

        private static PgViewRooms instance = null;

        public static PgViewRooms GetViewRoomsPage() {
            if (instance == null) {
                instance = new PgViewRooms();
            }

            return instance;
        }

        /// <summary>
        ///Creator:Suliman Adam Suliman
        ///Created: 02/26/2024
        ///Summary: Created a class for RoomManager and emplemented roomManager.
        ///Last Updated By: Jared Harvey
        ///Last Updated: 02/28/2024
        ///What Was Changed: Now using main manager
        /// </summary>
        private MainManager _manager;
        public PgViewRooms() {
            _shelterID = "Test Homeless Shelter";
            InitializeComponent();
            _manager = MainManager.GetMainManager();
            statusList = _manager.RoomManager.GetRoomStatusForDropDown();
            statusList.Insert(0, "All");
            cbxRoomStatus.ItemsSource = statusList;
            cbxRoomStatus.SelectedIndex = 0;
            cbxRoomStatus.SelectedItem = status;
            cbxShelter.ItemsSource = _manager.RoomManager.GetShelterIDForDropDown();
            cbxShelter.SelectedItem = _shelterID;
        }

        /// <summary>
        ///Creator:Suliman Adam Suliman
        ///Created: 02/26/2024
        ///Summary: Created a Interaction logic to get the new room list.
        ///Last Updated By: Jared Harvey
        ///Last Updated: 02/28/2024
        ///What Was Changed: Now using main manager and filters rooms
        /// </summary>
        public void fillRoomsGrid(string status, string shelterID) {
            List<RoomVM> rooms = new List<RoomVM>();
            rooms = _manager.RoomManager.GetRoomsByShelterID(shelterID);
            if (status == "All") {
                dgViewRooms.ItemsSource = rooms;
                return;
            }
            dgViewRooms.ItemsSource = rooms.Where(x => x.Status == status);
        }
        /// <summary>
        ///Creator:Suliman Adam Suliman
        ///Created: 01/26/2024
        ///Summary: Created an Interaction logic for btnEditRoom.xaml.
        ///Last Updated By: Suliman Adam Suliman
        ///Last Updated: 01/26/2024
        ///What Was Changed: No changes.
        /// </summary>
        private void btnEditRoom_Click(object sender, RoutedEventArgs e) {
            if (dgViewRooms.SelectedItem == null) {
                MessageBox.Show("Please Select Room");
                return;
            }
            lblErrorMessage.Content = "";
            RoomVM room = (RoomVM)dgViewRooms.SelectedItem;
            PgEditRoom pgEditRoom = new PgEditRoom(room, this);
            pgEditRoom.Show();
        }

        /// <summary>
        /// Creator:Jared Harvey
        /// Created: 02/28/2024
        /// Summary: Click handler for btnAssignClient
        /// Last Updated By: Jared Harvey
        /// Last Updated: 02/28/2024
        /// What Was Changed: Initial Creation
        /// </summary>
        private void btnAssignClient_Click(object sender, RoutedEventArgs e) {
            if (dgViewRooms.SelectedItem == null) {
                MessageBox.Show("You must select a room to assign a client to");
                return;
            }
            DataObjects.Room room = (DataObjects.Room)dgViewRooms.SelectedItem;
            if (room.Status != "Available") {
                MessageBox.Show("You can't assign a client to a room that isn't available.");
                return;
            }
            AssignClientShelter assignClientShelter = new AssignClientShelter(room.RoomID);
            bool? result = assignClientShelter.ShowDialog();
            if (result == true) {
                MessageBox.Show("Successfully added client to room");
                fillRoomsGrid(status, _shelterID);
            }
        }

        /// <summary>
        /// Creator:Jared Harvey
        /// Created: 02/28/2024
        /// Summary: Selection changed handler for cbxRoomStatus
        /// Last Updated By: Jared Harvey
        /// Last Updated: 02/28/2024
        /// What Was Changed: Initial Creation
        /// </summary>
        private void cbxRoomStatus_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            if (cbxRoomStatus.SelectedItem == null) {
                return;
            }
            status = cbxRoomStatus.SelectedItem.ToString();
            fillRoomsGrid(status, _shelterID);
        }

        private void btnFileRequest_Click(object sender, RoutedEventArgs e) {
            if (dgViewRooms.SelectedItem == null) {
                MessageBox.Show("You must select a room to file a request.");
                return;
            }
            DataObjects.Room room = (DataObjects.Room)dgViewRooms.SelectedItem;
            CreateRequest createRequest = new CreateRequest(room);
            bool? result = createRequest.ShowDialog();
            if (result == true) {
                MessageBox.Show("Successfully submitted the request.");
            }
        }

        /// <summary>
        /// Creator: Kirsten Stage
        /// Created: 02/29/2024
        /// Summary: Created the interaction logic for btnCreateRoom
        /// Last Updated By: Kirsten Stage
        /// Last Updated: 02/29/2024
        /// What Was Changed: Initial Creation
        /// </summary>
        private void btnCreateRoom_Click(object sender, RoutedEventArgs e) {
            NavigationService.Navigate(new pgCreateRoom());
        }

        /// <summary>
        /// Creator: Kirsten Stage
        /// Created: 02/29/2024
        /// Summary: Created the interaction logic for btnExit
        /// Last Updated By: Kirsten Stage
        /// Last Updated: 02/29/2024
        /// What Was Changed: Initial Creation
        /// </summary>
        private void btnExit_Click(object sender, RoutedEventArgs e) {
            new MainWindow().Show();
        }


        /// <summary>
        ///Creator:Suliman Adam Suliman
        ///Created: 02/02/2024
        ///Summary: Created a btnFliterByStatus_Click method that 
        ///for button filter and return void.
        ///Last Updated By: Suliman Adam Suliman
        ///Last Updated: 02/02/2024
        ///What Was Changed: No changes.
        /// </summary>
        //private void btnFliterByStatus_Click(object sender, RoutedEventArgs e)
        //{
        //    _manager.RoomManager.RefreshFilterList();
        //    if (cmbRoomStatus.SelectedItem == null)
        //    {
        //        MessageBox.Show("Please pick a filter option!");
        //    }

        //    if (cmbRoomStatus.Text == "Available")
        //    {
        //        try
        //        {
        //            dgViewRooms.ItemsSource = _manager.RoomManager.GetAvailableRoomList();
        //        }
        //        catch (Exception ex)
        //        {

        //            throw ex;
        //        }

        //    }
        //    if (cmbRoomStatus.Text == "Occupied")
        //    {
        //        try
        //        {
        //            dgViewRooms.ItemsSource = _manager.RoomManager.GetOccupiedRoomList();
        //        }
        //        catch (Exception ex)
        //        {

        //            throw ex;
        //        }

        //    }

        //    if (cmbRoomStatus.Text == "Needs Maintenance")
        //    {
        //        try
        //        {
        //            dgViewRooms.ItemsSource = _manager.RoomManager.GetNeedsMaintenanceRoomList();
        //        }
        //        catch (Exception ex)
        //        {

        //            throw ex;
        //        }

        //    }
        //    if (cmbRoomStatus.Text == "Needs Housekeeping")
        //    {
        //        try
        //        {
        //            dgViewRooms.ItemsSource = _manager.RoomManager.GetNeedsHousekeepingList();
        //        }
        //        catch (Exception ex)
        //        {

        //            throw ex;
        //        }

        //    }
        //    if (cmbRoomStatus.Text == "Deactivated")
        //    {
        //        try
        //        {
        //            dgViewRooms.ItemsSource = roomManager.GetDeactivatedList();
        //        }
        //        catch (Exception ex)
        //        {

        //            throw ex;
        //        }

        //    }
        //}


        /// <summary>
        ///Creator:Suliman Adam Suliman
        ///Created: 02/02/2024
        ///Summary: Created abtnAllRooms_Click method for all rooms and return void.
        ///Last Updated By: Suliman Adam Suliman
        ///Last Updated: 02/02/2024
        ///What Was Changed: No changes.
        /// </summary>
        //private void btnAllRooms_Click(object sender, RoutedEventArgs e) {
        //    fillRoomsGrid();
        //    cmbRoomStatus.SelectedIndex = 0;
        //}
        /// <summary>
        ///Creator:Suliman Adam Suliman
        ///Created: 02/02/2024
        ///Summary: Created Page_Loaded method that pass object and 
        ///RoutedEventArgs as a parameters and return void.
        ///Last Updated By: Suliman Adam Suliman
        ///Last Updated: 02/02/2024
        ///What Was Changed: No changes.
        /// </summary>

        //private void Page_Loaded(object sender, RoutedEventArgs e)
        //{
        //    fillRoomsGrid();
        //    cmbRoomStatus.Items.Add(" ");
        //    cmbRoomStatus.Items.Add("Available");
        //    cmbRoomStatus.Items.Add("Deactivated");
        //    cmbRoomStatus.Items.Add("Occupied");
        //    cmbRoomStatus.Items.Add("Needs Maintenance");
        //    cmbRoomStatus.Items.Add("Needs Housekeeping");

        //}

        /// <summary>
        ///Creator:Suliman Adam Suliman
        ///Created: 02/02/2024
        ///Summary: Created DeactivateRoom_Click method that pass object sender and 
        ///RoutedEventArgs as a parameters and return void.
        ///Last Updated By: Suliman Adam Suliman
        ///Last Updated: 02/02/2024
        ///What Was Changed: No changes.
        /// </summary>
        private void DeactivateRoom_Click(object sender, RoutedEventArgs e) {
            if (dgViewRooms.SelectedItem == null) {
                MessageBox.Show("Please select a room to deactivat!");
                return;
            }

            RoomVM _room = new RoomVM();
            _room = (RoomVM)dgViewRooms.SelectedItem;
            if (_room.Status == "Deactivated") {
                MessageBox.Show("This room is already deactivated");
                return;
            }
            try {
                _manager.RoomManager.DeactivateRoom(_room);
                MessageBox.Show("Room Deactivated successfully!");
                fillRoomsGrid(status, _shelterID);
            } catch (Exception ex) {

                throw ex;
            }
        }

        private void cbxShelter_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            if(cbxShelter.SelectedItem != null) {
                _shelterID = cbxShelter.SelectedItem.ToString();
            }
            fillRoomsGrid(status, _shelterID);
        }
    }
}
