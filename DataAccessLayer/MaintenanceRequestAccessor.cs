using DataAccessInterfaces;
using DataObjects;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    /// <summary>
    /// Creator:            Mitchell Stirmel
    /// Created:            02/08/2024
    /// Summary:            This class gets the maintenance request table data.
    /// Last Updated By:    Mitchell Stirmel
    /// Last Updated:       02/08/2024
    /// What Was Changed:   Initial Creation
    /// </summary>
    public class MaintenanceRequestAccessor : IMaintenanceAccessor
    {
        /// <summary>
        /// Creator:            Jared Harvey
        /// Created:            03/03/2024
        /// Summary:            Method implementation for InsertMaintenanceRequest.
        /// Last Updated By:    Jared Harvey
        /// Last Updated:       03/03/2024
        /// What Was Changed:   Initial Creation
        /// </summary>
        public int InsertMaintenanceRequest(MaintenanceRequest maintenanceRequest) {
            int rows = 0;

            // create connection object
            var conn = DatabaseConnection.GetConnection();

            // set the command text
            var commandText = "sp_insert_maintenance_request";

            // create command object
            var cmd = new SqlCommand(commandText, conn);

            // set command type
            cmd.CommandType = CommandType.StoredProcedure;

            // add parameters to command
            cmd.Parameters.Add("@RoomID", SqlDbType.Int);
            cmd.Parameters.Add("@Urgency", SqlDbType.NVarChar, 50);
            cmd.Parameters.Add("@Requester", SqlDbType.NVarChar, 50);
            cmd.Parameters.Add("@Phone", SqlDbType.NVarChar, 50);
            cmd.Parameters.Add("@Description", SqlDbType.NVarChar, 255);

            // set parameter values
            cmd.Parameters["@RoomID"].Value = maintenanceRequest._roomID;
            cmd.Parameters["@Urgency"].Value = maintenanceRequest._urgency;
            cmd.Parameters["@Requester"].Value = maintenanceRequest._requestor;
            cmd.Parameters["@Phone"].Value = maintenanceRequest._phone;
            cmd.Parameters["@Description"].Value = maintenanceRequest._description;

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
        ///Creator:            Mitchell Stirmel
        ///Created:            02/08/2024
        ///Summary:            This method gets all the maintenance requests.
        ///Last Updated By:    Jared Harvey
        ///Last Updated:       03/08/2024
        ///What Was Changed:   Changed from property to an actual method
        /// </summary>
        public List<MaintenanceRequest> ViewMaintenanceRequests()
        {
            SqlConnection sqlConn = DatabaseConnection.GetConnection();
            var cmd = new SqlCommand("sp_get_shelter_maintenance_requests");
            cmd.Connection = sqlConn;

            List<MaintenanceRequest> returnList = new List<MaintenanceRequest>();

            try
            {
                sqlConn.Open();

                var reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        MaintenanceRequest request = new MaintenanceRequest();

                        request._status = reader.GetString(0);
                        request._requestID = reader.GetInt32(1);
                        request._roomID = reader.GetInt32(2);
                        request._urgency = reader.GetString(3);
                        request._dateCreated = reader.GetDateTime(4);
                        request._phone = reader.GetString(5);
                        request._requestor = reader.GetString(6);
                        request._description = reader.GetString(7);

                        returnList.Add(request);
                    }
                }
                return returnList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally { sqlConn.Close(); }
        }


        /// <summary>
        /// Creator:            Marwa Ibrahim
        /// Created:            02/08/2024
        /// Summary:            This class Create the maintenance request table data.
        /// What Was Changed:   Initial Creation
        /// </summary>
        public bool insertMaintenanceRequest(MaintenanceRequest maintenanceRequest)
        {
            bool result = true;

            SqlConnection sqlConn = DatabaseConnection.GetConnection();
            var cmd = new SqlCommand("sp_Create_maintenance_request", sqlConn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@_roomID", maintenanceRequest._roomID);
            cmd.Parameters.AddWithValue("@Status", maintenanceRequest._status);
            cmd.Parameters.AddWithValue("@_requestor", maintenanceRequest._requestor);
            cmd.Parameters.AddWithValue("@_phone", maintenanceRequest._phone);
            cmd.Parameters.AddWithValue("@_dateCreated", maintenanceRequest._dateCreated);
            cmd.Parameters.AddWithValue("@_description", maintenanceRequest._description);
            try
            {
                sqlConn.Open();
                result = cmd.ExecuteNonQuery() == 1;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally { sqlConn.Close(); }
            return result;
        }

        /// <summary>
        /// Creator:            Kirsten Stage
        /// Created:            03/07/2024
        /// Summary:            This method updates the maintenance request status to completed.
        /// Last Updated By:    Kirsten Stage
        /// Last Updated:       03/07/2024
        /// What Was Changed:   Initial Creation
        /// </summary>
        public int UpdateMaintenanceRequestStatusToCompleted(int requestID)
        {
            int rows = 0;

            var conn = DatabaseConnection.GetConnection();
            var cmdText = "sp_updateStatus_to_complete";
            var cmd = new SqlCommand(cmdText, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@RequestID", requestID);

            try
            {
                conn.Open();
                rows = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }

            return rows;
        }
        /// <summary>
        /// Creator:            Donald Winchester
        /// Created:            02/23/2024
        /// Summary:            This data access method confirms the maintenance request
        /// Last Updated By:    Donald Winchester
        /// Last Updated:       03/08/2024
        /// What Was Changed:   Initial Creation
        /// </summary>

        public int ConfirmMaintenanceRequest(int requestID, string status)
        {
            int rows = 0;

            var conn = DatabaseConnection.GetConnection();
            var commandText = "sp_confirm_maintenance_request";
            var cmd = new SqlCommand(commandText, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@RequestID", SqlDbType.Int);
            cmd.Parameters.Add("@Status", SqlDbType.NVarChar, 50);

            cmd.Parameters["@RequestID"].Value = requestID;
            cmd.Parameters["@Status"].Value = status;

            try
            {
                conn.Open();

                rows = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
            return rows;
        }

        /// <summary>
        /// Creator: Matthew Baccam
        /// Created: 03/01/2024
        /// Summary: Updates maintenance request for suspension
        /// Last Updated By: Matthew Baccam
        /// Last Updated 03/01/2024
        /// What was changed: Initial Creation.
        /// </summary>
        public bool UpdateMaintenanceRequestForSuspension(int requestID, string oldDescription, string newDescription)
        {
            int rows = 0;

            var connection = DatabaseConnection.GetConnection();
            var commandText = "sp_suspend_maintenance_request";
            var cmd = new SqlCommand(commandText, connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@RequestID", requestID);
            cmd.Parameters.AddWithValue("@OldRequestDescription", oldDescription);
            cmd.Parameters.AddWithValue("@NewRequestDescription", newDescription);

            try
            {
                connection.Open();
                rows = cmd.ExecuteNonQuery();
                if (rows == 0)
                {
                    throw new Exception("Failed to save the suspension");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally { connection.Close(); }
            return rows == 1;
        }

        /// <summary>
        /// Creator:Andres Garcia
        /// Created: 04/019/2024
        /// Summary: Adds a scheduled repair
        /// Last Updated By: Andres Garcia
        /// Last Updated: 04/019/2024
        /// What was Changed: Initial Creation
        /// </summary>

        public bool ScheduleRepair(int requestID, string employeeID, DateTime repairDate)
        {
            int rows = 0;

            var connection = DatabaseConnection.GetConnection();

            var commandText = "sp_schedule_repair";

            var cmd = new SqlCommand(commandText, connection);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@RequestID", requestID);
            cmd.Parameters.AddWithValue("@EmployeeID", employeeID);
            cmd.Parameters.AddWithValue("@RepairDate", repairDate);

            try
            {
                // open the connection
                connection.Open();

                // an update is executed nonquery
                rows = cmd.ExecuteNonQuery();
                if (rows == 0)
                {
                    // create a failed update as an exception
                    throw new Exception("Failed to schedule repair");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally { connection.Close(); }
            return rows == 1;
        }

        public List<ScheduledRepairs> ViewScheduledRepairs(string status)
        {
            /// <summary>
            /// Creator:            Seth Nerney
            /// Created:            02/13/2024
            /// Summary:            This method gets all the scheduled repairs.
            /// Last Updated By:    Seth Nerney
            /// Last Updated:       02/13/2024
            /// What Was Changed:   Initial Creation
            /// </summary>

            List<ScheduledRepairs> scheduledRepairs = new List<ScheduledRepairs>();
            var conn = DatabaseConnection.GetConnection();
            var commandText = "sp_get_shelter_scheduled_repairs";
            var cmd = new SqlCommand(commandText, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Status", SqlDbType.NVarChar, 50);
            cmd.Parameters["@Status"].Value = status;

            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        ScheduledRepairs scheduledRepair = new ScheduledRepairs()
                        {
                            _repairID = reader.GetInt32(0),
                            _requestID = reader.GetInt32(1),
                            _employeeID = reader.GetString(2),
                            _status = reader.GetString(3)
                        };
                        scheduledRepairs.Add(scheduledRepair);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }


            return scheduledRepairs;
        }
    }
}
