using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataObjects
{    /// <summary>
     /// Creator:            Miyada Abas
     /// Created:            03/01/2024
     /// Summary:            This is the model class for HouseKeepingTasks.
     /// Last Updated By:    Miyada Abas
     /// Last Updated:       03/01/2024
     /// What Was Changed:   
     /// </summary>
    public class HouseKeepingTask
    {
        public int TaskID { get; set; }
        public int RoomID { get; set; }
        public string EmployeeID { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public string Status { get; set; }
    }
}
