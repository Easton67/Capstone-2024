using DataAccessInterfaces;
using DataObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessFakes {
    /// <summary>
    /// Creator: Jared Harvey
    /// Created: 03/02/2024
    /// Summary: This class accesses the fake room records for testing
    /// Last Updated By: Jared Harvey
    /// Last Updated: 03/02/2024
    /// What Was Changed: Initial Creation
    /// </summary>
    public class RoomAccessorFakes : IRoomAccessor
    {
        public List<RoomVM> fakeRooms = new List<RoomVM>();

        /// <summary>
        /// Creator: Jared Harvey
        /// Created: 03/03/2024
        /// Summary: This constructor populates the fakeRooms list
        /// Last Updated By: Jared Harvey
        /// Last Updated: 03/03/2024
        /// What Was Changed: Initial Creation
        /// </summary>
        private List<string> fake_room_status_list = new List<string>();
        public RoomAccessorFakes() {
            fake_room_status_list.Add("Avilable");
            fake_room_status_list.Add("Need Mantenece");
            fake_room_status_list.Add("Clean");
            fake_room_status_list.Add("Dirty");
            fake_room_status_list.Add("UnAvilable");
            fakeRooms.Add(new RoomVM() {
                RoomID = 100000,
                ShelterID = "Test Homeless Shelter",
                RoomNumber = 101,
                Status = "Dirty"
            });
            fakeRooms.Add(new RoomVM() {
                RoomID = 100001,
                ShelterID = "Test Homeless Shelter",
                RoomNumber = 102,
                Status = "In Cleaning"
            });
            fakeRooms.Add(new RoomVM() {
                RoomID = 100002,
                ShelterID = "Test Homeless Shelter",
                RoomNumber = 201,
                Status = "Clean"
            });
            fakeRooms.Add(new RoomVM() {
                RoomID = 100003,
                ShelterID = "Test Homeless Shelter",
                RoomNumber = 202,
                Status = "Needs Inspected"
            });
            fakeRooms.Add(new RoomVM() {
                RoomID = 100004,
                ShelterID = "Test Homeless Shelter #2",
                RoomNumber = 203,
                Status = "Under Maintenance"
            });
            fakeRooms.Add(new RoomVM() {
                RoomID = 100005,
                ShelterID = "Test Homeless Shelter #2",
                RoomNumber = 101,
                Status = "Dirty"
            });
            fakeRooms.Add(new RoomVM() {
                RoomID = 100006,
                ShelterID = "Test Homeless Shelter #2",
                RoomNumber = 102,
                Status = "In Cleaning"
            });
            fakeRooms.Add(new RoomVM() {
                RoomID = 100007,
                ShelterID = "Test Homeless Shelter #2",
                RoomNumber = 201,
                Status = "Clean"
            });
            fakeRooms.Add(new RoomVM() {
                RoomID = 100008,
                ShelterID = "Test Homeless Shelter #2",
                RoomNumber = 202,
                Status = "Needs Inspected"
            });
            fakeRooms.Add(new RoomVM() {
                RoomID = 100009,
                ShelterID = "Test Homeless Shelter #2",
                RoomNumber = 203,
                Status = "Under Maintenance"
            });
        }

        /// <summary>
        /// Creator: Jared Harvey
        /// Created: 03/03/2024
        /// Summary: The implementation of SelectRoomsByShelterID
        /// Last Updated By: Jared Harvey
        /// Last Updated: 03/03/2024
        /// What Was Changed: Initial Creation
        /// </summary>
        public List<RoomVM> SelectRoomsByShelterID(string shelterID) {
            return fakeRooms.Where(x => x.ShelterID == shelterID).ToList();
        }

        /// <summary>
        /// Creator: Kirsten Stage
        /// Created: 02/01/2024
        /// Summary: The implementation of CreateRoom() used for testing. 
        /// Last Updated By: Kirsten Stage
        /// Last Updated: 02/01/2024
        /// What Was Changed: Initial Creation
        /// </summary>

        public int CreateRoom(Room room) {
            int rows = 0;

            for (int i = 0; i < fakeRooms.Count; i++) {
                if (fakeRooms[i].RoomID.GetType() == typeof(int) &&
                    fakeRooms[i].ShelterID.GetType() == typeof(string) &&
                    fakeRooms[i].RoomNumber.GetType() == typeof(int) &&
                    fakeRooms[i].Status.GetType() == typeof(string)) {
                    rows = 1;
                }
            }

            return rows;
        }

        /// <summary>
        /// Creator: Kirsten Stage
        /// Created: 02/01/2024
        /// Summary: The implementation of SelectAllShelterID() used for testing.
        /// Last Updated By: Kirsten Stage
        /// Last Updated: 02/01/2024
        /// What Was Changed: Initial Creation
        /// </summary>

        public List<string> SelectAllShelterID() {
            List<string> shelterID = new List<string>();

            foreach (RoomVM room in fakeRooms) {
                shelterID.Add(room.ShelterID);
            }

            return shelterID;
        }

        /// <summary>
        /// Creator: Kirsten Stage
        /// Created: 02/01/2024
        /// Summary: The implementation of SelectAllStatus() used for testing.
        /// Last Updated By: Kirsten Stage
        /// Last Updated: 02/01/2024
        /// What Was Changed: Initial Creation
        /// </summary>

        public List<string> SelectAllStatus() {
            List<string> status = new List<string>();

            foreach (RoomVM room in fakeRooms) {
                status.Add(room.Status);
            }

            return status;
        }

        /// <summary>
        ///Creator:Suliman Adam Suliman
        ///Created: 01/26/2024
        ///Summary: Created a Interaction logic that rerurn a RoomVM List.
        ///Last Updated By: Suliman Adam Suliman
        ///Last Updated: 01/26/2024
        ///What Was Changed: Initial Creation
        /// </summary>
        public List<RoomVM> SelectRooms() {
            return fakeRooms;
        }

        /// <summary>
        ///Creator:Suliman Adam Suliman
        ///Created: 01/26/2024
        ///Summary: Created a Constructor that retrurn a boolean.
        ///Last Updated By: Suliman Adam Suliman
        ///Last Updated: 01/26/2024
        ///What Was Changed: Initial Creation
        /// </summary>
        public bool updateRoom(RoomVM newRoom) {
            return true;
        }

        /// <summary>
        /// Creator: Jared Harvey
        /// Created: 03/01/2024
        /// Summary: The implementation of SelectAvailableRooms
        /// Last Updated By: Jared Harvey
        /// Last Updated: 03/01/2024
        /// What Was Changed: Initial Creation
        /// </summary>
        public List<RoomVM> SelectAvailableRooms(string shelterID) {
            return fakeRooms.Where(x => x.ShelterID == shelterID && x.Status == "Available").ToList();
        }

        /// <summary>
        /// Creator: Jared Harvey
        /// Created: 03/01/2024
        /// Summary: The implementation of UpdateRoomStatus
        /// Last Updated By: Jared Harvey
        /// Last Updated: 03/01/2024
        /// What Was Changed: Initial Creation
        /// </summary>
        public int UpdateRoomStatus(int roomID, string status) {
            int result = 0;
            try {
                RoomVM room = fakeRooms.Find(x => x.RoomID == roomID);
                room.Status = status;
                result += 1;
            } catch (Exception ex) {
                throw ex;
            }
            return result;
		}
		
        // <summary>
        ///Creator:Suliman Adam Suliman
        ///Created: 02/16/2024
        ///Summary: Created a DeactivateRoom Method that pass a Room as parameter and
        ///return boonlean result.
        ///Last Updated By: NA
        ///Last Updated: NA
        ///What Was Changed: NA
        /// </summary>
        public bool DeactivateRoom(RoomVM room)
        {
            if (room.RoomID == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Room GetRoom(int roomID) {
            throw new NotImplementedException();
		}
		
        // <summary>
        ///Creator:Miyada Abas
        ///Created: 03/22/2024
        ///Summary: Created a Update status Room Method.
        ///Last Updated By: NA
        ///Last Updated: NA
        ///What Was Changed: NA
        /// </summary>
        public bool updatestatus(Room room)
        {
            foreach (RoomVM roomVM in fakeRooms)
            {
                if (roomVM.RoomNumber == room.RoomNumber) roomVM.Status = room.Status;
                return true;
            }
            return false;
        }

        public List<string> get_all_room_status()
        {
            return fake_room_status_list;
        }

        public Room SelectRoomByRoomNumber(int roomNumber, string shelterID) {
            throw new NotImplementedException();
        }
    }
}
