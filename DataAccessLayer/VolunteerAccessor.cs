using DataAccessInterfaces;
using DataObjects;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    /// <summary>
    /// Creator:            Ethan McElree
    /// Created:            04/1/2024
    /// Summary:            Accessor class for volunteers.
    /// Last Updated By:    Ethan McElree
    /// Last Updated:       04/1/2024
    /// What Was Changed:   Initial Creation
    /// </summary>
    public class VolunteerAccessor : IVolunteerAccessor
    {
        /// <summary>
        /// Creator: Andrew Larson
        /// Created: 04/02/2024
        /// Summary: Data access method to update the volunteer data
        /// Last Updated By: Andrew Larson
        /// Last Updated: 04/02/2024
        /// What Was Changed: Initial Creation
        /// </summary>
        public VolunteerVM UpdateVolunteer(string volunteerID, string firstName, string lastName, string phone, bool gender, string address, int zip)
        {
            VolunteerVM volunteer = new VolunteerVM();

            var conn = DatabaseConnection.GetConnection();
            var cmdText = "sp_update_volunteer";
            var cmd = new SqlCommand(cmdText, conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@VolunteerID", SqlDbType.NVarChar, 100).Value = volunteerID;
            cmd.Parameters.Add("@NewFname", SqlDbType.NVarChar, 25).Value = firstName;
            cmd.Parameters.Add("@NewLname", SqlDbType.NVarChar, 25).Value = lastName;
            cmd.Parameters.Add("@NewPhone", SqlDbType.NVarChar, 15).Value = phone;
            cmd.Parameters.Add("@NewGender", SqlDbType.Bit).Value = gender;
            cmd.Parameters.Add("@NewAddress", SqlDbType.NVarChar, 50).Value = address;
            cmd.Parameters.Add("@NewZipCode", SqlDbType.Int).Value = zip;

            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conn.Close();
            }
            return volunteer;
        }

        /// <summary>
        /// Creator:            Ethan McElree
        /// Created:            04/8/2024
        /// Summary:            Accessor method for deleting a volunteer
        /// Last Updated By:    Ethan McElree
        /// Last Updated:       04/8/2024
        /// What Was Changed:   Initial Creation
        /// </summary>
        public bool DeleteVolunteer(VolunteerVM volunteerVM)
        {
            bool result = false;
            var conn = DatabaseConnection.GetConnection();
            var commandText = "sp_delete_volunteer";
            var cmd = new SqlCommand(commandText, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@VolunteerID", SqlDbType.NVarChar, 100);
            cmd.Parameters["@VolunteerID"].Value = volunteerVM.VolunteerID;

            try
            {
                conn.Open();
                result = cmd.ExecuteNonQuery() > 0;          
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

        /// <summary>
        /// Creator:            Ethan McElree
        /// Created:            04/12/2024
        /// Summary:            Accessor method for retrieveing a volunteer by their id
        /// Last Updated By:    Ethan McElree
        /// Last Updated:       04/12/2024
        /// What Was Changed:   Initial Creation
        /// </summary>
        public VolunteerVM RetrieveVolunteer(string volunteerID)
        {
            VolunteerVM volunteerVM = new VolunteerVM();
            var conn = DatabaseConnection.GetConnection();
            var commandText = "sp_retrieve_volunteer_by_id";
            var cmd = new SqlCommand(commandText, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@VolunteerID", SqlDbType.NVarChar, 100);
            cmd.Parameters["@VolunteerID"].Value = volunteerID;

            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        volunteerVM.VolunteerID = reader.GetString(0);
                        volunteerVM.FirstName = reader.GetString(1);
                        volunteerVM.LastName = reader.GetString(2);
                        volunteerVM.Phone = reader.GetString(3);
                        volunteerVM.Gender = reader.GetBoolean(4);
                        volunteerVM.PasswordHash = reader.GetString(5);
                        volunteerVM.AccountStatus = reader.GetBoolean(6);
                        volunteerVM.RoleID = reader.GetString(7);
                        volunteerVM.RegistrationDate = reader.GetDateTime(8);
                        volunteerVM.Address = reader.GetString(9);
                        volunteerVM.ZipCode = reader.GetInt32(10);
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
            return volunteerVM;
        }

        /// <summary>
        /// Creator:            Ethan McElree
        /// Created:            04/1/2024
        /// Summary:            Method for viewing all of the volunteers
        /// Last Updated By:    Ethan McElree
        /// Last Updated:       04/1/2024
        /// What Was Changed:   Initial Creation
        /// </summary>
        public List<VolunteerVM> ViewVolunteers()
        {
            List<VolunteerVM> volunteerVMs = new List<VolunteerVM>();
            var conn = DatabaseConnection.GetConnection();
            var commandText = "sp_get_all_volunteers";
            var cmd = new SqlCommand(commandText, conn);

            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        VolunteerVM volunteer = new VolunteerVM()
                        {
                            VolunteerID = reader.GetString(0),
                            FirstName = reader.GetString(1),
                            LastName = reader.GetString(2),
                            Phone = reader.GetString(3),
                            Gender = reader.GetBoolean(4),
                            PasswordHash = reader.GetString(5),
                            AccountStatus = reader.GetBoolean(6),
                            RoleID = reader.GetString(7),
                            RegistrationDate = reader.GetDateTime(8),
                            Address = reader.GetString(9),
                            ZipCode = reader.GetInt32(10),
                        };
                        Role role = new Role()
                        {
                            RoleID = volunteer.RoleID
                        };
                        List<Role> roles = new List<Role>();
                        roles.Add(role);
                        volunteer.Roles = roles;
                        volunteerVMs.Add(volunteer);
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
            return volunteerVMs;
        }

        /// <summary>
        /// Creator:            Donald Winchester
        /// Created:            04/25/2024
        /// Summary:            Method for creating volunteers
        /// Last Updated By:    Donald Winchester
        /// Last Updated:       04/25/2024
        /// What Was Changed:   Initial Creation
        /// </summary>
        public bool CreateVolunteer(Volunteer volunteer)
        {
            bool result = false;
            SqlConnection conn = DatabaseConnection.GetConnection();
            var cmd = new SqlCommand("sp_insert_volunteer_signup", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            // Clear existing parameters
            cmd.Parameters.Clear();

            cmd.Parameters.AddWithValue("@FirstName", volunteer.FirstName);
            cmd.Parameters.AddWithValue("@LastName", volunteer.LastName);
            cmd.Parameters.AddWithValue("@Phone", volunteer.Phone);
            cmd.Parameters.AddWithValue("@Gender", volunteer.Gender);
            cmd.Parameters.AddWithValue("@AccountStatus", volunteer.AccountStatus);
            cmd.Parameters.AddWithValue("@RoleID", volunteer.RoleID);
            cmd.Parameters.AddWithValue("@PasswordHash", volunteer.PasswordHash);
            cmd.Parameters.AddWithValue("@VolunteerID", volunteer.VolunteerID);
            cmd.Parameters.AddWithValue("@RegistrationDate", volunteer.RegistrationDate);
            cmd.Parameters.AddWithValue("@Address", volunteer.Address);
            cmd.Parameters.AddWithValue("@ZipCode", volunteer.ZipCode);

            try
            {
                conn.Open();
                result = cmd.ExecuteNonQuery() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conn.Close();
            }

            return result;
        }
    }
}
