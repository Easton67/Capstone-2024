using DataAccessInterfaces;
using DataObjects;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace DataAccessLayer
{
    /// <summary>
    /// Creator:            Mitchell Sitrmel
    /// Created:            02/07/2024
    /// Summary:            PartsInventoryAccessor.cs
    /// Last Updated By:    Darryl Shirley
    /// Last Updated:       02/07/2024
    /// What Was Changed:   Initial creation  
    /// </summary>
    public class PartsInventoryAccessor : IPartsInventoryAccessor
    {
        
        /// <summary>
        /// Creator:            Darryl Shirley
        /// Created:            01/31/2024
        /// Summary:            SelectAllMaintenanceItems() method
        /// Last Updated By:    Darryl Shirley
        /// Last Updated:       02/07/2024
        /// What Was Changed:   Initial Creation 
        /// </summary>
        public List<PartsInventory> SelectAllMaintenanceItems()
        {
            List<PartsInventory> maintenanceItems = new List<PartsInventory>();

            var conn = DatabaseConnection.GetConnection();

            var cmdText = "sp_view_maintenance_inventory";

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
                        maintenanceItems.Add(new PartsInventory()
                        {
                            _itemID = reader.GetString(0),
                            _category = reader.GetString(1),
                            _quantity= reader.GetInt32(2),
                            _stockType = reader.GetString(3)

                        });
                    }
                }
                else
                {
                    throw new ArgumentException("Maintenance Items not found");
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

          return maintenanceItems;
        }

        /// <summary>
        /// Creator:            Mitchell Stirmel
        /// Created:            02/01/2024
        /// Summary:            This method calls the database and gets back all of the current data for maintenance parts.
        /// Last Updated By:    Mitchell Stirmel
        /// Last Updated:       02/01/2024
        /// What Was Changed:   Initial Creation
        /// </summary>
        public DateTime ViewLastUpdatedTime()
        {
            SqlConnection sqlConn = DatabaseConnection.GetConnection();
            var cmd = new SqlCommand("sp_view_maintenance_inventory_update_time");
            cmd.Connection = sqlConn;

            DateTime returnTime = new DateTime();

            try
            {
                sqlConn.Open();

                returnTime = (DateTime) cmd.ExecuteScalar();
                
                return returnTime;
            }
            catch (Exception)
            {
                return returnTime;
            }
            finally { sqlConn.Close(); }
        }

        /// <summary>
        /// Creator:            Mitchell Stirmel
        /// Created:            02/01/2024
        /// Summary:            This method calls the database and gets back all of the current data for maintenance parts.
        /// Last Updated By:    Mitchell Stirmel
        /// Last Updated:       02/01/2024
        /// What Was Changed:   Initial Creation
        /// </summary>
        public List<PartsInventory> ViewPartsInventory()
        {
            SqlConnection sqlConn = DatabaseConnection.GetConnection();
            var cmd = new SqlCommand("sp_view_maintenance_inventory");
            cmd.Connection = sqlConn;

            List<PartsInventory> returnList = new List<PartsInventory>();

            try
            {
                sqlConn.Open();

                var reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        PartsInventory part = new PartsInventory();

                        part._itemID = reader.GetString(0);
                        part._category = reader.GetString(1);
                        part._quantity = reader.GetInt32(2);

                        returnList.Add(part);
                    }
                }
                return returnList;
            }
            catch (Exception)
            {
                return returnList;
            } finally { sqlConn.Close(); }
        }

        /// <summary>
        /// Creator:            Anthony Talamantes
        /// Created:            02/12/2024
        /// Summary:            Method that calls database to insert a part into PartsInventory
        /// Last Updated By:    Anthony Talamantes
        /// Last Updated:       02/12/2024
        /// What Was Changed:   Initial Creation
        /// </summary>
        public int InsertPartsInventory(PartsInventory partsInventory)
        {
            int rows = 0;

            var conn = DatabaseConnection.GetConnection();
            var cmdText = "sp_insert_part_to_inventory";
            var cmd = new SqlCommand(cmdText, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@PartID", partsInventory._itemID);
            cmd.Parameters.AddWithValue("@Category", partsInventory._category);
            cmd.Parameters.AddWithValue("@Qty", partsInventory._quantity);
            cmd.Parameters.AddWithValue("@StockType", partsInventory._stockType);

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
        /// Creator:            Anthony Talamantes
        /// Created:            02/12/2024
        /// Summary:            Method that calls the database to get all the categories of parts in PartInventory
        /// Last Updated By:    Anthony Talamantes
        /// Last Updated:       02/12/2024
        /// What Was Changed:   Initial Creation
        /// </summary>
        public List<string> SelectAllCategory()
        {
            List<string> result = new List<string>();

            var conn = DatabaseConnection.GetConnection();
            var cmdText = "sp_select_all_category";
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
                    throw new ArgumentException("Categories not found");
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally { conn.Close(); }

            return result;
        }

        /// <summary>
        /// Creator:            Anthony Talamantes
        /// Created:            02/12/2024
        /// Summary:            Method that calls the database to get all the stock types of parts in PartInventory
        /// Last Updated By:    Anthony Talamantes
        /// Last Updated:       02/12/2024
        /// What Was Changed:   Initial Creation
        /// </summary>
        public List<string> SelectAllStockType()
        {
            List<string> result = new List<string>();

            var conn = DatabaseConnection.GetConnection();
            var cmdText = "sp_select_all_stock_type";
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
                    throw new ArgumentException("Stock Type not found");
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally { conn.Close(); }

            return result;
        }

        /// <summary>
        /// Creator:            Anthony Talamantes
        /// Created:            02/20/2024
        /// Summary:            Method that calls the database to delete a part from PartsInventory
        /// Last Updated By:    Anthony Talamantes
        /// Last Updated:       02/20/2024
        /// What Was Changed:   Initial Creation
        /// </summary>
        public int DeletePartsInventory(string partId)
        {
            int rows = 0;

            var conn = DatabaseConnection.GetConnection();
            var cmdText = "sp_delete_part_from_parts_inventory";
            var cmd = new SqlCommand(cmdText, conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@PartID", partId);

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
    }
}

