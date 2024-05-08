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
    /// Created: 02/15/2024
    /// Summary: Reminder Manager Interface
    /// Last Updated By: Marwa Ibrahim
    /// Last Updated: 02/15/2024
    /// What Was Changed: Initial Creation
    /// </summary>
    public interface IReminderManager
    {
        bool createReminder(Reminder reminder);
    }
}
