using DataAccessFakes;
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
    /// Creator: Ethan McElree
    /// Created: 03/5/2024
    /// Summary: Test class for HousekeepingTask
    /// Last Updated By: Ethan McElree
    /// Last Updated: 03/5/2024
    /// What Was Changed: Initial Creation
    /// </summary>
    [TestClass]
    public class HousekeepingTaskManagerTest
    {
        /// <summary>
        /// Creator: Ethan McElree
        /// Created: 03/5/2024
        /// Summary: Test method for successfully updating the task status
        /// Last Updated By: Ethan McElree
        /// Last Updated: 03/5/2024
        /// What Was Changed: Initial Creation
        /// </summary>
        [TestMethod]
        public void SuccessfullyUpdateTaskStatus()
        {
            IHousekeepingTaskManager housekeepingTaskManager = new HousekeepingTaskManager(new HousekeepingTaskAccessorFakes());
            housekeepingTaskManager.UpdateHousekeepingTaskStatus(100000, "Clean");
            HousekeepingTaskVM housekeepingTaskVM = housekeepingTaskManager.GetHousekeepingTaskVM(100000);
            Assert.AreEqual("Clean", housekeepingTaskVM.Status);
        }

        /// <summary>
        /// Creator: Ethan McElree
        /// Created: 03/5/2024
        /// Summary: Test method for failing to update the task status
        /// Last Updated By: Ethan McElree
        /// Last Updated: 03/5/2024
        /// What Was Changed: Initial Creation
        /// </summary>
        [TestMethod]
        public void FailedToUpdateTaskStatus()
        {
            IHousekeepingTaskManager housekeepingTaskManager = new HousekeepingTaskManager(new HousekeepingTaskAccessorFakes());
            housekeepingTaskManager.UpdateHousekeepingTaskStatus(100000, "Clean");
            HousekeepingTaskVM housekeepingTaskVM = housekeepingTaskManager.GetHousekeepingTaskVM(100000);
            Assert.AreNotEqual("Failed", housekeepingTaskVM.Status);
        }
    }
}
