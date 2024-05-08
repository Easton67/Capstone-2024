using LogicLayer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessFakes;
using DataObjects;

namespace LogicLayerTests
{
    /// <summary>
    ///Creator:            Mitchell Stirmel
    ///Created:            03/20/2024
    ///Summary:            This contains all methods for volunteer application data management.
    ///Last Updated By:    Mitchell Stirmel
    ///Last Updated:       03/20/2024
    ///What Was Changed:   Initial Creation
    /// </summary>
    [TestClass]
    public class VolunteerApplicationManagerTests
    {
        private VolunteerApplicationManager _volunteerApplicationManager;
        [TestInitialize] 
        public void Init() 
        {
            _volunteerApplicationManager = new VolunteerApplicationManager(new VolunteerApplicationAccessorFakes());
        }


        /// <summary>
        ///Creator:            Mitchell Stirmel
        ///Created:            03/20/2024
        ///Summary:            This test returns true if the list data is returned correctly.
        ///Last Updated By:    Mitchell Stirmel
        ///Last Updated:       03/20/2024
        ///What Was Changed:   Initial Creation
        /// </summary>
        [TestMethod]
        public void VolunteerApplicationManagerReturnsApplications()
        {
            var result = _volunteerApplicationManager.GetVolunteerApplications();

            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Count);
        }

        /// <summary>
        ///Creator:            Darryl Shirley
        ///Created:            03/27/2024
        ///Summary:            This test returns true if the application is updated0
        ///Last Updated By:    Darryl Shirley
        ///Last Updated:       03/27/2024
        ///What Was Changed:   Initial Creation
        /// </summary>
        [TestMethod]
        public void VolunteerApplicationStatusSuccessfullyUpdates()
        {
            bool result = false;
            int VolunteerID = 100;
            result = _volunteerApplicationManager.EditVolunteerAplicationStatus(VolunteerID, "On Hold", "Awaiting Background check");

            Assert.IsTrue(result);
        }

        /// <summary>
        ///Creator:            Darryl Shirley
        ///Created:            03/29/2024
        ///Summary:            This test returns false if the application is not updated
        ///Last Updated By:    Darryl Shirley
        ///Last Updated:       03/29/2024
        ///What Was Changed:   Initial Creation
        /// </summary>
        [TestMethod]
        public void VolunteerApplicationStatusUnsuccessfullyUpdates()
        {
            bool result = false;
            int VolunteerID = 99;
            result = _volunteerApplicationManager.EditVolunteerAplicationStatus(VolunteerID, "On Hold", "Awaiting Background check");

            Assert.IsFalse(result);
        }


        /// <summary>
        ///Creator:            Mitchell Stirmel
        ///Created:            04/04/2024
        ///Summary:            This test returns true if the system pulls back valid information
        ///Last Updated By:    Mitchell Stirmel
        ///Last Updated:       04/04/2024
        ///What Was Changed:   Initial Creation
        /// </summary>
        [TestMethod]
        public void VolunteerApplicationInfoReturnsInfo()
        {
            VolunteerApplicationInfo result = new VolunteerApplicationInfo();
            int ApplicationID = 10005;
            result = _volunteerApplicationManager.GetApplicationInfo(ApplicationID);

            Assert.IsNotNull(result.GivenName);
            Assert.AreEqual("Concerns", result.VolunteerConcerns);
        }

        /// <summary>
        ///Creator:            Mitchell Stirmel
        ///Created:            04/04/2024
        ///Summary:            This test returns true if the system pulls back a new model (this only happens if the accessor does not find any data).
        ///Last Updated By:    Mitchell Stirmel
        ///Last Updated:       04/04/2024
        ///What Was Changed:   Initial Creation
        /// </summary>
        [TestMethod]
        public void VolunteerApplicationInfoReturnsNewVolunteer()
        {
            VolunteerApplicationInfo result = new VolunteerApplicationInfo();
            int ApplicationID = 10000;
            result = _volunteerApplicationManager.GetApplicationInfo(ApplicationID);

            Assert.IsNull(result.GivenName);
        }

        /// <summary>
        ///Creator:            Suliman Suliman
        ///Created:            03/20/2024
        ///Summary:           TestAcceptingVolunteerApllication() This test returns true                                   if the list data is returned correctly.
        ///Last Updated By:   
        ///Last Updated:       
        ///What Was Changed:   
        /// </summary>
        [TestMethod]
        public void TestAcceptingVolunteerApllication()
        {
            VolunteerApplication volunteerApplication = new VolunteerApplication();
            volunteerApplication.ApplicationID = 100;
            volunteerApplication.Status = "Accepted";
            bool result = _volunteerApplicationManager.AcceptVolunteerApplication(volunteerApplication);
            Assert.IsTrue(result);
        }

        /// <summary>
        ///Creator:            Suliman Suliman
        ///Created:            03/20/2024
        ///Summary:            TestDeniedingVolunteerApllication() This test returns                                        true if the list data is returned correctly.
        ///Last Updated By:   
        ///Last Updated:       
        ///What Was Changed:  
        /// </summary>
        //[TestMethod]
        //public void TestDeniedingVolunteerApllication()
        //{
        //    VolunteerApplication volunteerApplication = new VolunteerApplication();
        //    volunteerApplication.ApplicationID = 100;
        //    volunteerApplication.Status = "Denied";
        //    bool result = _volunteerApplicationManager.DenyVolunteerApplication(volunteerApplication);
        //    Assert.IsTrue(result);
        //}


        /// <summary>
        ///Creator:            Mitchell Stirmel
        ///Created:            04/23/2024
        ///Summary:            Test passes if the faked method returns true.
        ///Last Updated By:    Mitchell Stirmel
        ///Last Updated:       04/23/2024
        ///What Was Changed:   Initial Creation
        /// </summary>
        [TestMethod]
        public void CreateVolunteerApplicationReturnsTrue()
        {
            CreateVolunteerApplication model = new CreateVolunteerApplication()
            {
                Email = "TestEmail"
            };

            var result = _volunteerApplicationManager.CreateVolunteerApplication(model);

            Assert.IsTrue(result);
        }


        /// <summary>
        ///Creator:            Mitchell Stirmel
        ///Created:            04/23/2024
        ///Summary:            Test passes if the faked method returns false.
        ///Last Updated By:    Mitchell Stirmel
        ///Last Updated:       04/23/2024
        ///What Was Changed:   Initial Creation
        /// </summary>
        [TestMethod]
        public void CreateVolunteerApplicationReturnsFalse()
        {
            CreateVolunteerApplication model = new CreateVolunteerApplication();

            var result = _volunteerApplicationManager.CreateVolunteerApplication(model);

            Assert.IsFalse(result);
        }


        /// <summary>
        ///Creator:            Mitchell Stirmel
        ///Created:            04/23/2024
        ///Summary:            Test passes if the faked method returns an exception.
        ///Last Updated By:    Mitchell Stirmel
        ///Last Updated:       04/23/2024
        ///What Was Changed:   Initial Creation
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void CreateVolunteerApplicationReturnsException()
        {
            CreateVolunteerApplication model = new CreateVolunteerApplication()
            {
                Email = "Ex"
            };
            var result = _volunteerApplicationManager.CreateVolunteerApplication(model);

        }
    }
}
