using DataAccessInterfaces;
using DataObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DataAccessLayer
{
    /// <summary>
    /// Creator:            Andrew Larson
    /// Created:            04/9/2024
    /// Summary:            data access class for confiscated items
    /// Last Updated By:    Andrew Larson
    /// Last Updated:       04/9/2024
    /// What Was Changed:   Initial Creation
    /// </summary>
    public class ConfiscatedItemAccessor : IConfiscatedItemAccessor
    {
        /// <summary>
        /// Creator:            Andrew Larson
        /// Created:            04/16/2024
        /// Summary:            data access method to add a confiscated item
        /// Last Updated By:    Andrew Larson
        /// Last Updated:       04/16/2024
        /// What Was Changed:   Initial Creation
        /// </summary>
        public int AddConfiscatedItem(string itemConfiscated, string reasonForConfiscation)
        {
            int rows = 0;
            List<ConfiscatedItem> confiscatedItems = new List<ConfiscatedItem>();
            var conn = DatabaseConnection.GetConnection();
            var cmdText = "sp_add_confiscated_item";
            var cmd = new SqlCommand(cmdText, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ItemsConfiscated", SqlDbType.NVarChar, 100);
            cmd.Parameters.Add("@ReasonForConfiscation", SqlDbType.Text);
            cmd.Parameters["@ItemsConfiscated"].Value = itemConfiscated;
            cmd.Parameters["@ReasonForConfiscation"].Value = reasonForConfiscation;

            try
            {
                conn.Open();
                rows = cmd.ExecuteNonQuery();
                if(rows == 0)
                {
                    throw new ArgumentException("Item not added");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally { conn.Close(); }
            return rows;
        }

        /// <summary>
        /// Creator:            Andrew Larson
        /// Created:            04/10/2024
        /// Summary:            data access method to return all confiscated items
        /// Last Updated By:    Andrew Larson
        /// Last Updated:       04/10/2024
        /// What Was Changed:   Initial Creation
        /// </summary>
        public List<ConfiscatedItem> GetAllConfiscatedItems()
        {
            List<ConfiscatedItem> confiscatedItems = new List<ConfiscatedItem>();
            var conn = DatabaseConnection.GetConnection();
            var cmdText = "sp_view_confiscated_items";
            var cmd = new SqlCommand(cmdText, conn);
            cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();
                if(reader.HasRows)
                {
                    while (reader.Read())
                    { 
                        ConfiscatedItem confiscatedItem = new ConfiscatedItem()
                        { 
                            LogConfiscatedItemsID = reader.GetInt32(0),
                            ItemsConfiscated = reader.GetString(1),
                            ConfiscationDate = reader.GetDateTime(2),
                            ReasonForConfiscation = reader.GetString(3)
                        };
                        confiscatedItems.Add(confiscatedItem);
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally { conn.Close(); }
            return confiscatedItems;
        }
    }
}
