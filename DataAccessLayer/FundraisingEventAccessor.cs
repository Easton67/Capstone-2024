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
    /// <summary>
    /// Creator: Kirsten Stage
    /// Created: 04/11/2024
    /// Summary: Fundraising Event Accessor class that implements 
    ///          IFundraisingEventAccessor interface.
    /// Last Updated By: Kirsten Stage
    /// Last Updated: 04/11/2024
    /// What Was Changed: Initial Creation
    /// </summary>

    public class FundraisingEventAccessor : IFundraisingEventAccessor
    {
        /// <summary>
        /// Creator: Kirsten Stage
        /// Created: 04/11/2024
        /// Summary: The InsertFundraisingEvent() method runs the stored procedure
        ///          sp_create_fundraising_event
        /// Last Updated By: Kirsten Stage
        /// Last Updated: 04/11/2024
        /// What Was Changed: Initial Creation
        /// </summary>

        public int InsertFundraisingEvent(FundraisingEvent fundraisingEvent)
        {
            int rows = 0;

            var conn = DatabaseConnection.GetConnection();
            var cmdText = "sp_create_fundraising_event";
            var cmd = new SqlCommand(cmdText, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@EventName", fundraisingEvent.EventName);
            cmd.Parameters.AddWithValue("@FundraisingGoal", fundraisingEvent.FundraisingGoal);
            cmd.Parameters.AddWithValue("@EventAddress", fundraisingEvent.EventAddress);
            cmd.Parameters.AddWithValue("@EventDate", fundraisingEvent.EventDate);
            cmd.Parameters.AddWithValue("@StartTime", fundraisingEvent.StartTime);
            cmd.Parameters.AddWithValue("@EndTime", fundraisingEvent.EndTime);
            cmd.Parameters.AddWithValue("@EventDescription", fundraisingEvent.EventDescription);

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
        /// Creator: Kirsten Stage
        /// Created: 04/18/2024
        /// Summary: The RetrieveFundraisingEvent() method runs the stored procedure
        ///          sp_get_fundraising_events
        /// Last Updated By: Kirsten Stage
        /// Last Updated: 04/18/2024
        /// What Was Changed: Initial Creation
        /// </summary>

        public List<FundraisingEvent> RetrieveFundraisingEvents()
        {
            List<FundraisingEvent> events = new List<FundraisingEvent>();

            var conn = DatabaseConnection.GetConnection();
            var cmdText = "sp_get_fundraising_events";
            var cmd = new SqlCommand(@cmdText, conn);

            try
            {
                conn.Open();

                var reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        FundraisingEvent fundraisingEvent = new FundraisingEvent()
                        {
                            FundraisingId = reader.GetInt32(0),
                            EventName = reader.GetString(1),
                            FundraisingGoal = reader.GetDecimal(2),
                            EventAddress = reader.GetString(3),
                            EventDate = reader.GetDateTime(4),
                            StartTime = reader.GetDateTime(5),
                            EndTime = reader.GetDateTime(6),
                            EventDescription = reader.GetString(7)
                        };

                        events.Add(fundraisingEvent);
                    }
                }
                else
                {
                    throw new ArgumentException("Fundraising events not found.");
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

            return events;
        }
    }
}
