using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataObjects {
    /// <summary>
    /// Creator: Kirsten Stage
    /// Created: 02/01/2024
    /// Summary: This class represents the rooms contained within our shelters.
    /// Last Updated By: Kirsten Stage
    /// Last Updated: 02/01/2024
    /// What Was Changed: Initial Creation
    /// </summary>

    public class Room {
        public int RoomID { get; set; }
        [DisplayName("Shelter")]
        public string ShelterID { get; set; }
        [DisplayName("Room #")]
        public int RoomNumber { get; set; }
        public string Status { get; set; }
    }

    /// <summary>
    /// Creator: Jared Harvey
    /// Created: 02/06/2024
    /// Summary: A model that inherits from RoomVM but can store extra values from other tables in the database.
    /// Last Updated By: Jared Harvey
    /// Last Updated: 02/06/2024
    /// What Was Changed: Initial Creation
    /// </summary>
    public class RoomVM : Room {

    }
}
