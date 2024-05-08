using DataAccessInterfaces;
using DataObjects;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class AppointmentAccessor : IAppointmentAccessor
    {

        /// <summary>
        /// Creator:            Miyada Abas
        /// Created:            03/14/2024
        /// Summary:            This is the accessor Method to Remove Appointment.
        /// Last Updated By:    Miyada Abas
        /// Last Updated:       03/14/2024
        /// What Was Changed:   Initial Creation
        /// </summary>
        public bool RemoveAppointment(Appointment appointment)
        {
            bool result = false;
            var conn = DatabaseConnection.GetConnection();
            var commandText = "sp_Remove_appointment";
            var cmd = new SqlCommand(commandText, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ClientID", appointment._clientID);
            cmd.Parameters.AddWithValue("@AppoitmentType", appointment._appointmentType);
            cmd.Parameters.AddWithValue("@AppoitmentStartTime", appointment._appointmentStartTime);
            cmd.Parameters.AddWithValue("@AppoitmentEndTime", appointment._appointmentEndTime);
            try
            {
                conn.Open();
                result = cmd.ExecuteNonQuery()==1;
            }
            catch (Exception)
            {
                throw;
            }
            finally { conn.Close(); }   
            return result;
        }

        /// <summary>
        /// Creator:            Seth Nerney
        /// Created:            02/22/2024
        /// Summary:            This is the access class for the Appointments.
        /// Last Updated By:    Seth Nerney
        /// Last Updated:       02/22/2024
        /// What Was Changed:   Initial Creation
        /// </summary>
        public List<Appointment> ViewAllAppointments()
        {
            List<Appointment> appointments = new List<Appointment>();
            var conn = DatabaseConnection.GetConnection();
            var commandText = "sp_get_all_appointments";
            var cmd = new SqlCommand(commandText, conn);

            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Appointment appointment = new Appointment()
                        {
                            _clientID = reader.GetString(0),
                            _locationName = reader.GetString(1),
                            _appointmentStartTime = reader.GetDateTime(2),
                            _appointmentEndTime = reader.GetDateTime(3),
                            _appointmentType = reader.GetString(4),
                            _appointmentID = reader.GetInt32(5)
                        };
                        appointments.Add(appointment);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return appointments;
        }

        /// <summary>
        /// Creator:            Ethan McElree
        /// Created:            03/25/2024
        /// Summary:            Accessor method for creating an appointment.
        /// Last Updated By:    Ethan McElree
        /// Last Updated:       04/26/2024
        /// What Was Changed:   Changed the status so it equals 1 so that when the appointment is created it gets added to the list
        /// since the stored procedure for getting all appointments only gets the appointments that have a status that equals 1.
        /// </summary>
        public void CreateAppointment(AppointmentVM appointment)
        {
            var conn = DatabaseConnection.GetConnection();
            var commandText = "sp_create_appointment";
            var cmd = new SqlCommand(commandText, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ClientID", SqlDbType.NVarChar, 100);
            cmd.Parameters.Add("@LocationID", SqlDbType.Int);
            cmd.Parameters.Add("@AppointmentStartTime", SqlDbType.DateTime);
            cmd.Parameters.Add("@AppointmentEndTime", SqlDbType.DateTime);
            cmd.Parameters.Add("@AppointmentType", SqlDbType.NVarChar, 25);
            cmd.Parameters.Add("@Status", SqlDbType.Bit);
            cmd.Parameters.Add("@EmployeeID", SqlDbType.NVarChar, 100);

            cmd.Parameters["@ClientID"].Value = appointment._clientID;
            cmd.Parameters["@LocationID"].Value = appointment._locationId;
            cmd.Parameters["@AppointmentStartTime"].Value = appointment._appointmentStartTime;
            cmd.Parameters["@AppointmentEndTime"].Value = appointment._appointmentEndTime;
            cmd.Parameters["@AppointmentType"].Value = appointment._appointmentType;
            cmd.Parameters["@Status"].Value = 1;
            cmd.Parameters["@EmployeeID"].Value = appointment._employeeID;

            try
            {
                conn.Open();
                var reader = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
