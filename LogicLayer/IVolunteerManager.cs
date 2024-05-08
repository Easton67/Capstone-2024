using DataObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer
{
    /// <summary>
    /// Creator:            Ethan McElree
    /// Created:            04/1/2024
    /// Summary:            Manager interface for volunteers.
    /// Last Updated By:    Ethan McElree
    /// Last Updated:       04/1/2024
    /// What Was Changed:   Initial Creation
    /// </summary>
    public interface IVolunteerManager
    {
        /// <summary>
        /// Creator:            Ethan McElree
        /// Created:            04/1/2024
        /// Summary:            Manager interface method for viewing volunteers.
        /// Last Updated By:    Ethan McElree
        /// Last Updated:       04/1/2024
        /// What Was Changed:   Initial Creation
        /// </summary>
        List<VolunteerVM> ViewVolunteers();

        VolunteerVM UpdateVolunteer(string volunteerID, string firstName, string lastName, string phone, bool gender, string address,int zip);

        /// <summary>
        ///Creator:            Ethan McElree
        ///Created:            04/12/2024
        ///Summary:            Manager interface method for retrieveing a volunteer by their id.
        ///Last Updated By:    Ethan McElree
        ///Last Updated:       04/12/2024
        ///What Was Changed:   Initial Creation
        /// </summary>
        VolunteerVM RetrieveVolunteer(string volunteerID);

        /// <summary>
        ///Creator:            Ethan McElree
        ///Created:            04/8/2024
        ///Summary:            Interface Manager method for deleting a volunteer.
        ///Last Updated By:    Ethan McElree
        ///Last Updated:       04/8/2024
        ///What Was Changed:   Initial Creation
        /// </summary>
        bool DeleteVolunteer(VolunteerVM volunteerVM);

        /// <summary>
        ///Creator:            Donald Winchester
        ///Created:            04/25/2024
        ///Summary:            Interface Manager method for creating a volunteer.
        ///Last Updated By:    Donald Winchester
        ///Last Updated:       04/25/2024
        ///What Was Changed:   Initial Creation
        /// </summary>
        bool CreateVolunteer(Volunteer volunteer);
    }
}
