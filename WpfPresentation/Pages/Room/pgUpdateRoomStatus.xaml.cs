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
using WpfPresentation.Pages.Applications;

namespace WpfPresentation.Pages.Room
{
    /// <Summary>
    /// Creator: Miyada Abas
    /// created: 03/22/2024
    /// Summary: creation of the pgUpdateRoomStatus method
    /// Last updated By: Miyada Abas
    /// Last Updated: 03/22/2024
    /// What was changed/updated: creation of the pgUpdateRoomStatus method
    /// Last updated By: Liam Easton    
    /// Last Updated: 04/11/2024
    /// What was changed/updated: 
    ///     added try catch around get_all_room_status()
    ///     added distinct to the list of statuses to only get unique values
    /// Last Updated By:    Mitchell Stirmel
    /// Last Updated:       04/11/2024
    /// What Was changed:   Added try catch
    /// </Summary>

    /// <summary>
    /// Interaction logic for pgUpdateRoomStatus.xaml
    /// </summary>
    public partial class pgUpdateRoomStatus : Page
    {
        private IRoomManager _roomManager;
        private DataObjects.Room room;
        private List<DataObjects.RoomVM> rooms;
        private List<string> room_status_list = new List<string>();

        private static pgUpdateRoomStatus _instance = null;

        public static pgUpdateRoomStatus GetPgUpdateRoomStatus()
        {
            return _instance ?? (_instance = new pgUpdateRoomStatus());
        }

        public pgUpdateRoomStatus()
        {
            InitializeComponent();
            _roomManager = new RoomManager();
            room = new DataObjects.Room();
            rooms = new List<DataObjects.RoomVM>();
            try
            {
                room_status_list = _roomManager.get_all_room_status().Distinct().ToList();
                txtRoomStatus.ItemsSource = room_status_list;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to get room statuses \n" + ex.ToString(), "Failure", MessageBoxButton.OK);
            }
            refreshDataGrid();
        }

        /// <Summary>
        /// Creator: Miyada Abas
        /// created:  03/22/2024
        /// Summary: creation of the pgUpdateRoomStatus method
        /// Last updated By: Miyada Abas
        /// Last Updated: 03/22/2024
        /// What was changed/updated: creation of the  pgUpdateRoomStatus method
        /// Last Updated By:    Mitchell Stirmel
        /// Last Updated:       04/11/2024
        /// What Was changed:   Added try catch
        /// </Summary>
        public void refreshDataGrid()
        {
            try
            {
                rooms = _roomManager.GetRoomsByShelterID("Test Homeless Shelter");
                dgRooms.ItemsSource = rooms; 
                dgRooms.SelectedIndex = 1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to get rooms \n" + ex.ToString(), "Failure", MessageBoxButton.OK);
            }
        }

        /// <Summary>
        /// Creator:Miyada Abas
        /// created:  03/22/2024
        /// Summary: creation of the pgUpdateRoomStatusmethod
        /// Last updated By:Miyada Abas
        /// Last Updated: 03/22/2024
        /// What was changed/updated: creation of the  pgUpdateRoomStatus method
        /// Last Updated By:    Mitchell Stirmel
        /// Last Updated:       04/11/2024
        /// What Was changed:   Added try catch
        /// </Summary>
        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            if (!dataValid())
            {
                return;
            }
            DataObjects.Room room = new DataObjects.Room();
            room.RoomID = Convert.ToInt32(txtRoomId.Text);
            room.Status = txtRoomStatus.Text;
            try
            {
                bool result = _roomManager.UpdateRoomstatus(room);
                if (result)
                {
                    lblErrorMessage.Content = "room Status update it correctly";
                    refreshDataGrid();
                }
                else
                {
                    lblErrorMessage.Content = "roomstatus did not update it";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to update room status \n" + ex.ToString(), "Failure", MessageBoxButton.OK);
            }

        }
        /// <Summary>
        /// Creator: Miyada Abas
        /// created: 03/22/2024
        /// Summary: creation of the RepopulateIncidents method
        /// Last updated By:Miyada Abas
        /// Last Updated: 03/22/2024
        /// What was changed/updated: creation of the RepopulateIncidents method
        /// </Summary>
        private bool dataValid()
        {
            if (txtRoomId.Text.Length == 0)
            {
                lblErrorMessage.Content = "RoomId is requird";
                return false;
            }
            
            lblErrorMessage.Content = "";
            return true;
        }
        /// <Summary>
        /// Creator: Miyada Abas
        /// created: 03/22/2024
        /// Summary: creation of the method
        /// Last updated Miyada Abas
        /// Last Updated: 03/22/2024
        /// What was changed/updated: creation of the RepopulateIncidents method
        /// </Summary>
        private void dgRooms_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            RoomVM roomsVM = new RoomVM();
            roomsVM = dgRooms.SelectedItem as RoomVM;
            txtRoomId.Text = roomsVM.RoomID.ToString();
            txtRoomStatus.Text = roomsVM.Status.ToString();
        }
    }
}
