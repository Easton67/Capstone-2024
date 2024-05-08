using LogicLayer;
using DataAccessFakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace LogicLayerTests
{
    /// <summary>
    /// Creator: Kirsten Stage
    /// Created: 03/29/2024
    /// Summary: Created the Event Meal Plan unit tests.
    /// Last Updated By: Kirsten Stage
    /// Last Updated: 03/29/2024
    /// What Was Changed: Initial Creation
    /// </summary>

    [TestClass]
    public class EventMealPlanTests
    {
        private EventMealPlanManager _eventMealPlanManager = null;

        [TestInitialize]
        public void TestSetup()
        {
            _eventMealPlanManager = new EventMealPlanManager(new EventMealPlanAccessorFakes());
        }

        /// <summary>
        /// Creator: Kirsten Stage
        /// Created: 03/29/2024
        /// Summary: Testing the GetMealPlanById() method using the EventMealPlanAccessorFakes class.
        /// Last Updated By: Kirsten Stage
        /// Last Updated: 03/29/2024
        /// What Was Changed: Initial Creation
        /// </summary>

        [TestMethod]
        public void TestGetMealPlanByNameWorksCorrectly()
        {
            // arrange
            string name = "Name1";
            int expectedID = 1;
            int actualID = 0;

            // act
            actualID = _eventMealPlanManager.GetMealPlanByName(name).EventID;

            // assert
            Assert.AreEqual(expectedID, actualID);
        }

        /// <summary>
        /// Creator: Kirsten Stage
        /// Created: 04/01/2024
        /// Summary: Testing the GetEventNamesForDropDown() method using the EventMealPlanAccessorFakes class.
        /// Last Updated By: Kirsten Stage
        /// Last Updated: 04/01/2024
        /// What Was Changed: Initial Creation
        /// </summary>

        [TestMethod]
        public void TestGetEventNamesForDropDownReturnsCorrectList()
        {
            // arrange
            int expectedCount = 3;
            int actualCount = 0;

            // act
            actualCount = (_eventMealPlanManager.GetEventNamesForDropDown()).Count;

            // assert
            Assert.AreEqual(expectedCount, actualCount);
        }
    }
}
