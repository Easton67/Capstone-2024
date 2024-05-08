using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Automation.Peers;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using DataObjects;
using LogicLayer;

namespace WpfPresentation.Pages.Rooms
{
    /// <summary>
    ///Creator:Suliman Adam Suliman
    ///Created: 02/26/2024
    ///Summary: Created an Interaction logic for PgEditRoom.xaml
    ///Last Updated By: Suliman Suliman
    ///Last Updated: 02/26/2024
    ///What Was Changed: Initial Creation
    /// </summary>
    public partial class PgEditRoom : Window
    {
        private RoomVM room;
        private RoomManager roomManager;
        private PgViewRooms pgViewRooms;

        /// <summary>
        ///Creator:Suliman Adam Suliman
        ///Created: 02/26/2024
        ///Summary: Created a Constructor that pass RoomVM and PgViewRooms as a parameters
        ///Last Updated By: Suliman Suliman
        ///Last Updated: 02/26/2024
        ///What Was Changed: Initial Creation
        /// </summary>
        public PgEditRoom(RoomVM room, PgViewRooms pgViewRooms)
        {
            InitializeComponent();
            this.room = room;
            roomManager = new RoomManager();
            InitializeRoomForm();
            this.pgViewRooms = pgViewRooms;

        }
        /// <summary>
        ///Creator:Suliman Adam Suliman
        ///Created: 02/26/2024
        ///Summary: Created InitializeRoom Method that return Void result
        ///Last Updated By: Suliman Suliman
        ///Last Updated: 02/26/2024
        ///What Was Changed: Initial Creation
        /// </summary>
        private void InitializeRoomForm()
        {
           
            cmbStatus.Items.Add("Available");
            cmbStatus.Items.Add("Occupied");
            cmbStatus.Items.Add("Needs Maintenance");
            cmbStatus.Items.Add("Needs Housekeeping");
            cmbStatus.Items.Add("Deactivated");
            txtRoomNumber.Text = room.RoomNumber.ToString();
           txtShelterID.Text = room.ShelterID.ToString();
           cmbStatus.Text = room.Status.ToString();
        }
        /// <summary>
        ///Creator:Suliman Adam Suliman
        ///Created: 02/26/2024
        ///Summary: Created a Void Method that send an object sender and RoutEventArgs as an arguments.
        ///Last Updated By:    Mitchell Stirmel
        ///Last Updated:       04/11/2024
        ///What Was changed:   Added try catch
        /// </summary>
        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            if (!dataIsValid())
            {
                return;
            }
            cmbStatus.IsEnabled = true;
            RoomVM  newRoom = new RoomVM();
            newRoom.RoomID = room.RoomID;
            newRoom.ShelterID = txtShelterID.Text;
            newRoom.RoomNumber = Convert.ToInt32(txtRoomNumber.Text);
            newRoom.Status = cmbStatus.Text;
            try
            {
                bool result = roomManager.EditRoom(newRoom);
                if (result)
                {
                    lblErrorMessage.Content = "Room Data Updated Conrectly";
                    pgViewRooms.fillRoomsGrid("All", pgViewRooms._shelterID);
                    this.Close();
                }
                else
                {
                    lblErrorMessage.Content = "Room Did not Updated";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to update room \n" + ex.ToString(), "Failure", MessageBoxButton.OK) ;
            }
            

        }

        /// <summary>
        ///Creator:Suliman Adam Suliman
        ///Created: 02/26/2024
        ///Summary: Created a private Method that return Boolean
        ///Last Updated By: Suliman Suliman
        ///Last Updated: 02/26/2024
        ///What Was Changed: Initial Creation
        /// </summary>

        private bool dataIsValid()
        {
            if (txtShelterID.Text.Length == 0)
            {
                lblErrorMessage.Content = "Please Enter ShelterID";
                return false;
            }

            if (txtRoomNumber.Text.Length == 0)
            {
                lblErrorMessage.Content = "Please Enter Room Number";
                return false;
            }

            if (cmbStatus.Text.Length == 0)
            {
                lblErrorMessage.Content = "Please Enter The Status";
                return false;
            }


            if (!(Convert.ToInt32(txtRoomNumber.Text) > 0))
            {
                lblErrorMessage.Content = "RoomNumber Must Be a Number";
                return false;
            }

           // lblErrorMessage.Content = " ";
            return true;

        }
    }
}
