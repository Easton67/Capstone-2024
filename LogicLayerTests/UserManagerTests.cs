using LogicLayer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataAccessFakes;
using DataObjects;
using System;
using static DataObjects.Enums;
using System.Linq;
using System.Collections.Generic;

namespace LogicLayerTests
{
    /// <summary>
    /// Creator:            Tyler Barz
    /// Created:            02/14/2024
    /// Summary:            Tests for user manager
    /// Last Updated By:    Tyler Barz
    /// Last Updated:       02/14/2024
    /// What Was Changed:   Inital creation
    /// </summary>
    [TestClass]
    public class UserManagerTests
    {
        private UserManager _userManager;

        [TestInitialize]
        public void TestInit()
        {
            _userManager = new UserManager(new UserAccessFakes());
        }

        #region [TestMethod] Return Client,Employee,Volunteer user types
        /// <summary>
        /// Creator:            Tyler Barz
        /// Created:            02/14/2024
        /// Summary:            Tests for returning correct user type
        /// Last Updated By:    Tyler Barz
        /// Last Updated:       02/14/2024
        /// What Was Changed:   Inital Creation
        /// </summary>
        [TestMethod]
        public void TestReturnsClientUserType()
        {
            Assert.IsTrue(_userManager.SelectClientByID("test@test.com").UserType == "Client");
        }

        /// <summary>
        /// Creator:            Tyler Barz
        /// Created:            02/14/2024
        /// Summary:            Tests for returning correct user type
        /// Last Updated By:    Tyler Barz
        /// Last Updated:       02/14/2024
        /// What Was Changed:   Inital Creation
        /// </summary>
        [TestMethod]
        public void TestReturnsEmployeeUserType()
        {
            Assert.IsTrue(_userManager.SelectEmployeeByID("testee@test.com").UserType == "Employee");
        }

        /// <summary>
        /// Creator:            Tyler Barz
        /// Created:            02/14/2024
        /// Summary:            Tests for returning correct user type
        /// Last Updated By:    Tyler Barz
        /// Last Updated:       02/14/2024
        /// What Was Changed:   Inital Creation
        /// </summary>
        [TestMethod]
        public void TestReturnsVolunteerUserType()
        {
            Assert.IsTrue(_userManager.SelectVolunteerByID("tested@test.com").UserType == "Volunteer");
        }

        /// <summary>
        /// Creator:            Tyler Barz
        /// Created:            02/14/2024
        /// Summary:            Tests for returning correct user type
        /// Last Updated By:    Tyler Barz
        /// Last Updated:       02/25/2024
        /// What Was Changed:   Fixed returned user type, and exception type
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestReturnsInvalidUser()
        {
            Assert.IsTrue(_userManager.SelectClientByID("incorrect user").UserType == "Undefined User Type");
        }
        #endregion

        #region Commented-out client tests
        //<summary>
        //Creator: Sagan DeWald
        //Created: 2/08/2024
        //Summary: Checks that client authentication will fail when given an incorrect password.
        //Last Updated By: Tyler Barz
        //Last Updated: 02/23/2024
        //What was Changed: Commented out since we aren't needing client data currently
        //</summary>
        //[TestMethod]
        //public void UserManagerClientAuthenticationPasswordHashFails()
        //{
        //    // Arrange.
        //    string userName = "newuser@gmail.com";
        //    string password = "badpassword";
        //    AuthenticationType expected = AuthenticationType.Client;
        //    UserManager userManager = new UserManager(withFakes:true);

        //    // Act.
        //    AuthenticationType actual = userManager.AuthenticateUser(userName, password);

        //    //Assert.
        //    Assert.AreEqual(expected, actual);
        //}

        //<summary>
        //Creator: Sagan DeWald
        //Created: 2/08/2024
        //Summary: Checks that client authentication will succeed when given a valid name and password.
        //Last Updated By: Tyler Barz
        //Last Updated: 02/23/2024
        //What was Changed: Commented out since we aren't dealing with client authentication yet.
        //</summary>
        //[TestMethod]
        //public void UserManagerClientAuthenticationPasswordHashPasses()
        //{
        //    // Arrange.
        //    //TODO: The test records for Client include password hashes that aren't actually hashes. Bad, needs fixed, used a custom script to make this pass.
        //    string userName = "newuser@gmail.com";
        //    string password = "newuser";
        //    AuthenticationType expected = AuthenticationType.;
        //    UserManager userManager = new UserManager(withFakes: true);

        //    // Act.
        //    bool actual = (1 == userManager.AuthenticateUser(userName, password));

        //    //Assert.
        //    Assert.AreEqual(expected, actual);
        //} 
        #endregion

