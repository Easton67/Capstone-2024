using DataAccessFakes;
using DataAccessInterfaces;
using DataObjects;
using LogicLayer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayerTests
{
    /// <summary>
    ///Creator:            Anthony Talamantes
    ///Created:            02/01/2024
    ///Summary:            This is the class for item logic testing.
    ///Last Updated By:    Anthony Talamantes
    ///Last Updated:       02/01/2024
    ///What Was Changed:   Initial Creation
    /// </summary>
    [TestClass]
    public class ItemManagerTests
    {
        /// <summary>
        ///Creator:            Anthony Talamantes
        ///Created:            02/01/2024
        ///Summary:            Unit test for the ItemManager class to ensure the GetItems method returns a valid list of items.
        ///Last Updated By:    Anthony Talamantes
        ///Last Updated:       02/01/2024
        ///What Was Changed:   Initial Creation
        /// </summary>
        [TestMethod]
        public void ItemReturnsValidResult()
        {
            // Arrange
            IItemAccessor fakeItemAccessor = new ItemAccessorFake();
            ItemManager itemManager = new ItemManager(fakeItemAccessor);

            // Act
            List<Item> items = itemManager.GetItems();

            // Assert
            Assert.IsNotNull(items);
            Assert.AreEqual(3, items.Count);

            Assert.AreEqual("Umbrella", items[0].ItemName);
            Assert.AreEqual("Bed Sheets", items[1].ItemName);
            Assert.AreEqual("Pillows", items[2].ItemName);
        }

        [TestMethod]
        public void ItemUpdateQtyReturnsTrue()
        {
            IItemAccessor fakeItemAccessor = new ItemAccessorFake();
            ItemManager itemManager = new ItemManager(fakeItemAccessor);

            Item item = new Item {
                ItemID = 1,
                QtyOnHand = 1
            };

            bool result = itemManager.UpdateQtyOnHand(item);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void ItemUpdateQtyReturnsFalse()
        {
            IItemAccessor fakeItemAccessor = new ItemAccessorFake();
            ItemManager itemManager = new ItemManager(fakeItemAccessor);

            Item item = new Item
            {
                ItemID = 0,
                QtyOnHand = 0
            };

            bool result = itemManager.UpdateQtyOnHand(item);

            Assert.IsFalse(result);
        }


        /// <summary>
        /// Creator:Andres Garcia
        /// Created: 1/30/2024
        /// Summary:This test method should pass after getting inventory item by id.
        /// Last Updated By: Andres Garcia
        /// Last Updated: 1/30/2024
        /// What was Changed: Inital Creation
        /// </summary>

        [TestMethod]
        public void TestGetInventoryItemByIdPass()
        {
            IItemAccessor fakeItemAccessor = new ItemAccessorFake();
            ItemManager itemManager = new ItemManager(fakeItemAccessor);
            //arrange
            int expectedId = 1111;
            int actualId = 0;

            //act
            actualId = itemManager.GetItemByItemId(1111).ItemID;

            //assert
            Assert.AreEqual(expectedId, actualId);

        }

        /// <summary>
        /// Creator:Andres Garcia
        /// Created: 1/30/2024
        /// Summary:This test method should pass after taking an item id and a new item object and updating the existing
        /// item with the new item object
        /// Last Updated By: Andres Garcia
        /// Last Updated: 1/30/2024
        /// What was Changed: Inital Creation
        /// </summary>

        [TestMethod]
        public void TestEditItem()
        {
            IItemAccessor fakeItemAccessor = new ItemAccessorFake();
            ItemManager itemManager = new ItemManager(fakeItemAccessor);
            //arrange
            Item item = itemManager.GetItems()[0];
            string expectedItemName = "Edited Name";
            string actualItemName = item.ItemName;

            //act
            Item item2 = new Item()
            {
                ItemID = 31234,
                ItemName = "Edited Name",
                ItemDescription = "Edited Description",
                QtyOnHand = 20,
                NormalStockQty = 20,
                ReorderPoint = 10,
                OnOrder = 0
            };
            itemManager.EditItem(item.ItemID, item2);
            item = itemManager.GetItems()[0];
            actualItemName = item.ItemName;

            //assert
            Assert.AreEqual(expectedItemName, actualItemName);

        }

        /// <summary>
        /// Creator:Andres Garcia
        /// Created: 04/19/2024
        /// Summary: Test method should pass after setting all QtyOnHand of items to 0
        /// Last Updated By: Andres Garcia
        /// Last Updated: 04/19/2024
        /// What was Changed: Initial Creation
        /// </summary>
        [TestMethod]
        public void TestDeleteInevntory()
        {
            IItemAccessor itemAccessor = new ItemAccessorFake();
            int expectedQtyOnHand = 0;
            int actualQtyOnHand = 0;

            itemAccessor.DeleteInventory();

            List<Item> items = itemAccessor.SelectAllItems();

            foreach (Item item in items)
            {
                actualQtyOnHand += item.QtyOnHand;
            }


            Assert.AreEqual(expectedQtyOnHand, actualQtyOnHand);

        }

        /// <summary>
        /// Creator:Andres Garcia
        /// Created: 04/19/2024
        /// Summary: Test method should pass after adding an item to fakeitem list
        /// Last Updated By: Andres Garcia
        /// Last Updated: 04/19/2024
        /// What was Changed: Initial Creation
        /// </summary>
        [TestMethod]
        public void TestAddItemToInventory()
        {
            IItemAccessor fakeItemAccessor = new ItemAccessorFake();
            List<Item> items = fakeItemAccessor.SelectAllItems();
            int expectedItemCount = items.Count + 1;
            int actualItemCount;

            Item item = new Item()
            {
                ItemName = "NewFakeitem",
                ItemDescription = "Description",
                QtyOnHand = 0,
                NormalStockQty = 10,
                ReorderPoint = 5,
                OnOrder = 0
            };
            fakeItemAccessor.AddItem(item);
            actualItemCount = items.Count;


            Assert.AreEqual(expectedItemCount, actualItemCount);

        }

        /// <summary>
        /// Creator:Andres Garcia
        /// Created: 04/19/2024
        /// Summary: Test method should pass after deleteing item by itemid from fakeitem list
        /// Last Updated By: Andres Garcia
        /// Last Updated: 04/19/2024
        /// What was Changed: Initial Creation
        /// </summary>
        [TestMethod]
        public void TestDeleteItemFromInventory()
        {
            IItemAccessor fakeItemAccessor = new ItemAccessorFake();
            int expectedItemsRemoved = 1;
            int actualItemsRemoved = 0;

            actualItemsRemoved = fakeItemAccessor.DeleteItem(1111);

            Assert.AreEqual(expectedItemsRemoved, actualItemsRemoved);

        }
    }
}
