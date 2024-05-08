using DataAccessFakes;
using LogicLayer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace LogicLayerTests {
    /// <summary>
    /// Creator: Jared Harvey
    /// Created: 03/03/2024
    /// Summary: Test class for DepartmentManager
    /// Last Updated By: Jared Harvey
    /// Last Updated: 03/03/2024
    /// What Was Changed: Initial Creation
    /// </summary>
    [TestClass]
    public class DepartmentManagerTests {
        private DepartmentManager _departmentManager = null;

        [TestInitialize]
        public void TestSetup() {
            _departmentManager = new DepartmentManager(new DepartmentAccessorFakes());
        }

        /// <summary>
        /// Creator: Jared Harvey
        /// Created: 03/03/2024
        /// Summary: This method tests the GetShelterDepartments manager method
        /// Last Updated By: Jared Harvey
        /// Last Updated: 03/03/2024
        /// What Was Changed: Initial Creation
        /// </summary>
        [TestMethod]
        public void TestGetShelterDepartments() {
            string shelterID = "Test Homeless Shelter";
            int expected = 5;
            int actual = 0;

            actual = _departmentManager.GetShelterDepartments(shelterID).Count;

            Assert.AreEqual(expected, actual);
        }
    }
}
