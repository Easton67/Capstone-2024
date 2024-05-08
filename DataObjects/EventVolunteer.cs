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
    /// Creator: Abdalgader Ibrahim
    /// created: 02/28/2024
    /// Summary: Event Volunteer class
    /// Last Updated By:    Tyler Barz
    /// Last Updated:       03/24/2024
    /// What Was Changed:   Data annotations
    /// </Summary>
    public class EventVolunteer: Volunteer
    {
        [DisplayName("User ID")]
        public string VolunteerID { get; set; }

        [Required]
        [DisplayName("Event ID")]
        public int EventID { get; set; }
    }
}
