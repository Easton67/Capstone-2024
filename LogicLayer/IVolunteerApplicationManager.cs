using DataObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer
{
    /// <summary>
    ///Creator:            Mitchell Stirmel
    ///Created:            03/20/2024
    ///Summary:            This contains all methods for volunteer application data management.
    ///Last Updated By:    Daryl Shirley
    ///Last Updated:       03/27/2024
    ///What Was Changed:   Added EditVolunteerApplicationStatus method
    ///Last Updated By:    Mitchell Stirmel
    ///Last Updated:       04/04/2024
    ///What Was Changed:   Added GetApplicationInfo method
    /// </summary>
    public interface IVolunteerApplicationManager
    {
        List<VolunteerApplication> GetVolunteerApplications();

        bool EditVolunteerAplicationStatus(int applicationID, string status, string reasonForStatus);

        VolunteerApplicationInfo GetApplicationInfo(int applicationID);

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
