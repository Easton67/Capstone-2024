using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataObjects
{
    /// <summary>
    /// Creator: Kirsten Stage
    /// Created: 03/29/2024
    /// Summary: This class represents event meal plans.
    /// Last Updated By: Kirsten Stage
    /// Last Updated: 03/29/2024
    /// What Was Changed: Initial Creation
    /// </summary> 

    public class EventMealPlan
    {
        public int EventMealID { get; set; }
        public int EventID { get; set; }
        public string Food {  get; set; }
        public string Beverages { get; set; }
        public string EventName { get; set; }
        public DateTime Date { get; set; }
        public DateTime Time { get; set; }
    }
}
