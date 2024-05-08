using DataAccessInterfaces;
using DataObjects;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer {
    /// <summary>
    /// Creator: Jared Harvey
    /// Created: 02/12/2024
    /// Summary: Manages getting all the data from the database relating to HousekeepingTask
    /// Last Updated By: Jared Harvey
    /// Last Updated: 02/12/2024
    /// What Was Changed: Initial Creation
    /// </summary>
    public class HousekeepingTaskAccessor : IHousekeepingTaskAccessor {
        public List<HouseKeepingTask> SelectAllHouseKeepingTasks()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Creator: Ethan McElree
        /// Created: 03/5/2024
        /// Summary: Accessor method for getting housekeeping task
        /// Last Updated By: Ethan McElree
        /// Last Updated: 03/5/2024
        /// What Was Changed: Initial Creation
        /// </summary>
        public HousekeepingTaskVM GetHousekeepingTaskVM(int taskID)
        {
            try
            {
                return null;
            }
            catch(Exception ex)
            {
                throw new ApplicationException("Failed to get housekeeping task", ex);
            }            
        }

        /// <summary>
        /// Creator: Jared Harvey
        /// Created: 03/04/2024
        /// Summary: Inserts new HousekeepingTask field into the database
        /// Last Updated By: Jared Harvey
        /// Last Updated: 03/04/2024
        /// What Was Changed: Initial Creation
        /// </summary>
        public int InsertHousekeepingTask(HousekeepingTask task) {
            int rows;

            // create connection object
            var conn = DatabaseConnection.GetConnection();

            // set the command text
            var commandText = "sp_insert_housekeeping_task";

            // create command object
            var cmd = new SqlCommand(commandText, conn);

            // set command type
            cmd.CommandType = CommandType.StoredProcedure;

            // add parameters to command
            cmd.Parameters.Add("@RoomID", SqlDbType.Int);
            cmd.Parameters.Add("@Type", SqlDbType.NVarChar, 50);
            cmd.Parameters.Add("@Description", SqlDbType.NVarChar, 255);

            // set parameter values
            cmd.Parameters["@RoomID"].Value = task.RoomID;
            cmd.Parameters["@Type"].Value = task.Type;
            cmd.Parameters["@Description"].Value = task.Description;

            try {
                // open connection
                conn.Open();

                // execute command
                rows = cmd.ExecuteNonQuery();
            } catch (Exception ex) {
                throw ex;
            } finally {
                conn.Close();
            }
            return rows;
        }

        /// <summary>
        /// Creator: Jared Harvey
        /// Created: 02/12/2024
        /// Summary: Queries the database for all HousekeepingTasks in a given shelter.
        /// Last Updated By: Jared Harvey
        /// Last Updated: 02/12/2024
        /// What Was Changed: Initial Creation
        /// </summary>
        public List<HousekeepingTaskVM> SelectHousekeepingTasksByShelterID(string shelterID) 
        {
            List<HousekeepingTaskVM> result = new List<HousekeepingTaskVM>();

            var conn = DatabaseConnection.GetConnection();
            var commandText = "sp_get_housekeeping_tasks";
            var cmd = new SqlCommand(commandText, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ShelterID", SqlDbType.NVarChar);
            cmd.Parameters["@ShelterID"].Value = shelterID;

            try {
                conn.Open();
                var reader = cmd.ExecuteReader();
                if (reader.HasRows) {
                    while (reader.Read()) {
                        HousekeepingTaskVM d = new HousekeepingTaskVM();
                        d.TaskID = reader.GetInt32(0);
                        d.RoomID = reader.GetInt32(1);
                        d.EmployeeID = reader.IsDBNull(2) ? "" : reader.GetString(2);
                        d.Type = reader.GetString(3);
                        d.Description = reader.GetString(4);
                        d.Date = reader.GetDateTime(5);
                        d.Status = reader.GetString(6);
                        d.RoomNumber = reader.GetInt32(7);
                        d.EmployeeName = reader.IsDBNull(2) ? "Unclaimed" : reader.GetString(8) + " " + reader.GetString(9);
                        result.Add(d);
                    }
                }
            } catch (Exception ex) {
                throw ex;
            } finally {
                conn.Close();
            }
            return result;
        }

        /// <summary>
        /// Creator: Ethan McElree
        /// Created: 03/4/2024
        /// Summary: Accessor method for updating a housekeeping task status
        /// Last Updated By: Ethan McElree
        /// Last Updated: 03/4/2024
        /// What Was Changed: Initial Creation
        /// </summary>
        public void UpdateHousekeepingTaskStatus(int TaskID, string Status)
        {
            var conn = DatabaseConnection.GetConnection();
            var commandText = "sp_update_housekeeping_task_status";
            var cmd = new SqlCommand(commandText, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@TaskID", SqlDbType.Int);
            cmd.Parameters.Add("@Status", SqlDbType.NVarChar, 50);

            cmd.Parameters["@TaskID"].Value = TaskID;
            cmd.Parameters["@Status"].Value = Status;

            try
            {
                conn.Open();
                var response = cmd.ExecuteNonQuery();                
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
        }

        /// <summary>
        /// Creator: Jared Harvey
        /// Created: 04/27/2024
        /// Summary: Implementation for UpdateAssignedHousekeeper
        /// Last Updated By: 
        /// Last Updated: 
        /// What Was Changed:
        /// </summary>
        public int UpdateAssignedHousekeeper(int taskID, string userID) {
            int result = 0;
            var conn = DatabaseConnection.GetConnection();
            var commandText = "sp_update_assigned_housekeeper";
            var cmd = new SqlCommand(commandText, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@TaskID", SqlDbType.Int);
            cmd.Parameters.Add("@EmployeeID", SqlDbType.NVarChar, 255);

            cmd.Parameters["@TaskID"].Value = taskID;
            cmd.Parameters["@EmployeeID"].Value = userID;

            try {
                conn.Open();
                result = cmd.ExecuteNonQuery();
            } catch (Exception ex) {
                throw ex;
            } finally {
                conn.Close();
            }
            return result;
        }
    }
}

