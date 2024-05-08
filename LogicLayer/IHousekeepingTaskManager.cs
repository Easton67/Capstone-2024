using DataObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer
{
    /// <summary>
    /// Creator: Jared Harvey
    /// Created: 02/12/2024
    /// Summary: An interface for HousekeepingManager.
    /// Last Updated By: Jared Harvey
    /// Last Updated: 02/12/2024
    /// What Was Changed: Initial Creation
    /// </summary>
    public interface IHousekeepingTaskManager {
        /// <summary>
        /// Creator: Jared Harvey
        /// Created: 03/04/2024
        /// Summary: Method definition for GetHousekeepingTasksByShelterID.
        /// Last Updated By: Jared Harvey
        /// Last Updated: 03/04/2024
        /// What Was Changed: Initial Creation
        /// </summary>
        List<HousekeepingTaskVM> GetHousekeepingTasksByShelterID(string shelterID);
        /// <summary>
        /// Creator: Jared Harvey
        /// Created: 03/04/2024
        /// Summary: Method definition for CreateHousekeepingTask.
        /// Last Updated By: Jared Harvey
        /// Last Updated: 03/04/2024
        /// What Was Changed: Initial Creation
        /// </summary>
        bool CreateHousekeepingTask(HousekeepingTask task);
		/// <summary>
        /// Creator: Ethan McElree
        /// Created: 03/4/2024
        /// Summary: Interface manager method for updating a housekeeping task status
        /// Last Updated By: Ethan McElree
        /// Last Updated: 03/4/2024
        /// What Was Changed: Initial Creation
        /// </summary>
        void UpdateHousekeepingTaskStatus(int TaskID, string Status);

        /// <summary>
        /// Creator: Jared Harvey
        /// Created: 04/27/2024
        /// Summary: Method definition for AssignHousekeeperToTask
        /// Last Updated By: Ethan McElree
        /// Last Updated: 03/4/2024
        /// What Was Changed: Initial Creation
        /// </summary>
        bool AssignHousekeeperToTask(int taskID, string userID);

        /// <summary>
        /// Creator: Ethan McElree
        /// Created: 03/5/2024
        /// Summary: Interface manager method for getting the housekeeping task
        /// Last Updated By: Ethan McElree
        /// Last Updated: 03/5/2024
        /// What Was Changed: Initial Creation
        /// </summary>
        HousekeepingTaskVM GetHousekeepingTaskVM(int TaskID);
    }
}
