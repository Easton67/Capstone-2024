using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace DataObjects
{
    /// <summary>
    ///Creator:            Ethan McElree
    ///Created:            03/29/2024
    ///Summary:            Volunteer data object class
    ///Last Updated By:    Ethan McElree
    ///Last Updated:       03/29/2024
    ///What Was Changed:   Initial Creation
    /// </summary>
    public class Volunteer : InternalUser
    {
        public string VolunteerID { get; set; }
        [DisplayName("First Name")]
        public string FirstName { get; set; }
        [DisplayName("Last Name")]
        public string LastName { get; set; }
        [DisplayName("Phone Number")]
        public string Phone { get; set; }
        [DisplayName("Gender")]
        public bool Gender { get; set; }
        [DisplayName("Password Hash")]
        public string PasswordHash { get; set; }
        [DisplayName("Account Status")]
        public bool AccountStatus { get; set; }
        [DisplayName("Role")]
        public string RoleID { get; set; }
        [DisplayName("Register Date")]
        public DateTime RegistrationDate { get; set; }
        [DisplayName("Address")]
        public string Address { get; set; }
        [DisplayName("Zipcode")]
        public int ZipCode { get; set; }
    }

    public class VolunteerVM : Volunteer 
    {
        public string Fname { get; set; }
        public string Lname { get; set; }
    }          
}

