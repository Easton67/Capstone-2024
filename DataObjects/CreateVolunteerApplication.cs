using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataObjects
{
    /// <summary>
    /// Creator:            Mitchell Stirmel
    /// Created:            04/20/2024
    /// Summary:            Class used to represent a volunteer application model in code.
    /// Last Updated By:    Mitchell Stirmel
    /// Last Updated:       04/20/2024
    /// What Was Changed:   Initial Creation
    /// </summary>
    public class CreateVolunteerApplication
    {
        public int ApplicationID { get; set; }
        public int ApplicantID { get; set; }
        public string Status { get; set; }
        public DateTime DateApplied { get; set; }
        public string ReasonForStatus { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string GivenName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string FamilyName { get; set; }

        [Required]
        [Display(Name = "Phone Number")]
        [Phone]
        public string PhoneNumber { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Hours Desired")]
        [Range(1, 40, ErrorMessage = "Must be a number between 1 and 40")]
        public string HoursDesired { get; set; }

        [Required]
        [Display(Name = "Why Apply?")]
        public string ApplicationReason { get; set; }

        [Required]
        [Display(Name = "Concerns or Questions?")]
        public string VolunteerConcerns { get; set; }
    }
}
