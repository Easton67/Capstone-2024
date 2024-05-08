using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Versioning;
using System.Text;
using System.Threading.Tasks;

namespace DataObjects
{
    /// <summary>
    /// Creator:            Tyler Barz
    /// Created:            02/13/2024
    /// Summary:            Base Employee which inherits InternalUser:User
    /// Last Updated By:    Tyler Barz
    /// Last Updated:       02/13/2024
    /// What Was Changed:   Removed all extra properties since they're interited
    ///                     03/02/2024 - Looks like they were added back..
    ///                     03/05/2024 - Removed extra properties -- left EmployeeID because of the total reference count
    ///                                  Will fix eventually
    ///                     03/07/2024 - Added DisplayDate to make my life easier
    public class Employee : InternalUser
    {
        // Should be removed, and all references ported to the inheritied UserID eventually
        [Required]
        [DisplayName("Employee ID")]
        public string EmployeeID { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [DisplayName("Start Date")]
        public string DisplayDate => StartDate.ToShortDateString();
        public DateTime? EndDate { get; set; }
    }
      
    /// <summary>
    /// Creator:            Liam Easton
    /// Created:            02/01/2024
    /// Summary:            Creation of EmployeePass View Model. This is to return the password hash from the email
    ///                     so employees can reset their password without being logged in.
    /// Last Updated By:    Liam Easton
    /// Last Updated:       02/01/2024
    /// What Was Changed:   Creation of EmployeePass View Model
    /// </summary>
    public class EmployeePass : Employee
    {
        public string PasswordHash { get; set; }
    }

    /// <summary>
    /// Creator:            Tyler Barz
    /// Created:            03/02/2024
    /// Summary:            EmployeeVM to view roles
    /// Last Updated By:    Tyler Barz
    /// Last Updated:       03/02/2024
    /// What Was Changed:   Initial creation
    ///                     03/05/2024 - Nothing being used in this, but too many references to go through and change currently
    /// </summary>
    public class EmployeeVM : Employee { }
}
