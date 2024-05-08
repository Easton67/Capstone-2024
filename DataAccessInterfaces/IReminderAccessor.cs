using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataObjects;

namespace DataAccessInterfaces
{

    /// <summary>
    ///Creator:           Marwa Ibrahim
    ///Created:            02/15/2024
    ///Summary:            Reminder Accessor Interface
    ///What Was Changed:   Initial Creation
    /// </summary>
    public interface IReminderAccessor
    {
        bool insertReminder(Reminder reminder);
    }
}
