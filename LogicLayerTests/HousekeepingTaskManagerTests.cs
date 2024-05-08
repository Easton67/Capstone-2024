using DataAccessFakes;
using DataObjects;
using LogicLayer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace LogicLayerTests {
    [TestClass]
    public class HousekeepingTaskManagerTests {
        private HousekeepingTaskManager _manager = null;

        [TestInitialize]

        public void TestSetup() {
            _manager = new HousekeepingTaskManager(new HousekeepingTaskAccessorFakes());
        }

        /// <summary>
        /// Creator: Jared Harvey
        /// Created: 03/05/2024
        /// Summary: This method tests the CreateHousekeepingTask manager method.
        /// Last Updated By: Jared Harvey
        /// Last Updated: 03/05/2024
        /// What Was Changed: Initial Creation
        /// </summary>
        [TestMethod]
        public void TestCreateHousekeepingTask() {
            bool expected = true;
            bool actual = false;
            HousekeepingTask task = new HousekeepingTaskVM() {
                TaskID = 100003,
                RoomID = 100003,
                EmployeeID = "beans@whitehouse.org",
                Type = "Requested Cleaning",
                Description = "Bed sheets are stained, would like them replaced please.",
                Date = DateTime.Now,
                Status = "Pending"
            };

            actual = _manager.CreateHousekeepingTask(task);

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Creator: Jared Harvey
        /// Created: 03/05/2024
        /// Summary: This method tests the CreateHousekeepingTask manager method.
        /// Last Updated By: Jared Harvey
        /// Last Updated: 03/05/2024
        /// What Was Changed: Initial Creation
        /// </summary>
        [TestMethod]
        public void TestAssignHousekeeperToTask() {
            bool expected = true;
            bool actual = false;

            actual = _manager.AssignHousekeeperToTask(100000, "obama-prism@whitehouse.org");

            Assert.AreEqual(expected, actual);
        }
    }
}
