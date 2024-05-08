using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataObjects {

    /// <summary>
    /// Creator: Jared Harvey
    /// Created: 02/06/2024
    /// Summary: A model class that allows the system to store data from the Shift table in the database.
    /// Last Updated By: Jared Harvey
    /// Last Updated: 02/06/2024
    /// What Was Changed: Initial Creation
    /// </summary>
    public class Shift {
        public int ShiftID { get; set; }
        public string EmployeeID { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int ScheduleID { get; set; }
    }

    public class ShiftVM : Shift
    {
        public string EmployeeName { get; set; }
        public string ShiftDuration { get; set; }
        public Schedule schedule { get; set; }
        public Employee employee { get; set; }

    }

    /// <summary>
    /// Creator: Abdalgader Ibrahim
    /// Created: 02/06/2024
    /// Summary: create ShiftData class that allows the system to store data .
    /// </summary>
    public class ShiftData
    {
        public string Shift { get; set; }

    }
}
