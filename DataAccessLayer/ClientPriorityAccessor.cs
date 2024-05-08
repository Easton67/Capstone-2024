using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DataAccessInterfaces;
using DataObjects;

namespace DataAccessLayer
{ 
    /// <summary> 
    /// Creator:            Sagan DeWald
    /// Created:            03/19/2024
    /// Summary:            A class with methods for accessing and modifying the ClientPriority table in the database.
    /// Last Updated By:    Sagan DeWald
    /// Last Updated:       03/19/2024
    /// What Was Changed:   Initial creation.
    /// </summary>

    public class ClientPriorityAccessor : IClientPriorityAccessor
    {
	    /// <summary> 
	    /// Creator:            Sagan DeWald
	    /// Created:            03/19/2024
	    /// Summary:            Returns a List of ClientPriority objects, representing rows from the ClientPriority table in the database.
	    /// Last Updated By:    Sagan DeWald
	    /// Last Updated:       04/25/2024
	    /// What Was Changed:   Fixed bug with not returning ClientPriority objects.
	    /// </summary>
        public List<ClientPriority> SelectAllClientPriorities()
        {
            List<ClientPriority> clientPriorities = new List<ClientPriority>();

            var conn = DatabaseConnection.GetConnection();
            var cmdText = "sp_get_all_client_priorities";
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
                        ClientPriority clientPriority = new ClientPriority();
                        clientPriority.ClientPriorityID = reader.GetInt32(0);
                        clientPriority.Client = reader.GetString(1);
                        clientPriority.BasePriority = reader.GetInt32(2);
                        clientPriority.Deductions = reader.GetInt32(3);
                        clientPriority.NotableConvictions = reader.GetString(4);
                        clientPriority.OtherHousingSituation = reader.GetString(5);
                        clientPriorities.Add(clientPriority);
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
            return clientPriorities;
        }

	    /// <summary> 
	    /// Creator:            Sagan DeWald
	    /// Created:            03/19/2024
	    /// Summary:            Updates a row in the ClientPriority table of the database.
	    /// Last Updated By:    Sagan DeWald
	    /// Last Updated:       03/19/2024
	    /// What Was Changed:   Initial creation.
	    /// </summary>
        public int UpdateClientPriority(int clientPriorityId, int basePriority, int deductions, string notableConvictions, string otherHousingSituation)
        {
            int rowsAffected = 0;

            var conn = DatabaseConnection.GetConnection();
            var cmdText = "sp_update_client_priority";
            var cmd = new SqlCommand(cmdText, conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@ClientPriorityID", clientPriorityId);
            cmd.Parameters.AddWithValue("@BasePriority", basePriority);
            cmd.Parameters.AddWithValue("@Deductions", deductions);
            cmd.Parameters.AddWithValue("@NotableConvictions", notableConvictions);
            cmd.Parameters.AddWithValue("@OtherHousingSituation", otherHousingSituation);

            try
            {
                conn.Open();
                rowsAffected= cmd.ExecuteNonQuery();
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
	    /// Creator:            Sagan DeWald
	    /// Created:            03/19/2024
	    /// Summary:            Adds a row to the ClientPriority table of the database.
	    /// Last Updated By:    Sagan DeWald
	    /// Last Updated:       03/19/2024
	    /// What Was Changed:   Initial creation.
	    /// </summary>
        public int AddClientPriority(string clientId, int basePriority, int deductions, string notableConvictions, string otherHousingSituation)
        {
            int rowsAffected = 0;

            var conn = DatabaseConnection.GetConnection();
            var cmdText = "sp_add_client_priority";
            var cmd = new SqlCommand(cmdText, conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@ClientID", clientId);
            cmd.Parameters.AddWithValue("@BasePriority", basePriority);
            cmd.Parameters.AddWithValue("@Deductions", deductions);
            cmd.Parameters.AddWithValue("@NotableConvictions", notableConvictions);
            cmd.Parameters.AddWithValue("@OtherHousingSituation", otherHousingSituation);

            try
            {
                conn.Open();
                rowsAffected = cmd.ExecuteNonQuery();
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
    }
}
