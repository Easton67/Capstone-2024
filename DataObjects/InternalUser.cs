using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;

namespace DataObjects
{
    /// <summary>
    /// Creator:            Tyler Barz
    /// Created:            02/13/2024
    /// Summary:            Base InternalUser class for Employee/Volunteer
    /// Last Updated By:    Tyler Barz
    /// Last Updated:       02/13/2024
    /// What Was Changed:   Created User inheritance class
    /// Last Updated By:    Tyler Barz
    /// Last Updated:       03/07/2024
    /// What Was Changed:   Added RoleDisplay
    /// </summary>
    public class InternalUser : User
    {
        [DisplayName("Phone Number")]
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public int ZipCode { get; set; }

        #region Role Properties
        public List<Role> Roles { get; set; }
        [DisplayName("Roles")]
        public string RoleDisplay => string.Join(", ", Roles.Select(r => r.RoleID)); 
        #endregion
    }
}
