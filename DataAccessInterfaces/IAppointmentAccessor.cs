using DataObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessInterfaces
{
    public interface IAppointmentAccessor
    {
        bool RemoveAppointment(Appointment appointment);

        /// <summary>
        ///Creator:            Seth Nerney
        ///Created:            02/22/2024
        ///Summary:            This is the intereface for the Appointment Accessor.
        ///Last Updated By:    Seth Nerney
        ///Last Updated:       02/22/2024
        ///What Was Changed:   Initial Creation
        /// </summary>
        List<Appointment> ViewAllAppointments();

        /// <summary>
        ///Creator:            Ethan McElree
        ///Created:            03/25/2024
        ///Summary:            Interface method for creating an appointment.
        ///Last Updated By:    Ethan McElree
        ///Last Updated:       03/25/2024
        ///What Was Changed:   Initial Creation
        /// </summary>
        void CreateAppointment(AppointmentVM appointment);
    }
}
