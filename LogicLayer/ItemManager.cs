using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessInterfaces;
using DataAccessLayer;
using DataObjects;

namespace LogicLayer
{
    public class ItemManager : IItemManager
    {
        private IItemAccessor _itemAccessor = null;

        /// <summary>
        /// Creator: Anthony Talamantes
        /// Created: 02/01/2024
        /// Summary: Constructor for the real database
        /// Last Updated By: Anthony Talamantes
        /// Last Updated: 02/01/2024
        /// What Was Changed: Initial Creation
        /// </summary>
        public ItemManager()
        {
            _itemAccessor = new ItemAccessor();
        }

        /// <summary>
        /// Creator: Anthony Talamantes
        /// Created: 02/01/2024
        /// Summary: Constructor for testing
        /// Last Updated By: Anthony Talamantes
        /// Last Updated: 02/01/2024
        /// What Was Changed: Initial Creation
        /// </summary>
        public ItemManager(IItemAccessor itemAccessor)
        {
            _itemAccessor = itemAccessor;
        }

        /// <summary>
        /// Creator: Anthony Talamantes
        /// Created: 02/01/2024
        /// Summary: 
        /// Last Updated By: Anthony Talamantes
        /// Last Updated: 02/01/2024
        /// What Was Changed: Initial Creation
        /// </summary>
        public List<Item> GetItems()
        {
            List<Item> allItems = null;

            try
            {
                allItems = _itemAccessor.SelectAllItems();

                if (allItems == null || allItems.Count == 0)
                {
                    throw new ArgumentException("Items not found");
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error retrieving Items", ex);
            }
            return allItems;
        }

        /// <summary>
        /// Creator: Mitchell Stirmel
        /// Created: 02/20/2024
        /// Summary: This method returns the outcome of the update. If false, the update did not work, if true, it did.
        /// Last Updated By: Mitchell Stirmel
        /// Last Updated 04/10/2024
        /// What was changed: Added try/catch and code cleanup
        /// </summary>
        public bool UpdateQtyOnHand(Item item)
        {
            try
            {
                return _itemAccessor.UpdateQtyOnHand(item);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Unable to update quantity", ex);
            }
        }


        /// <summary>
        /// Creator:Andres Garcia
        /// Created: 1/30/2024
        /// Summary: Gets items by itemId returned by inventoryAccessor.SelectItemBYITemId.
        /// Last Updated By: Andres Garcia
        /// Last Updated: 02/06/2024
        /// What was Changed: Inital Creation
        /// </summary>

        public Item GetItemByItemId(int itemId)
        {
            Item item = null;
            try
            {

                item = _itemAccessor.SelectItemByItemId(itemId);

                if (item == null)
                {
                    throw new ArgumentException("No item with that id found");
                }
            }
            catch (Exception)
            {

                throw new ApplicationException("No item with that id found");
            }
            return item;
        }


        /// <summary>
        /// Creator:Andres Garcia
        /// Created: 02/06/2024
        /// Summary: Edits item in item table. Takes itemId of existing item and new item object 
        /// to replace existing item data
        /// Last Updated By: Andres Garcia
        /// Last Updated: 1/30/2024
        /// What was Changed: Inital Creation
        /// </summary>

        public int EditItem(int itemId, Item item)
        {
            int rowsupdated = 0;
            try
            {

                rowsupdated = _itemAccessor.UpdateItem(itemId, item);

                if (item == null)
                {
                    throw new ArgumentException("No item with that id found");
                }
            }
            catch (Exception)
            {

                throw new ApplicationException("No item with that id found");
            }

            return rowsupdated;
        }

        /// <summary>
        /// Creator:Andres Garcia
        /// Created: 04/19/2024
        /// Summary: Sets qtyOnHand of all inventory items to 0
        /// Last Updated By: Andres Garcia
        /// Last Updated: 04/19/2024
        /// What was Changed: Initial Creation
        /// </summary>
        public bool DeleteInventory()
        {
            try
            {
                return _itemAccessor.DeleteInventory();
            }
            catch (Exception)
            {

                throw;
            }
           
        }

        /// <summary>
        /// Creator:Andres Garcia
        /// Created: 04/19/2024
        /// Summary: Adds an item to inventory 
        /// Last Updated By: Andres Garcia
        /// Last Updated: 04/19/2024
        /// What was Changed: Initial Creation
        /// </summary>
        public int AddItem(Item item)
        {
            try
            {
                return _itemAccessor.AddItem(item);
            }
            catch (Exception ex)
            {

                throw new ArgumentException("Unable to add Item", ex);
            }
           
        }

        /// <summary>
        /// Creator:Andres Garcia
        /// Created: 04/19/2024
        /// Summary: Deletes an item from inventory by itemID
        /// Last Updated By: Andres Garcia
        /// Last Updated: 04/19/2024
        /// What was Changed: Initial Creation
        /// </summary>
        public int DeleteItem(int itemId)
        {
            try
            {
               return _itemAccessor.DeleteItem(itemId);
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Unable to delete Item", ex);
            }

        }
    }
}
