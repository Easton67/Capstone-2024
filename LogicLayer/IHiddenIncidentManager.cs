using DataObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer
{
    //<summary>
    //Creator: Sagan DeWald
    //Created: 2/23/2024
    //Summary: Interface defining methods needed to access the HiddenIncidents table of the database.
    //Last Updated: 2/23/2024
    //What was Changed: Initial creation.
    //</summary>
    public interface IHiddenIncidentManager
    {
        List<HiddenIncident> GetHiddenIncidentsByUserId(string targetUser);
        int AddHiddenIncident(string userId, int incidentId);
    }
}
