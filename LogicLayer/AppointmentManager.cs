using DataAccessInterfaces;
using DataAccessLayer;
using DataObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer
{
    /// <summary>
    /// Creator:            Seth Nerney
    /// Created:            02/22/2024
    /// Summary:            This class contains all the methods for appointment.
    /// Last Updated By:    Seth Nerney
    /// Last Updated:       02/22/2024
    /// What Was Changed:   Initial Creation
    /// </summary>
    public class AppointmentManager : IAppointmentManager
    {
        IAppointmentAccessor _appointmentAccessor;


        /// <summary>
        /// Creator:            Seth Nerney
        /// Created:            02/22/2024
        /// Summary:            initial creation of AppointmentManager class.
        /// Last Updated By:    Seth Nerney
        /// Last Updated:       02/22/2024
        /// What Was Changed:   Initial Creation
        /// </summary>
        public AppointmentManager()
        {
            _appointmentAccessor = new AppointmentAccessor();
        }


        /// <summary>
        /// Creator:            Seth Nerney
        /// Created:            02/22/2024
        /// Summary:            initial creation of GetAllAppointments class.
        /// Last Updated By:    Seth Nerney
        /// Last Updated:       02/22/2024
        /// What Was Changed:   Initial Creation
        /// </summary>
        public AppointmentManager(IAppointmentAccessor appointmentAccessor)
        {
            _appointmentAccessor = appointmentAccessor;
        }

        /// <summary>
        /// Creator:            Ethan McElree
        /// Created:            03/25/2024
        /// Summary:            Manager method for creating an appointment.
        /// Last Updated By:    Ethan McElree
        /// Last Updated:       03/25/2024
        /// What Was Changed:   Initial Creation
        /// </summary>
        public void CreateAppointment(AppointmentVM appointmentVM)
        {
            try
            {
                _appointmentAccessor.CreateAppointment(appointmentVM);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Failed to create an appointment", ex);
            }          
        }


        /// <summary>
        /// Creator:            Seth Nerney
        /// Created:            02/22/2024
        /// Summary:            initial creation of GetAllAppointments class.
        /// Last Updated By: Mitchell Stirmel
        /// Last Updated 04/10/2024
        /// What was changed: Added try/catch and code cleanup
        /// </summary>
        public List<Appointment> GetAllAppointments()
        {
            try
            {
                return _appointmentAccessor.ViewAllAppointments();
            }
            catch (Exception ex)
            {

                throw new ApplicationException("Failed to get appointments.", ex);
            }
        }

        /// <summary>
        /// Creator:            Miyada Abas
        /// Created:            03/14/2024
        /// Summary:            initial creation of RemoveAppointment .
        /// Last Updated By:    Miyada Abas
        /// Last Updated:       03/14/2024
        /// What Was Changed:   Initial Creation
        /// </summary>
        public bool RemoveAppointment(Appointment appointment)
        {
            try
            {
                return _appointmentAccessor.RemoveAppointment(appointment);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Failed to remove an appointment", ex);
            }
        }
    }
}
