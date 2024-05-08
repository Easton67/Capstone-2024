using DataObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessInterfaces
{
    /// <summary>
    /// Creator:            Ethan McElree
    /// Created:            02/13/2024
    /// Summary:            Creation of IScheduleAccessor interface
    /// Last Updated By:    Ethan McElree
    /// Last Updated:       02/13/2024
    /// What Was Changed:   Initial Creation
    /// </summary>
    public interface IScheduleAccessor
    {
        /// <summary>
        /// Creator:            Ethan McElree
        /// Created:            02/13/2024
        /// Summary:            Creation of CreateSchedule accessor interface method
        /// Last Updated By:    Ethan McElree
        /// Last Updated:       02/13/2024
        /// What Was Changed:   Initial Creation
        /// </summary>
        int CreateSchedule(string ScheduleMonth, int ScheduleWeek, int ScheduleYear, DateTime ScheduleStartDate, DateTime ScheduleEndDate);

        /// <summary>
        /// Creator:            Ethan McElree
        /// Created:            02/14/2024
        /// Summary:            Creation of CreateSchedule accessor interface method
        /// Last Updated By:    Ethan McElree
        /// Last Updated:       02/14/2024
        /// What Was Changed:   Initial Creation
        /// </summary>
        bool ScheduleExists(string ScheduleMonth, int ScheduleWeek, int ScheduleYear);

        /// <summary>
        /// Creator:            Abdalgader Ibrahim
        /// Created:            03/26/2024
        /// Summary:            Creation of CreateSchedule accessor interface method
        /// </summary>
        List<ScheduleVM> GetAllSchedules();
    }
}
