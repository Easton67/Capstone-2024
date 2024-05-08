using DataAccessInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataObjects;
using System.Data.SqlClient;
using System.Data;
using DataObjects.Kitchen;

namespace DataAccessLayer
{
    /// <summary>
    /// Creator:Suliman Adam Suliman
    /// Created: 02/02/2024
    /// Summary: Created a public class for kitchenInventoryItemAccessor and implemented IKitchenInventoryItemAccessor InterFace.
    /// Last Updated By: 
    /// Last Updated: 
    /// What Was Changed: No changes.
    /// </summary>
    public class KitchenInventoryItemAccessor : IKitchenInventoryItemAccessor
    {
        /// <summary>
        /// Creator:Suliman Adam Suliman
        /// Created: 02/02/2024
        /// Summary: Created a Method that return a List for kitchenInventoryItem.
        /// Last Updated By: 
        /// Last Updated: 
        /// What Was Changed: No changes.
        /// </summary>
        public List<KitchenInventoryItem> ViewKitchenInventoryItem()
        {
            List<KitchenInventoryItem> items = new List<KitchenInventoryItem>();

            var conn = DatabaseConnection.GetConnection();
            var cmdText = "sp_select_all_kitchen_inventory_items";
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
                        items.Add(new KitchenInventoryItem()
                        {

                            KitchenItemID = reader.GetInt32(0),
                            ItemName = reader.GetString(1),
                            QuantityInStock = reader.GetInt32(2),
                            Category = reader.GetString(3),
                            UnitCost = reader.GetDecimal(4),
                            Supplier = reader.GetString(5),
                            ReorderQuantity = reader.GetInt32(6)
                        });
                    }
                }
                else
                {
                    throw new ArgumentException("items not found");
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
        /// Creator: Ethan McElree
        /// Created: 04/15/2024
        /// Summary: Created the method that retrieves certain kitchen items by their category.
        /// Last Updated By: Ethan McElree
        /// Last Updated: 4/15/2024
        /// What Was Changed: Initial Creation.
        /// </summary>
        public List<KitchenInventoryItemVM> ViewKitchenInventoryItemsByCategory(string category)
        {
            if(category == "All")
            {
                List<KitchenInventoryItem> items = ViewKitchenInventoryItem();
                List<KitchenInventoryItemVM> itemsVM = new List<KitchenInventoryItemVM>();
                foreach (var item in items)
                {
                    KitchenInventoryItemVM newItem = new KitchenInventoryItemVM()
                    {
                        KitchenItemID = item.KitchenItemID,
                        ItemName = item.ItemName,
                        QuantityInStock = item.QuantityInStock,
                        Category = item.Category,
                        UnitCost = item.UnitCost,
                        Supplier = item.Supplier,
                        ReorderQuantity = item.ReorderQuantity
                    };
                    itemsVM.Add(newItem);
                }
                return itemsVM;
            }
            var List = new List<KitchenInventoryItemVM>();

            var conn = DatabaseConnection.GetConnection();
            var cmdText = "sp_select_kitchen_inventory_item_by_category";
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
                        KitchenInventoryItemVM kitchenInventoryItemVM = new KitchenInventoryItemVM();
                        kitchenInventoryItemVM.KitchenItemID = reader.GetInt32(0);
                        kitchenInventoryItemVM.ItemName = reader.GetString(1);
                        kitchenInventoryItemVM.QuantityInStock = reader.GetInt32(2);
                        kitchenInventoryItemVM.Category = reader.GetString(3);
                        kitchenInventoryItemVM.UnitCost = reader.GetDecimal(4);
                        kitchenInventoryItemVM.Supplier = reader.GetString(5);
                        kitchenInventoryItemVM.ReorderQuantity = reader.GetInt32(6);
                    }
                }
                else
                {
                    throw new ArgumentException("Failed to find kitchen items by their category.");
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

            return List;
        }
    }
}
