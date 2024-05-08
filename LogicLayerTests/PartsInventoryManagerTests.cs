using DataAccessFakes;
using DataObjects;
using LogicLayer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LogicLayerTests
{
    /* 
       <summary>
           Creator:            Darryl Shirley
           Created:            02/07/2024
           Summary:            MaintenanceItemManagerTests.cs
           Last Updated By:    Darryl Shirley
           Last Updated:       02/07/2024
           What Was Changed:   Initial creation  
       </summary>
       */

    [TestClass]
    public class PartsInventoryManagerTests
    {
        IPartsInventoryManager _maintenanceItemManager = null;



        /* 
            <summary>
                Creator:            Darryl Shirley
                Created:            01/31/2024
                Summary:            TestSetUp() Method
                Last Updated By:    Darryl Shirley
                Last Updated:       02/07/2024
                What Was Changed:   Initial Creation 
            </summary>
        */
        [TestInitialize]
        public void TestSetUp()
        {
            _maintenanceItemManager = new PartsInventoryManager(new PartsInventoryAccessorFakes());

        }



        /* 
            <summary>
                Creator:            Darryl Shirley
                Created:            01/31/2024
                Summary:            TestGetListOfAllMaintenanceItems()
                Last Updated By:    Darryl Shirley
                Last Updated:       02/07/2024
                What Was Changed:   Initial Creation 
            </summary>
        */
        [TestMethod]
        public void TestGetListOfAllMaintenanceItems()
        {
            int expectedCount = 4;
            int actualCount = 0;


            actualCount = _maintenanceItemManager.GetPartsInventory().Count;

            Assert.AreEqual(expectedCount, actualCount);
        }

        /// <summary>
        /// Creator:            Anthony Talamantes
        /// Created:            02/22/2024
        /// Summary:            Test used to get all categories of a part in PartInventory
        /// Last Updated By:    Anthony Talamantes
        /// Last Updated:       02/22/2024
        /// What Was Changed:   Initial Creation
        /// </summary>
        [TestMethod]
        public void TestGetAllCategory()
        {
            int expectedCount = 4;
            int actualCount = 0;
            actualCount = _maintenanceItemManager.GetCategoriesForDropDown().Count;
            Assert.AreEqual(expectedCount, actualCount);
        }

        /// <summary>
        /// Creator:            Anthony Talamantes
        /// Created:            02/22/2024
        /// Summary:            Test used to get all stock types of a part in PartInventory
        /// Last Updated By:    Anthony Talamantes
        /// Last Updated:       02/22/2024
        /// What Was Changed:   Initial Creation
        /// </summary>
        [TestMethod]
        public void TestGetAllStockType()
        {
            int expectedCount = 4;
            int actualCount = 0;
            actualCount = _maintenanceItemManager.GetStockTypeForDropDown().Count;
            Assert.AreEqual(expectedCount, actualCount);
        }

        /// <summary>
        /// Creator:            Anthony Talamantes
        /// Created:            02/22/2024
        /// Summary:            Test used to get insert a part in PartInventory
        /// Last Updated By:    Anthony Talamantes
        /// Last Updated:       02/22/2024
        /// What Was Changed:   Initial Creation
        /// </summary>
        [TestMethod]
        public void TestInsertPart()
        {
            PartsInventory part = new PartsInventory()
            {
                _category = "Tools",
                _itemID = "Shovel",
                _quantity = 5,
                _stockType = "In Stock"
            };
            bool expectedResult = true;
            bool actualResult = false;
            actualResult = _maintenanceItemManager.AddPartsInventory(part);
            Assert.AreEqual(expectedResult, actualResult);
        }

        /// <summary>
        /// Creator:            Anthony Talamantes
        /// Created:            02/22/2024
        /// Summary:            Test used to delete a part in PartInventory
        /// Last Updated By:    Anthony Talamantes
        /// Last Updated:       02/22/2024
        /// What Was Changed:   Initial Creation
        /// </summary>
        [TestMethod]
        public void TestDeletePart()
        {

            string partIdToDelete = "hammer";
            int expectedResult = 1;
            int actualResult = 0;

            List<PartsInventory> partsInventoryList = _maintenanceItemManager.GetPartsInventory();

            foreach (var partToDelete in partsInventoryList.Where(p => p._itemID == partIdToDelete))
            {
                if (_maintenanceItemManager.RemovePartsInventory(partToDelete))
                {
                    actualResult = 1;
                }
                else
                {
                    actualResult = 0;
                }
            }
            Assert.AreEqual(expectedResult, actualResult);
        }

    }
}
