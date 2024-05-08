using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataObjects
{
    /// <Summary>
    /// Creator: Darryl Shirley
    /// created: 01/22/2024
    /// Summary: Event.cs
    /// Last Updated By:    Tyler Barz
    /// Last Updated:       03/24/2024
    /// What Was Changed:   Data annotations
    /// Last Updated By:    Liam Easton
    /// Last Updated:       04/17/2024
    /// What Was Changed:   Added more data annotations to VM and description and volunteers needed
    /// </Summary>
    public class Event
    {
        [DisplayName("Event ID")]
        public int EventID { get; set; }

        [Required]
        [DisplayName("Event Name")]
        public string EventName { get; set; }

        [Required]
        [DisplayName("Description")]
        public string Description { get; set; }
        
        [Required]
        [DisplayName("Volunteers Needed")]
        public int VolunteersNeeded { get; set; } 
        
    }

    /// <Summary>
    /// Creator: Abdalgader Ibrahim
    /// created: 02/22/2024
    /// Summary: EventVM class
    /// </Summary>
    public class EventVM: Event 
    {
        public DateTime EventDay { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string Address { get; set; }
    }
}
