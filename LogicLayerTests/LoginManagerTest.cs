using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using LogicLayer;
using DataAccessInterfaces;
using DataAccessFakes;
using DataObjects;

namespace LogicLayerTests
{
    [TestClass]

    /// <summary>
    /// Creator: Miyada Abas         
    /// Created: 02/27/2024
    /// Summary: TestSingnUp for login manager
    /// Last Updated By: Miyada Abas
    /// Last Updated: 02/27/2024
    /// What Was Changed: Added StayManager
    /// </summary>
    public class LoginManagerTest
    {
        private LoginAccessorInterFace loginAccessorFake = new LoginAccessorFake();
        private LoginManger loginManger;
        [TestInitialize]
        public void SetUp () {
            loginManger = new LoginManger(loginAccessorFake);
        }
        [TestMethod]

        /// <summary>
        /// Creator: Miyada Abas         
        /// Created: 02/27/2024
        /// Summary: TestSingnUp for login manager
        /// Last Updated By: Tyler Barz
        /// Last Updated: 03/05/2024
        /// What Was Changed: Changed properties to match User class
        /// </summary>
        public void TestSignUp()
        {
            EmployeePass employee = new EmployeePass();
            employee.EmployeeID = "1";
            employee.StartDate = DateTime.Now;
            employee.AccountStatus = true;
            employee.Address = "test";
            employee.Gender = true;
            employee.EndDate = DateTime.Now;
            employee.FirstName = "test";
            employee.LastName = "test";
            employee.ZipCode = 1;
            bool result = loginManger.SignUp(employee);
            Assert.IsTrue(result);
        }
    }
}
