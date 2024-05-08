using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataObjects 
{
    /// <summary>
    /// Creator: Jared Harvey
    /// Created: 02/12/2024
    /// Summary: A model class that allows the system to store data from the HousekeepingTask table in the database.
    /// Last Updated By: Jared Harvey
    /// Last Updated: 02/12/2024
    /// What Was Changed: Initial Creation
    /// </summary>
    public class HousekeepingTask {
        public int TaskID { get; set; }
        public int RoomID { get; set; }
        public string EmployeeID { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public string Status { get; set; }
    }

    public class HousekeepingTaskVM : HousekeepingTask {
        public int RoomNumber { get; set; }
        public string EmployeeName { get; set; }
    
    }
}
