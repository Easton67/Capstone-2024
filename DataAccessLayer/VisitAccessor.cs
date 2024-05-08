using DataAccessInterfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataObjects;
using System.Security.Policy;

namespace DataAccessLayer
{
    /// <summary>
    /// Creator: Ibrahim Albashair
    /// Created: 02/10/2024
    /// Summary: Created VisitAccessor
    /// Last Updated By: Ibrahim Albashair
    /// Last Updated 02/10/2024
    /// What was changed: Initial Creation.
    /// </summary>
    public class VisitAccessor : IVisitAccessor
    {
        /// <summary>
        /// Creator: Ibrahim Albashair
        /// Created: 02/10/2024
        /// Summary: Created createViist 
        /// Last Updated By: Ibrahim Albashair
        /// Last Updated 02/10/2024
        /// What was changed: Initial Creation.
        /// Last Updated By: Matthew Baccam
        /// Last Updated 02/28/2024
        /// What was changed: I made the CreateVisit pass a object in the param instead of the individual properties of that obj
        /// </summary>
        public int CreateVisit(Visit visit)
        {
            int rows = 0;

            var connection = DatabaseConnection.GetConnection();
            var commandText = "sp_create_visit";
            var cmd = new SqlCommand(commandText, connection);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@FirstName", SqlDbType.NVarChar, 100);
            cmd.Parameters.Add("@LastName", SqlDbType.NVarChar, 100);
            cmd.Parameters.Add("@CheckIn", SqlDbType.DateTime);
            cmd.Parameters.Add("@CheckOut", SqlDbType.DateTime);
            cmd.Parameters.Add("@VisitReason", SqlDbType.NVarChar, 100);

            cmd.Parameters["@FirstName"].Value = visit.FirstName;
            cmd.Parameters["@LastName"].Value = visit.LastName;
            cmd.Parameters["@CheckIn"].Value = visit.CheckIn;
            cmd.Parameters["@CheckOut"].Value = visit.CheckOut;
            cmd.Parameters["@VisitReason"].Value = visit.VisitReason;

            try
            {
                connection.Open();
                rows = cmd.ExecuteNonQuery();
                if (rows == 0)
                {
                    throw new ArgumentException("Invalid Inputs");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally { connection.Close(); }
            return rows;
        }


        /// <summary>
        /// Creator: Ibrahim Albashair
        /// Created: 02/10/2024
        /// Summary: Delete a visit by VisitID
        /// Last Updated By: Ibrahim Albashair
        /// Last Updated 02/10/2024
        /// What was changed: Initial Creation.
        /// Last Updated 04/04/2024
        /// Last Updated By: Matthew Baccam 
        /// What Was changed: Madet the delete method uses the whole object selected rather than the visit id
        /// </summary>
        public int DeleteVisit(Visit visit)
        {
            int rows = 0;

            var connection = DatabaseConnection.GetConnection();
            var commandText = "sp_delete_visit";
            var cmd = new SqlCommand(commandText, connection);
            cmd.CommandType = CommandType.StoredProcedure;
            
            cmd.Parameters.AddWithValue("@VisitID", visit.VisitID);
            cmd.Parameters.AddWithValue("@FirstName", visit.FirstName);
            cmd.Parameters.AddWithValue("@LastName", visit.LastName);
            cmd.Parameters.AddWithValue("@CheckIn", visit.CheckIn);
            cmd.Parameters.AddWithValue("@CheckOut", visit.CheckOut);
            cmd.Parameters.AddWithValue("@VisitReason", visit.VisitReason);
            cmd.Parameters.AddWithValue("@Status", visit.Status);

            try
            {
                connection.Open();
                rows = cmd.ExecuteNonQuery();
                if (rows == 0)
                {
                    throw new ArgumentException("Invalid Inputs");
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally { connection.Close(); }
            return rows;
        }

        /// <summary>
        /// Creator: Ibrahim Albashair
        /// Created: 02/10/2024
        /// Summary: Created getAllVisitsByName 
        /// Last Updated By: Ibrahim Albashair
        /// Last Updated 02/10/2024
        /// What was changed: Initial Creation.
        /// Last Updated By: Matthew Baccam
        /// Last Updated 02/28/2024
        /// What was changed: I made it read in DateTime for check in and check out rather than a string
        /// </summary>
        public List<Visit> GetAllVisitsByName(string firstName, string lastName)
        {
            List<Visit> visits = new List<Visit>();

            var conn = DatabaseConnection.GetConnection();
            var cmdText = "sp_view_visits_on_firstname";
            var cmd = new SqlCommand(cmdText, conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@FirstName", SqlDbType.NVarChar, 100);
            cmd.Parameters.Add("@LastName", SqlDbType.NVarChar, 100);

            cmd.Parameters["@Firstname"].Value = firstName;
            cmd.Parameters["@LastName"].Value = lastName;

            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var v = new Visit();
                        v.VisitID = reader.GetInt32(0);
                        v.FirstName = reader.GetString(1);
                        v.LastName = reader.GetString(2);
                        v.CheckIn = reader.GetDateTime(3);
                        v.CheckOut = reader.GetDateTime(4);
                        v.VisitReason = reader.GetString(5);
                        v.Status = reader.GetBoolean(6);
                        visits.Add(v);
                    }
                }
            }
            catch (Exception ex) { throw ex; }
            finally { conn.Close(); }
            return visits;
        }

        /// <summary>
        /// Creator: Ibrahim Albashair
        /// Created: 02/20/2024
        /// Summary: Returns int, Reschules visit by visit ID
        /// Last Updated By: Ibrahim Albashair
        /// Last Updated 02/10/2024
        /// What was changed: Initial Creation.
        /// Last Updated 02/28/2024
        /// What was changed: I made it read in DateTime for check in and check out rather than a string
        /// </summary>
        public int RescheduleVisit(int visitID, DateTime checkIn, DateTime checkOut)
        {
            int rows = 0;

            var connection = DatabaseConnection.GetConnection();
            var commandText = "sp_reschedule_visit";
            var cmd = new SqlCommand(commandText, connection);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@VisitID", SqlDbType.Int);
            cmd.Parameters.Add("@CheckIn", SqlDbType.DateTime);
            cmd.Parameters.Add("@CheckOut", SqlDbType.NVarChar);

            cmd.Parameters["@VisitID"].Value = visitID;
            cmd.Parameters["@checkIn"].Value = checkIn;
            cmd.Parameters["@CheckOut"].Value = checkOut;

            try
            {
                connection.Open();
                rows = cmd.ExecuteNonQuery();
                if (rows == 0)
                {
                    throw new ArgumentException("Invalid Inputs");
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally { connection.Close(); }
            return rows;
        }


        /// <Summary>
        /// Creator: Matthew Baccam
        /// Created: 02/08/2024
        /// Summary: Initial Creation
        /// Last Updated By: Matthew Baccam
        /// Last Updated: 02/08/2024
        /// What Was Changed: Initial Creation
        /// Last Updated By: Liam Easton
        /// Last Updated: 04/04/2024
        /// What Was Changed: Added brackets around the if statement
        /// <Summary>
        public int VisitCount(DateTime searchDate)
        {
            int rows = 0;

            var connection = DatabaseConnection.GetConnection();
            var commandText = "sp_select_visit_count";
            var cmd = new SqlCommand(commandText, connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@VisitDate", searchDate);

            try
            {
                connection.Open();
                rows = (int)cmd.ExecuteScalar();

                if (rows < 0)
                {
                    throw new Exception("Failed to gather appointments");
                }
                return rows;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }
        }

        /// <Summary>
        /// Creator: Matthew Baccam
        /// Created: 02/15/2024
        /// Summary: Initial Creation
        /// Last Updated By: Matthew Baccam
        /// Last Updated: 02/15/2024
        /// What Was Changed: Initial Creation
        /// Last Updated By: Liam Easton
        /// Last Updated: 04/04/2024
        /// What Was Changed: Added brackets around the if statement
        /// <Summary>
        public bool UpdateVisitForCheckInByVisitID(int visitID, DateTime oldCheckIn)
        {
            var connection = DatabaseConnection.GetConnection();
            var commandText = "sp_update_visit_for_checkin_with_visitID";
            var cmd = new SqlCommand(commandText, connection);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@VisitID", visitID);
            cmd.Parameters.AddWithValue("@OldCheckIn", oldCheckIn);
            try
            {
                connection.Open();
                var rows = cmd.ExecuteNonQuery();

                if (rows == 0)
                {
                    throw new Exception("Failed to update for check in");
                }

                return rows == 1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }
        }

        /// <Summary>
        /// Creator: Matthew Baccam
        /// Created: 02/15/2024
        /// Summary: Initial Creation
        /// Last Updated By: Matthew Baccam
        /// Last Updated: 02/15/2024
        /// What Was Changed: Initial Creation        
        /// Last Updated By: Liam Easton
        /// Last Updated: 04/04/2024
        /// What Was Changed: Added brackets around the if statement
        /// <Summary>
        public bool UpdateVisitForCheckOutByVisitID(int VisitID, DateTime oldCheckOut)
        {
            var connection = DatabaseConnection.GetConnection();
            var commandText = "sp_update_visit_for_checkout_with_visitID";
            var cmd = new SqlCommand(commandText, connection);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@VisitID", VisitID);
            cmd.Parameters.AddWithValue("@OldCheckOut", oldCheckOut);

            try
            {
                connection.Open();
                var rows = cmd.ExecuteNonQuery();

                if (rows == 0) 
                {
                    throw new Exception("Failed to update for check out");
                }

                return rows == 1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }
        }

        /// <Summary>
        /// Creator: Matthew Baccam
        /// Created: 02/15/2024
        /// Summary: Initial Creation
        /// Last Updated By: Matthew Baccam
        /// Last Updated: 02/15/2024
        /// What Was Changed: Initial Creation
        /// <Summary>
        public List<Visit> SelectVisitWithFromTo(DateTime from, DateTime to)
        {
            var visits = new List<Visit>();

            var conn = DatabaseConnection.GetConnection();
            var cmdText = "sp_search_for_visits_with_from_to";
            var cmd = new SqlCommand(cmdText, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@From", from);
            cmd.Parameters.AddWithValue("@To", to);

            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var visit = new Visit();
                        visit.VisitID = reader.GetInt32(0);
                        visit.FirstName = reader.GetString(1);
                        visit.LastName = reader.GetString(2);
                        visit.CheckIn = reader.GetDateTime(3);
                        visit.CheckOut = reader.GetDateTime(4);
                        visit.VisitReason = reader.GetString(5);
                        visit.Status = reader.GetBoolean(6);
                        visits.Add(visit);
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

            return visits;
        }

        /// <Summary>
        /// Creator: Matthew Baccam
        /// Created: 02/15/2024
        /// Summary: Initial Creation
        /// Last Updated By: Matthew Baccam
        /// Last Updated: 02/15/2024
        /// What Was Changed: Initial Creation
        /// <Summary>
        public Visit SelectVisitByVisitID(int visitID)
        {
            var visit = new Visit();

            var conn = DatabaseConnection.GetConnection();
            var cmdText = "sp_select_visit_by_visitID";
            var cmd = new SqlCommand(cmdText, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@VisitID", visitID);

            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        visit.VisitID = reader.GetInt32(0);
                        visit.FirstName = reader.GetString(1);
                        visit.LastName = reader.GetString(2);
                        visit.CheckIn = reader.GetDateTime(3);
                        visit.CheckOut = reader.GetDateTime(4);
                        visit.VisitReason = reader.GetString(5);
                        visit.Status = reader.GetBoolean(6);
                    }
                }
                else
                {
                    throw new Exception("Failed to select visit");
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

            return visit;
        }

        /// <summary>
        /// Creator: Ibrahim Albashair
        /// Created: 02/20/2024
        /// Summary: Returns List of all Visits
        /// Last Updated By: Ibrahim Albashair
        /// Last Updated 02/10/2024
        /// What was changed: Initial Creation.        
        /// </summary>
        public List<Visit> GetAllVisits()
        {
            List<Visit> visits = new List<Visit>();

            var conn = DatabaseConnection.GetConnection();
            var cmdText = "sp_view_all_visits";
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
                        var v = new Visit();
                        v.VisitID = reader.GetInt32(0);
                        v.FirstName = reader.GetString(1);
                        v.LastName = reader.GetString(2);
                        v.CheckIn = reader.GetDateTime(3);
                        v.CheckOut = reader.GetDateTime(4);
                        v.VisitReason = reader.GetString(5);
                        v.Status = reader.GetBoolean(6);
                        visits.Add(v);
                    }
                }
            }
            catch (Exception ex) { throw ex; }
            finally { conn.Close(); }
            return visits;
        }
    }
}
