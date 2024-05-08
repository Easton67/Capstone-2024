using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataObjects;
using System.Data.SqlClient;
using DataAccessInterfaces;
using System.Data;

namespace DataAccessLayer
{
    /// <summary>
    /// Creator: Anthony Talamantes
    /// Created: 02/01/2024
    /// Summary: A class that provides data access methods for managing items in the inventory.
    /// Last Updated By: Anthony Talamantes
    /// Last Updated: 02/01/2024
    /// What Was Changed: Initial Creation
    /// </summary>
    public class ItemAccessor : IItemAccessor
    {
        /// <summary>
        /// Creator: Anthony Talamantes
        /// Created: 02/01/2024
        /// Summary: Retrieves a list of all items from the database by executing the stored procedure 
        /// "sp_Select_All_Item_Inventory". The method maps the retrieved data to Item objects and returns a list of items.
        /// Last Updated By: Anthony Talamantes
        /// Last Updated: 02/01/2024
        /// What Was Changed: Initial Creation
        /// </summary>
        public List<Item> SelectAllItems()
        {
            List<Item> items = new List<Item>();

            var conn = DatabaseConnection.GetConnection();
            var cmdText = "sp_Select_All_Item_Inventory";
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
                        items.Add(new Item()
                        {
                            ItemID = reader.GetInt32(0),
                            ItemName = reader.GetString(1),
                            ItemDescription = reader.GetString(2),
                            QtyOnHand = reader.GetInt32(3),
                            NormalStockQty = reader.GetInt32(4),
                            ReorderPoint = reader.GetInt32(5),
                            OnOrder = reader.GetInt32(6),
                        });
                    }
                }
                else
                {
                    throw new ArgumentException("Items not found");
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
            return items;
        }


