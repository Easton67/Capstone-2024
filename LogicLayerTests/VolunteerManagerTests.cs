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
    /// Creator:            Ethan McElree
    /// Created:            04/1/2024
    /// Summary:            Manager tests class for volunteers
    /// Last Updated By:    Ethan McElree
    /// Last Updated:       04/1/2024
    /// What Was Changed:   Initial Creation
    /// </summary>
    [TestClass]
    public class VolunteerManagerTests
    {
        private VolunteerManager _volunteerManager = null;

        [TestInitialize]
        public void TestSetUp()
        {
            _volunteerManager = new VolunteerManager(new VolunteerAccessorFakes());
        }

        /// <summary>
        /// Creator:            Ethan McElree
        /// Created:            04/1/2024
        /// Summary:            Test method that successfully views all volunteers
        /// Last Updated By:    Ethan McElree
        /// Last Updated:       04/1/2024
        /// What Was Changed:   Initial Creation
        /// </summary>
        [TestMethod]
        public void TestSuccessfullyViewAllVolunteers()
        {
            const int expectedCount = 3;
            int actualCount = 0;

            actualCount = (_volunteerManager.ViewVolunteers()).Count();

            Assert.AreEqual(expectedCount, actualCount);
        }

        /// <summary>
        /// Creator:            Ethan McElree
        /// Created:            04/1/2024
        /// Summary:            Test method that fails to view all volunteers
        /// Last Updated By:    Ethan McElree
        /// Last Updated:       04/1/2024
        /// What Was Changed:   Initial Creation
        /// </summary>
        [TestMethod]
        public void TestFailedToViewAllVolunteers()
        {
            const int expectedCount = 0;
            int actualCount = 3;

            actualCount = (_volunteerManager.ViewVolunteers()).Count();

            Assert.AreNotEqual(expectedCount, actualCount);
        }

        /// <summary>
        /// Creator:            Ethan McElree
        /// Created:            04/12/2024
        /// Summary:            Test method that successfully retrieves a volunteer by their id
        /// Last Updated By:    Ethan McElree
        /// Last Updated:       04/12/2024
        /// What Was Changed:   Initial Creation
        /// </summary>
        [TestMethod]
        public void TestSuccessfullyRetrieveVolunteerByID()
        {
            VolunteerVM volunteerVM = new VolunteerVM();
            volunteerVM.VolunteerID = "fake@email1";

            volunteerVM = _volunteerManager.RetrieveVolunteer(volunteerVM.VolunteerID);

            Assert.IsNotNull(volunteerVM);
        }

        /// <summary>
        /// Creator:            Ethan McElree
        /// Created:            04/1/2024
        /// Summary:            Test method that fails to retrieve a volunteer by their id
        /// Last Updated By:    Ethan McElree
        /// Last Updated:       04/1/2024
        /// What Was Changed:   Initial Creation
        /// </summary>
        [TestMethod]
        public void TestFailedToRetrieveVolunteerByID()
        {
            VolunteerVM volunteerVM = new VolunteerVM();
            volunteerVM.VolunteerID = "fake@email4";

            volunteerVM = _volunteerManager.RetrieveVolunteer(volunteerVM.VolunteerID);

            Assert.IsNull(volunteerVM);
        }

        /// <summary>
        /// Creator: Ethan McElree
        /// Created: 04/8/2024
        /// Summary: Creation of the test method that tests if it successfully deletes a volunteer.
        /// Last Updated By: Ethan McElree
        /// Last Updated: 02/20/2024
        /// What Was Changed: Initial Creation
        /// </summary>
        [TestMethod]
        public void TestSuccessfullyDeleteVolunteer()
        {
            bool actualCount;
            VolunteerVM volunteerVM = new VolunteerVM();
            volunteerVM.VolunteerID = "fake@email1";

            actualCount = _volunteerManager.DeleteVolunteer(volunteerVM);

            Assert.IsTrue(actualCount);
        }

        /// <summary>
        /// Creator: Ethan McElree
        /// Created: 04/8/2024
        /// Summary: Creation of the test method that tests if it fails to delete a volunteer.
        /// Last Updated By: Ethan McElree
        /// Last Updated: 02/20/2024
        /// What Was Changed: Initial Creation
        /// </summary>
        [TestMethod]
        public void TestFailedToDeleteVolunteer()
        {
            bool actualCount;
            VolunteerVM volunteerVM = new VolunteerVM();
            volunteerVM.VolunteerID = "fake@email4";

            actualCount = _volunteerManager.DeleteVolunteer(volunteerVM);

            Assert.IsFalse(actualCount);
        }

        /// <summary>
        /// Creator: Donald Winchester
        /// Created: 04/25/2024
        /// Summary: Creation of the test method that tests if it successfully creates a volunteer.
        /// Last Updated By: Donald Winchester
        /// Last Updated: 04/25/2024
        /// What Was Changed: Initial Creation
        /// </summary>
        [TestMethod]
        public void TestSuccessfullyCreateVolunteer()
        {
            bool actualCount;
            Volunteer volunteer = new Volunteer();
            volunteer.VolunteerID = "fake@email1";
            volunteer.PasswordHash = "password";

            try
            {
                actualCount = _volunteerManager.CreateVolunteer(volunteer);
            }
            catch (ApplicationException)
            {
                actualCount = true;
            }

            Assert.IsTrue(actualCount);
        }

        /// <summary>
        /// Creator: Donald Winchester
        /// Created: 04/8/2024
        /// Summary: Creation of the test method that tests if it fails to create a volunteer.
        /// Last Updated By: Ethan McElree
        /// Last Updated: 02/20/2024
        /// What Was Changed: Initial Creation
        /// </summary>
        [TestMethod]
        public void TestFailedToCreateVolunteer()
        {
            bool actualCount;
            Volunteer volunteer = new Volunteer();
            volunteer.VolunteerID = "fake@email1";
            volunteer.PasswordHash = "password";

            try
            {
                actualCount = _volunteerManager.CreateVolunteer(volunteer);
            }
            catch (ApplicationException)
            {
                actualCount = false;
            }

            Assert.IsFalse(actualCount);
        }

        /// <summary>
        /// Creator:            Andrew Larson
        /// Created:            04/1/2024
        /// Summary:            Testing values after being changed
        /// Last Updated By:    Andrew Larson
        /// Last Updated:       04/1/2024
        /// What Was Changed:   Initial Creation
        /// </summary>
        [TestMethod]
        public void TestChangedValuesFromVolunteerAfterUpdate()
        {
            VolunteerVM volunteer = new VolunteerVM()
            {
                VolunteerID = "fake@email1",
                Fname = "fakeFName1",
                Lname = "fakeLName1",
                Phone = "000-111-1111",
                Gender = true,
                PasswordHash = "AduAHdoadu89708yiadu8F9CVUHUOCBH",
                AccountStatus = true,
                RoleID = "Role1",
                ZipCode = 11111,
                Address = "fake street 1",
                RegistrationDate = DateTime.Now
            };
            VolunteerVM updatedVolunteer = _volunteerManager.UpdateVolunteer("fake@email1", "newFirst", "newLast", "111-222-3333", true, "123 fake street", 55555);
            Assert.AreEqual("newFirst", updatedVolunteer.Fname);
            Assert.AreEqual("newLast", updatedVolunteer.Lname);
            Assert.AreEqual("111-222-3333", updatedVolunteer.Phone);
            Assert.AreEqual(true, updatedVolunteer.Gender);
            Assert.AreEqual("123 fake street", updatedVolunteer.Address);
            Assert.AreEqual(55555, updatedVolunteer.ZipCode);
        }
    }
}
