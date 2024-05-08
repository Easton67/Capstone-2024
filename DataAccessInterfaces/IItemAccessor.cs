using DataObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessInterfaces
{
    /// <summary>
    /// Creator: Anthony Talamantes
    /// Created: 02/01/2024
    /// Summary: Interface for ItemAccessor
    /// Last Updated By: Anthony Talamantes
    /// Last Updated: 02/01/2024
    /// What Was Changed: Initial Creation
    /// </summary>
    public interface IItemAccessor
    {
        List<Item> SelectAllItems();
        bool UpdateQtyOnHand(Item item);


        /// <summary>
        /// Creator:Andres Garcia
        /// Created: 2/06/2024
        /// Summary: Accessor method used to select item from item table by itemId.
        /// Last Updated By: Andres Garcia
        /// Last Updated: 1/30/2024
        /// What was Changed: Inital Creation
        /// </summary>
        Item SelectItemByItemId(int itemId);


        /// <summary>
        /// Creator:Andres Garcia
        /// Created: 1/30/2024
        /// Summary: Accessor method used to update an item in the item table.
        /// Last Updated By: Andres Garcia
        /// Last Updated: 2/06/2024
        /// What was Changed: Inital Creation
        /// </summary>
        int UpdateItem(int itemId, Item item);


        /// <summary>
        /// Creator:Andres Garcia
        /// Created: 4/19/2024
        /// Summary: Sets qtyOnHand of all items to 0.
        /// Last Updated By: Andres Garcia
        /// Last Updated: 4/19/2024
        /// What was Changed: Inital Creation
        /// </summary>
        bool DeleteInventory();

        /// <summary>
        /// Creator:Andres Garcia
        /// Created: 4/19/2024
        /// Summary: Adds an item to inventory.
        /// Last Updated By: Andres Garcia
        /// Last Updated: 4/19/2024
        /// What was Changed: Inital Creation
        /// </summary>
        int AddItem(Item item);

        /// <summary>
        /// Creator:Andres Garcia
        /// Created: 4/19/2024
        /// Summary: Deletes an item from inventory by itemId.
        /// Last Updated By: Andres Garcia
        /// Last Updated: 4/19/2024
        /// What was Changed: Inital Creation
        /// </summary>
        int DeleteItem(int itemId);


    }
}
