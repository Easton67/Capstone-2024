using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataObjects
{
    /// <Summary>
    /// Creator: Darryl Shirley
    /// created: 02/21/2024
    /// Summary: Incident.cs
    /// Last updated By: Darryl Shirley
    /// Last Updated: 02/21/2024
    /// What was changed/updated: Initial Creation
    /// Last updated By: Liam Easton
    /// Last Updated: 04/25/2024
    /// What was changed/updated: Added semi colons to data annotation
    /// </Summary>
    public class Incident
    {
        [DisplayName("Incident ID")]
        public int incidentID { get; set; }
        [DisplayName("Description:")]
        public string description { get; set; }
        [DisplayName("Status:")]
        public string incidentStatus { get; set; }
        [DisplayName("Reported:")]
        public string reported { get; set; }
        [DisplayName("Reported By:")]
        public string reportedBy { get; set; }
        [DisplayName("Feedback:")]
        public string feedBack { get; set; }
        [DisplayName("Severity:")]
        public int severity { get; set; }
    }
}
