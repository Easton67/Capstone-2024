using DataObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer
{
    /// <summary>
    /// Creator:            Ethan McElree
    /// Created:            02/13/2024
    /// Summary:            Creation of the IScheduleManager interface
    /// Last Updated By:    Ethan McElree
    /// Last Updated:       02/13/2024
    /// What Was Changed:   Initial Creation
    /// </summary>
    public interface IScheduleManager
    {
        /// <summary>
        /// Creator:            Ethan McElree
        /// Created:            02/13/2024
        /// Summary:            Creation of the CreateSchedule manager interface method
        /// Last Updated By:    Ethan McElree
        /// Last Updated:       02/13/2024
        /// What Was Changed:   Initial Creation
        /// </summary>
        int CreateSchedule(string ScheduleMonth, int ScheduleWeek, int ScheduleYear, DateTime ScheduleStartDate, DateTime ScheduleEndDate);

        /// <summary>
        /// Creator:            Ethan McElree
        /// Created:            02/13/2024
        /// Summary:            Creation of the ScheduleExists manager interface method
        /// Last Updated By:    Ethan McElree
        /// Last Updated:       02/13/2024
        /// What Was Changed:   Initial Creation
        /// </summary>
        bool ScheduleExists(string ScheduleMonth, int ScheduleWeek, int ScheduleYear);

        /// <summary>
        /// Creator:            Abdalgader Ibrahim
        /// Created:            03/26/2024
        /// Summary:            Creation of CreateSchedule manager interface method
        /// </summary>
        List<ScheduleVM> GetAllSchedules();
    }
}
