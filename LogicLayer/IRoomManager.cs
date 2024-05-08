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
    /// Summary: RoomVM Manager Interface
    /// Last Updated By: Kirsten Stage
    /// Last Updated: 02/01/2024
    /// What Was Changed: Initial Creation
    /// </summary>

    public interface IRoomManager
    {
        Room GetRoomByRoomNumber(int roomNumber, string shelterID);
        bool AddRoom(Room room);
        List<RoomVM> GetRoomsByShelterID(string shelterID);
        List<RoomVM> GetRoomList();
        bool EditRoom(RoomVM room);
        List<string> GetRoomStatusForDropDown();
        /// <summary>
        /// Creator:            Jared Harvey
        /// Created:            03/01/2024
        /// Summary:            Method definition for GetAvailableRooms
        /// Last Updated By:    Jared Harvey
        /// Last Updated:       03/01/2024
        /// What Was Changed:   Initial Creation
        /// </summary>
        List<RoomVM> GetAvailableRooms(string shelterID);
        /// <summary>
        /// Creator:            Jared Harvey
        /// Created:            03/01/2024
        /// Summary:            Method definition for EditRoomStatus
        /// Last Updated By:    Jared Harvey
        /// Last Updated:       03/01/2024
        /// What Was Changed:   Initial Creation
        /// </summary>
        bool EditRoomStatus(int roomID, string status);
        /// <summary>
        /// Creator:Suliman Suliman
        /// Created: 16/02/2024
        /// Summary: Created GetAvailableRoomList Method that returns 
        /// GetAvailableRoomList.
        /// Last Updated By: 
        /// Last Updated: 
        /// What Was Changed: Initial Creation
        /// </summary>
        List<RoomVM> GetAvailableRoomList();

        /// <summary>
        /// Creator:Suliman Suliman
        /// Created: 16/02/2024
        /// Summary: Created GetOccupiedRoomList Method that returns 
        /// GetOccupiedRoomList.
        /// Last Updated By: 
        /// Last Updated: 
        /// What Was Changed: Initial Creation
        /// </summary>
        List<RoomVM> GetOccupiedRoomList();

        /// <summary>
        /// Creator:Suliman Suliman
        /// Created: 16/02/2024
        /// Summary: Created GetNeedsMaintenanceRoomList Method that returns 
        /// GetNeedsMaintenanceRoomList.
        /// Last Updated By: 
        /// Last Updated: 
        /// What Was Changed: Initial Creation
        /// </summary>
        List<RoomVM> GetNeedsMaintenanceRoomList();

        /// <summary>
        /// Creator:Suliman Suliman
        /// Created: 16/02/2024
        /// Summary: Created GetNeedsHousekeepingList Method that returns 
        /// GetNeedsHousekeepingList.
        /// Last Updated By: 
        /// Last Updated: 
        /// What Was Changed: Initial Creation
        /// </summary>
        List<RoomVM> GetNeedsHousekeepingList();
        /// <summary>
        /// Creator:Suliman Suliman
        /// Created: 16/02/2024
        /// Summary: Created GetDeactivatedList Method that returns 
        /// GetDeactivatedList.
        /// Last Updated By: 
        /// Last Updated: 
        /// What Was Changed: Initial Creation
        /// </summary>
        List<RoomVM> GetDeactivatedList();

        /// <summary>
        /// Creator:Suliman Suliman
        /// Created: 16/02/2024
        /// Summary: Created RefreshFilterList Method that returns void.
        /// Last Updated By: 
        /// Last Updated: 
        /// What Was Changed: Initial Creation
        /// </summary>
        void RefreshFilterList();

        /// <summary>
        /// Creator:Suliman Suliman
        /// Created: 16/02/2024
        /// Summary: Created DeactivateRoom Method that returns bool.
        /// Last Updated By: 
        /// Last Updated: 
        /// What Was Changed: Initial Creation
        /// </summary>
        bool DeactivateRoom(RoomVM room);

        /// <summary>
        /// Creator:Miyada Abas
        /// Created: 03/22/2024
        /// Summary: Created GetRoomsByShelterID Method return string.
        /// Last Updated By: 
        /// Last Updated: 
        /// What Was Changed: Initial Creation
        /// </summary>
        bool UpdateRoomstatus(Room room);
        List<string> get_all_room_status();

        List<string> GetShelterIDForDropDown();
    }
}
