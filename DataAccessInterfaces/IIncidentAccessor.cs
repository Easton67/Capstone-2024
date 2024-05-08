using DataObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessInterfaces
{
    /// <summary>
    /// Creator: Darryl Shirley
    /// Created: 02/21/2024
    /// Summary: Interface for IIncidentAccessor
    /// Last Updated By: Darryl Shirley
    /// Last Updated: 02/21/2024
    /// What Was Changed: Initial Creation
    /// </summary>
    public interface IIncidentAccessor
    {
        int createIncidentReport(string description, string reported, string reportedBy, int severity);
        /// <summary>
        /// Creator: Liam Easton
        /// Created: 02/25/2024
        /// Summary: Interface for SelectAllIncidents
        /// Last Updated By: Liam Easton
        /// Last Updated: 02/25/2024
        /// What Was Changed: Initial Creation
        /// </summary>
        List<Incident> SelectAllIncidents();
        List<Incident> GetCurrentUserIncidents(string reportedBy);
    }
}
