using DataAccessInterfaces;
using DataObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessFakes
{

    /// <summary>
    /// Creator: Miyada Abas
    /// Created: 03/01/2024
    /// Summary: HouseKeeping Accessor Fakes
    /// Last Updated By: Miyada Abas
    /// Last Updated: 02/01/2024
    /// What Was Changed:
    /// </summary>
    
    public class HousekeepingAccessorFakes : IHouseKeepingAccessor
    {
        public List<HouseKeepingTask> fakeTasks = new List<HouseKeepingTask>();

        public HousekeepingAccessorFakes()
        {
            fakeTasks.Add(new HouseKeepingTask()
            {
                TaskID = 1,
                RoomID = 1,
                EmployeeID = "joe-obama@company.com",
                Type = "whatever",
                Description = "jakdjf;lkasjd",
                Date = DateTime.Now,
                Status = "ksjdfkjsald"
            });
            fakeTasks.Add(new HouseKeepingTask()
            {
                TaskID = 1,
                RoomID = 2,
                EmployeeID = "joe-obama@company.com",
                Type = "whatever",
                Description = "jakdjf;lkasjd",
                Date = DateTime.Now,
                Status = "ksjdfkjsald"
            });
            fakeTasks.Add(new HouseKeepingTask()
            {
                TaskID = 1,
                RoomID = 3,
                EmployeeID = "joe-obama@company.com",
                Type = "whatever",
                Description = "jakdjf;lkasjd",
                Date = DateTime.Now,
                Status = "ksjdfkjsald"
            });
        }


        /// <summary>
        /// Creator: Miyada Abas
        /// Created: 03/01/2024
        /// Summary: SelectAllHouseKeepingTasks
        /// Last Updated By: Miyada Abas
        /// Last Updated: 02/01/2024
        /// What Was Changed:
        /// </summary>
        public List<HouseKeepingTask> SelectAllHouseKeepingTasks()
        {
            return fakeTasks;
        }
    }
}