        /// <summary>
        /// Creator: Sagan DeWald
        /// Created: 2/08/2024
        /// Summary: Checks that employee authentication will fail when given an incorrect password.
        /// Last Updated By: Tyler Barz
        /// Last Updated: 2/08/2024
        /// What was Changed: Initial Creation
        /// </summary>
        [TestMethod]
        public void UserManagerEmployeeAuthenticationPasswordHashFails()
        {
            // Arrange.
            string userName = "olduser@gmail.com";
            string password = "badpassword";
            AuthenticationType expected = AuthenticationType.Unauthorized;
            // Act.
            AuthenticationType actual = _userManager.AuthenticateUser(userName, password);

            //Assert.
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Creator: Sagan DeWald
        /// Created: 2/08/2024
        /// Summary: Checks that employee authentication succeeds when given a valid name and password.
        /// Last Updated By: Tyler Barz
        /// Last Updated: 2/25/2024
        /// What was Changed: Removed userManager instantiation to use the one in constructor
        /// </summary>
        [TestMethod]
        public void UserManagerEmployeeAuthenticationPasswordHashPasses()
        {
            // Arrange.
            string userName = "olduser@gmail.com";
            string password = "olduser";
            AuthenticationType expected = AuthenticationType.Employee;

            // Act.
            AuthenticationType actual = _userManager.AuthenticateUser(userName, password);

            //Assert.
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Creator: Sagan DeWald
        /// Created: 2/08/2024
        /// Summary: Checks that volunteer authentication will fail when given an incorrect password.
        /// Last Updated By: Tyler Barz
        /// Last Updated: 2/25/2024
        /// What was Changed: Removed userManager instantiation to use the one in constructor
        /// </summary>
        [TestMethod]
        public void UserManagerVolunteerAuthenticationPasswordHashFails()
        {
            // Arrange.
            string userName = "middleuser@gmail.com";
            string password = "badpassword";
            AuthenticationType expected = AuthenticationType.Unauthorized;

            // Act.
            AuthenticationType actual = _userManager.AuthenticateUser(userName, password);

            //Assert.
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Creator: Sagan DeWald
        /// Created: 2/08/2024
        /// Summary: Checks that volunteer authentication will succeed when given a valid name and password.
        /// Last Updated By: Tyler Barz
        /// Last Updated: 2/25/2024
        /// What was Changed: Removed userManager instantiation to use the one in constructor
        /// </summary>
        [TestMethod]
        public void UserManagerVolunteerAuthenticationPasswordHashPasses()
        {
            // Arrange.
            //TODO: Same problem here, test records contain plain text instead of hashes. Used a custom database script to pass.
            // Two separate people did this, it makes me unhappy.
            string userName = "middleuser@gmail.com";
            string password = "middleuser";
            AuthenticationType expected = AuthenticationType.Volunteer;

            // Act.
            AuthenticationType actual = _userManager.AuthenticateUser(userName, password);

            //Assert.
            Assert.AreEqual(expected, actual);
        }


        /// <summary>
        /// Creator:            Liam Easton
        /// Created:            01/31/2024
        /// Summary:            Creation of TestHashSha256ReturnsACorrectHashValue test
        /// Last Updated By:    Liam Easton
        /// Last Updated:       01/31/2024
        /// What Was Changed:   Creation of TestHashSha256ReturnsACorrectHashValue test
        /// </summary>
        [TestMethod]
        public void TestHashSha256ReturnsACorrectHashValue()
        {
            string testString = "newuser";
            string actualHash = "";
            string expectedHash = "9c9064c59f1ffa2e174ee754d2979be80dd30db552ec03e7e327e9b1a4bd594e";

            actualHash = _userManager.HashSha256(testString);

            Assert.AreEqual(expectedHash, actualHash);
        }

        /// <summary>
        /// Creator:            Liam Easton
        /// Created:            01/31/2024
        /// Summary:            Creation of TestUpdateEmployeePasswordHashWorksCorrectly test
        /// Last Updated By:    Liam Easton
        /// Last Updated:       01/31/2024
        /// What Was Changed:   Creation of TestUpdateEmployeePasswordHashWorksCorrectly test
        /// </summary>
        [TestMethod]
        public void TestUpdateEmployeePasswordHashWorksCorrectly()
        {
            string employeeID = "Liam@gmail.com";
            string password = "5e884898da28047151d0e56f8dc6292773603d0d6aabbdd62a11ef721d1542d8";
            string newPassword = "password";
            bool expectedResult = true;
            bool actualResult = false;

            actualResult = _userManager.UpdateEmployeePasswordHash(employeeID, password, newPassword);

            Assert.AreEqual(expectedResult, actualResult);
        }

        /// <summary>
        /// Creator:            Liam Easton
        /// Created:            01/31/2024
        /// Summary:            Creation of TestSelectEmployeePasswordHashByEmployeeIDWorksCorrectly test
        /// Last Updated By:    Liam Easton
        /// Last Updated:       01/31/2024
        /// What Was Changed:   Creation of TestSelectEmployeePasswordHashByEmployeeIDWorksCorrectly test
        /// </summary>
        [TestMethod]
        public void TestSelectEmployeePasswordHashByEmployeeIDWorksCorrectly()
        {
            string employeeID = "Liam@gmail.com";

            string expectedResult = "5e884898da28047151d0e56f8dc6292773603d0d6aabbdd62a11ef721d1542d8";
            EmployeePass actualPasswordHash = _userManager.SelectEmployeePasswordHashByEmployeeID(employeeID);

            Assert.AreEqual(expectedResult, actualPasswordHash.PasswordHash);
        }

        /// <summary>
        /// Creator:            Jared Harvey
        /// Created:            03/05/2024
		/// Summary:            TestGetAllEmployeeIDs method
        /// Last Updated By:    Jared Harvey
        /// Last Updated:       03/05/2024
        /// What Was Changed:   Initial Creation
        /// </summary>
        [TestMethod]
        public void TestGetAllClients()
        {
            int expected = 1;
            int actual = _userManager.GetAllClients().Count;

            Assert.AreEqual(expected, actual);
        }
		
		/// <summary>
        /// Creator:            Liam Easton
        /// Created:            03/04/2024
        /// Summary:            Creation of TestSelectSpecificRoleByRoleIDWorksCorrectly test
        /// Last Updated By:    Liam Easton
        /// Last Updated:       03/04/2024
        /// What Was Changed:   Creation of TestSelectSpecificRoleByRoleIDWorksCorrectly test
        /// </summary>
        [TestMethod]
        public void TestSelectSpecificRoleByRoleIDWorksCorrectly()
        {
            string RoleID = "CEO";

            int expectedResult = 4; 
            int actualResult = _userManager.SelectSpecificRoles(RoleID).Count;

            Assert.AreEqual(expectedResult, actualResult);
        }

        /// <summary>
        /// Creator:            Liam Easton
        /// Created:            03/04/2024
        /// Summary:            Creation of TestSelectSpecificRoleByRoleIDWorksCorrectly test
        /// Last Updated By:    Liam Easton
        /// Last Updated:       03/04/2024
        /// What Was Changed:   Creation of TestSelectSpecificRoleByRoleIDWorksCorrectly test
        /// </summary>
        [TestMethod]
        public void TestSelectAllRolesWorksCorrectly ()
        {
            int expectedResult = 5;
            int actualResult = _userManager.SelectAllRoles().Count;

            Assert.AreEqual(expectedResult, actualResult);
        }

        /// <summary>
        /// Creator:            Liam Easton
        /// Created:            02/27/2024
        /// Summary:            Creation of TestGetAllEmployeesReturnsCorrectly test
        /// Last Updated By:    Liam Easton
        /// Last Updated:       02/27/2024
        /// What Was Changed:   Creation of TestGetAllEmployeesReturnsCorrectly test
        /// </summary>
        [TestMethod]
        public void TestGetAllEmployeesReturnsCorrectly()
        {
            int expectedResult = 5;

            int actualResult = _userManager.SelectAllEmployees().Count();

            Assert.AreEqual(expectedResult, actualResult);
        }


        /// <summary>
        /// Creator:            Darryl Shirley
        /// Created:            02/27/2024
        /// Summary:            Creation of TestGetAllEmployeesReturnsCorrectly test
        /// Last Updated By:    Darryl Shirley
        /// Last Updated:       02/27/2024
        /// What Was Changed:   Creation of TestGetAllEmployeesReturnsCorrectly test
        /// </summary>
        [TestMethod]
        public void TestGetACorrectListOfAssignedVolunteers()
        {
            int eventID = 1;
            int expected = 2;
            int actual = 0;

            actual = _userManager.GetAllVolunteersAssignedToAnEvent(eventID).Count();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestGetACorrectListOfNonAssignedVolunteers()
        {
            int eventID = 1;
            int expected = 3;
            int actual = 0;

            actual = _userManager.GetAllVolunteersNotAssignedToAnEvent(eventID).Count();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestAddingAVolunteerToAnEvent()
        {
            int expected = 1;
            int actual = 0;
            EventAccessorFakes eventAccessorFakes = new EventAccessorFakes();

            if(_userManager.AddVolunteerToEvent("tested@test.com", 1) == true)
            {
                actual = 1;
            }
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Creator: Matthew Baccam
        /// Created: 03/21/2024
        /// Summary: Test inserts a new user into the database
        /// Last Updated By: Matthew Baccam
        /// Last Updated: 03/21/2024
        /// What Was changed: Initial creation
        /// </summary>
        [TestMethod]
        public void TestCreateNewUser()
        {
            var user = new User()
            {
                UserID = "test@test.com",
                FirstName = "test",
                LastName = "tester",
            };
            var ogCount = _userManager.SelectAllEmployees().Count;
            int newCount = 0;
            if (_userManager.CreateNewUser(user, "password"))
            {
                newCount = _userManager.SelectAllEmployees().Count;
            }
            Assert.IsTrue(ogCount < newCount);
        }

        /// <summary>
        /// Creator: Matthew Baccam
        /// Created: 03/21/2024
        /// Summary: Test email availability
        /// Last Updated By: Matthew Baccam
        /// Last Updated: 03/21/2024
        /// What Was changed: Initial creation
        /// </summary>
        [TestMethod]
        public void TestCheckEmailAvailability()
        {
            Assert.IsFalse(_userManager.EmailAvailability("test@test.com"));
        }
        /// <summary>
        /// Creator: Matthew Baccam
        /// Created: 03/15/2024
        /// Summary: Ttest updates users details
        /// Last Updated By: Matthew Baccam
        /// Last Updated: 03/15/2024
        /// What Was changed: Initial creation
        /// </summary>
        [TestMethod]
        public void TestUpdateUsersDetails()
        {
            var newClient = new Client() { UserID = "test@test.com", FirstName = "asdfasdf", LastName = "asdfasdf", RegistrationDate = DateTime.Now };
            var oldClient = _userManager.SelectClientByID(newClient.UserID);
            _userManager.UpdateUserDetails(newClient, oldClient);
            Assert.AreNotEqual(newClient, oldClient);
        }


        /// <summary>
        /// Creator: Matthew Baccam
        /// Created: 03/15/2024
        /// Summary: Test insert roles
        /// Last Updated By: Matthew Baccam
        /// Last Updated: 03/15/2024
        /// What Was changed: Initial creation
        /// </summary>
        [TestMethod]
        public void TestInsertRoles()
        {
            var rolesList = new List<Role>() {
            new Role(){
                RoleID = "asdfasdf"
            },
            new Role(){
                RoleID = "zxcvzxcv"
            }};
            Assert.IsTrue(_userManager.CreateEmployeeRoles("tester@test.com", rolesList));
        }


        /// <summary>
        /// Creator: Matthew Baccam
        /// Created: 03/15/2024
        /// Summary: Test remove roles
        /// Last Updated By: Matthew Baccam
        /// Last Updated: 03/15/2024
        /// What Was changed: Initial creation
        /// </summary>
        [TestMethod]
        public void TestRemoveRoles()
        {
            var rolesList = new List<Role>() {
            new Role(){
                RoleID = "CEO"
            } };
            Assert.IsTrue(_userManager.CreateEmployeeRoles("tester@test.com", rolesList));
        }


        /// <summary>
        /// Creator: Marwa Ibrahim
        /// Created: 03/27/2024
        /// Summary: Test Change Client Password
        /// Last Updated By: Marwa Ibrahim
        /// Last Updated: 03/27/2024
        /// What Was changed: Initial creation
        /// </summary>
        [TestMethod]
        public void TestChangeClientPassword()
        {
            bool result = _userManager.changeClientPassword("test@test.com", "test");
            Assert.IsTrue(result);
        }
    

      /// <summary>
        /// Creator: Ibrahim Albashair
        /// Created: 02/10/2024
        /// Summary: Created TestGetAllVolunteersReturnsCorrectValue
        /// Last Updated By: Ibrahim Albashair
        /// Last Updated 03/18/2024
        /// What was changed: Initial Creation.
        /// </summary>
        [TestMethod]
        public void TestGetAllVolunteersReturnsCorrectValue()
        {
            // arange
            int expectedTotal = 3;
            int actualTotal = 0;
            // act
            actualTotal = _userManager.GetAllVolunteers().Count();
            // assert
            Assert.AreEqual(expectedTotal, actualTotal);
        }
        /// <summary>
        /// Creator: Miyada Abas
        /// Created: 04/05/2024
        /// Summary: Test Deactivte Client Application
        /// Last Updated By: Miyada Abas
        /// Last Updated: 04/05/2024
        /// What Was changed: Initial creation
        /// </summary>
        [TestMethod]
        public void TestDeactivteClientApplication()
        {
            string ClientID = "test@test.com";
            Client client = new Client();
            client.UserID = ClientID;
            bool result = _userManager.DeactivateClientApplication(client);
            Assert.IsTrue(result);
        }

        /// <summary>
        /// Creator: Abdalgader Ibrahim
        /// Created: 04/18/2024
        /// Summary: Test Update Employee Password
        /// </summary>
        [TestMethod]
        public void TestUpdateEmployeePassword()
        {
            bool result = _userManager.UpdateEmployeePassword("test1@test.com", "test1");
            Assert.IsFalse(result);
        }
    }
}
