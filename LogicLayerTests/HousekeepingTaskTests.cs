using DataAccessFakes;
using LogicLayer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace LogicLayerTests
{/* 
        <summary>
            Creator:            Miyada Abas
            Created:            01/31/2024
            Summary:             Creation of HouseKeepingTasks test class
            Last Updated By:    Miyada Abas
            Last Updated:       02/07/2024
            What Was Changed:    
        </summary>
        */

    [TestClass]
    public class HousekeepingTaskTests
    {
        HouseKeepingManager _housekeepingManager;
        [TestInitialize]
        public void TestSetup()
        {
            _housekeepingManager = new HouseKeepingManager(new HousekeepingAccessorFakes());
        }

        /* 
        <summary>
            Creator:            Miyada Abas
            Created:            03/01/2024
            Summary:            Creation of HouseKeepingTasks test class
            Last Updated By:    Miyada Abas
            Last Updated:       03/01/2024
            What Was Changed:   
        </summary>
        */

        [TestMethod]
        public void TestGetAllHousekeepingTasksReturnsAllTasks()
        {
            int expected = 3;
            int actual = 0;

            actual = _housekeepingManager.GetAllHouseKeepingTasks().Count;

            Assert.AreEqual(expected, actual);
        }
    }
}
