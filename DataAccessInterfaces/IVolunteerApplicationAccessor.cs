using DataObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessInterfaces
{
    /// <summary>
    /// Creator:            Mitchell Stirmel
    /// Created:            03/20/2024
    /// Summary:            Interface used to describe method signatures for the VolunteerApplicationAccessor
    /// Last Updated By:    Darryl Shirley
    /// Last Updated:       03/27/2024
    /// What Was Changed:   Added update volunteer application status method
    /// Last Updated By:    Mitchell Stirmel
    /// Last Updated:       04/03/2024
    /// What Was Changed:   Added SelectVolunteerApplicationById
    /// </summary>
    public interface IVolunteerApplicationAccessor
    {
        List<VolunteerApplication> SelectVolunteerApplications();

        int UpdateVolunteerApplicationStatus(int volunteerApplicationID, string status, string reasonForStatus);
        VolunteerApplicationInfo SelectVolunteerApplicationById(int applicationId);
        /// <summary>
        /// ///Creator:        Suliman Suliman
        ///Created:            03/20/2024
        ///Summary:            This method accepting the volunteer application and return boolean result.
        ///Last Updated By:     
        ///Last Updated:       
        ///What Was Changed:   
        /// </summary>
        bool AcceptVolunteerApplication(VolunteerApplication volunteerApplication);

        bool CreateVolunteerApplication(CreateVolunteerApplication application);
    }
}
