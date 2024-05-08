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
    /// Creator:            Ethan McElree
    /// Created:            02/13/2024
    /// Summary:            Creation of ScheduleManagerTest class.
    /// Last Updated By:    Ethan McElree
    /// Last Updated:       02/13/2024
    /// What Was Changed:   Initial Creation
    /// </summary>
    [TestClass]
    public class ScheduleManagerTests
    {
        IScheduleManager _scheduleManager = null;

        /// <summary>
        /// Creator: Ethan McElree
        /// Created: 02/13/2024
        /// Summary: Creation of the TestSetUp method for schedule manager.
        /// Last Updated By: Ethan McElree
        /// Last Updated: 02/13/2024
        /// What Was Changed: Initial Creation
        /// </summary>
        [TestInitialize]
        public void TestSetup()
        {
            _scheduleManager = new ScheduleManager(new DataAccessFakes.ScheduleAccessFake());
        }

        /// <summary>
        /// Creator:            Ethan McElree
        /// Created:            02/13/2024
        /// Summary:            Creation of test method to successfully create a schedule
        /// Last Updated By:    Ethan McElree
        /// Last Updated:       02/13/2024
        /// What Was Changed:   Initial Creation
        /// </summary>
        [TestMethod]
        public void SuccessfullyCreatedASchedule()
        {
            string ScheduleMonth = "Unknown";
            int ScheduleWeek = 5;
            int ScheduleYear = 2000;
            DateTime ScheduleStartDate = DateTime.MinValue;
            DateTime ScheduleEndDate = DateTime.MinValue;

            int rows = _scheduleManager.CreateSchedule(ScheduleMonth, ScheduleWeek, ScheduleYear, ScheduleStartDate, ScheduleEndDate);

            Assert.AreEqual(1, rows);
        }

        /// <summary>
        /// Creator:            Ethan McElree
        /// Created:            02/13/2024
        /// Summary:            Creation of test method to fail to create a schedule
        /// Last Updated By:    Ethan McElree
        /// Last Updated:       02/13/2024
        /// What Was Changed:   Initial Creation
        /// </summary>
        [TestMethod]
        public void FailedToCreateASchedule()
        {
            string ScheduleMonth = "Unknown";
            int ScheduleWeek = 5;
            int ScheduleYear = 2000;
            DateTime ScheduleStartDate = DateTime.MinValue;
            DateTime ScheduleEndDate = DateTime.MinValue;

            int rows = _scheduleManager.CreateSchedule(ScheduleMonth, ScheduleWeek, ScheduleYear, ScheduleStartDate, ScheduleEndDate);

            Assert.AreNotEqual(0, rows);
        }

        /// <summary>
        /// Creator:            Ethan McElree
        /// Created:            02/15/2024
        /// Summary:            Creation of test method to successfully identify a new schedule
        /// Last Updated By:    Ethan McElree
        /// Last Updated:       02/15/2024
        /// What Was Changed:   Initial Creation
        /// </summary>
        [TestMethod]
        public void SuccessfullyIdentityANewSchedule()
        {
            string ScheduleMonth = "Unknown";
            int ScheduleWeek = 5;
            int ScheduleYear = 2000;
            
            bool doesExist = _scheduleManager.ScheduleExists(ScheduleMonth, ScheduleWeek, ScheduleYear);

            Assert.IsFalse(doesExist);
        }

        /// <summary>
        /// Creator:            Ethan McElree
        /// Created:            02/15/2024
        /// Summary:            Creation of test method to fail to identify a new schedule
        /// Last Updated By:    Ethan McElree
        /// Last Updated:       02/15/2024
        /// What Was Changed:   Initial Creation
        /// </summary>
        [TestMethod]
        public void FailedToIdentityANewSchedule()
        {
            int rows = 0;
            string scheduleMonth = "Unknown";
            int scheduleWeek = 6;
            int scheduleYear = 2000;
            DateTime ScheduleStartDate = DateTime.MinValue;
            DateTime ScheduleEndDate = DateTime.MinValue;

            rows = _scheduleManager.CreateSchedule(scheduleMonth, scheduleWeek, scheduleYear, ScheduleStartDate, ScheduleEndDate);
            bool doesExist = _scheduleManager.ScheduleExists(scheduleMonth, scheduleWeek, scheduleYear);

            Assert.IsTrue(doesExist);
        }
        /// <summary>
        /// Creator:            Abdalgader Ibrahim
        /// Created:            03/28/2024
        /// Summary:            Creation of test method to fail to identify a All schedules
        /// </summary>
        [TestMethod]
        public void TestGetAllSchedules() 
        {
            List<ScheduleVM> scheduleVMs = _scheduleManager.GetAllSchedules().ToList<ScheduleVM>();
            Assert.AreEqual(5, scheduleVMs.Count);

        }
    }
}
