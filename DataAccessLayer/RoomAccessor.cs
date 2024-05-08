using DataAccessInterfaces;
using DataObjects;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.Remoting.Messaging;

namespace DataAccessLayer {
    /// <summary>
    /// Creator: Kirsten Stage
    /// Created: 02/01/2024
    /// Summary: RoomVM Accessor class that implements IRoomAccessor interface
    /// Last Updated By: Kirsten Stage
    /// Last Updated: 02/01/2024
    /// What Was Changed: Initial Creation
    /// </summary>
    public class RoomAccessor : IRoomAccessor {
        /// <summary>
        /// Creator: Jared Harvey
        /// Created: 01/29/2024
        /// Summary: This method queries the database to get a list of rooms for a given shelter.
        /// Parameters: string shelterID
        /// Returns: List<RoomVM>
        /// Last Updated By: Jared Harvey
        /// Last Updated: 01/29/2024
        /// What Was Changed: Initial Creation
        /// </summary>
        public List<RoomVM> SelectRoomsByShelterID(string shelterID) {

            List<RoomVM> result = new List<RoomVM>();

            var conn = DatabaseConnection.GetConnection();
            var commandText = "sp_get_shelter_rooms";
            var cmd = new SqlCommand(commandText, conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@ShelterID", SqlDbType.NVarChar);
            cmd.Parameters["@ShelterID"].Value = shelterID;

            try {
                conn.Open();
                var reader = cmd.ExecuteReader();
                if (reader.HasRows) {
                    while (reader.Read()) {
                        RoomVM s = new RoomVM();
                        s.RoomID = reader.GetInt32(0);
                        s.ShelterID = reader.GetString(1);
                        s.RoomNumber = reader.GetInt32(2);
                        s.Status = reader.GetString(3);
                        result.Add(s);
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
        /// Creator: Kirsten Stage
        /// Created: 02/01/2024
        /// Summary: CreateRoom() method
        /// Last Updated By: Kirsten Stage
        /// Last Updated: 02/01/2024
        /// What Was Changed: Initial Creation
        /// </summary>
        public int CreateRoom(Room room) {
            int rows = 0;

            var conn = DatabaseConnection.GetConnection();
            var cmdText = "sp_create_room";
            var cmd = new SqlCommand(@cmdText, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ShelterID", room.ShelterID);
            cmd.Parameters.AddWithValue("@RoomNumber", room.RoomNumber);
            cmd.Parameters.AddWithValue("@Status", room.Status);

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
        /// Creator: Kirsten Stage
        /// Created: 02/01/2024
        /// Summary: The SelectAllShelterID() method runs the stored procedure
        ///          sp_select_all_shelterIDs, & the results are used to populate a 
        ///          dropdown list. 
        /// Last Updated By: Kirsten Stage
        /// Last Updated: 02/01/2024
        /// What Was Changed: Initial Creation
        /// </summary>
        public List<string> SelectAllShelterID() {
            List<string> result = new List<string>();

            var conn = DatabaseConnection.GetConnection();
            var cmdText = "sp_select_all_shelterIDs";
            var cmd = new SqlCommand(cmdText, conn);
            cmd.CommandType = CommandType.StoredProcedure;

            try {
                conn.Open();
                var reader = cmd.ExecuteReader();
                if (reader.HasRows) {
                    while (reader.Read()) {
                        result.Add(reader.GetString(0));
                    }
                } else {
                    throw new ArgumentException("Shelter IDs not found.");
                }
            } catch (Exception ex) {
                throw ex;
            } finally {
                conn.Close();
            }

            return result;
        }

        /// <summary>
        /// Creator: Kirsten Stage
        /// Created: 02/01/2024
        /// Summary: The SelectAllStatus() method runs the stored procedure
        ///          sp_select_all_roomStatuses, & the results are used to 
        ///          populate a dropdown list. 
        /// Last Updated By: Kirsten Stage
        /// Last Updated: 02/01/2024
        /// What Was Changed: Initial Creation
        /// </summary>

        public List<string> SelectAllStatus() {

            List<string> result = new List<string>();

            var conn = DatabaseConnection.GetConnection();
            var cmdText = "sp_select_all_room_statuses";
            var cmd = new SqlCommand(cmdText, conn);
            cmd.CommandType = CommandType.StoredProcedure;

            try {
                conn.Open();
                var reader = cmd.ExecuteReader();
                if (reader.HasRows) {
                    while (reader.Read()) {
                        result.Add(reader.GetString(0));
                    }
                } else {
                    throw new ArgumentException("Room status types not found.");
                }
            } catch (Exception ex) {
                throw ex;
            } finally {
                conn.Close();
            }
            return result;
        }

        /// <summary>
        /// Creator: Suliman Suliman
        /// Created: 02/02/2024
        /// Summary: The SelectRooms() method runs the stored procedure
        ///          "sp_select_rooms", to return a List from the RoomVM Table in Database.
        /// Last Updated By: Suliman Suliman
        /// Last Updated: 02/02/2024
        /// What Was Changed: Initial Creation
        /// </summary>
        public List<RoomVM> SelectRooms()
        {
            List<RoomVM> rooms = new List<RoomVM>();

            var conn = DatabaseConnection.GetConnection();
            var cmd = new SqlCommand("sp_select_rooms");
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var room = new RoomVM();
                        {
                            room.RoomID = reader.GetInt32(0);
                            room.ShelterID = reader.GetString(1);
                            room.RoomNumber = reader.GetInt32(2);
                            room.Status = reader.GetString(3);
                        }
                        rooms.Add(room);
                    }
                    reader.Close();
                }
            }
            catch (Exception up)
            {
                throw up;
            }
            finally
            {
                conn.Close();
            }

            return rooms;

        }

        /// <summary>
        /// Creator: Suliman Suliman
        /// Created: 01/26/2024
        /// Summary: Created the updateRoom() method. it takes RoomVM newRoom as
        /// parameter and returns Boolean. 
        /// Last Updated By: Suliman Suliman
        /// Last Updated: 01/26/2024
        /// What Was Changed: Initial Creation
        /// </summary>
        public bool updateRoom(RoomVM newRoom)
        {
            bool result = false;

            var conn = DatabaseConnection.GetConnection();
            var cmd = new SqlCommand("sp_update_Room");
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@RoomID", newRoom.RoomID);
            cmd.Parameters.AddWithValue("@ShelterID", newRoom.ShelterID);
            cmd.Parameters.AddWithValue("@RoomNumber", newRoom.RoomNumber);
            cmd.Parameters.AddWithValue("@Status", newRoom.Status);

            try
            {
                conn.Open();
                result = cmd.ExecuteNonQuery() == 1;
            }
            catch (Exception up)
            {
                throw up;
            }
            finally
            {
                conn.Close();
            }

            return result;
        }

        /// <summary>
        /// Creator:            Jared Harvey
        /// Created:            03/01/2024
        /// Summary:            Implementation for SelectAvailableRooms
        /// Last Updated By:    Jared Harvey
        /// Last Updated:       03/01/2024
        /// What Was Changed:   Initial Creation
        /// </summary>
        public List<RoomVM> SelectAvailableRooms(string shelterID) {
            List<RoomVM> result = new List<RoomVM>();

            // create connection object
            var conn = DatabaseConnection.GetConnection();

            // set the command text
            var commandText = "sp_get_shelter_available_rooms";

            // create command object
            var cmd = new SqlCommand(commandText, conn);

            // set command type
            cmd.CommandType = CommandType.StoredProcedure;

            // add parameters to command
            cmd.Parameters.Add("@ShelterID", SqlDbType.NVarChar);

            // set parameter values
            cmd.Parameters["@ShelterID"].Value = shelterID;

            try {
                // open connection
                conn.Open();

                // execute command
                var reader = cmd.ExecuteReader();
                if (reader.HasRows) {
                    while (reader.Read()) {
                        RoomVM s = new RoomVM();
                        s.RoomID = reader.GetInt32(0);
                        s.ShelterID = reader.GetString(1);
                        s.RoomNumber = reader.GetInt32(2);
                        s.Status = reader.GetString(3);
                        result.Add(s);
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
        /// Created:            03/01/2024
        /// Summary:            Implementation for UpdateRoomStatus
        /// Last Updated By:    Jared Harvey
        /// Last Updated:       03/01/2024
        /// What Was Changed:   Initial Creation
        /// </summary>
        public int UpdateRoomStatus(int roomID, string status) {
            int result = 0;
            var conn = DatabaseConnection.GetConnection();
            var cmd = new SqlCommand("sp_update_roomStatus");
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@RoomID", SqlDbType.Int);
            cmd.Parameters.Add("@Status", SqlDbType.NVarChar, 50);
            cmd.Parameters["@RoomID"].Value = roomID;
            cmd.Parameters["@Status"].Value = status;
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
		
        /// <summary>
        /// Creator: Suliman Suliman
        /// Created: 16/02/2024
        /// Summary: Created the DeactivateRoom() method that returns 
        /// boolean and runs the stored procedures "sp_deactivate_room".
        /// Last Updated By:
        /// Last Updated:
        /// What Was Changed: 
        /// </summary>
        public bool DeactivateRoom(RoomVM room)
        {
            bool rowsAffected = false;

            var conn = DatabaseConnection.GetConnection();
            var cmd = new SqlCommand("sp_deactivate_room", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@RoomID", room.RoomID);

            try
            {
                conn.Open();
                rowsAffected = cmd.ExecuteNonQuery() == 1;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            finally
            {
                conn.Close();
            }

            return rowsAffected;
        }

        /// <summary>
        /// Creator: Jared Harvey
        /// Created: 04/05/2024
        /// Summary: This method queries the database to get a a single room using a room id.
        /// Last Updated By: Jared Harvey
        /// Last Updated: 04/05/2024
        /// What Was Changed: Initial Creation
        /// </summary>
        public Room GetRoom(int roomID) {
            Room result = new Room();
            var conn = DatabaseConnection.GetConnection();
            var cmd = new SqlCommand("sp_get_room_by_roomid");
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;
			
            cmd.Parameters.Add("@RoomID", SqlDbType.Int);
			
            cmd.Parameters["@RoomID"].Value = roomID;
            try {
                // open connection
                conn.Open();

                // execute command
                var reader = cmd.ExecuteReader();
                if (reader.HasRows) {
                    while (reader.Read()) {
                        result.RoomID = reader.GetInt32(0);
                        result.ShelterID = reader.GetString(1);
                        result.RoomNumber = reader.GetInt32(2);
                        result.Status = reader.GetString(3);
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
        /// Creator: Miyada Abas
        /// Created: 03/07/2024
        /// Summary: This method queries the database to update the room status.
        /// Parameters: bool Updatestatus
        /// Returns: Room room
        /// Last Updated By: Miyada Abas
        /// Last Updated: 01/03/2024
        /// What Was Changed: 
        /// </summary>
        public bool updatestatus(Room room)
        {
            bool result = false;

            var conn = DatabaseConnection.GetConnection();
            var commandText = "sp_update_room_status";
            var cmd = new SqlCommand(commandText, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@RoomID", SqlDbType.Int);

            cmd.Parameters["@RoomID"].Value = room.RoomID;
            cmd.Parameters.Add("@Status", SqlDbType.NVarChar);
            cmd.Parameters["@Status"].Value = room.Status;
            try
            {
                conn.Open();
                result = cmd.ExecuteNonQuery() >= 1;
            }
            catch (Exception)
            {
                throw;
            }
            return result;
        }

        public List<string> get_all_room_status()
        { 
            List<string> room_status_list = new List<string>();

            var conn = DatabaseConnection.GetConnection();
            var commandText = "sp_get_all_room_status";
            var cmd = new SqlCommand(commandText, conn);
            cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        room_status_list.Add(reader.GetString(0));
                    }
                    reader.Close();
                }
            }
            catch (Exception)
            {
                throw;
            }
			return room_status_list;
        }

        public Room SelectRoomByRoomNumber(int roomNumber, string shelterID) {
            Room result = new Room();
            var conn = DatabaseConnection.GetConnection();
            var cmd = new SqlCommand("sp_get_room_by_room_number");
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@RoomNumber", SqlDbType.Int);
            cmd.Parameters.Add("@ShelterID", SqlDbType.Int);

            cmd.Parameters["@RoomNumber"].Value = roomNumber;
            cmd.Parameters["@ShelterID"].Value = shelterID;

            try {
                // open connection
                conn.Open();

                // execute command
                var reader = cmd.ExecuteReader();
                if (reader.HasRows) {
                    while (reader.Read()) {
                        result.RoomID = reader.GetInt32(0);
                        result.ShelterID = reader.GetString(1);
                        result.RoomNumber = reader.GetInt32(2);
                        result.Status = reader.GetString(3);
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
