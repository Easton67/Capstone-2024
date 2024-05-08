using DataAccessInterfaces;
using DataObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessFakes {
    public class HousekeepingTaskAccessorFakes : IHousekeepingTaskAccessor {
        List<HousekeepingTaskVM> _fakeTasks = new List<HousekeepingTaskVM>();

        public HousekeepingTaskAccessorFakes() {
            _fakeTasks.Add(new HousekeepingTaskVM() {
                TaskID = 100000,
                RoomID = 100000,
                EmployeeID = "barrack-obama@whitehouse.org",
                Type = "Requested Cleaning",
                Description = "Room must have been forgoten to be cleaned",
                Date = DateTime.Now,
                Status = "Pending"
            });
            _fakeTasks.Add(new HousekeepingTaskVM() {
                TaskID = 100001,
                RoomID = 100001,
                EmployeeID = "joe-biden@whitehouse.org",
                Type = "Requested Cleaning",
                Description = "Room must have been forgoten to be cleaned",
                Date = DateTime.Now,
                Status = "Pending"
            });
            _fakeTasks.Add(new HousekeepingTaskVM() {
                TaskID = 100002,
                RoomID = 100002,
                EmployeeID = "obama-prism@whitehouse.org",
                Type = "Requested Cleaning",
                Description = "Room must have been forgoten to be cleaned",
                Date = DateTime.Now,
                Status = "Pending"
            });
        }

        public int InsertHousekeepingTask(HousekeepingTask task) {
            int preCount = _fakeTasks.Count;
            try {
                _fakeTasks.Add((HousekeepingTaskVM)task);
                return _fakeTasks.Count - preCount;
            } catch (Exception ex) {
                throw ex;
            }
        }

        public List<HousekeepingTaskVM> SelectHousekeepingTasksByShelterID(string shelterID) {
            return _fakeTasks;
		}

        /// <summary>
        /// Creator: Ethan McElree
        /// Created: 03/5/2024
        /// Summary: Update the status of a Housekeeping task.
        /// Last Updated By: Ethan McElree
        /// Last Updated: 03/5/2024
        /// What Was Changed: Initial Creation
        /// </summary>
        public void UpdateHousekeepingTaskStatus(int TaskID, string Status)
        {
            foreach (var HousekeepingTask in _fakeTasks)
            {
                if (HousekeepingTask.TaskID == TaskID)
                {
                    HousekeepingTask.Status = Status;
                }
            }
        }

        /// <summary>
        /// Creator: Ethan McElree
        /// Created: 03/5/2024
        /// Summary: Get the Housekeeping task.
        /// Last Updated By: Ethan McElree
        /// Last Updated: 03/5/2024
        /// What Was Changed: Initial Creation
        /// </summary>
        public HousekeepingTaskVM GetHousekeepingTaskVM(int TaskID)
        {
            foreach (var HousekeepingTask in _fakeTasks)
            {
                if (HousekeepingTask.TaskID == TaskID)
                {
                    return HousekeepingTask;
                }
            }
            return null;
        }

        /// <summary>
        /// Creator: Jared Harvey
        /// Created: 04/27/2024
        /// Summary: returns rows affected by update
        /// Last Updated By: 
        /// Last Updated: 
        /// What Was Changed:
        /// </summary>
        public int UpdateAssignedHousekeeper(int taskID, string userID) {
            int result = 0;

            int index = _fakeTasks.FindIndex(t => t.TaskID == taskID);
            _fakeTasks[index].EmployeeID = userID;
            result = _fakeTasks.FindAll(h => h.EmployeeID == userID && h.TaskID == taskID).Count();

            return result;
        }
    }
}