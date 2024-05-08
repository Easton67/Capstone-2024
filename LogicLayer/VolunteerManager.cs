using DataAccessInterfaces;
using DataAccessLayer;
using DataObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer
{
    /// <summary>
    ///Creator:            Ethan McElree
    ///Created:            04/1/2024
    ///Summary:            Volunteer manager class
    ///Last Updated By:    Ethan McElree
    ///Last Updated:       04/1/2024
    ///What Was Changed:   Initial Creation
    /// </summary>
    public class VolunteerManager : IVolunteerManager
    {
        IVolunteerAccessor _volunteerAccessor;
        public VolunteerManager() 
        {
            _volunteerAccessor = new VolunteerAccessor();
        }

        public VolunteerManager(IVolunteerAccessor volunteerAccessor)
        {
            _volunteerAccessor = volunteerAccessor;
        }

        public string HashSha256(string source)
        {
            // Method chaining, looks cleaner
            byte[] data = SHA256.Create().ComputeHash(Encoding.UTF8.GetBytes(source));

            // Remove need for count controlled for loop
            return string.Join("", data.Select(b => b.ToString("x2")));
        }

        /// <summary>
        /// Creator: Andrew Larson
        /// Created: 04/01/2024
        /// Summary: Updates the 
        /// Last Updated By: Andrew Larson
        /// Last Updated 04/01/2024
        /// What was changed: Initial Creation
        /// </summary>
        public VolunteerVM UpdateVolunteer(string volunteerID, string firstName, string lastName, string phone, bool gender, string address, int zip)
        {
            VolunteerVM volunteer = new VolunteerVM();

            try
            {
                volunteer = _volunteerAccessor.UpdateVolunteer(volunteerID, firstName, lastName, phone, gender, address, zip);
            }
            catch (Exception)
            {
                throw;
            }

            return volunteer;
        }

        ///Creator:            Ethan McElree
        ///Created:            04/1/2024
        ///Summary:            Manager method for deleting a volunteer
        ///Last Updated By:    Ethan McElree
        ///Last Updated:       04/1/2024
        ///What Was Changed:   Initial Creation
        /// </summary>
        public bool DeleteVolunteer(VolunteerVM volunteerVM)
        {
            try
            {
                return _volunteerAccessor.DeleteVolunteer(volunteerVM);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Failed to delete volunteer", ex);
            }
        }

        /// <summary>
        ///Creator:            Ethan McElree
        ///Created:            04/12/2024
        ///Summary:            Manager method for retrieveing a volunteer by their id.
        ///Last Updated By:    Ethan McElree
        ///Last Updated:       04/12/2024
        ///What Was Changed:   Initial Creation
        /// </summary>
        public VolunteerVM RetrieveVolunteer(string volunteerID)
        {
            try
            {
                return _volunteerAccessor.RetrieveVolunteer(volunteerID);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Failed to retrieve the volunteer by their id.", ex);
            }
        }

        /// <summary>
        ///Creator:            Ethan McElree
        ///Created:            04/1/2024
        ///Summary:            Manager method for viewing volunteers
        ///Last Updated By:    Ethan McElree
        ///Last Updated:       04/1/2024
        ///What Was Changed:   Initial Creation
        /// </summary>
        public List<VolunteerVM> ViewVolunteers()
        {
            try
            {
                return _volunteerAccessor.ViewVolunteers();
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Failed to get all volunteers", ex);
            }
        }

        /// <summary>
        ///Creator:            Donald Winchester
        ///Created:            04/25/2024/
        ///Summary:            Manager method for creating volunteers
        ///Last Updated By:    Donald Winchester
        ///Last Updated:       04/25/2024/
        ///What Was Changed:   Initial Creation
        /// </summary>
        public bool CreateVolunteer(Volunteer volunteer)
        {
            bool result = false;
            volunteer.PasswordHash = HashSha256(volunteer.PasswordHash);
            try
            {
                result = _volunteerAccessor.CreateVolunteer(volunteer);
            }
            catch (Exception ex)
            {

                throw new ApplicationException("Failed to create volunteer", ex);
            }
            return result;
        }
    }
}
