using DataAccessFakes;
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
    /// Created: 03/26/2024
    /// Summary: Test class for the Locations table.
    /// Last Updated By: Ethan McElree
    /// Last Updated By: 03/26/2024
    /// What Was Changed: Initial Creation
    /// </summary>
    [TestClass]
    public class LocationManagerTests
    {
        private LocationManager _locationManager = null;

        [TestInitialize]
        public void TestSetUp()
        {
            _locationManager = new LocationManager(new LocationAccessorFakes());
        }

        /// <summary>
        /// Creator: Ethan McElree
        /// Created: 03/26/2024
        /// Summary: Test method for successfully getting locations.
        /// Last Updated By: Ethan McElree
        /// Last Updated By: 03/26/2024
        /// What Was Changed: Initial Creation
        /// </summary>
        [TestMethod]
        public void SuccessfullyRetrievedLocations()
        {
            int expectedAmount = 3;
            int actualAmount = 0;

            actualAmount = (_locationManager.GetLocations()).Count;

            Assert.AreEqual(expectedAmount, actualAmount);
        }

        /// <summary>
        /// Creator: Ethan McElree
        /// Created: 03/26/2024
        /// Summary: Test method for failing to get locations.
        /// Last Updated By: Ethan McElree
        /// Last Updated By: 03/26/2024
        /// What Was Changed: Initial Creation
        /// </summary>
        [TestMethod]
        public void FailedToRetrieveLocations()
        {
            int expectedAmount = 0;
            int actualAmount = 3;

            actualAmount = (_locationManager.GetLocations()).Count;

            Assert.AreNotEqual(expectedAmount, actualAmount);
        }
    }
}
