using DataObjects;
using LogicLayer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace LogicLayerTests
{
    /// <summary>
    /// Creator: Marwa Ibrahim
    /// Created: 02/16/2024
    /// Summary: Created the Reminder Manager unit tests.
    /// Last Updated By: Marwa Ibrahim
    /// Last Updated: 02/16/2024
    /// What Was Changed: Initial Creation
    /// </summary>
    [TestClass]
    public class ReminderManagerTest
    {
        IReminderManager _ReminderManager = null;

        [TestInitialize]
        public void TestSetUp()
        {
            _ReminderManager = new ReminderManager(new DataAccessFakes.ReminderAccessorFake());
        }

        [TestMethod]
        public void TestInsertReminder()
        {
            Reminder reminder = new Reminder
            {
                EmailTo = "Company.com",
                EmailFrom = "Company.com",
                Title = "Reminder Title",
                Message = "Reminder Massage",
                Frequency = "Reminder Frequency",
                Date = DateTime.Now,
                Read = true,
                Deactivate = true
            };
            Boolean insert = _ReminderManager.createReminder(reminder);
            Assert.IsTrue(insert);

        }
    }
}
