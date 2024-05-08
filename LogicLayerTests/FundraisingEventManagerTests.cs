using Microsoft.VisualStudio.TestTools.UnitTesting;
using LogicLayer;
using DataObjects;
using System;
using DataAccessFakes;
using System.Collections.Generic;

namespace LogicLayerTests
{
    /// <summary>
    /// Creator: Kirsten Stage
    /// Created: 04/11/2024
    /// Summary: Created the Fundraising Event Manager unit tests.
    /// Last Updated By: Kirsten Stage
    /// Last Updated: 04/11/2024
    /// What Was Changed: Initial Creation
    /// </summary>

    [TestClass]
    public class FundraisingEventManagerTests
    {
        private FundraisingEventManager _fundraisingEventManager = null;

        [TestInitialize]
        public void TestSetup()
        {
            _fundraisingEventManager = new FundraisingEventManager(new FundraisingEventFakes());
        }

        /// <summary>
        /// Creator: Kirsten Stage
        /// Created: 04/11/2024
        /// Summary: Testing the CreateFundraisingEvent() method using 
        ///          the FundraisingEventFakes class.
        /// Last Updated By: Kirsten Stage
        /// Last Updated: 04/11/2024
        /// What Was Changed: Initial Creation
        /// </summary>

        [TestMethod]
        public void TestCreateFundraisingEventWorksCorrectly()
        {
            // arrange
            FundraisingEvent fundraisingEvent = new FundraisingEvent()
            {
                FundraisingId = 1,
                EventName = "Name1",
                FundraisingGoal = 100m,
                EventAddress = "Online",
                EventDate = DateTime.Now,
                StartTime = DateTime.Now,
                EndTime = DateTime.Now,
                EventDescription = "Description1"
            };

            bool expectedResult = true;
            bool actualResult = false;

            // act
            actualResult = _fundraisingEventManager.CreateFundraisingEvent(fundraisingEvent);

            // assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        /// <summary>
        /// Creator: Kirsten Stage
        /// Created: 04/18/2024
        /// Summary: Testing the GetFundraisingEvents() method using 
        ///          the FundraisingEventFakes class.
        /// Last Updated By: Kirsten Stage
        /// Last Updated: 04/18/2024
        /// What Was Changed: Initial Creation
        /// </summary>

        [TestMethod]
        public void TestGetFundraisingEventsWorksCorrectly()
        {
            // arrange
            List<FundraisingEvent> fe = _fundraisingEventManager.GetFundraisingEvents();
            int expectedCount = 3;
            int actualCount = 0;

            // act
            actualCount = fe.Count;

            // assert
            Assert.AreEqual(expectedCount, actualCount);
        }
    }
}
