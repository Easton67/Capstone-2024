using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using LogicLayer;
using DataAccessFakes;
using DataObjects;
using System.Collections.Generic;

namespace LogicLayerTests
{
    /// <summary>
    /// Creator:            Andrew Larson
    /// Created:            04/9/2024
    /// Summary:            Test class for confiscated items
    /// Last Updated By:    Andrew Larson
    /// Last Updated:       04/9/2024
    /// What Was Changed:   Initial Creation
    /// </summary>
    [TestClass]
    public class ConfiscatedItemsManagerTest
    {
        private ConfiscatedItemManager _confiscatedItemManager = null;

        [TestInitialize]
        public void TestSetUp()
        {
            _confiscatedItemManager = new ConfiscatedItemManager(new ConfiscatedItemAccessorFakes());
        }

        /// <summary>
        /// Creator:            Andrew Larson
        /// Created:            04/9/2024
        /// Summary:            Tests GetAllConfiscatedItems returns a non-empty list
        /// Last Updated By:    Andrew Larson
        /// Last Updated:       04/9/2024
        /// What Was Changed:   Initial Creation
        /// </summary>
        [TestMethod]
        public void TestGetAllConfiscatedItemsListIsNotEmpty()
        {
            int actualCount = 4;

            List<ConfiscatedItem> confiscatedItems = new List<ConfiscatedItem>();
            confiscatedItems = _confiscatedItemManager.GetAllConfiscatedItems();
            int expectedCount = confiscatedItems.Count;

            Assert.AreEqual(expectedCount, actualCount);
            Assert.AreNotEqual(0, actualCount);
        }

        /// <summary>
        /// Creator:            Andrew Larson
        /// Created:            04/9/2024
        /// Summary:            Tests GetAllConfiscatedItems returns correct values
        /// Last Updated By:    Andrew Larson
        /// Last Updated:       04/9/2024
        /// What Was Changed:   Initial Creation
        /// </summary>
        [TestMethod]
        public void TestGetAllConfiscatedItemsReturnsCorrectValues()
        {
            ConfiscatedItem expectedConfiscated = new ConfiscatedItem
            {
                LogConfiscatedItemsID = 1,
                ItemsConfiscated = "Mike's Hard Lemonade",
                ConfiscationDate = DateTime.Parse("04-09-2024"),
                ReasonForConfiscation = "Not allowed"
            };

            List<ConfiscatedItem> actualConfiscatedList = new List<ConfiscatedItem>();
            actualConfiscatedList = _confiscatedItemManager.GetAllConfiscatedItems();

            Assert.AreEqual(expectedConfiscated.LogConfiscatedItemsID, actualConfiscatedList[0].LogConfiscatedItemsID);
            Assert.AreEqual(expectedConfiscated.ItemsConfiscated, actualConfiscatedList[0].ItemsConfiscated);
            Assert.AreEqual(expectedConfiscated.ConfiscationDate, actualConfiscatedList[0].ConfiscationDate);
            Assert.AreEqual(expectedConfiscated.ReasonForConfiscation, actualConfiscatedList[0].ReasonForConfiscation);
        }

        /// <summary>
        /// Creator:            Andrew Larson
        /// Created:            04/9/2024
        /// Summary:            Tests AddConfiscatedItem returns correct boolean
        ///                     based off of number of rows affected
        /// Last Updated By:    Andrew Larson
        /// Last Updated:       04/9/2024
        /// What Was Changed:   Initial Creation
        /// </summary>
        [TestMethod]
        public void TestNumberOfRowsAffectedAfterAddingAConfiscatedItem()
        {
            bool expected = true;

            bool actual = _confiscatedItemManager.AddConfiscatedItem("test", "test");

            Assert.AreEqual(expected, actual);
        }


        /// <summary>
        /// Creator:            Andrew Larson
        /// Created:            04/9/2024
        /// Summary:            tests values of added item
        /// Last Updated By:    Andrew Larson
        /// Last Updated:       04/9/2024
        /// What Was Changed:   Initial Creation
        /// </summary>
        [TestMethod]
        public void TestInsertedConfiscatedItemValuesAreCorrect()
        {
            string expectedItem = "test item";
            string expectedReason = "test reason";
            _confiscatedItemManager.AddConfiscatedItem("test item", "test reason");
            List<ConfiscatedItem> confiscatedItems = new List<ConfiscatedItem>();
            confiscatedItems = _confiscatedItemManager.GetAllConfiscatedItems();

            Assert.AreEqual(expectedItem, confiscatedItems[4].ItemsConfiscated);
            Assert.AreEqual(expectedReason, confiscatedItems[4].ReasonForConfiscation);
        }
    }
}
