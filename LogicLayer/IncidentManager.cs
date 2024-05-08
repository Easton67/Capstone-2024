using DataAccessInterfaces;
using DataAccessLayer;
using DataObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer
{
    /* 
            <summary>
                Creator:            Darryl Shirley
                Created:            02/21/2024
                Summary:            IncidentManager.cs 
                Last Updated By:    Darryl Shirley
                Last Updated:       02/21/2024
                What Was Changed:   Initial Creation  
            </summary>
        */
    public class IncidentManager : IIncidentManager
    {
        private IIncidentAccessor _incidentAccessor;

        /* 
            <summary>
                Creator:            Darryl Shirley
                Created:            02/21/2024
                Summary:            IncidentManager Constructor 
                Last Updated By:    Darryl Shirley
                Last Updated:       02/21/2024
                What Was Changed:   Initial Creation  
            </summary>
        */
        public IncidentManager()
        {
            _incidentAccessor = new IncidentAccessor();
        }

        /* 
            <summary>
                Creator:            Darryl Shirley
                Created:            02/21/2024
                Summary:            IncidentManager Constructor with parameter 
                Last Updated By:    Darryl Shirley
                Last Updated:       02/21/2024
                What Was Changed:   Initial Creation  
            </summary>
        */
        public IncidentManager(IIncidentAccessor incidentAccessor)
        {
            _incidentAccessor = incidentAccessor;
        }


        /// <summary>
        /// Creator:            Darryl Shirley
        /// Created:            02/21/2024
        /// Summary:            _AddIncident Method 
        /// Last Updated By:    Darryl Shirley
        /// Last Updated:       02/21/2024
        /// What Was Changed:   Initial Creation  
        /// </summary>
        public bool AddIncident(string description, string reported, string reportedBy, int severity)
        {
            bool result = false;

            try
            {
                if (_incidentAccessor.createIncidentReport(description, reported, reportedBy, severity) == 1)
                {
                    result = true;
                }
            }
            catch (Exception ex)
            {
                
                throw new ApplicationException("Incident not created", ex);
            }

            return result;
        }

        /// <summary>
        /// Creator: Andrew Larson
        /// Created: 03/03/2024
        /// Summary: GetCurrentUserIncidents method
        /// Last Updated By: Andrew Larson
        /// Last Updated: 03/03/2024
        /// What Was Changed: Initial Creation
        /// </summary>
        public List<Incident> GetCurrentUserIncidents(string reportedBy)
        {
            List<Incident> incidents = new List<Incident>();

            try
            {
                incidents = _incidentAccessor.GetCurrentUserIncidents(reportedBy);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("No incidents found", ex);
            }
            return incidents;
        }

        /// <summary>
        /// Creator: Liam Easton
        /// Created: 02/25/2024
        /// Summary: manager for SelectAllIncidents
        /// Last Updated By: Liam Easton
        /// Last Updated: 02/25/2024
        /// What Was Changed: manager for SelectAllIncidents
        /// </summary>
        public List<Incident> SelectAllIncidents()
        {
            List<Incident> incidents = new List<Incident>();

            try
            {
                incidents = _incidentAccessor.SelectAllIncidents();
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Incidents not found", ex);
            }
            return incidents;
        }
    }
}
