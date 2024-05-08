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
    /// Created: 03/29/2024
    /// Summary: Event Meal Plan Accessor class
    /// Last Updated: 03/29/2024
    /// Last Updated By: Kirsten Stage
    /// What Was Changed: Initial Creation
    /// </summary>

    public class EventMealPlanAccessor : IEventMealPlanAccessor
    {
        /// <summary>
        /// Creator: Kirsten Stage
        /// Created: 03/29/2024
        /// Summary: The SelectEventMealsById() method will run the stored procedure
        ///          sp_get_event_meals. 
        /// Last Updated By: Kirsten Stage
        /// Last Updated: 03/29/2024
        /// What Was Changed: Initial Creation
        /// </summary>
        public EventMealPlan SelectEventMealsByName(string eventName)
        {
            EventMealPlan eventMealPlan = new EventMealPlan();

            var conn = DatabaseConnection.GetConnection();
            var cmdText = "sp_get_event_meals";
            var cmd = new SqlCommand(cmdText, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@EventName", SqlDbType.NVarChar, 100);
            cmd.Parameters["@EventName"].Value = eventName;

            try
            {
                conn.Open();

                var reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        eventMealPlan.EventName = reader.GetString(0);
                        eventMealPlan.Date = reader.GetDateTime(1);
                        eventMealPlan.Time = reader.GetDateTime(2);
                        eventMealPlan.Food = reader.GetString(3);
                        eventMealPlan.Beverages = reader.GetString(4);
                    }
                }
                else
                {
                    throw new ArgumentException("Event Meal Plan Not Found.");
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

            return eventMealPlan;
        }


        /// <summary>
        /// Creator: Kirsten Stage
        /// Created: 04/01/2024
        /// Summary: The SelectAllEventNames() method will run the stored procedure
        ///          sp_select_all_event_names. 
        /// Last Updated By: Kirsten Stage
        /// Last Updated: 04/01/2024
        /// What Was Changed: Initial Creation
        /// </summary>
        public List<string> SelectAllEventNames()
        {
            List<string> result = new List<string>();

            var conn = DatabaseConnection.GetConnection();
            var cmdText = "sp_select_all_event_names";
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
                        result.Add(reader.GetString(0));
                    }
                }
                else
                {
                    throw new ArgumentException("Event names not found.");
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

            return result;
        }
    }
}
