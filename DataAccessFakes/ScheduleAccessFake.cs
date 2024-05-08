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
    /// Creator:            Ethan McElree
    /// Created:            02/13/2024
    /// Summary:            Creation of the ScheduleAccessFake class
    /// Last Updated By:    Ethan McElree
    /// Last Updated:       02/13/2024
    /// What Was Changed:   Intial Creation
    /// </summary>
    public class ScheduleAccessFake : IScheduleAccessor
    {
        List<ScheduleVM> scheduleVMs = new List<ScheduleVM>();
        /// <summary>
        /// Creator: Abdalgader Ibrahim
        /// Created: 03/26/2024
        /// Summary: Creation of the ScheduleAccessFake method.
        /// Last Updated By: Abdalgader Ibrahim
        /// Last Updated: 03/26/2024
        /// What Was Changed: Initial Creation
        /// </summary>
        public ScheduleAccessFake() 
        {
            scheduleVMs.Add(new ScheduleVM()
            {
                ScheduleID = 1,
                ScheduleWeek = 1,
                ScheduleMonth = "March",
                ScheduleYear = 1000,
                ScheduleStartDate = DateTime.Now,
                ScheduleEndDate = DateTime.Now,
            });
            scheduleVMs.Add(new ScheduleVM()
            {
                ScheduleID = 2,
                ScheduleWeek = 1,
                ScheduleMonth = "March",
                ScheduleYear = 1001,
                ScheduleStartDate = DateTime.Now,
                ScheduleEndDate = DateTime.Now,
            });
            scheduleVMs.Add(new ScheduleVM()
            {
                ScheduleID = 3,
                ScheduleWeek = 1,
                ScheduleMonth = "March",
                ScheduleYear = 1002,
                ScheduleStartDate = DateTime.Now,
                ScheduleEndDate = DateTime.Now,
            });
            scheduleVMs.Add(new ScheduleVM()
            {
                ScheduleID = 4,
                ScheduleWeek = 1,
                ScheduleMonth = "March",
                ScheduleYear = 1003,
                ScheduleStartDate = DateTime.Now,
                ScheduleEndDate = DateTime.Now,
            });
            scheduleVMs.Add(new ScheduleVM()
            {
                ScheduleID = 5,
                ScheduleWeek = 1,
                ScheduleMonth = "March",
                ScheduleYear = 1004,
                ScheduleStartDate = DateTime.Now,
                ScheduleEndDate = DateTime.Now,
            });
        }
        /// <summary>
        /// Creator: Ethan McElree
        /// Created: 02/13/2024
        /// Summary: Creation of the CreateSchedule method.
        /// Last Updated By: Ethan McElree
        /// Last Updated: 04/22/2024
        /// What Was Changed: Added start date and end date.
        /// </summary>
        public int CreateSchedule(string ScheduleMonth, int ScheduleWeek, int ScheduleYear, DateTime ScheduleStartDate, DateTime ScheduleEndDate)
        {
            ScheduleVM scheduleVM = new ScheduleVM();
            scheduleVM.ScheduleID = 99;
            scheduleVM.ScheduleMonth = ScheduleMonth;
            scheduleVM.ScheduleWeek = ScheduleWeek;
            scheduleVM.ScheduleYear = ScheduleYear;
            scheduleVM.ScheduleStartDate = ScheduleStartDate;
            scheduleVM.ScheduleEndDate = ScheduleEndDate;
            scheduleVMs.Add(scheduleVM);
            return 1;
        }

        /// <summary>
        /// Creator: Abdalgader Ibrahim
        /// Created: 03/26/2024
        /// Summary: Creation of the GetAllSchedules method.
        /// Last Updated By: Abdalgader Ibrahim
        /// Last Updated: 03/26/2024
        /// What Was Changed: Initial Creation
        /// </summary>
        public List<ScheduleVM> GetAllSchedules()
        {
            return scheduleVMs;
        }

        /// <summary>
        /// Creator: Ethan McElree
        /// Created: 02/14/2024
        /// Summary: Creation of the ScheduleExists method.
        /// Last Updated By: Ethan McElree
        /// Last Updated: 02/14/2024
        /// What Was Changed: Initial Creation
        /// </summary>
        public bool ScheduleExists(string ScheduleMonth, int ScheduleWeek, int ScheduleYear)
        {    
            foreach (var dbScheduleVM in scheduleVMs)
            {
                if(dbScheduleVM.ScheduleMonth.Equals(ScheduleMonth) && dbScheduleVM.ScheduleWeek == ScheduleWeek && dbScheduleVM.ScheduleYear == ScheduleYear)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
