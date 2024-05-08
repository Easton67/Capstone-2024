using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataObjects
{
    /// <summary>
    ///Creator:            Mitchell Stirmel
    ///Created:            04/03/2024
    ///Summary:            Contains data for volunteer application information
    ///Last Updated By:    Mitchell Stirmel
    ///Last Updated:       04/03/2024
    ///What Was Changed:   Initial Creation
    /// </summary>
    public class VolunteerApplicationInfo
    {
        /*
         * 
	SELECT [Applicant].[GivenName], [Applicant].[FamilyName], [Applicant].[PhoneNumber], [Applicant].[Email],
			[VolunteerApplication].[ApplicationReason], [VolunteerApplication].[HoursDesired], [VolunteerApplication].[VolunteerConcerns]
        */
        public string GivenName { get; set; }
        public string FamilyName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string ApplicationReason {  get; set; }
        public int HoursDesired { get; set; }
        public string VolunteerConcerns {  get; set; }

    }
}
