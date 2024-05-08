using DataAccessInterfaces;
using DataObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessFakes
{
    public class AppointmentAccessorFake : IAppointmentAccessor
    {
        List<AppointmentVM> _appointments = new List<AppointmentVM>();

        /// <summary>
        ///Creator:            Seth Nerney
        ///Created:            02/22/2024
        ///Summary:            This is the fake data for the Appointment Accessor.
        ///Last Updated By:    Ethan McElree
        ///Last Updated:       03/26/2024
        ///What Was Changed:   Added status and employeeID to the fakes and the create appointment method.
        /// </summary>
        public AppointmentAccessorFake()
        {
            _appointments.Add(new AppointmentVM
            {
                _clientID = "a@email.com",
                _locationName = "location1",
                _appointmentType = "Regular",
                _appointmentStartTime = DateTime.Now,
                _appointmentEndTime = DateTime.Now.AddHours(3),
                _status = false,
                _employeeID = "fake@gmail.com"
            });

            _appointments.Add(new AppointmentVM
            {
                _clientID = "b@email.com",
                _locationName = "Location2",
                _appointmentType = "Regular",
                _appointmentStartTime = DateTime.Now,
                _appointmentEndTime = DateTime.Now.AddHours(3),
                _status = true,
                _employeeID = "fake@email.com"
            });

            _appointments.Add(new AppointmentVM
            {
                _clientID = "c@email.com",
                _locationName = "Location2",
                _appointmentType = "Regular",
                _appointmentStartTime = DateTime.Now,
                _appointmentEndTime = DateTime.Now.AddHours(3),
                _status = false,
                _employeeID = "fake@company.com"
            });

            _appointments.Add(new AppointmentVM
            {
                _clientID = "d@email.com",
                _locationName = "Location3",
                _appointmentType = "Regular",
                _appointmentStartTime = DateTime.Now,
                _appointmentEndTime = DateTime.Now.AddHours(3),
                _status = true,
                _employeeID = "fake@outlook.com"
            });
        }

        public bool RemoveAppointment(Appointment appointment)
        {
           bool result = false;
            List<AppointmentVM> temp = _appointments;
            foreach (AppointmentVM item in temp)
            {
                if (item._clientID.Equals(appointment._clientID))
                {
                    _appointments.Remove(item); 
                    result = true;
                    break;

                }
            }
            return result;
        }

        /// <summary>
        ///Creator:            Ethan McElree
        ///Created:            03/26/2024
        ///Summary:            Accessor fake method for creating an appointment.
        ///Last Updated By:    Ethan McElree
        ///Last Updated:       03/26/2024
        ///What Was Changed:   Initial Creation
        /// </summary>
        public void CreateAppointment(AppointmentVM appointment)
        {
            _appointments.Add(appointment);
        }

        /// <summary>
        ///Creator:            Seth Nerney
        ///Created:            02/22/2024
        ///Summary:            This is the returns the data from the fake for the tests.
        ///Last Updated By:    Ethan McElree
        ///Last Updated:       03/26/2024
        ///What Was Changed:   Adjust for AppointmentVM in the testing
        /// </summary>
        public List<Appointment> ViewAllAppointments()
        {
            List<Appointment> appointments = new List<Appointment>();
            foreach (AppointmentVM appointmentVM in _appointments)
            {
                Appointment appointment = new Appointment()
                {
                    _clientID = appointmentVM._clientID,
                    _locationName = appointmentVM._locationName,
                    _appointmentStartTime = appointmentVM._appointmentStartTime,
                    _appointmentEndTime = appointmentVM._appointmentEndTime,
                    _appointmentType = appointmentVM._appointmentType,
                };
                appointments.Add(appointment);
            }
            return appointments;
        }
    }
}
