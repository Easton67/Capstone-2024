using DataAccessInterfaces;
using DataObjects;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Remoting.Metadata.W3cXsd2001;

namespace DataAccessLayer {
    /// <summary>
    /// Creator:            Jared Harvey
    /// Created:            02/19/2024
    /// Summary:            Creation of StayAccessor class
    /// Last Updated By:    Jared Harvey
    /// Last Updated:       02/19/2024
    /// What Was Changed:   Initial Creation
    /// </summary>
    public class StayAccessor : IStayAccessor 
    {
        /// <summary>
        /// Creator:            Jared Harvey
        /// Created:            02/19/2024
        /// Summary:            Inserts new stay into database
        /// Last Updated By:    Jared Harvey
        /// Last Updated:       02/19/2024
        /// What Was Changed:   Initial Creation
        /// </summary>
        public int InsertStay(string clientID, int roomID) 
        {
            int rows = 0;

            var conn = DatabaseConnection.GetConnection();
            var commandText = "sp_assign_client_shelter";
            var cmd = new SqlCommand(commandText, conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@ClientID", SqlDbType.NVarChar);
            cmd.Parameters.Add("@RoomID", SqlDbType.Int);

            cmd.Parameters["@ClientID"].Value = clientID;
            cmd.Parameters["@RoomID"].Value = roomID;

            try {
                conn.Open();
                rows = cmd.ExecuteNonQuery();
            } catch (Exception ex) {
                throw ex;
            } finally {
                conn.Close();
            }
            return rows;
        }

        /// <summary>
        /// Creator:            Jared Harvey
        /// Created:            02/28/2024
        /// Summary:            Updates a stay
        /// Last Updated By:    Jared Harvey
        /// Last Updated:       02/28/2024
        /// What Was Changed:   Initial Creation
        /// </summary>
        public int UpdateStay(Stay oldStay, Stay newStay) {
            int rows = 0;
            // create connection object
            var conn = DatabaseConnection.GetConnection();

            // set the command text
            var commandText = "sp_update_stay";

            // create command object
            var cmd = new SqlCommand(commandText, conn);

            // set command type
            cmd.CommandType = CommandType.StoredProcedure;

            // add parameters to command
            cmd.Parameters.Add("@StayID", SqlDbType.Int);

            cmd.Parameters.Add("@OldClientID", SqlDbType.NVarChar);
            cmd.Parameters.Add("@OldRoomID", SqlDbType.Int);
            cmd.Parameters.Add("@OldInDate", SqlDbType.Date);
            cmd.Parameters.Add("@OldOutDate", SqlDbType.Date);
            cmd.Parameters.Add("@OldCheckedOut", SqlDbType.Bit);

            cmd.Parameters.Add("@NewClientID", SqlDbType.NVarChar);
            cmd.Parameters.Add("@NewRoomID", SqlDbType.Int);
            cmd.Parameters.Add("@NewInDate", SqlDbType.Date);
            cmd.Parameters.Add("@NewOutDate", SqlDbType.Date);
            cmd.Parameters.Add("@NewCheckedOut", SqlDbType.Bit);

            // set parameter values
            cmd.Parameters["@StayID"].Value = oldStay.StayID;

            cmd.Parameters["@OldClientID"].Value = oldStay.ClientID;
            cmd.Parameters["@OldRoomID"].Value = oldStay.RoomID;
            cmd.Parameters["@OldInDate"].Value = oldStay.InDate;
            cmd.Parameters["@OldOutDate"].Value = oldStay.OutDate;
            cmd.Parameters["@OldCheckedOut"].Value = oldStay.CheckedOut;

            cmd.Parameters["@NewClientID"].Value = newStay.ClientID;
            cmd.Parameters["@NewRoomID"].Value = newStay.RoomID;
            cmd.Parameters["@NewInDate"].Value = newStay.InDate;
            cmd.Parameters["@NewOutDate"].Value = newStay.OutDate;
            cmd.Parameters["@NewCheckedOut"].Value = newStay.CheckedOut;

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
        /// Creator:            Jared Harvey
        /// Created:            02/29/2024
        /// Summary:            Deletes stay
        /// Last Updated By:    Jared Harvey
        /// Last Updated:       02/29/2024
        /// What Was Changed:   Initial Creation
        /// </summary>
        public int DeleteStay(int stayID) {
            int rows = 0;

            // create connection object
            var conn = DatabaseConnection.GetConnection();

            // set the command text
            var commandText = "sp_delete_stay";

            // create command object
            var cmd = new SqlCommand(commandText, conn);

            // set command type
            cmd.CommandType = CommandType.StoredProcedure;

            // add parameters to command
            cmd.Parameters.Add("@StayID", SqlDbType.Int);

            // set parameter values
            cmd.Parameters["@StayID"].Value = stayID;

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
        /// Creator:            Jared Harvey
        /// Created:            02/29/2024
        /// Summary:            Gets all stays for a shelter
        /// Last Updated By:    Jared Harvey
        /// Last Updated:       02/29/2024
        /// What Was Changed:   Initial Creation
        /// </summary>
        public List<StayVM> SelectAllStaysForShelter(string shelterID) {
            List<StayVM> result = new List<StayVM>();

            // create connection object
            var conn = DatabaseConnection.GetConnection();

            // set the command text
            var commandText = "sp_get_all_stays_for_shelter";

            // create command object
            var cmd = new SqlCommand(commandText, conn);

            // set command type
            cmd.CommandType = CommandType.StoredProcedure;

            // add parameters to command
            cmd.Parameters.Add("@ShelterID", SqlDbType.NVarChar, 50);


            // set parameter values
            cmd.Parameters["@ShelterID"].Value = shelterID;

            try {
                // open connection
                conn.Open();

                // execute command
                var reader = cmd.ExecuteReader();
                if (reader.HasRows) {
                    while (reader.Read()) {
                        StayVM d = new StayVM();
                        d.StayID = reader.GetInt32(0);
                        d.ClientID = reader.GetString(1);
                        d.RoomID = reader.GetInt32(2);
                        d.InDate = reader.GetDateTime(3);
                        d.OutDate = reader.GetDateTime(4);
                        d.CheckedOut = reader.GetBoolean(5);
                        d.RoomNumber = reader.GetInt32(6);
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
        /// Creator:            Jared Harvey
        /// Created:            03/22/2024
        /// Summary:            SelectStayByStayID
        /// Last Updated By:    Jared Harvey
        /// Last Updated:       03/22/2024
        /// What Was Changed:   Initial Creation
        /// </summary>
        public Stay SelectStayByStayID(int stayID) {
            Stay result = new Stay();

            // create connection object
            var conn = DatabaseConnection.GetConnection();

            // set the command text
            var commandText = "sp_get_stay";

            // create command object
            var cmd = new SqlCommand(commandText, conn);

            // set command type
            cmd.CommandType = CommandType.StoredProcedure;

            // add parameters to command
            cmd.Parameters.Add("@StayID", SqlDbType.Int);


            // set parameter values
            cmd.Parameters["@StayID"].Value = stayID;

            try {
                // open connection
                conn.Open();

                // execute command
                var reader = cmd.ExecuteReader();
                if (reader.HasRows) {
                    while (reader.Read()) {
                        result.StayID = reader.GetInt32(0);
                        result.ClientID = reader.GetString(1);
                        result.RoomID = reader.GetInt32(2);
                        result.InDate = reader.GetDateTime(3);
                        result.OutDate = reader.GetDateTime(4);
                        result.CheckedOut = reader.GetBoolean(5);
                    }
                }
            } catch (Exception ex) {
                throw ex;
            } finally {
                conn.Close();
            }
            return result;
        }
    }
}
