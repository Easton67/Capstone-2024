using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataObjects
{
    /// <summary>
    /// Creator: Kirsten Stage
    /// Created: 04/11/2024
    /// Summary: This class represents fundraising events.
    /// Last Updated By: Kirsten Stage
    /// Last Updated: 04/11/2024
    /// What Was Changed: Initial Creation
    /// </summary> 

    public class FundraisingEvent
    {
        [DisplayName("Fundraising ID")]
        public int FundraisingId { get; set; }

        [DisplayName("Event Name")]
        public string EventName { get; set; }

        [DisplayName("Fundraising Goal")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal FundraisingGoal { get; set; }

        [DisplayName("Event Address")]
        public string EventAddress { get; set; }

        [DisplayName("Event Date")]
        [DisplayFormat(DataFormatString = "{0:MM-dd-yyyy}")]
        public DateTime EventDate { get; set; }

        [DisplayName("Start Time")]
        [DisplayFormat(DataFormatString = "{0:hh:mm tt}")]
        public DateTime StartTime { get; set; }

        [DisplayName("End Time")]
        [DisplayFormat(DataFormatString = "{0:hh:mm tt}")]
        public DateTime EndTime { get; set; }

        [DisplayName("Event Description")]
        public string EventDescription { get; set; }

    }
}
