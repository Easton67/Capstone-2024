using DataAccessInterfaces;
using DataObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessFakes
{
    /// <summary>
    ///Creator:            Mitchell Stirmel
    ///Created:            03/20/2024
    ///Summary:            This class contains all fake data regarding volunteer applications
    ///Last Updated By:    Darryl Shirley
    ///Last Updated:       03/27/2024
    ///What Was Changed:   Added ReasonForStatus field
    /// </summary>
    public class VolunteerApplicationAccessorFakes : IVolunteerApplicationAccessor
    {
        List<VolunteerApplication> _applications = new List<VolunteerApplication>();

        public VolunteerApplicationAccessorFakes() 
        {
            _applications.Add(new VolunteerApplication
            {
                ApplicantID = 100,
                ApplicationID = 100,
                Status = "TestStatus",
                DateApplied = DateTime.Now,
                ReasonForStatus= "No reason at all"
            });
        }

        /// <summary>
        ///Creator:            Mitchell Stirmel
        ///Created:            04/04/2024
        ///Summary:            This method will mock the SelectVolunteerApplicationById functionality
        ///Last Updated By:    Mitchell Stirmel
        ///Last Updated:       04/04/2024
        ///What Was Changed:   Initial Creation
        /// </summary>
        public VolunteerApplicationInfo SelectVolunteerApplicationById(int applicationId)
        {
            if (applicationId == 10005)
            {
                return new VolunteerApplicationInfo
                {
                    ApplicationReason = "AppReason",
                    VolunteerConcerns = "Concerns",
                    HoursDesired = 450,
                    FamilyName = "FirstName",
                    GivenName = "GivenName",
                    Email = "Email",
                    PhoneNumber = "1234567890"
                };
            }
            else
            {
                return new VolunteerApplicationInfo();
            }
        }

        /// <summary>
        ///Creator:            Mitchell Stirmel
        ///Created:            03/20/2024
        ///Summary:            This fake method allows testing of fake data for getting volunteer applications.
        ///Last Updated By:    Mitchell Stirmel
        ///Last Updated:       03/20/2024
        ///What Was Changed:   Initial Creation
        /// </summary>
        public List<VolunteerApplication> SelectVolunteerApplications()
        {
            return _applications;
        }

        /// <summary>
        ///Creator:            Darryl Shirley
        ///Created:            03/27/2024
        ///Summary:            This fake method allows testing of fake data for updating volunteer application statuses.
        ///Last Updated By:    Darryl Shirley
        ///Last Updated:       03/27/2024
        ///What Was Changed:   Initial Creation
        /// </summary>
        public int UpdateVolunteerApplicationStatus(int volunteerApplicationID, string status, string reasonForStatus)
        {
            int rowsAffected = 0;

            for (int i = 0; i < _applications.Count; i++)
            {
                if (_applications[i].ApplicationID == volunteerApplicationID)
                {
                    _applications[i].Status = status;
                    _applications[i].ReasonForStatus = reasonForStatus;
                    rowsAffected+= 1;
                    break;
                }
            }
            if (rowsAffected != 1)
            {
                rowsAffected= 0;
            }

            return rowsAffected;
        }

        /// <summary>
        ///Creator:            Suliman Suliman
        ///Created:            03/20/2024
        ///Summary:            This fake method allows testing of fake data for getting                          volunteer applications.
        ///Last Updated By:    
        ///Last Updated:       
        ///What Was Changed:   
        /// </summary>
        public bool AcceptVolunteerApplication(VolunteerApplication volunteerApplication)
        {
            bool result = false;
            foreach (VolunteerApplication item in _applications)
            {
                if (item.ApplicationID == volunteerApplication.ApplicationID)
                {
                    item.Status = volunteerApplication.Status;
                    result = true;
                    break;
                }
            }
            return result;
        }


        /// <summary>
        ///Creator:            Mitchell Stirmel
        ///Created:            04/23/2024
        ///Summary:            This method will mock the CreateVolunteerApplication functionality
        ///Last Updated By:    Mitchell Stirmel
        ///Last Updated:       04/23/2024
        ///What Was Changed:   Initial Creation
        /// </summary>
        public bool CreateVolunteerApplication(CreateVolunteerApplication application)
        {
            try
            {
                if(application.Email == "Ex")
                {
                    throw new Exception();
                }
                if(application.Email == "TestEmail")
                {
                    return true;
                } 
                else
                {
                    return false;
                } 
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
