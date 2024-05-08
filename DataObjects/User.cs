using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace DataObjects
{
    /// <summary>
    /// Creator:            Tyler Barz
    /// Created:            02/13/2024
    /// Summary:            Base User class to inherit from
    /// Last Updated By:    Tyler Barz
    /// Last Updated:       02/14/2024
    /// What Was Changed:   Added better userType identification
    /// Last Updated By:    Tyler Barz
    /// Last Updated:       02/25/2024
    /// What Was Changed:   Added IsEmpty property, some methods return empty user objects
    /// Last Updated By:    Tyler Barz
    /// Last Updated:       03/07/2024
    /// What Was Changed:   Added Gender display
    /// </summary>
    public class User
    {
        // backstore props
        private string _firstName = string.Empty;
        private string _lastName = string.Empty;

        // public props
        public string UserID { get; set; }

        public bool Gender { get; set; }

        [DisplayName("Gender")]
        public string DisplayGender => Gender ? "Male" : "Female";

        [DisplayName("Is Enabled")]
        public bool AccountStatus { get; set; }
        public string FirstName
        {
            get => _firstName;
            set { _firstName = value; }
        }
        public string LastName
        {
            get => _lastName;
            set { _lastName = value; }
        }
        public string FullName => $"{_firstName} {_lastName}";

        public string UserType => _userTypes.TryGetValue(GetType(), out string userType) ? userType : "Undefined User Type";
        private readonly Dictionary<Type, string> _userTypes = new Dictionary<Type, string>()
        {
            { typeof(Employee), "Employee" },
            { typeof(Volunteer), "Volunteer" },
            { typeof(Client), "Client" }
        };

        public bool IsEmpty
        {
            get
            {
                return UserID == null;
            }
        }
    }
}
