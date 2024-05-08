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
    /// Creator: Jared Harvey
    /// Created: 02/08/2024
    /// Summary: This class is responsible for testing shift logic.
    /// Last Updated By: Jared Harvey
    /// Last Updated: 02/08/2024
    /// What Was Changed: Initial Creation
    /// </summary>
    [TestClass]
    public class ShiftManagerTests
    {
        IShiftManager shiftManager = null;
        [TestInitialize]
        public void TestSetup()
        {
            shiftManager = new ShiftManager(new ShiftAccessorFakes());
        }

        /// <summary>
        /// Creator: Jared Harvey
        /// Created: 02/08/2024
        /// Summary: This method tests the GetDepartmentShifts manager method.
        /// Last Updated By: Jared Harvey
        /// Last Updated: 02/08/2024
        /// What Was Changed: Initial Creation
        /// </summary>
        [TestMethod]
        public void TestGetDepartmentShifts()
        {
            // arrange
            int expected = 4;
            int actual = 0;

            // act
            actual = shiftManager.GetShiftsByDepartment(100000).Count;

            // assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Creator: Jared Harvey
        /// Created: 02/16/2024
        /// Summary: Test Update Shift
        /// Last Updated By: Jared Harvey
        /// Last Updated: 02/16/2024
        /// What Was Changed: Initial Creation
        /// </summary>
        [TestMethod]
        public void TestUpdateShift()
        {
            // arrange
            Shift oldShift = new Shift() {
                ShiftID = 100000,
                EmployeeID = "tess@company.com",
                StartTime = DateTime.Now.AddDays(2),
                EndTime = DateTime.Now.AddDays(2)
            };
            Shift newShift = new Shift() {
                ShiftID = 100000,
                EmployeeID = "bill@company.com",
                StartTime = DateTime.Now.AddDays(3),
                EndTime = DateTime.Now
            };
            bool actual = false;
            bool expected = true;

            // act
            actual = shiftManager.EditShift(oldShift, newShift);

            // assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Creator: Liam Easton
        /// Created: 03/22/2024
        /// Summary: Test Add Shift
        /// Last Updated By: Liam Easton
        /// Last Updated: 03/22/2024
        /// What Was Changed: Initial Creation
        /// </summary>
        [TestMethod]
        public void TestAddShiftWorksCorrectly()
        {
            // arrange
            Shift newShift = new Shift()
            {
                ShiftID = 1,
                EmployeeID = "bill@company.com",
                StartTime = DateTime.Now,
                EndTime = DateTime.Now.AddDays(3),
            };
            bool actual = false;
            bool expected = true;

            // act
            actual = shiftManager.AddEmployeeShift(newShift);

            // assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Creator: Liam Easton
        /// Created: 03/22/2024
        /// Summary: Test Remove Shift
        /// Last Updated By: Liam Easton
        /// Last Updated: 03/22/2024
        /// What Was Changed: Initial Creation
        /// </summary>
        [TestMethod]
        public void TestAddRemoveWorksCorrectly()
        {
            // arrange
            Shift newShift = new Shift()
            {
                ShiftID = 1,
                EmployeeID = "bill@company.com",
                StartTime = DateTime.Now,
                EndTime = DateTime.Now.AddDays(3),
            };
            bool actual = false;
            bool expected = true;

            // act
            shiftManager.AddEmployeeShift(newShift);
            actual = shiftManager.RemoveShift(1);   

            // assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Creator: Abdalgader Ibrahim
        /// Created: 03/21/2024
        /// Summary: TestSelectShiftByScheduleID
        /// </summary>
        [TestMethod]
        public void TestSelectShiftByScheduleID()
        {
            List<ShiftVM> shifts = new List<ShiftVM>();
            shifts = shiftManager.SelectShiftByScheduleID(1);

            Assert.AreEqual(1, shifts.Count);
        }
    }
}
