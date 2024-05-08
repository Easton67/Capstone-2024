using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataObjects
{
    /// <summary>
    /// Creator:            Mitchell Stirmel
    /// Created:            03/20/2024
    /// Summary:            Class used to represent a volunteer application model in code.
    /// Last Updated By:    Darryl Shirley
    /// Last Updated:       03/27/2024
    /// What Was Changed:   Added ReasonForStatus field
    /// </summary>
    public class VolunteerApplication
    {
        public int ApplicationID { get; set; }
        public int ApplicantID { get; set; }
        public string Status { get; set; }
        public DateTime DateApplied { get; set; }
        public string ReasonForStatus { get; set; }
    }
}
