using DataAccessInterfaces;
using DataAccessLayer;
using DataObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static LogicLayer.HousekeepingTaskManager;

namespace LogicLayer {
    /// <summary>
    /// Creator: Jared Harvey
    /// Created: 02/12/2024
    /// Summary: This class is responsible for all the logic done with HousekeepingTask
    /// Last Updated By: Jared Harvey
    /// Last Updated: 02/12/2024
    /// What Was Changed: Initial Creation
    /// </summary>
    public class HousekeepingTaskManager : IHousekeepingTaskManager {
        private IHousekeepingTaskAccessor _housekeepingTaskAccessor = null;
 

        public HousekeepingTaskManager() {
            _housekeepingTaskAccessor = new HousekeepingTaskAccessor();
        }

        public HousekeepingTaskManager(IHousekeepingTaskAccessor housekeepingTaskAccessor) {
            _housekeepingTaskAccessor = housekeepingTaskAccessor;
        }

        /// <summary>
        /// Creator: Jared Harvey
        /// Created: 04/27/2024
        /// Summary: Method implementation for AssignHousekeeperToTask.
        /// Last Updated By: 
        /// Last Updated: 
        /// What Was Changed:
        /// </summary>
        public bool AssignHousekeeperToTask(int taskID, string userID) {
            try {
                return 0 < _housekeepingTaskAccessor.UpdateAssignedHousekeeper(taskID, userID);
            } catch (Exception ex) {
                throw ex;
            }
        }

        /// <summary>
        /// Creator: Jared Harvey
        /// Created: 03/04/2024
        /// Summary: Method implementation for CreateHousekeepingTask.
        /// Last Updated By: Jared Harvey
        /// Last Updated: 03/04/2024
        /// What Was Changed: Initial Creation
        /// </summary>
        public bool CreateHousekeepingTask(HousekeepingTask task) {
            try {
                return 1 == _housekeepingTaskAccessor.InsertHousekeepingTask(task);
            } catch (Exception ex) {
                throw ex;
            }
        }

        /// <summary>
        /// Creator: Jared Harvey
        /// Created: 03/04/2024
        /// Summary: Method implementation for GetHousekeepingTasksByShelterID.
        /// Last Updated By: Jared Harvey
        /// Last Updated: 03/04/2024
        /// What Was Changed: Initial Creation
        /// </summary>
        public List<HousekeepingTaskVM> GetHousekeepingTasksByShelterID(string shelterID) {
            List<HousekeepingTaskVM> result = new List<HousekeepingTaskVM>();
            try {
                result = _housekeepingTaskAccessor.SelectHousekeepingTasksByShelterID(shelterID);
            } catch (Exception ex) {
                throw ex;
            }
            return result;
        }

        /// <summary>
        /// Creator: Ethan McElree
        /// Created: 03/5/2024
        /// Summary: Manager method for getting housekeeping task
        /// Last Updated By: Ethan McElree
        /// Last Updated: 03/5/2024
        /// What Was Changed: Initial Creation
        /// </summary>
        public HousekeepingTaskVM GetHousekeepingTaskVM(int TaskID)
        {
            HousekeepingTaskVM result = null;
            try
            {
                result = _housekeepingTaskAccessor.GetHousekeepingTaskVM(TaskID);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("There was an error while getting housekeeping task", ex);
            }
            return result;
        }

        /// <summary>
        /// Creator: Ethan McElree
        /// Created: 03/4/2024
        /// Summary: Manager method for updating a housekeeping task status
        /// Last Updated By: Ethan McElree
        /// Last Updated: 03/4/2024
        /// What Was Changed: Initial Creation
        /// </summary>
        public void UpdateHousekeepingTaskStatus(int TaskID, string Status)
        {
            try
            {
                _housekeepingTaskAccessor.UpdateHousekeepingTaskStatus(TaskID, Status);
            }
            catch(Exception ex)
            {
                throw new ApplicationException("There was an error while updating your task status", ex);
            }
        }
    }
}

