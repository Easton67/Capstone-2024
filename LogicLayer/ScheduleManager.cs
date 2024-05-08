using DataAccessInterfaces;
using DataAccessLayer;
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
    /// Summary:            Creation of the ScheduleManager class
    /// Last Updated By:    Ethan McElree
    /// Last Updated:       02/13/2024
    /// What Was Changed:   Intial Creation
    /// </summary>
    public class ScheduleManager : IScheduleManager
    {
        private IScheduleAccessor _scheduleAccessor;

        /// <summary>
        /// Creator: Ethan McElree
        /// Created: 02/13/2024
        /// Summary: Creation of the Constructor.
        /// Last Updated By: Ethan McElree
        /// Last Updated: 02/13/2024
        /// What Was Changed: Initial Creation.
        /// </summary>
        public ScheduleManager()
        {
            _scheduleAccessor = new ScheduleAccessor();
        }

        /// <summary>
        /// Creator: Ethan McElree
        /// Created: 02/13/2024
        /// Summary: Creation of the second Constructor with parameters.
        /// Last Updated By: Ethan McElree
        /// Last Updated: 02/13/2024
        /// What Was Changed: Initial Creation.
        /// </summary>
        public ScheduleManager(IScheduleAccessor scheduleAccessor)
        {
            _scheduleAccessor = scheduleAccessor;
        }

        /// <summary>
        /// Creator: Ethan McElree
        /// Created: 02/13/2024
        /// Summary: Creation of the CreateSchedule method.
        /// Last Updated By: Tyler Barz
        /// Last Updated: 03/02/2024
        /// What Was Changed: Fixed method, where it wasn't utilizing the try-block
        /// </summary>
        public int CreateSchedule(string ScheduleMonth, int ScheduleWeek, int ScheduleYear, DateTime ScheduleStartDate, DateTime ScheduleEndDate)
        {
            int rows = 0;
            try
            {
                rows = _scheduleAccessor.CreateSchedule(ScheduleMonth, ScheduleWeek, ScheduleYear, ScheduleStartDate, ScheduleEndDate);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Couldn't create schedule", ex);
            }
            return rows;
        }
        /// <summary>
        /// Creator: Abdalgader Ibrahim
        /// Created: 03/26/2024
        /// Summary: Creation of the GetAllSchedules method.
        /// Last Updated By: Abdalgader Ibrahim
        /// </summary>
        public List<ScheduleVM> GetAllSchedules()
        {
            try
            {
                return  _scheduleAccessor.GetAllSchedules();
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Couldn't get schedules", ex);
            }
           
        }

        /// <summary>
        /// Creator: Ethan McElree
        /// Created: 02/13/2024
        /// Summary: Creation of the ScheduleExists method.
        /// Last Updated By: Ethan McElree
        /// Last Updated: 02/13/2024
        /// What Was Changed: Initial Creation.
        /// </summary>
        public bool ScheduleExists(string ScheduleMonth, int ScheduleWeek, int ScheduleYear)
        {
            bool exists = false;
            try
            {
                exists = _scheduleAccessor.ScheduleExists(ScheduleMonth, ScheduleWeek, ScheduleYear);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Couldn't determine if the schedule already exists", ex);
            }
            return exists;
        }
    }
}
