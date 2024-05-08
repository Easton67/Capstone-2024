using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataObjects
{
    public class Repair
    {
        public int RepairID { get; set; }
        public int RequestID { get; set; }
        public string EmployeeID { get; set; }
        public DateTime RepairDate { get; set; }
        public string Status { get; set; }
    }
}
