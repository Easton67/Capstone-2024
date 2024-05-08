using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessInterfaces;
using DataObjects;
using DataObjects.Kitchen;

namespace DataAccessFakes
{

    /// <summary>
    ///Creator:Suliman Adam Suliman
    ///Created: 02/02/2024
    ///Summary: Created a DataAccessFakes for kitchenInventoryItemAccessorFake.
    ///Last Updated By: 
    ///Last Updated:
    ///What Was Changed: No changes.
    /// </summary>
    public class KitchenInventoryItemAccessorFake : IKitchenInventoryItemAccessor
    {
        private List<KitchenInventoryItem> _inventoryItems = null;

        /// <summary>
        ///Creator:Suliman Adam Suliman
        ///Created: 02/02/2024
        ///Summary: Created a Fake Data for UnitTesting.
        ///Last Updated By: 
        ///Last Updated:
        ///What Was Changed: No changes.
        /// </summary>
        public KitchenInventoryItemAccessorFake()
        {

            _inventoryItems = new List<KitchenInventoryItem>()
            {
                new KitchenInventoryItem()
                {
                    KitchenItemID = 10000,
                    ItemName = "myItem",
                    QuantityInStock = 100,
                    Category = "Kitchen",
                    UnitCost = 25,
                    Supplier = "mySupplier",
                    ReorderQuantity = 88
                },
                 new KitchenInventoryItem()
                 {
                     KitchenItemID = 10000,
                     ItemName = "myItem",
                     QuantityInStock = 100,
                     Category = "Kitchen",
                     UnitCost = 25,
                     Supplier = "mySupplier",
                     ReorderQuantity = 88

                 },
            };
        }

        /// <summary>
        ///Creator:Suliman Adam Suliman
        ///Created: 02/02/2024
        ///Summary: Created a Constructor that return a List for kitchenInventoryItem.
        ///Last Updated By: 
        ///Last Updated: 
        ///What Was Changed: No changes.
        /// </summary>
        public List<KitchenInventoryItem> ViewKitchenInventoryItem()
        {
           return _inventoryItems;
        }

        /// <summary>
        ///Creator: Ethan McElree
        ///Created: 04/15/2024
        ///Summary: Created a method for returning a list of kitchen inventory items by their category.
        ///Last Updated By: Ethan McElree
        ///Last Updated: 4/15/2024
        ///What Was Changed: Initial Creation.
        /// </summary>
        public List<KitchenInventoryItemVM> ViewKitchenInventoryItemsByCategory(string category)
        {
            List<KitchenInventoryItem> items = _inventoryItems.Where(item => item.Category == category).ToList();
            List<KitchenInventoryItemVM> itemVMs = new List<KitchenInventoryItemVM>();
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
                itemVMs.Add(newItem);
            }
            return itemVMs;
        }
    }
}
