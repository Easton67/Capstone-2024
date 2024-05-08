using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using DataAccessInterfaces;
using DataObjects;

namespace LogicLayer
{
    /// <summary>
    /// Creator: Marwa Ibrahim
    /// Created: 02/16/2024
    /// Summary: Reminder Manager class that implements IReminderManager interface
    /// Last Updated By: Marwa Ibrahim
    /// Last Updated: 02/16/2024
    /// What Was Changed: Initial Creation
    /// </summary>
    public class ReminderManager : IReminderManager
    {
        private IReminderAccessor reminderAccessor;

        public ReminderManager()
        {
            reminderAccessor = new ReminderAccessor();
        }

        public ReminderManager(DataAccessFakes.ReminderAccessorFake reminderAccessorFake)
        {
            reminderAccessor = reminderAccessorFake;
        }
        /// <summary>
        /// 
        ///Last Updated By:    Mitchell Stirmel
        ///Last Updated        04/10/2024
        ///What was changed:   Added try/catch and code cleanup
        /// </summary>
        public bool createReminder(Reminder reminder)
        {
            try
            {
                bool result = false;
                result = reminderAccessor.insertReminder(reminder);
                return result;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Unable to create reminder", ex);
            }

        }
    }
}
