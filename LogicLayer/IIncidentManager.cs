using DataObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer
{
    public interface IIncidentManager
    {
        /// <summary>
        /// Creator: Liam Easton
        /// Created: 02/25/2024
        /// Summary: Interface for SelectAllIncidents
        /// Last Updated By: Liam Easton
        /// Last Updated: 02/25/2024
        /// What Was Changed: Initial Creation
        /// </summary>
        List<Incident> SelectAllIncidents();
        bool AddIncident(string description, string reported, string reportedBy, int severity);
        List<Incident> GetCurrentUserIncidents(string reportedBy);
    }
}
