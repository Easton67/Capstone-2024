using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataObjects
{
    //<summary>
    //Creator: Sagan DeWald
    //Created: 2/23/2024
    //Summary: Stores data from rows of the HiddenIncident database table. Represents an incident, and a user to hide it from. HiddenIncidentId can be used to delete the incident.
    //Last Updated: 2/23/2024
    //What was Changed: Initial Creation
    //</summary>
    public class HiddenIncident
    {
        public int HiddenIncidentId { get; }
        public string TargetUser { get; }
        public int IncidentId { get; }
        public HiddenIncident(int hiddenIncidentId, string targetUser, int incidentId)
        {
            this.HiddenIncidentId = hiddenIncidentId;
            this.TargetUser = targetUser;
            this.IncidentId = incidentId;
        }
    }
}

