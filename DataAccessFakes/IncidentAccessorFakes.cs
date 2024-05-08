using DataAccessInterfaces;
using DataObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessFakes
{
    /// <Summary>
    /// Creator: Darryl Shirley
    /// created: 02/21/2024
    /// Summary: IncidentAccessorFakes class
    /// Last updated By: Darryl Shirley
    /// Last Updated:02-21-2024
    /// What was changed/updated: Initial Creation
    /// </Summary>
    public class IncidentAccessorFakes : IIncidentAccessor
    {
        private List<Incident> _incidents = new List<Incident>();

        /// <Summary>
        /// Creator: Darryl Shirley
        /// created: 02/21/2024
        /// Summary: IncidentAccessorFakes Constructor
        /// Last updated By: Darryl Shirley
        /// Last Updated: 02-21-2024
        /// What was changed/updated: Initial Creation
        /// </Summary>
        public IncidentAccessorFakes()
        {
            _incidents.Add(new Incident()
            {
                incidentID = 1,
                description = "Carl pooped on the hallway floor in front of the children.",
                incidentStatus = "unread",
                reported = "Sarah mcAlistor",
                reportedBy = "sarah@gmail.com",
                feedBack = null,
                severity= 1,
            });
            _incidents.Add(new Incident()
            {
                incidentID = 2,
                description = "One of the Clients scraped their knee on a bedpost.",
                incidentStatus = "unread",
                reported = "Ronda Shorts",
                reportedBy = "rhonda@gmail.com",
                feedBack = null,
                severity = 1,
            });
            _incidents.Add(new Incident()
            {
                incidentID = 3,
                description = "The Green Goblin kidnapped a volunteer named of Mary Jane.",
                incidentStatus = "unread",
                reported = "Peter Parker",
                reportedBy = "spiderman@hotmail.com",
                feedBack = null,
                severity = 1,
            });
            _incidents.Add(new Incident()
            {
                incidentID = 4,
                description = "Hoodlums broke into the donations room and stole the lightbulbs.",
                incidentStatus = "unread",
                reported = "Sonya Deetay",
                reportedBy = "sonya@gmail.com",
                feedBack = null,
                severity = 1,
            });
        }

        /// <Summary>
        /// Creator: Darryl Shirley
        /// created: 02/21/2024
        /// Summary: createIncidentReport method
        /// Last updated By: Darryl Shirley
        /// Last Updated: 02-21-2024
        /// What was changed/updated: Initial Creation
        /// </Summary>
        public int createIncidentReport(string description, string reported, string reportedBy, int severity)
        {
            int rows = 0;
            try
            {
                Incident incident = new Incident();
                incident.description = description;
                incident.reported = reported;
                incident.reportedBy = reportedBy;
                incident.severity = severity;

                _incidents.Add(incident);
                rows += 1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return rows;
        }

        public List<Incident> GetCurrentUserIncidents(string reportedBy)
        {
            List<Incident> fakeIncidents = new List<Incident>();
            foreach (var incident in _incidents)
            {
                if (incident.reportedBy.Equals(reportedBy)) 
                {
                    fakeIncidents.Add(incident);
                }
            }
            return fakeIncidents;
        }

        /// <summary>
        /// Creator: Liam Easton
        /// Created: 02/28/2024
        /// Summary: Creation of the SelectAllIncidents method
        /// Last Updated By: Liam Easton
        /// Last Updated: 02/28/2024
        /// What Was Changed: Creation of the SelectAllIncidents method
        /// </summary>
        public List<Incident> SelectAllIncidents()
        {
            return _incidents;
        }
    }
}
