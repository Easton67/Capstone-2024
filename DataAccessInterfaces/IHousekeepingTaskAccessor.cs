using DataObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessInterfaces {
    /// <summary>
    /// Creator: Jared Harvey
    /// Created: 02/12/2024
    /// Summary: An interface for HousekeepingAccessor
    /// Last Updated By: Jared Harvey
    /// Last Updated: 02/12/2024
    /// What Was Changed: Initial Creation
    /// </summary>
    public interface IHousekeepingTaskAccessor {
        /// <summary>
        /// Creator: Jared Harvey
        /// Created: 03/03/2024
        /// Summary: An method definition for SelectHousekeepingTasksByShelterID
        /// Last Updated By: Jared Harvey
        /// Last Updated: 03/03/2024
        /// What Was Changed: Initial Creation
        /// </summary>
        List<HousekeepingTaskVM> SelectHousekeepingTasksByShelterID(string shelterID);
        /// <summary>
        /// Creator: Jared Harvey
        /// Created: 03/03/2024
        /// Summary: An method definition for InsertHousekeepingTask
        /// Last Updated By: Jared Harvey
        /// Last Updated: 03/03/2024
        /// What Was Changed: Initial Creation
        /// </summary>
        int InsertHousekeepingTask(HousekeepingTask task);

        /// <summary>
        /// Creator: Ethan McElree
        /// Created: 03/5/2024
        /// Summary: Interface accessor method for getting housekeeping task
        /// Last Updated By: Ethan McElree
        /// Last Updated: 03/5/2024
        /// What Was Changed: Initial Creation
        /// </summary>
        HousekeepingTaskVM GetHousekeepingTaskVM(int taskID);

        /// <summary>
        /// Creator: Ethan McElree
        /// Created: 03/4/2024
        /// Summary: Interface accessor method for updating a housekeeping task status
        /// Last Updated By: Ethan McElree
        /// Last Updated: 03/4/2024
        /// What Was Changed: Initial Creation
        /// </summary>
        void UpdateHousekeepingTaskStatus(int TaskID, string Status);

        /// <summary>
        /// Creator: Jared Harvey
        /// Created: 04/27/2024
        /// Summary: An method definition for UpdateAssignedHousekeeper
        /// Last Updated By: Jared Harvey
        /// Last Updated: 03/03/2024
        /// What Was Changed: Initial Creation
        /// </summary>
        int UpdateAssignedHousekeeper(int taskID, string userID);
    }
}
