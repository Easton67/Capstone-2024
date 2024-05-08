using DataAccessInterfaces;
using DataObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessFakes
{
    /// <summary>
    /// Creator: Anthony Talamantes
    /// Created: 02/01/2024
    /// Summary: Test data for Item Accessor
    /// Last Updated By: Anthony Talamantes
    /// Last Updated: 02/01/2024
    /// What Was Changed: Initial Creation
    /// </summary>
    public class ItemAccessorFake : IItemAccessor
    {
        private List<Item> _items = new List<Item>();
        public ItemAccessorFake()
        {
            _items.Add(new Item()
            {
                ItemID = 1111,
                ItemName = "Umbrella",
                ItemDescription = "stuff for the rain",
                QtyOnHand = 3,
                NormalStockQty = 5,
                ReorderPoint = 3,
                OnOrder = 2
            });
            _items.Add(new Item()
            {
                ItemID = 2222,
                ItemName = "Bed Sheets",
                ItemDescription = "stuff for the bed",
                QtyOnHand = 4,
                NormalStockQty = 5,
                ReorderPoint = 3,
                OnOrder = 0
            });
            _items.Add(new Item()
            {
                ItemID = 3333,
                ItemName = "Pillows",
                ItemDescription = "stuff for the bed",
                QtyOnHand = 2,
                NormalStockQty = 5,
                ReorderPoint = 2,
                OnOrder = 3
            });
        }

        /// <summary>
        /// Creator: Anthony Talamantes
        /// Created: 02/01/2024
        /// Summary: method for select all items fake data
        /// Last Updated By: Anthony Talamantes
        /// Last Updated: 02/01/2024
        /// What Was Changed: Initial Creation
        /// </summary>
        public List<Item> SelectAllItems()
        {
            return _items;
        }


        /// <summary>
        /// Creator: Mitchell Stirmel   
        /// Created: 02/20/2024
        /// Summary: method for update items fake data
        /// Last Updated By: Mitchell Stirmel
        /// Last Updated: 02/20/2024
        /// What Was Changed: Initial Creation
        /// </summary>
        public bool UpdateQtyOnHand(Item item)
        {
            if (item.ItemID == 1 && item.QtyOnHand == 1)
            {
                return true;
            } 
            else
            {
                return false;
            }

        }

        /// <summary>
        /// Creator:Andres Garcia
        /// Created: 2/06/2024
        /// Summary: Returns a single item object by itemId from accessor fakes.
        /// Last Updated By: Andres Garcia
        /// Last Updated: 2/06/2024
        /// What was Changed: Inital Creation
        /// </summary>
        public Item SelectItemByItemId(int itemId)
        {
            return _items[0];
        }


        /// <summary>
        /// Creator:Andres Garcia
        /// Created: 2/06/2024
        /// Summary: Inventory accessor fakes class.
        /// Last Updated By: Andres Garcia
        /// Last Updated: 2/06/2024
        /// What was Changed: Inital Creation
        /// </summary>
        public int UpdateItem(int itemId, Item item)
        {
            _items[0] = item;
            return 1;
        }

        /// <summary>
        /// Creator:Andres Garcia
        /// Created: 4/19/2024
        /// Summary: Sets quantity on hand of all item fakes to 0.
        /// Last Updated By: Andres Garcia
        /// Last Updated: 4/19/2024
        /// What was Changed: Inital Creation
        /// </summary>

        public bool DeleteInventory()
        {
            foreach (Item item in _items)
            {
                item.QtyOnHand = 0;
            }

            return true;

        }

        /// <summary>
        /// Creator:Andres Garcia
        /// Created: 4/19/2024
        /// Summary: Adds an item to item fakes.
        /// Last Updated By: Andres Garcia
        /// Last Updated: 4/19/2024
        /// What was Changed: Inital Creation
        /// </summary>

        public int AddItem(Item item)
        {

            _items.Add(item);
            return 1;

        }

        /// <summary>
        /// Creator:Andres Garcia
        /// Created: 4/19/2024
        /// Summary: Deletes an item from item fakes.
        /// Last Updated By: Andres Garcia
        /// Last Updated: 4/19/2024
        /// What was Changed: Inital Creation
        /// </summary>

        public int DeleteItem(int itemId)
        {
            int itemCountBefore = _items.Count;
            Item itemToRemove = null;
            foreach (Item item in _items)
            {
                if (item.ItemID == itemId)
                {
                    itemToRemove = item;
                }
            }
            _items.Remove(itemToRemove);
            int itemCountAfter = _items.Count;
            if (itemCountAfter < itemCountBefore)
            {
                return 1;
            }
            else { return 0; }
        }
    }

}