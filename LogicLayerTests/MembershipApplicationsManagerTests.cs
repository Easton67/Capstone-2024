using DataAccessFakes;
using LogicLayer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace LogicLayerTests
{
    [TestClass]
    public class MembershipApplicationsManagerTests
    {
        private MembershipApplicationsManager _membershipApplicationsManager = null;

        [TestInitialize]
        public void TestSetUp()
        {
            _membershipApplicationsManager = new MembershipApplicationsManager(new MembershipApplicationsAccessorFake());
        }
        /// <summary>
        ///Creator:            Donald Winchester
        ///Created:            04/16/2024
        ///Summary:            This is the Test for the Membership Applications Logic Layer.
        ///Last Updated By:    Donald Winchester
        ///Last Updated:       04/16/2024
        ///What Was Changed:   Initial Creation
        /// </summary>
        [TestMethod]
        public void TestGetsAllApplications()
        {
            const int expectedCount = 2;
            int actualCount = 0;

            actualCount = (_membershipApplicationsManager.GetAllMembershipApplications()).Count;

            Assert.AreEqual(expectedCount, actualCount);
        }
    }
}
