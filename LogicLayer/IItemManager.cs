using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataObjects;

namespace LogicLayer
{
    /// <summary>
    /// Creator: Anthony Talamantes
    /// Created: 02/01/2024
    /// Summary: Interface for IItemManager that will be implemeted by ItemManager
    /// Last Updated By: Anthony Talamantes
    /// Last Updated: 02/01/2024
    /// What Was Changed: Initial Creation
    /// </summary>
    public interface IItemManager
    {
        List<Item> GetItems();

        bool UpdateQtyOnHand(Item item);



        /// <summary>
        /// Creator:Andres Garcia
        /// Created: 1/30/2024
        /// Summary: Gets item by item id.
        /// Last Updated By: Andres Garcia
        /// Last Updated: 1/30/2024
        /// What was Changed: Inital Creation
        /// </summary>
        Item GetItemByItemId(int itemId);


        /// <summary>
        /// Creator:Andres Garcia
        /// Created: 1/30/2024
        /// Summary: Edits current item in item table by taking in itemId of existing item
        /// and a new item object to replace the existing item
        /// Last Updated By: Andres Garcia
        /// Last Updated: 1/30/2024
        /// What was Changed: Inital Creation
        /// </summary>
        int EditItem(int itemId, Item item);

        /// <summary>
        /// Creator:Andres Garcia
        /// Created: 4/19/2024
        /// Summary: Sets qtyOnHand of all inventory items to 0
        /// Last Updated: 1/30/2024
        /// What was Changed: Inital Creation
        /// </summary>
        bool DeleteInventory();

        /// <summary>
        /// Creator:Andres Garcia
        /// Created: 4/19/2024
        /// Summary: Adds an item to the inventory
        /// Last Updated: 1/30/2024
        /// What was Changed: Inital Creation
        /// </summary>
        int AddItem(Item item);

        /// <summary>
        /// Creator:Andres Garcia
        /// Created: 4/19/2024
        /// Summary: Deletes an item from the inventory by itemId
        /// Last Updated: 1/30/2024
        /// What was Changed: Inital Creation
        /// </summary>
        int DeleteItem(int itemId);
    }
}