        /// <summary>
        /// Creator: Mitchell Stirmel
        /// Created: 02/20/2024
        /// Summary: Updates the quantity on hand of an item by its item ID.
        /// Last Updated By: Mitchell Stirmel
        /// Last Updated: 02/20/2024
        /// What Was Changed: Initial Creation
        /// </summary>
        public bool UpdateQtyOnHand(Item item)
        {
            SqlConnection sqlConn = DatabaseConnection.GetConnection();
            var cmd = new SqlCommand("sp_update_item_quantity_on_hand");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = sqlConn;

            cmd.Parameters.Add("@ItemID", SqlDbType.NVarChar);
            cmd.Parameters.Add("@QtyOnHand", SqlDbType.Int);

            cmd.Parameters["@ItemID"].Value = item.ItemID;
            cmd.Parameters["@QtyOnHand"].Value = item.QtyOnHand;

            try
            {
                sqlConn.Open();

                if (cmd.ExecuteNonQuery() == 1)
                {
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
            finally { sqlConn.Close(); }
        }

        /// <summary>
        /// Creator:Andres Garcia
        /// Created: 02/06/2024
        /// Summary: Selects a single item from the inventory table by itemId
        /// Last Updated By: Andres Garcia
        /// Last Updated: 02/06/2024
        /// What was Changed: Inital Creation
        /// </summary>
        public Item SelectItemByItemId(int itemId)
        {
            Item item = null;

            var conn = DatabaseConnection.GetConnection();
            var cmdText = "sp_select_item_by_itemId";
            var cmd = new SqlCommand(cmdText, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ItemId", SqlDbType.Int);
            cmd.Parameters["@ItemId"].Value = itemId;

            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {

                    while (reader.Read())
                    {
                        item = new Item()
                        {
                            ItemID = reader.GetInt32(0),
                            ItemName = reader.GetString(1),
                            ItemDescription = reader.GetString(2),
                            QtyOnHand = reader.GetInt32(3),
                            NormalStockQty = reader.GetInt32(4),
                            ReorderPoint = reader.GetInt32(5),
                            OnOrder = reader.GetInt32(6)
                        };
                    }
                }
                else
                {
                    throw new ArgumentException("No inventory items with that Id");
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
            return item;


        }

        /// <summary>
        /// Creator:Andres Garcia
        /// Created: 02/06/2024
        /// Summary: Updates a single item from the item table. Takes itemId of existing item and a new item object
        /// that replaces the item in the table.
        /// Last Updated By: Andres Garcia
        /// Last Updated: 02/06/2024
        /// What was Changed: Initial Creation
        /// </summary>
        public int UpdateItem(int itemId, Item item)
        {
            var conn = DatabaseConnection.GetConnection();
            var cmdText = "sp_edit_item_by_itemId";
            var cmd = new SqlCommand(cmdText, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ItemId", SqlDbType.Int);
            cmd.Parameters.Add("@ItemName", SqlDbType.NVarChar, 50);
            cmd.Parameters.Add("@ItemDescription", SqlDbType.NVarChar, 255);
            cmd.Parameters.Add("@QtyOnHand", SqlDbType.Int);
            cmd.Parameters.Add("@NormalStockQty", SqlDbType.Int);
            cmd.Parameters.Add("@ReorderPoint", SqlDbType.Int);
            cmd.Parameters.Add("@OnOrder", SqlDbType.Int);

            cmd.Parameters["@ItemId"].Value = itemId;
            cmd.Parameters["@ItemName"].Value = item.ItemName;
            cmd.Parameters["@ItemDescription"].Value = item.ItemDescription;
            cmd.Parameters["@QtyOnHand"].Value = item.QtyOnHand;
            cmd.Parameters["@NormalStockQty"].Value = item.NormalStockQty;
            cmd.Parameters["@ReorderPoint"].Value = item.ReorderPoint;
            cmd.Parameters["@OnOrder"].Value = item.OnOrder;

            try
            {
                conn.Open();
                int rowsAdded = cmd.ExecuteNonQuery();

                if (rowsAdded > 0)
                {
                    return rowsAdded;
                }
                else
                {
                    throw new ArgumentException("Unable to update item, try again later");
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
        }

        /// <summary>
        /// Creator:Andres Garcia
        /// Created: 04/019/2024
        /// Summary: Sets the qtyOnHand of all inventory items to 0
        /// Last Updated By: Andres Garcia
        /// Last Updated: 04/019/2024
        /// What was Changed: Initial Creation
        /// </summary>
        public bool DeleteInventory()
        {
            SqlConnection sqlConn = DatabaseConnection.GetConnection();
            var cmd = new SqlCommand("sp_delete_inventory");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = sqlConn;

            try
            {
                sqlConn.Open();

                if (cmd.ExecuteNonQuery() == 1)
                {
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                sqlConn.Close();
            }
        }

        /// <summary>
        /// Creator:Andres Garcia
        /// Created: 04/019/2024
        /// Summary: Adds an item to the inventory 
        /// Last Updated By: Andres Garcia
        /// Last Updated: 04/019/2024
        /// What was Changed: Initial Creation
        /// </summary>

        public int AddItem(Item item)
        {
            var conn = DatabaseConnection.GetConnection();
            var cmdText = "sp_add_item";
            var cmd = new SqlCommand(cmdText, conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@ItemName", SqlDbType.NVarChar, 50);
            cmd.Parameters.Add("@ItemDescription", SqlDbType.NVarChar, 255);
            cmd.Parameters.Add("@QtyOnHand", SqlDbType.Int);
            cmd.Parameters.Add("@NormalStockQty", SqlDbType.Int);
            cmd.Parameters.Add("@ReorderPoint", SqlDbType.Int);
            cmd.Parameters.Add("@OnOrder", SqlDbType.Int);

            cmd.Parameters["@ItemName"].Value = item.ItemName;
            cmd.Parameters["@ItemDescription"].Value = item.ItemDescription;
            cmd.Parameters["@QtyOnHand"].Value = item.QtyOnHand;
            cmd.Parameters["@NormalStockQty"].Value = item.NormalStockQty;
            cmd.Parameters["@ReorderPoint"].Value = item.ReorderPoint;
            cmd.Parameters["@OnOrder"].Value = item.OnOrder;


            try
            {
                conn.Open();
                int rowsAdded = cmd.ExecuteNonQuery();

                if (rowsAdded > 0)
                {
                    return rowsAdded;
                }
                else
                {
                    throw new ArgumentException("Unable to update item, try again later");
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
        }

        /// <summary>
        /// Creator:Andres Garcia
        /// Created: 04/019/2024
        /// Summary: Deletes and item from inventory
        /// Last Updated By: Andres Garcia
        /// Last Updated: 04/019/2024
        /// What was Changed: Initial Creation
        /// </summary>

        public int DeleteItem(int itemId)
        {
            var conn = DatabaseConnection.GetConnection();
            var cmdText = "sp_delete_item_by_id";
            var cmd = new SqlCommand(cmdText, conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@ItemID", SqlDbType.Int);

            cmd.Parameters["@ItemID"].Value = itemId;

            try
            {
                conn.Open();
                int rowsDeleted = cmd.ExecuteNonQuery();

                if (rowsDeleted > 0)
                {
                    return rowsDeleted;
                }
                else
                {
                    throw new ArgumentException("Unable to delete item, try again later");
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
        }

    }
}