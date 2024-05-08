using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataObjects
{
    /// <Summary>
    /// Creator: Abdalgader Ibrahim
    /// created: 02/22/2024
    /// Summary: Create EventRequest class
    /// </Summary>
    public class EventRequest
    {
        public int RequestID { get; set; }
        public string EventTypeID { get; set; }
        public string ClientID { get; set; }
        public string Information { get; set; }
    }
    public class EventRequestVM : EventRequest 
    {

    }
}
