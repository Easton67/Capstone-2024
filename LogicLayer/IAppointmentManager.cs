using DataObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer
{
    public interface IAppointmentManager
    {
        /// <summary>
        ///Creator:            Seth Nerney
        ///Created:            02/22/2024
        ///Summary:            This is the intereface for the Appointment Logic layer.
        ///Last Updated By:    Seth Nerney
        ///Last Updated:       02/22/2024
        ///What Was Changed:   Initial Creation
        /// </summary>
        List<Appointment> GetAllAppointments();

        /// <summary>
        ///Creator:            Ethan McElree
        ///Created:            03/25/2024
        ///Summary:            Interface accessor method for creating an appointment.
        ///Last Updated By:    Ethan McElree
        ///Last Updated:       03/25/2024
        ///What Was Changed:   Initial Creation
        /// </summary>
        void CreateAppointment(AppointmentVM appointmentVM);

        /// <summary>
        ///Creator:            Miyada Abas
        ///Created:            03/27/2024
        ///Summary:            Interface accessor method for removing an appointment.
        /// </summary>
        bool RemoveAppointment(Appointment appointment);
    }
}

