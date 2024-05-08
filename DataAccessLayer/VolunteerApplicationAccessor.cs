using DataAccessInterfaces;
using DataObjects;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace DataAccessLayer
{
    /// <summary>
    ///Creator:            Mitchell Stirmel
    ///Created:            03/20/2024
    ///Summary:            Class used to operate on data regarding volunteer applications.
    ///Last Updated By:    Mitchell Stirmel
    ///Last Updated:       03/20/2024
    ///What Was Changed:   Initial Creation
    /// </summary>
    public class VolunteerApplicationAccessor : IVolunteerApplicationAccessor
    {

        /// <summary>
        ///Creator:            Mitchell Stirmel
        ///Created:            03/20/2024
        ///Summary:            Selects all volunteer applications.
        ///Last Updated By:    Mitchell Stirmel
        ///Last Updated:       03/20/2024
        ///What Was Changed:   Initial Creation
        /// </summary>
        public List<VolunteerApplication> SelectVolunteerApplications()
        {
            List<VolunteerApplication> applications = new List<VolunteerApplication>();
            var conn = DatabaseConnection.GetConnection();
            var cmdText = "sp_select_volunteer_application";
            var cmd = new SqlCommand(cmdText, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        applications.Add(new VolunteerApplication()
                        {
                            ApplicationID = reader.GetInt32(0),
                            ApplicantID = reader.GetInt32(1),
                            Status = reader.GetString(2),
                            DateApplied = reader.GetDateTime(3),
                            ReasonForStatus= reader.GetString(4)
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
            return applications;
        }

        /// <summary>
        /// Creator:            Mitchell Stirmel
        /// Created:            03/20/2024
        /// Summary:            Selects a volunteer application given its id.
        /// Last Updated By:    Mitchell Stirmel
        /// Last Updated:       03/20/2024
        /// What Was Changed:   Initial Creation
        /// </summary>
        public VolunteerApplicationInfo SelectVolunteerApplicationById(int applicationId)
        {
            VolunteerApplicationInfo application = new VolunteerApplicationInfo();
            var conn = DatabaseConnection.GetConnection();
            var cmdText = "sp_select_volunteer_application_by_id";
            var cmd = new SqlCommand(cmdText, conn);
            cmd.Parameters.AddWithValue("@ApplicationID", applicationId);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        application.GivenName = reader.GetString(0);
                        application.FamilyName = reader.GetString(1);
                        application.PhoneNumber = reader.GetString(2);
                        application.Email = reader.GetString(3);
                        application.ApplicationReason = reader.GetString(4);
                        application.HoursDesired = reader.GetInt32(5);
                        application.VolunteerConcerns = reader.GetString(6);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
            return application;

        }

        /// <summary>
        /// Creator:            Mitchell Stirmel
        /// Created:            04/20/2024
        /// Summary:            Creates a full volunteer application
        /// Last Updated By:    Mitchell Stirmel
        /// Last Updated:       04/20/2024
        /// What Was Changed:   Initial Creation
        /// </summary>
        public bool CreateVolunteerApplication(CreateVolunteerApplication application)
        {
            var conn = DatabaseConnection.GetConnection();
            var cmdText = "sp_create_volunteer_application";
            var cmd = new SqlCommand(cmdText, conn);
            cmd.Parameters.AddWithValue("@GivenName", application.GivenName);
            cmd.Parameters.AddWithValue("@FamilyName", application.FamilyName);
            cmd.Parameters.AddWithValue("@PhoneNumber", application.PhoneNumber);
            cmd.Parameters.AddWithValue("@Email", application.Email);
            cmd.Parameters.AddWithValue("@ApplicationReason", application.ApplicationReason);
            cmd.Parameters.AddWithValue("@HoursDesired", application.HoursDesired);
            cmd.Parameters.AddWithValue("@VolunteerConcerns", application.VolunteerConcerns);
            cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                conn.Open();
                var count = cmd.ExecuteNonQuery();
                if(count > 0)
                {
                    return true;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
            return false;

        }

        /// <summary>
        /// Creator:            Darryl Shirley
        /// Created:            03/27/2024
        /// Summary:            Updates the status of the volunteer application.
        /// Last Updated By:    Darryl Shirley
        /// Last Updated:       03/27/2024
        /// What Was Changed:   Initial Creation
        /// </summary>
        public int UpdateVolunteerApplicationStatus(int volunteerApplicationID, string status, string reasonForStatus)
        {
            int rows = 0;
            var conn = DatabaseConnection.GetConnection();
            var commandText = "sp_update_VolunteerApplicationStatus";
            var cmd = new SqlCommand(commandText, conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@ApplicationID", SqlDbType.Int);
            cmd.Parameters.Add("@Status", SqlDbType.NVarChar, 50);
            cmd.Parameters.Add("@ReasonForStatus", SqlDbType.NVarChar, 255);

            cmd.Parameters["@ApplicationID"].Value = volunteerApplicationID;
            cmd.Parameters["@Status"].Value = status;
            cmd.Parameters["@ReasonForStatus"].Value = reasonForStatus;

            try
            {
                conn.Open();
                rows = cmd.ExecuteNonQuery();

                if (rows == 0)
                {
                    throw new ArgumentException("Fields not updated");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally { conn.Close(); }

            return rows;
        }

        /// <summary>
        ///Creator:           Suliman Suliman
        ///Created:            03/20/2024
        ///Summary:            Selects all volunteer applications.
        ///Last Updated By:    
        ///Last Updated:       
        ///What Was Changed:   
        /// </summary>
        public bool AcceptVolunteerApplication(VolunteerApplication volunteerApplication)
        {
            bool result = false;
            var conn = DatabaseConnection.GetConnection();
            var cmdText = "sp_accepting_volunteer_application";
            var cmd = new SqlCommand(cmdText, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ApplicationID", volunteerApplication.ApplicationID);
            cmd.Parameters.AddWithValue("@status", "Accepted");
            try
            {
                conn.Open();
                result = cmd.ExecuteNonQuery() == 1;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                conn.Close();
            }
            return result;
        }
    }
}
