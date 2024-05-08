using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using DataObjects;
using LogicLayer;
using DataAccessFakes;
using DataAccessInterfaces;
using System.Collections.Generic;
using DataObjects.Kitchen;

/// <summary>
///Creator:Suliman Adam Suliman
///Created: 02/02/2024
///Summary: Created a LogicLayer for kitchenInventoryItem.
///Last Updated By: 
///Last Updated: 
///What Was Changed: 
/// </summary>
namespace LogicLayerTests
{
    /// <summary>
    ///Creator:Suliman Adam Suliman
    ///Created: 02/02/2024
    ///Summary: Created a Class for kitchenInventoryItemManagerTest for UnitTest.
    ///Last Updated By: 
    ///Last Updated: 
    ///What Was Changed:
    /// </summary>
    [TestClass]
    public class KitchenInventoryItemManagerTests
    {
        private KitchenInventoryItemManager _manager;

        /// <summary>
        ///Creator:Suliman Adam Suliman
        ///Created: 02/02/2024
        ///Summary: Created a Method that return Void for UnitTesting.
        ///Last Updated By: 
        ///Last Updated: 
        ///What Was Changed: 
        /// </summary>
        [TestInitialize]
        public void TestSetup()
        {
            _manager = new KitchenInventoryItemManager(new KitchenInventoryItemAccessorFake());
        }
        /// <summary>
        ///Creator:Suliman Adam Suliman
        ///Created: 02/02/2024
        ///Summary: Created a method that return Void for UnitTesting.
        ///Last Updated By:
        ///Last Updated:
        ///What Was Changed:
        /// </summary>
        [TestMethod]
        public void TestGetKitchenInventoryItems()
        {
            // Arrange
            List<KitchenInventoryItem> SelectkitchenInventoryItems;
            // Act
            SelectkitchenInventoryItems = _manager.GetKitchenInventoryItems();
            // Assert
            Assert.AreEqual(2, SelectkitchenInventoryItems.Count);
        }

        /// <summary>
        ///Creator: Ethan McElree
        ///Created: 04/15/2024
        ///Summary: Test method that successfully gets kitchen inventory items by their category.
        ///Last Updated By: Ethan McElree
        ///Last Updated: 4/15/2024
        ///What Was Changed: Initial Creation.
        /// </summary>
        [TestMethod]
        public void TestSuccessfullyGetKitchenInventoryItemsByCategory()
        {
            // Arrange
            List<KitchenInventoryItemVM> SelectCategoryKitchenInventoryItems;
            // Act
            SelectCategoryKitchenInventoryItems = _manager.ViewKitchenInventoryItemsByCategory("Kitchen");
            // Assert
            Assert.AreEqual(2, SelectCategoryKitchenInventoryItems.Count);
        }

        /// <summary>
        ///Creator: Ethan McElree
        ///Created: 04/15/2024
        ///Summary: Test method that fails to get kitchen inventory items by their category.
        ///Last Updated By: Ethan McElree
        ///Last Updated: 4/15/2024
        ///What Was Changed: Initial Creation.
        /// </summary>
        [TestMethod]
        public void TestFailedToGetKitchenInventoryItemsByCategory()
        {
            // Arrange
            List<KitchenInventoryItemVM> SelectCategoryKitchenInventoryItems;
            // Act
            SelectCategoryKitchenInventoryItems = _manager.ViewKitchenInventoryItemsByCategory("Kitchen");
            // Assert
            Assert.AreNotEqual(0, SelectCategoryKitchenInventoryItems.Count);
        }
    }
}
