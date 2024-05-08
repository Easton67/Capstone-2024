using DataObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessInterfaces {
    /// <summary>
    /// Creator:            Jared Harvey
    /// Created:            02/19/2024
    /// Summary:            Creation of IStayAccessor interface
    /// Last Updated By:    Jared Harvey
    /// Last Updated:       02/19/2024
    /// What Was Changed:   Initial Creation
    /// Last Updated By:    Matthew Baccam
    /// Last Updated:       03/07/2024
    /// What Was Changed:   Added SelectActiveStayByClientID
    /// </summary>
    public interface IStayAccessor {
        /// <summary>
        /// Creator:            Jared Harvey
        /// Created:            02/19/2024
        /// Summary:            Method definition for InsertStay
        /// Last Updated By:    Jared Harvey
        /// Last Updated:       02/19/2024
        /// What Was Changed:   Initial Creation
        /// </summary>
        int InsertStay(string clientID, int roomID);

        /// <summary>
        /// Creator:            Jared Harvey
        /// Created:            02/28/2024
        /// Summary:            Method definition for UpdateStay
        /// Last Updated By:    Jared Harvey
        /// Last Updated:       02/28/2024
        /// What Was Changed:   Initial Creation
        /// </summary>
        int UpdateStay(Stay oldStay, Stay newStay);

        /// <summary>
        /// Creator:            Jared Harvey
        /// Created:            02/29/2024
        /// Summary:            Method definition for DeleteStay
        /// Last Updated By:    Jared Harvey
        /// Last Updated:       02/29/2024
        /// What Was Changed:   Initial Creation
        /// </summary>
        int DeleteStay(int stayID);

        /// <summary>
        /// Creator:            Jared Harvey
        /// Created:            02/29/2024
        /// Summary:            Method definition for SelectAllStays
        /// Last Updated By:    Jared Harvey
        /// Last Updated:       02/29/2024
        /// What Was Changed:   Initial Creation
        /// </summary>
        List<StayVM> SelectAllStaysForShelter(string shelterID);

        /// <summary>
        /// Creator:            Jared Harvey
        /// Created:            03/22/2024
        /// Summary:            Method definition for SelectStayByStayID
        /// Last Updated By:    Jared Harvey
        /// Last Updated:       03/22/2024
        /// What Was Changed:   Initial Creation
        /// </summary>
        Stay SelectStayByStayID(int stayID);
    }
}
