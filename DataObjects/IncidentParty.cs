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
    /// Summary: IncidentParty.cs
    /// Last Updated By:    Tyler Barz
    /// Last Updated:       03/24/2024
    /// What Was Changed:   Data annotations
    /// </Summary>
    public class IncidentParty
    {
        public int incidentPartyID { get; set; }
        [DisplayName("Incident ID")]
        public int incidentID { get; set; }
        [DisplayName("Description")]
        public string description { get; set; }
        [DisplayName("Incident Role")]
        public string incidentRole { get; set; }
    }
}
