using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessInterfaces;
using DataObjects;

namespace DataAccessFakes
{

    /// <summary>
    ///Creator:           Marwa Ibrahim
    ///Created:            02/15/2024
    ///Summary:            insert fake Reminder 
    ///What Was Changed:   Initial Creation
    /// </summary>
    public class ReminderAccessorFake : IReminderAccessor
    {
        List<Reminder> reminders = new List<Reminder>();

        public ReminderAccessorFake()
        {
            reminders.Add(new Reminder
            {
                EmailTo = "Company.com",
                EmailFrom = "Company.com",
                Title = "Reminder Title",
                 Message = "Reminder Massage",
                Frequency = "Reminder Frequency",
                Date = DateTime.Now,
                Read = true,
                Deactivate = true
        });  
            }
        public bool insertReminder(Reminder reminder)
        {
            reminders.Add(reminder);
            return true;
        }
    }
}
