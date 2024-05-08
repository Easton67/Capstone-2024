using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Linq;
using DataObjects;
using LogicLayer;
using MessageBox = System.Windows.Forms.MessageBox;

namespace WpfPresentation
{
    /// <summary>
    /// Creator: Kirsten Stage
    /// Created: 02/01/2024
    /// Summary: Interaction logic for pgCreateRoom.xaml
    /// Last Updated By: Kirsten Stage
    /// Last Updated: 02/01/2024
    /// What Was Changed: Initial Creation
    /// </summary>

    public partial class pgCreateRoom : Page
    {
        private static pgCreateRoom instance = null;

        public static pgCreateRoom GetCreateRoomPage()
        {
            if(instance == null)
            {
                instance = new pgCreateRoom();
            }

            return instance;
        }


        private RoomVM room = null;

        public pgCreateRoom(RoomVM r)
        {
            room = r;

            InitializeComponent();
        }

        public pgCreateRoom()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Creator: Kirsten Stage
        /// Created: 02/01/2024
        /// Summary: The "Cancel" button will close pgCreateRoom & no changes 
        ///          will be submitted. 
        /// Last Updated By: Kirsten Stage
        /// Last Updated: 02/01/2024
        /// What Was Changed: Initial Creation
        /// </summary>

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show("No changes will be made. Are you sure you'd like to cancel?", "Cancel Changes", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                NavigationService.Navigate(new Pages.Rooms.PgViewRooms());
            }
        }

        /// <summary>
        /// Creator: Kirsten Stage
        /// Created: 02/01/2024
        /// Summary: The "Create" button will submit the changes for creating
        ///          a new RoomVM. 
        /// Last Updated By: Kirsten Stage
        /// Last Updated: 02/01/2024
        /// What Was Changed: Initial Creation
        /// </summary>

        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            if(cboShelterID.Text == "")
            {
                MessageBox.Show("You need to choose a Shelter ID.");
                return;
            }
            if (txtRoomNumber.Text == "")
            {
                MessageBox.Show("You need to enter the Room Number.");
                return;
            }
            if(!txtRoomNumber.Text.All(Char.IsDigit))
            {
                MessageBox.Show("You need to enter the Room Number as a whole number only.");
                return;
            }
            if (cboStatus.Text == "")
            {
                MessageBox.Show("You need to choose a Room Status.");
                return;
            }

            var newRoom = new RoomVM()
            {
                ShelterID = cboShelterID.Text,
                RoomNumber = int.Parse(txtRoomNumber.Text),
                Status = cboStatus.Text
            };

            try
            {
                var rm = new RoomManager();
                bool result = rm.AddRoom(newRoom);
                MessageBox.Show("New Room Successfully Added.");

                NavigationService.Navigate(new Pages.Rooms.PgViewRooms());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n\n" + ex.InnerException.Message);
            }
        }

        /// <summary>
        /// Creator: Kirsten Stage
        /// Created: 02/01/2024
        /// Summary: The content that will display upon opening pgCreateRoom. 
        /// Last Updated By: Kirsten Stage
        /// Last Updated: 02/01/2024
        /// What Was Changed: Initial Creation
        /// </summary>

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                var roomManager = new RoomManager();
                cboStatus.ItemsSource = roomManager.GetRoomStatusForDropDown();
                cboShelterID.ItemsSource = roomManager.GetShelterIDForDropDown();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n\n" + ex.InnerException.Message);
            }
        }
    }
}
