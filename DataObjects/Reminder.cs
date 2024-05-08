using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataObjects
{
    /// <summary>
    /// Creator: Marwa Ibrahim
    /// Created: 01/13/2024
    /// Summary: Create Reminder
    /// Last Updated By:Marwa Ibrahim
    /// Last Updated: 01/13/2024
    /// What Was Changed: Initial Creation
    /// </summary>
    public class Reminder
    {
        public string EmailTo { get; set; }
        public string EmailFrom { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }
        public string Frequency { get; set; }
        public DateTime Date { get; set; }
        public bool Read {  get; set; }
        public bool Deactivate { get; set; }
    }
}
