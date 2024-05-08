using DataAccessInterfaces;
using DataAccessLayer;
using DataObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.XPath;

namespace LogicLayer
{
    /// <summary>
    ///Creator:            Mitchell Stirmel
    ///Created:            03/20/2024
    ///Summary:            Class used to operate on data regarding volunteer applications.
    ///Last Updated By:    Mitchell Stirmel
    ///Last Updated:       03/20/2024
    ///What Was Changed:   Initial Creation
    /// </summary>
    public class VolunteerApplicationManager : IVolunteerApplicationManager
    {
        IVolunteerApplicationAccessor _volunteerAccessor = null;

       
        public VolunteerApplicationManager()
        {
            _volunteerAccessor = new VolunteerApplicationAccessor();
        }
        public VolunteerApplicationManager(IVolunteerApplicationAccessor accessor)
        {
            _volunteerAccessor = accessor;
        }

        /// <summary>
        ///Creator:            Darryl Shirley
        ///Created:            03/27/2024
        ///Summary:            Method that edits the Volunteer Application status and reason for status.
        ///Last Updated By:    Darryl Shirley
        ///Last Updated:       03/27/2024
        ///What Was Changed:   Initial Creation
        /// </summary>
        public bool EditVolunteerAplicationStatus(int applicationID, string status, string reasonForStatus)
        {
            bool result = false;

            try
            {
                result = (1 == _volunteerAccessor.UpdateVolunteerApplicationStatus(applicationID, status, reasonForStatus));
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Volunteer Application Status not updated", ex);
            }
            return result;
        }

        /// <summary>
        ///Creator:            Mitchell Stirmel
        ///Created:            03/20/2024
        ///Summary:            Method that returns all volunteer applications.
        ///Last Updated By:    Mitchell Stirmel
        ///Last Updated        04/10/2024
        ///What was changed:   Added try/catch and code cleanup
        /// </summary>
        public List<VolunteerApplication> GetVolunteerApplications()
        {
            try
            {
                return _volunteerAccessor.SelectVolunteerApplications();
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Unable to get volunteer applications", ex);
            }
        }


        /// <summary>
        ///Creator:            Mitchell Stirmel
        ///Created:            04/04/2024
        ///Summary:            Method that returns application info given the application ID.
        ///Last Updated By:    Mitchell Stirmel
        ///Last Updated        04/10/2024
        ///What was changed:   Added try/catch and code cleanup
        /// </summary>
        public VolunteerApplicationInfo GetApplicationInfo(int applicationID)
        {
            try
            {
                return _volunteerAccessor.SelectVolunteerApplicationById(applicationID);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Unable to get application info", ex);
            }
        }

        /// <summary>
        ///Creator:             Suliman Suliman
        ///Created:            03/20/2024
        ///Summary:            AcceptVolunteerApplication() This Method Accepting the                            Volunteer Application and returns Boolean.
        ///Last Updated By:     
        ///Last Updated:       
        ///What Was Changed:   
        /// </summary>
        public bool AcceptVolunteerApplication(VolunteerApplication volunteerApplication)
        {
            bool result = false;
            try
            {
                result = _volunteerAccessor.AcceptVolunteerApplication(volunteerApplication);
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return result;

        }
        /// <summary>
        /// Creator:            Mitchell Stirmel
        /// Created:            04/20/2024
        /// Summary:            Sends volunteer application to data access, returns bool
        /// Last Updated By:    Mitchell Stirmel
        /// Last Updated:       04/20/2024
        /// What Was Changed:   Initial Creation
        /// </summary>
        public bool CreateVolunteerApplication(CreateVolunteerApplication application)
        {
            try
            {
                return _volunteerAccessor.CreateVolunteerApplication(application);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

