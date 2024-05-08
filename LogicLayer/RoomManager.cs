using DataAccessInterfaces;
using DataAccessLayer;
using DataObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer
{
    /// <summary>
    /// Creator: Kirsten Stage
    /// Created: 02/01/2024
    /// Summary: RoomVM Manager class that implements IRoomManager interface
    /// Last Updated By: Kirsten Stage
    /// Last Updated: 02/01/2024
    /// What Was Changed: Initial Creation
    /// </summary>

    public class RoomManager : IRoomManager {
        private IRoomAccessor _roomAccessor = null;
        List<RoomVM> rooms = new List<RoomVM>();
        List<RoomVM> deactivatedrooms = new List<RoomVM>();
        List<RoomVM> availablerooms = new List<RoomVM>();
        List<RoomVM> occupiedrooms = new List<RoomVM>();
        List<RoomVM> needsMaintenancerooms = new List<RoomVM>();
        List<RoomVM> needsHousekeepingrooms = new List<RoomVM>();

        /// <summary>
        /// Creator: Kirsten Stage
        /// Created: 02/01/2024
        /// Summary: Created two constructors for dependency inversion.
        ///          One is for the presentation layer and one is for testing. 
        /// Last Updated By: Kirsten Stage
        /// Last Updated: 02/01/2024
        /// What Was Changed: Initial Creation
        /// </summary>

        public RoomManager()
        {
            _roomAccessor = new RoomAccessor();
            RefreshFilterList();
        }

        public RoomManager(IRoomAccessor roomAccessor)
        {
            _roomAccessor = roomAccessor;
        }

        /// <summary>
        /// Creator: Suliman Suliman 
        /// Created: 16/02/2024
        /// Summary: Created the RefreshFilterList() method that gets the updated
        /// List of rooms and returns nothing.
        ///Last Updated By:    Mitchell Stirmel
        ///Last Updated        04/10/2024
        ///What was changed:   Added try/catch and code cleanup
        /// </summary>
        public void RefreshFilterList()
        {
            try
            {
                rooms = _roomAccessor.SelectRooms();
                availablerooms.Clear();
                occupiedrooms.Clear();
                needsMaintenancerooms.Clear();
                needsHousekeepingrooms.Clear();
                deactivatedrooms.Clear();
                foreach (var room in rooms)
                {
                    if (room.Status == "Available")
                    {
                        availablerooms.Add(room);
                    }
                    if (room.Status == "Occupied")
                    {
                        occupiedrooms.Add(room);
                    }
                    if (room.Status == "Needs Maintenance")
                    {
                        needsMaintenancerooms.Add(room);
                    }
                    if (room.Status == "Needs Housekeeping")
                    {
                        needsHousekeepingrooms.Add(room);
                    }
                    if (room.Status == "Deactivated")
                    {
                        deactivatedrooms.Add(room);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Refresh failed", ex);
            }



        }
		
        /// <summary>
        /// Creator: Jared Harvey
        /// Created: 01/29/2024
        /// Summary: This method gets the list of rooms that belong to a given shelter.
        /// Parameters: string shelterID
        /// Returns: List<RoomVM>
        /// Last Updated By: Jared Harvey
        /// Last Updated: 01/29/2024
        /// What Was Changed: Initial Creation
        /// </summary>
        public List<RoomVM> GetRoomsByShelterID(string shelterID) {
            List<RoomVM> result = new List<RoomVM>();
            try {
                result = _roomAccessor.SelectRoomsByShelterID(shelterID);
            } catch (Exception ex) {
                throw ex;
            }
            return result;
        }
		
        /// Creator: Kirsten Stage
        /// Created: 02/01/2024
        /// Summary: Created the AddRoom() method. It takes a RoomVM 
        ///          object as a parameter. 
        /// Last Updated By: Kirsten Stage
        /// Last Updated: 02/01/2024
        /// What Was Changed: Initial Creation
        /// </summary>
        public bool AddRoom(Room room)
        {
            bool result = false;

            try
            {
                result = (1 == _roomAccessor.CreateRoom(room));
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Room not created.", ex);
            }
            return result;
        }

        /// <summary>
        /// Creator: Suliman Suliman
        /// Created: 01/26/2024
        /// Summary: Created the EditRoom() method. It takes a RoomVM 
        ///          object as a parameter. 
        /// Last Updated By: Suliman Suliman
        /// Last Updated: 01/26/2024
        /// What Was Changed: Initial Creation
        /// </summary>
        public bool EditRoom(RoomVM newRoom)
        {
            bool result = false;
            try
            {
                result = _roomAccessor.updateRoom(newRoom);
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return result;
        }


        /// <summary>
        /// Creator: Suliman Suliman
        /// Created: 01/26/2024
        /// Summary: Created the GetRoomList() method. It takes no
        /// parameter and return rooms. 
        /// Last Updated By: Suliman Suliman
        /// Last Updated: 01/26/2024
        /// What Was Changed: Initial Creation
        /// </summary>
        public List<RoomVM> GetRoomList()
        {
            List<RoomVM> rooms = new List<RoomVM>();
            try
            {
                rooms = _roomAccessor.SelectRooms();
                return rooms;
            }
            catch (Exception ex)
            {

                throw new ApplicationException("List is not Available", ex);
            }
        }

        /// <summary>
        /// Creator: Kirsten Stage
        /// Created: 02/01/2024
        /// Summary: Created the GetRoomStatusForDropDown() method.
        /// Last Updated By: Kirsten Stage
        /// Last Updated: 02/01/2024
        /// What Was Changed: Initial Creation
        /// </summary>
        public List<string> GetRoomStatusForDropDown()
        {
            List<string> statusList = null;

            try
            {
                statusList = _roomAccessor.SelectAllStatus();

                if (statusList == null || statusList.Count == 0)
                {
                    throw new ArgumentException("Statuses not found.");
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Not found.", ex);
            }
            return statusList;
        }

        /// <summary>
        /// Creator: Kirsten Stage
        /// Created: 02/01/2024
        /// Summary: Created the GetShelterIDForDropDown() method.
        /// Last Updated By: Kirsten Stage
        /// Last Updated: 02/01/2024
        /// What Was Changed: Initial Creation
        /// </summary>
        public List<String> GetShelterIDForDropDown()
        {
            List<string> typeList = null;

            try
            {
                typeList = _roomAccessor.SelectAllShelterID();

                if (typeList == null || typeList.Count == 0)
                {
                    throw new ArgumentException("Shelters not found.");
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Not found", ex);
            }
            return typeList;
        }
		
        /// <summary>
        /// Creator: Jared Harvey
        /// Created: 03/01/2024
        /// Summary: Implementation for GetAvailableRooms.
        /// Last Updated By: Jared Harvey
        /// Last Updated: 03/01/2024
        /// What Was Changed: Initial Creation
        /// </summary>
        public List<RoomVM> GetAvailableRooms(string shelterID) {
            List<RoomVM> result = new List<RoomVM>();
            try {
                result = _roomAccessor.SelectAvailableRooms(shelterID);
            } catch (Exception ex) {
                throw new ApplicationException("Not found", ex);
            }
            return result;
        }

        /// <summary>
        /// Creator: Jared Harvey
        /// Created: 03/01/2024
        /// Summary: Implementation for EditRoomStatus.
        /// Last Updated By: Jared Harvey
        /// Last Updated: 03/01/2024
        /// What Was Changed: Initial Creation
        /// </summary>
        public bool EditRoomStatus(int roomID, string status) {
            try {
                return 1 == _roomAccessor.UpdateRoomStatus(roomID, status);
            } catch (Exception ex) {
                throw ex;
            }
		}
		
        ///Last Updated By:    Mitchell Stirmel
        ///Last Updated        04/10/2024
        ///What was changed:   Added try/catch for these helper methods.
        public List<RoomVM> GetAvailableRoomList()
        {
            try
            {
                return availablerooms;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<RoomVM> GetOccupiedRoomList()
        {
            try
            {
                return occupiedrooms;
            }
            catch (Exception)
            {
                throw;
            }  
        }

        public List<RoomVM> GetNeedsMaintenanceRoomList()
        {
            try
            {
                return needsMaintenancerooms;
            }
            catch (Exception)
            {
                throw;
            }
               
        }

        public List<RoomVM> GetNeedsHousekeepingList()
        {
            try
            {
                return needsHousekeepingrooms;
            }
            catch (Exception)
            {
                throw;
            }
           
        }

        public List<RoomVM> GetDeactivatedList()
        {
            try
            {
                return deactivatedrooms;
            }
            catch (Exception)
            {
                throw;
            }
        }


        /// <summary>
        /// Creator: Suliman Suliman
        /// Created: 02/16/2024
        /// Summary: Created the DeactivateRoom() method.
        /// Last Updated By: Suliman Suliman
        /// Last Updated: 02/16/2024
        /// What Was Changed: Initial Creation
        /// </summary>
        public bool DeactivateRoom(RoomVM room)
        {
            bool result = false;
            try
            {
                result = _roomAccessor.DeactivateRoom(room);
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return result;
        }

        ///<summary>
        ///Creator:            Miyada Abas
        ///Created:            ???
        ///Summary:            Updates room status
        ///Last Updated By:    Mitchell Stirmel
        ///Last Updated        04/10/2024
        ///What was changed:   Added try/catch and code cleanup
        /// </summary>
        public bool UpdateRoomstatus(Room room)
        {
            try
            {
                return _roomAccessor.updatestatus(room);
            }
            catch (Exception)
            {

                throw;
            }
        }

        ///<summary>
        ///Creator:            Miyada Abas
        ///Created:            ???
        ///Summary:            Updates room status
        ///Last Updated By:    Mitchell Stirmel
        ///Last Updated        04/10/2024
        ///What was changed:   Added try/catch and code cleanup
        /// </summary>
        public List<string> get_all_room_status()
        {
            try
            {
                return _roomAccessor.get_all_room_status();
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Unable to get room statuses", ex);
            }
        }

        public Room GetRoomByRoomNumber(int roomNumber, string shelterID) {
            Room room = null;
            try {
                room = _roomAccessor.SelectRoomByRoomNumber(roomNumber, shelterID);
            } catch (Exception ex) {
                throw ex;
            }
            return room;
        }
    }
}
