using DataObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessInterfaces
{
    /// <summary>
    /// Creator: Kirsten Stage
    /// Created: 02/01/2024
    /// Summary: RoomVM Accessor Interface
    /// Last Updated By: Kirsten Stage
    /// Last Updated: 02/01/2024
    /// What Was Changed: Initial Creation
    /// </summary>
    public interface IRoomAccessor
    {
        Room GetRoom(int roomID);
        Room SelectRoomByRoomNumber(int roomNumber, string shelterID);
        List<string> SelectAllStatus();
        List<string> SelectAllShelterID();
        int CreateRoom(Room room);
		List<RoomVM> SelectRoomsByShelterID(string shelterID);
        
        /// <summary>
        ///Creator:Suliman Adam Suliman
        ///Created: 01/26/2024
        ///Summary: Created a Method that return a RoomVM List.
        ///Last Updated By: Suliman Adam Suliman
        ///Last Updated: 01/26/2024
        ///What Was Changed: Initial Creation
        /// </summary>
        List<RoomVM> SelectRooms();
        /// <summary>
        /// Creator:            Jared Harvey
        /// Created:            03/01/2024
        /// Summary:            Method definition for SelectAvailableRooms
        /// Last Updated By:    Jared Harvey
        /// Last Updated:       03/01/2024
        /// What Was Changed:   Initial Creation
        /// </summary>
        List<RoomVM> SelectAvailableRooms(string shelterID);

        /// <summary>
        /// Creator:            Jared Harvey
        /// Created:            03/01/2024
        /// Summary:            Method definition for UpdateRoomStatus
        /// Last Updated By:    Jared Harvey
        /// Last Updated:       03/01/2024
        /// What Was Changed:   Initial Creation
        /// </summary>
        int UpdateRoomStatus(int roomID, string status);
        /// <summary>
        ///Creator:Suliman Adam Suliman
        ///Created: 02/16/2024
        ///Summary: Created a updateRoom Method that returns Boolean.
        ///Last Updated By:NA
        ///Last Updated: NA
        ///What Was Changed: NA
        /// </summary>
        bool updateRoom(RoomVM newRoom);

        /// <summary>
        ///Creator:Suliman Adam Suliman
        ///Created: 02/16/2024
        ///Summary: Created a DeactivateRoom Method that returns Boolean.
        ///Last Updated By:NA
        ///Last Updated: NA
        ///What Was Changed: NA
        /// </summary>
        bool DeactivateRoom(RoomVM room);

        /// <summary>
        ///Creator:Miyada Abas
        ///Created: 02/16/2024
        ///Summary: Created a Update Room status Method that returns Boolean.
        ///Last Updated By:NA
        ///Last Updated: NA
        ///What Was Changed: NA
        /// </summary>
        bool updatestatus(Room room);
        List<string> get_all_room_status();
    }
}
