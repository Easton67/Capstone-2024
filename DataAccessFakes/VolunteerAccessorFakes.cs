using DataAccessInterfaces;
using DataObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessFakes
{
    /// <summary>
    /// Creator:            Ethan McElree
    /// Created:            04/1/2024
    /// Summary:            Accessor fake data for the volunteers
    /// Last Updated By:    Ethan McElree
    /// Last Updated:       04/1/2024
    /// What Was Changed:   Initial Creation
    /// </summary>
    public class VolunteerAccessorFakes : IVolunteerAccessor
    {
        List<VolunteerVM> _volunteers = new List<VolunteerVM>();

        /// <summary>
        ///Creator:            Ethan McElree
        ///Created:            04/1/2024
        ///Summary:            Fake data for the Volunteer Accessor.
        ///Last Updated By:    Ethan McElree
        ///Last Updated:       04/1/2024
        ///What Was Changed:   Initial Creation.
        /// </summary>
        public VolunteerAccessorFakes()
        {
            _volunteers.Add(new VolunteerVM
            {
                VolunteerID = "fake@email1",
                FirstName = "fakeFName1",
                LastName = "fakeLName1",
                Phone = "000-111-1111",
                Gender = true,
                PasswordHash = "AduAHdoadu89708yiadu8F9CVUHUOCBH",
                AccountStatus = true,
                RoleID = "Role1",
                ZipCode = 11111,
                Address = "fake street 1",
                RegistrationDate = DateTime.Now
            });

            _volunteers.Add(new VolunteerVM
            {
                VolunteerID = "fake@email2",
                FirstName = "fakeFName2",
                LastName = "fakeLName",
                Phone = "000-222-2222",
                Gender = false,
                PasswordHash = "jdhGUOCZ&89YHVUOXU4OFG8OVHPIGJBPI",
                AccountStatus = true,
                RoleID = "Role2",
                ZipCode = 22222,
                Address = "fake street 2",
                RegistrationDate = DateTime.Now.AddHours(1)
            });

            _volunteers.Add(new VolunteerVM
            {
                VolunteerID = "fake@email3",
                FirstName = "fakeFName3",
                LastName = "fakeLName3",
                Phone = "000-333-3333",
                Gender = true,
                PasswordHash = "GJHIOUJIONHLknikEJFVIPK",
                AccountStatus = false,
                RoleID = "Role3",
                ZipCode = 33333,
                Address = "fake street 3",
                RegistrationDate = DateTime.Now.AddHours(2)
            });
        }

        public bool CreateVolunteer(Volunteer volunteer)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Creator: Andrew Larson
        /// Created: 04/01/2024
        /// Summary: update the Volunteer data.
        /// Last Updated By: Andrew Larson
        /// Last Updated 04/01/2024
        /// What was changed: Initial Creation
        /// </summary>
        public VolunteerVM UpdateVolunteer(string volunteerID, string firstName, string lastName, string phone, bool gender, string address, int zip)
        {
            VolunteerVM volunteer = new VolunteerVM();
            for (int i = 0; i < _volunteers.Count; i++)
            {
                if (_volunteers[i].VolunteerID.Equals(volunteerID))
                {
                    _volunteers[i].Fname = firstName;
                    _volunteers[i].Lname = lastName;
                    _volunteers[i].Phone = phone;
                    _volunteers[i].Gender = gender;
                    _volunteers[i].Address = address;
                    _volunteers[i].ZipCode = zip;
                    volunteer = _volunteers[i];
                    break;
                }
            }
            return volunteer;
        }

        /// <summary>
        /// Creator:            Ethan McElree
        /// Created:            04/8/2024
        /// Summary:            Accessor fake method for deleting a volunteer
        /// Last Updated By:    Ethan McElree
        /// Last Updated:       04/8/2024
        /// What Was Changed:   Initial Creation
        /// </summary>
        public bool DeleteVolunteer(VolunteerVM volunteerVM)
        {
            bool result = false;
            List<VolunteerVM> temp = _volunteers;
            foreach (VolunteerVM item in temp)
            {
                if (item.VolunteerID.Equals(volunteerVM.VolunteerID))
                {
                    _volunteers.Remove(item);
                    result = true;
                    break;

                }
            }
            return result;
        }

        /// <summary>
        /// Creator:            Ethan McElree
        /// Created:            04/12/2024
        /// Summary:            Accessor fake method for retrieveing a volunteer by their id.
        /// Last Updated By:    Ethan McElree
        /// Last Updated:       04/12/2024
        /// What Was Changed:   Initial Creation
        /// </summary>
        public VolunteerVM RetrieveVolunteer(string volunteerID)
        {
            foreach(var volunteer in _volunteers)
            {
                if (volunteer.VolunteerID == volunteerID)
                {
                    return volunteer;
                }
            }
            return null;
        }

        /// <summary>
        /// Creator:            Ethan McElree
        /// Created:            04/1/2024
        /// Summary:            Accessor fake method for viewing volunteers
        /// Last Updated By:    Ethan McElree
        /// Last Updated:       04/1/2024
        /// What Was Changed:   Initial Creation
        /// </summary>
        public List<VolunteerVM> ViewVolunteers()
        {
            return _volunteers;
        }
    }
}
