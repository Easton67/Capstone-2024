using DataAccessFakes;
using DataAccessInterfaces;
using DataObjects;
using LogicLayer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace LogicLayerTests
{
    /// <summary>
    /// Creator: Andrew Larson
    /// Created: 01/29/2024
    /// Summary: All the test methods for the HoursOfOperationManagerTests
    /// Last Updated By: Andrew Larson
    /// Last Updated 01/31/2024
    /// What was changed: Fixed CheckValidZipCodeReturnsCorrectValue().
    /// </summary>
    [TestClass]
    public class HoursOfOperationManagerTests
    {
        /// <summary>
        /// Creator: Andrew Larson
        /// Created: 01/29/2024
        /// Summary: Tests the number of results given a valid ZipCode
        /// Last Updated By: Andrew Larson
        /// Last Updated 01/29/2024
        /// What was changed: Initial Creation
        /// </summary>
        [TestMethod]
        public void GetLocationsByZipCodeWhenZipCodeIsValid()
        {
            int zipCode = 12345;

            IHoursOfOperationAccessor fakeAccessor = new HoursOfOperationFakes();
            IHoursOfOperationManager hoursOfOperationManager = new HoursOfOperationManager(fakeAccessor);


            List<Location> result = hoursOfOperationManager.GetLocationsByZipCode(zipCode);


            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Count);


        }

        /// <summary>
        /// Creator: Andrew Larson
        /// Created: 01/29/2024
        /// Summary: Tests the number of results given an invalid ZipCode
        /// Last Updated By: Andrew Larson
        /// Last Updated 01/29/2024
        /// What was changed: Initial Creation
        /// </summary>
        [TestMethod]
        public void GetLocationsByZipCodeWhenZipCodeIsInvalid()
        {
            int zipCode = 99999;

            IHoursOfOperationAccessor fakeAccessor = new HoursOfOperationFakes();
            IHoursOfOperationManager hoursOfOperationManager = new HoursOfOperationManager(fakeAccessor);


            List<Location> result = hoursOfOperationManager.GetLocationsByZipCode(zipCode);

            Assert.IsNotNull(result);
            Assert.AreEqual(0, result.Count);
        }


        /// <summary>
        /// Creator: Andrew Larson
        /// Created: 01/29/2024
        /// Summary: Tests values of zipcode and hoursOfOperationString 
        /// from the fakes directly vs the correct hard coded values
        /// Last Updated By: Andrew Larson
        /// Last Updated 01/31/2024
        /// What was changed: Asserting both hoursOfOperationString and zipCode
        /// </summary>
        [TestMethod]
        public void CheckValidZipCodeReturnsCorrectValue()
        {
            int zipCode = 12345;
            string hoursOfOperationString = "8:00AM - 5:00PM";

            IHoursOfOperationAccessor fakeAccessor = new HoursOfOperationFakes();
            IHoursOfOperationManager hoursOfOperationManager = new HoursOfOperationManager(fakeAccessor);

            List<Location> result = hoursOfOperationManager.GetLocationsByZipCode(zipCode);


            Assert.AreEqual(hoursOfOperationString, result[0].HoursOfOperation[0].HoursOfOperationString);
            Assert.AreEqual(zipCode, result[0].ZipCode);
        }
    }
}
