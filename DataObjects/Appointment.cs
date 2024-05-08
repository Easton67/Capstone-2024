using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DataObjects
{
    public class Appointment
    {
        /// <summary>
        ///Creator:            Seth Nerney
        ///Created:            02/22/2024
        ///Summary:            This is the model for the Appointment objects.
        ///Last Updated By:    Ethan McElree
        ///Last Updated:       03/27/2024
        ///What Was Changed:   Added display name attributes
        /// </summary>
        public int _appointmentID { get; set; }
        [DisplayName("Client")]
        public string _clientID { get; set; }
        [DisplayName("Location")]
        public string _locationName { get; set; }
        [DisplayName("Type")]
        public string _appointmentType { get; set; }
        [DisplayName("Start Time")]
        public DateTime _appointmentStartTime { get; set; }
        [DisplayName("End Time")]
        public DateTime _appointmentEndTime { get; set; }
    }

    /// <summary>
    ///Creator:            Ethan McElree
    ///Created:            03/25/2024
    ///Summary:            View model for appointments.
    ///Last Updated By:    Ethan McElree
    ///Last Updated:       03/25/2024
    ///What Was Changed:   Initial Creation
    /// </summary>
    public class AppointmentVM : Appointment
    {
        public int _locationId { get; set; }
        public Boolean _status { get; set; }
        [DisplayName("Employee")]
        public string _employeeID { get; set; }
    }
}
