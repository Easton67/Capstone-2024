using DataAccessFakes;
using DataAccessInterfaces;
using DataObjects;
using LogicLayer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicLayerTests
{
    /// <summary>
    ///Creator:            Mitchell Stirmel
	///Created:            01/31/2024
    ///Summary:            This is the class for inventory logic testing.
    ///Last Updated By:    Mitchell Stirmel
    ///Last Updated:       02/01/2024
	///What Was Changed:   Initial Creation
    /// </summary>
    [TestClass]
    public class InventoryManagerTests
    {

        /// <summary>
        ///Creator:            Mitchell Stirmel
        ///Created:            02/01/2024
        ///Summary:            This test method returns true if the parts inventory is not null, and contains 5 objects.
        ///Last Updated By:    Mitchell Stirmel
        ///Last Updated:       02/01/2024
        ///What Was Changed:   Initial Creation
        /// </summary>
        [TestMethod]
        public void PartsInventoryReturnsValid()
        {
            IPartsInventoryAccessor fakeAccessor = new PartsInventoryAccessorFakes();   
            PartsInventoryManager inventoryLogic = new PartsInventoryManager(fakeAccessor);

            List<PartsInventory> partsInventory = inventoryLogic.GetPartsInventory();

            Assert.IsNotNull(partsInventory);
            Assert.AreEqual(4, partsInventory.Count);
        }


        /// <summary>
        ///Creator:            Mitchell Stirmel
        ///Created:            02/01/2024
        ///Summary:            This test method returns true if the parts inventory is not null, and contains 5 objects.
        ///Last Updated By:    Mitchell Stirmel
        ///Last Updated:       02/01/2024
        ///What Was Changed:   Initial Creation
        /// </summary>
        [TestMethod]
        public void UpdatedDateReturnsValid()
        {
            IPartsInventoryAccessor fakeAccessor = new PartsInventoryAccessorFakes();
            PartsInventoryManager inventoryLogic = new PartsInventoryManager(fakeAccessor);

            DateTime dateTime = new DateTime();

            DateTime result = inventoryLogic.GetUpdatedDate();

            Assert.AreEqual(dateTime, result);
        }

    }
}
