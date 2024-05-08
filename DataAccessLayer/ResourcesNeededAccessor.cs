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
    /// Created: 02/08/2024
    /// Summary: Resources Needed Accessor class that implements IResourcesNeededAccessor interface.
    /// Last Updated By: Kirsten Stage
    /// Last Updated: 02/08/2024
    /// What Was Changed: Initial Creation
    /// </summary>
    public class ResourcesNeededAccessor : IResourcesNeededAccessor
    {
        /// <summary>
        /// Creator: Andrew Larson
        /// Created: 02/19/2024
        /// Summary: The AddResourcesNeeded() method will run the stored procedure
        ///          sp_add_resources_needed & will save the addition to the database. 
        /// Last Updated By: Andrew Larson
        /// Last Updated: 02/19/2024
        /// What Was Changed: Initial Creation
        /// </summary>
        public int AddResourcesNeeded(string resourceID, string category)
        {
            int rowsAffected = 0;

            var conn = DatabaseConnection.GetConnection();
            var commandText = "sp_add_resources_needed";
            var cmd = new SqlCommand(commandText, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ResourceID", resourceID);
            cmd.Parameters.AddWithValue("@Category", category);

            try
            {
                conn.Open();
                rowsAffected = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error adding resources needed", ex);
            }

            return rowsAffected;
        }

        /// <summary>
        /// Creator: Kirsten Stage
        /// Created: 02/08/2024
        /// Summary: The SelectActivelyNeededResources() method will run the stored procedure
        ///          sp_select_actively_needed_resources & will submit the changes to the database. 
        /// Last Updated By: Kirsten Stage
        /// Last Updated: 02/08/2024
        /// What Was Changed: Initial Creation
        /// </summary>

        public List<ResourcesNeeded> SelectActivelyNeededResources()
        {
            List<ResourcesNeeded> resources = new List<ResourcesNeeded>();

            var conn = DatabaseConnection.GetConnection();
            var cmdText = "sp_select_actively_needed_resources";
            var cmd = new SqlCommand(@cmdText, conn);

            try
            {
                conn.Open();

                var reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        resources.Add(new ResourcesNeeded()
                        {
                            ResourceID = reader.GetString(0),
                            Category = reader.GetString(1),
                            Active = reader.GetBoolean(2)
                        });
                    }
                }
                else
                {
                    throw new ArgumentException("Resources needed not found");
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

            return resources;
        }

        /// <summary>
        /// Creator: Kirsten Stage
        /// Created: 02/22/2024
        /// Summary: The SelectAllResourceCategories() method will run the stored procedure
        ///          sp_select_all_categories & will submit the changes to the database. 
        /// Last Updated By: Kirsten Stage
        /// Last Updated: 02/22/2024
        /// What Was Changed: Initial Creation
        /// </summary>

        public List<string> SelectAllResourceCategories()
        {
            List<string> result = new List<string>();

            var conn = DatabaseConnection.GetConnection();
            var cmdText = "sp_select_all_categories";
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
                    throw new ArgumentException("Categories not found.");
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

        /// <summary>
        /// Creator: Kirsten Stage
        /// Created: 02/22/2024
        /// Summary: The SelectResourcesNeededByCategory() method will run the stored procedure
        ///          sp_select_resources_by_category & will submit the changes to the database. 
        /// Last Updated By: Kirsten Stage
        /// Last Updated: 02/22/2024
        /// What Was Changed: Initial Creation
        /// </summary>

        public List<ResourcesNeeded> SelectResourcesNeededByCategory(string category)
        {
            List<ResourcesNeeded> rn = new List<ResourcesNeeded>();

            var conn = DatabaseConnection.GetConnection();
            var cmdText = "sp_select_resources_by_category";
            var cmd = new SqlCommand(cmdText, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Category", SqlDbType.NVarChar, 50);
            cmd.Parameters["@Category"].Value = category;

            try
            {
                conn.Open();

                var reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        rn.Add(new ResourcesNeeded()
                        {
                            ResourceID = reader.GetString(0),
                            Category = reader.GetString(1),
                            Active = reader.GetBoolean(2)
                        });
                    }
                }
                else
                {
                    throw new ArgumentException("Resources not found.");
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

            return rn;
        }

        /// <summary>
        /// Creator: Kirsten Stage
        /// Created: 02/22/2024
        /// Summary: The UpdateResourceNeeded() method will run the stored procedure
        ///          sp_edit_resources_needed & will submit the changes to the database. 
        /// Last Updated By: Kirsten Stage
        /// Last Updated: 02/22/2024
        /// What Was Changed: Initial Creation
        /// </summary>

        public int UpdateResourceNeeded(ResourcesNeeded oldResourceNeeded, ResourcesNeeded newResourceNeeded)
        {
            int rows = 0;

            var conn = DatabaseConnection.GetConnection();
            var commandText = "sp_edit_resources_needed";
            var cmd = new SqlCommand(commandText, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@NewResourceID", newResourceNeeded.ResourceID);
            cmd.Parameters.AddWithValue("@NewCategory", newResourceNeeded.Category);
            cmd.Parameters.AddWithValue("@NewActive", newResourceNeeded.Active);
            cmd.Parameters.AddWithValue("@OldResourceID", oldResourceNeeded.ResourceID);
            cmd.Parameters.AddWithValue("@OldCategory", oldResourceNeeded.Category);

            try
            {
                conn.Open();
                rows = cmd.ExecuteNonQuery();

                if (rows == 0)
                {
                    throw new ArgumentException("Resource not found.");
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

            return rows;
        }
    }
}
