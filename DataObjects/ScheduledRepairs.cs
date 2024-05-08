using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataObjects
{
    /// <summary>
    /// Creator:            Seth Nerney
    /// Created:            02/13/2024
    /// Summary:            This is the model class for scheduled repairs.
    /// Last Updated By:    Seth Nerney
    /// Last Updated:       02/13/2024
    /// What Was Changed:   Initial Creation
    /// </summary>
    public class ScheduledRepairs
    {
        public int _repairID { get; set; }
        public int _requestID { get; set; }
        public string _employeeID { get; set; }
        public string _status { get; set; }
    }
}
