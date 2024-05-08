using DataAccessFakes;
using DataAccessInterfaces;
using DataObjects;
using LogicLayer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LogicLayerTests
{
    /// <summary>
    ///Creator:            Mitchell Stirmel
	///Created:            02/08/2024
    ///Summary:            This is the class for maintenance request logic testing.
    ///Last Updated By:    Mitchell Stirmel
    ///Last Updated:       02/08/2024
	///What Was Changed:   Initial Creation
    /// </summary>
    [TestClass]
    public class MaintenanceRequestManagerUnitTests
    {
        private MaintenanceRequestManager _manager = null;

        [TestInitialize]
        public void TestSetup() {
            _manager = new MaintenanceRequestManager(new MaintenanceAccessorFake());
        }

        /// <summary>
        ///Creator:            Mitchell Stirmel
        ///Created:            02/08/2024
        ///Summary:            This method should return true if the fake data is returned through the logic layer.
        ///Last Updated By:    Jared Harvey
        ///Last Updated:       03/05/2024
        ///What Was Changed:   Used the TestSetup method to get the manager
        /// </summary>
        [TestMethod]
        public void MaintenanceRequestReturnsValid()
        {
            List<MaintenanceRequest> result = _manager.GetMaintenanceRequests();

            Assert.IsNotNull(result);
            Assert.AreEqual(3, result.Count);
        }

        /// <summary>
        ///Creator:            Jared Harvey
        ///Created:            03/05/2024
        ///Summary:            Test Method for CreateMaintenanceRequest
        ///Last Updated By:    Jared Harvey
        ///Last Updated:       03/05/2024
        ///What Was Changed:   Initial Creation
        /// </summary>
        [TestMethod]
        public void TestCreateMaintenanceRequest() {
            bool expected = true;
            bool actual = false;
            MaintenanceRequest request = new MaintenanceRequest() {
                _requestID = 100004,
                _status = "Pending",
                _requestor = "Jared",
                _phone = "31924712453",
                _dateCreated = DateTime.Now,
                _description = "Beans",
                _roomID = 100002
            };

            actual = _manager.CreateMaintenanceRequest(request);

            Assert.AreEqual(expected, actual);
		}
		///// <summary>
  //      ///Creator:            Marwa Ibrahim
  //      ///Created:            02/20/2024
  //      ///Summary:            This method should return true if the fake data is returned through the logic layer
  //      /// </summary>
  //      [TestMethod]
  //      public void TestCreateMaintenanceRequest()
  //      {

  //          IMaintenanceAccessor fakeAccessor = new MaintenanceAccessorFake();
  //          MaintenanceRequestManager maintenanceRequestManager = new MaintenanceRequestManager(fakeAccessor);
  //          MaintenanceRequest maintenanceRequest = new MaintenanceRequest();
  //          maintenanceRequest._roomID = 100000;
  //          maintenanceRequest.Status = "";
  //          maintenanceRequest._phone = "4355678";
  //          maintenanceRequest._dateCreated = DateTime.Now;
  //          maintenanceRequest._description = "Description";


  //          bool result = maintenanceRequestManager.CreateMaintenanceRequest(maintenanceRequest);

  //          Assert.IsTrue(result);
  //      }

        /// <summary>
        ///Creator:            Kirsten Stage
        ///Created:            03/07/2024
        ///Summary:            This test ensures the UpdateMaintenanceRequestStatusToCompleted() method
        ///                    works correctly.
        ///Last Updated By:    Kirsten Stage
        ///Last Updated:       03/07/2024
        ///What Was Changed:   Initial Creation
        /// </summary>
        [TestMethod]
        public void TestUpdateMaintenanceRequestStatusToCompleted()
        {
            // arrange
            _manager = new MaintenanceRequestManager(new MaintenanceAccessorFake());
            MaintenanceRequest maintenanceRequest = new MaintenanceRequest
            {
                _requestID = 1,
                _roomID = 1,
                _requestor = "Joe",
                _status = "Pending",
                _dateCreated = DateTime.Now,
                _phone = "1234567890",
                _description = "Description",
            };
            bool expectedResult = true;
            bool actualResult = false;

            // act
            actualResult = _manager.UpdateMaintenanceRequestStatusToCompleted(maintenanceRequest);

            // assert
            Assert.AreEqual(expectedResult, actualResult);
        }
        /// <summary>
        ///Creator:            Donald Winchester
        ///Created:            03/07/2024
        ///Summary:            This method should return true if the fake data is set.
        ///Last Updated By:    Donald Winchester
        ///Last Updated:       03/08/2024
        ///What Was Changed:   Initial Creation
        /// </summary>
        [TestMethod]
        public void TestConfirmMaintenanceRequestReturnsValid()
        {
            bool expectedResult = true;
            bool actualResult = false;

            IMaintenanceAccessor fakeAccessor = new MaintenanceAccessorFake();
            MaintenanceRequestManager maintenanceRequestManager = new MaintenanceRequestManager(fakeAccessor);

            actualResult = maintenanceRequestManager.ConfirmMaintenanceRequest(100000, "Pending");

            Assert.AreEqual(expectedResult, actualResult);

        }

        /// <summary>
        /// Creator: Matthew Baccam
        /// Created: 03/01/2024
        /// Summary: Updates maintenance request for suspension
        /// Last Updated By: Matthew Baccam
        /// Last Updated 03/01/2024
        /// What was changed: Initial Creation.
        /// </summary>
        /// </summary>
        [TestMethod]
        public void TestSuspendRequest()
        {
            MaintenanceRequestManager maintenanceRequestManager = new MaintenanceRequestManager(new MaintenanceAccessorFake());
            var actual = new MaintenanceRequest
            {
                _requestID = 100000,
                _status = "Pending",
                _requestor = "Joe",
                _phone = "3192471283",
                _dateCreated = DateTime.Now,
                _description = "Description",
                _roomID = 1
            };

            Assert.IsTrue(maintenanceRequestManager.SuspendMaintenanceRequest(actual._requestID, actual._description, actual._description));
        }


        /// <summary>
        /// Creator:Andres Garcia
        /// Created: 04/19/2024
        /// Summary: Test method should pass after add repair to fake repair list
        /// Last Updated By: Andres Garcia
        /// Last Updated: 04/19/2024
        /// What was Changed: Initial Creation
        /// </summary>
        [TestMethod]
        public void TestScheduleRepair()
        {
            MaintenanceRequestManager maintenanceRequestManager = new MaintenanceRequestManager(new MaintenanceAccessorFake());
            bool expectedResult = true;
            bool actualResult = false;

            actualResult = maintenanceRequestManager.ScheduleRepair(1, "FakeEmployeeId", DateTime.Now);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void TestGetsCorrectMaintenance()
        {
            const string status = "Scheduled for repair";
            const int expectedCount = 3;
            int actualCount = 0;

            actualCount = (_manager.GetScheduledRepairs(status)).Count();

            Assert.AreEqual(expectedCount, actualCount);
        }
    }
}
