using DataAccessInterfaces;
using DataObjects;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class HiddenIncidentAccessor : IHiddenIncidentAccessor
    {
        //<summary>
        //Creator: Sagan DeWald
        //Created: 2/23/2024
        //Summary: Gets a selection of which incidents are hidden to the given user, stores them in HiddenIncident objects, and returns them in a list.
        //Last Updated: 2/23/2024
        //What was Changed: Initial creation.
        //</summary>
        public List<HiddenIncident> GetHiddenIncidentsByUserId(string targetUser)
        {
            List<HiddenIncident> incidents = new List<HiddenIncident>();

            //Create a connection to the database.
            var conn = DatabaseConnection.GetConnection();

            //Specify the stored procedure to call.
            var commandText = "sp_select_hidden_incidents_by_user_id";

            //Use the connection and stored procedure to make a command object.
            var cmd = new SqlCommand(commandText, conn);

            //Specify to the command object that we're calling a stored procedure.
            cmd.CommandType = CommandType.StoredProcedure;

            //Add the E-Mail and password hash as parameters.
            cmd.Parameters.Add("@TargetUser", SqlDbType.NVarChar, 100);

            //Set the value of the E-Mail and password parameters.
            cmd.Parameters["@TargetUser"].Value = targetUser;

            //Finally, open the connection and execute the command. Watch for errors.
            try
            {
                // open the connection
                conn.Open();

                // execute the command and capture the result
                var reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        HiddenIncident incident = new HiddenIncident
                        (
                            reader.GetInt32(0), //HiddenIncidentID
                            reader.GetString(1), //TargetUser
                            reader.GetInt32(2) //IncidentID
                        );
                        incidents.Add(incident);
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

            return incidents;
        }

        //<summary>
        //Creator: Sagan DeWald
        //Created: 2/23/2024
        //Summary: Given a user ID and incident ID, add a row to the HiddenIncident database table.
        //Last Updated: 2/23/2024
        //What was Changed: Initial Creation
        //</summary>
        public int AddHiddenIncident(string userId, int incidentId)
        {
            int result = 0;

            //Create a connection to the database.
            var conn = DatabaseConnection.GetConnection();

            //Specify the stored procedure to call.
            var commandText = "sp_hide_incident";

            //Use the connection and stored procedure to make a command object.
            var cmd = new SqlCommand(commandText, conn);

            //Specify to the command object that we're calling a stored procedure.
            cmd.CommandType = CommandType.StoredProcedure;

            //Add the E-Mail and password hash as parameters.
            cmd.Parameters.Add("@IncidentId", SqlDbType.Int);
            cmd.Parameters.Add("@UserId", SqlDbType.NVarChar, 100);

            //Set the value of the E-Mail and password parameters.
            cmd.Parameters["@IncidentId"].Value = incidentId;
            cmd.Parameters["@UserId"].Value = userId;

            //Finally, open the connection and execute the command. Watch for errors.
            try
            {
                // open the connection
                conn.Open();

                // execute the command and capture the result
                result = Convert.ToInt32(cmd.ExecuteScalar());
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
