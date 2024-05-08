using DataObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer {
    /// <summary>
    /// Creator: Jared Harvey
    /// Created: 02/19/2024
    /// Summary: Creation of StayManager interface
    /// Last Updated By: Jared Harvey
    /// Last Updated: 02/19/2024
    /// What Was Changed: Initial Creation
    /// </summary>
    public interface IStayManager {
        /// <summary>
        /// Creator: Jared Harvey
        /// Created: 02/19/2024
        /// Summary: Method definition for AddStay
        /// Last Updated By: Jared Harvey
        /// Last Updated: 02/19/2024
        /// What Was Changed: Initial Creation
        /// </summary>
        bool AddStay(string clientID, int roomID);
        /// <summary>
        /// Creator: Jared Harvey
        /// Created: 02/19/2024
        /// Summary: Method definition for EditStay
        /// Last Updated By: Jared Harvey
        /// Last Updated: 02/19/2024
        /// What Was Changed: Initial Creation
        /// </summary>
        bool EditStay(Stay oldStay, Stay newStay);
        /// <summary>
        /// Creator: Jared Harvey
        /// Created: 02/29/2024
        /// Summary: Method definition for RemoveStay
        /// Last Updated By: Jared Harvey
        /// Last Updated: 02/29/2024
        /// What Was Changed: Initial Creation
        /// </summary>
        bool RemoveStay(int stayID);
        /// <summary>
        /// Creator: Jared Harvey
        /// Created: 02/29/2024
        /// Summary: Method definition for GetAllStaysForShelter
        /// Last Updated By: Jared Harvey
        /// Last Updated: 02/29/2024
        /// What Was Changed: Initial Creation
        /// </summary>
        List<StayVM> GetAllStaysForShelter(string shelterID);
        /// <summary>
        /// Creator: Jared Harvey
        /// Created: 03/22/2024
        /// Summary: Method definition for GetStay
        /// Last Updated By: Jared Harvey
        /// Last Updated: 03/22/2024
        /// What Was Changed: Initial Creation
        /// </summary>
        Stay GetStay(int stayID);
    }
}
