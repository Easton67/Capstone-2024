using DataAccessFakes;
using DataObjects;
using LogicLayer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Runtime.Remoting.Metadata.W3cXsd2001;

namespace LogicLayerTests {
    /// <summary>
    /// Creator: Jared Harvey
    /// Created: 03/02/2024
    /// Summary: Test class for StayManager
    /// Last Updated By: Jared Harvey
    /// Last Updated: 03/02/2024
    /// What Was Changed: Initial Creation
    /// </summary>
    [TestClass]
    public class StayManagerTests {
        private StayManager _stayManager = null;

        [TestInitialize]
        public void TestSetup() {
            _stayManager = new StayManager(new StayAccessorFakes());
        }

        /// <summary>
        /// Creator: Jared Harvey
        /// Created: 03/02/2024
        /// Summary: This method tests the AddStay manager method
        /// Last Updated By: Jared Harvey
        /// Last Updated: 03/02/2024
        /// What Was Changed: Initial Creation
        /// </summary>
        [TestMethod]
        public void TestAddStay() {
            string clientID = "barrack-obama@whitehouse.org";
            int roomID = 100000;
            bool expected = true;
            bool actual = false;

            actual = _stayManager.AddStay(clientID, roomID);

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Creator: Jared Harvey
        /// Created: 03/03/2024
        /// Summary: This method tests the EditStay manager method
        /// Last Updated By: Jared Harvey
        /// Last Updated: 03/03/2024
        /// What Was Changed: Initial Creation
        /// </summary>
        [TestMethod]
        public void TestEditStay() {
            StayVM oldStay = new StayVM() {
                StayID = 100000,
                ClientID = "tess@company.com",
                RoomID = 100000,
                InDate = DateTime.Now,
                OutDate = DateTime.Now.AddDays(1),
                CheckedOut = false
            };
            StayVM newStay = new StayVM() {
                StayID = 100000,
                ClientID = "tess@company.com",
                RoomID = 100001,
                InDate = DateTime.Now,
                OutDate = DateTime.Now.AddDays(1),
                CheckedOut = false
            };
            bool expected = true;
            bool actual = false;

            actual = _stayManager.EditStay(oldStay, newStay);

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Creator: Jared Harvey
        /// Created: 03/03/2024
        /// Summary: This method tests the RemoveStay method
        /// Last Updated By: Jared Harvey
        /// Last Updated: 03/03/2024
        /// What Was Changed: Initial Creation
        /// </summary>
        [TestMethod]
        public void TestDeleteStay() {
            int stayID = 100000;
            bool expected = true;
            bool actual = false;

            actual = _stayManager.RemoveStay(stayID);

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Creator: Jared Harvey
        /// Created: 03/22/2024
        /// Summary: This method tests the TestGetStay method
        /// Last Updated By: Jared Harvey
        /// Last Updated: 03/22/2024
        /// What Was Changed: Initial Creation
        /// </summary>
        [TestMethod]
        public void TestGetStay() {
            int stayID = 100000;
            bool expected = true;
            bool actual = false;

            actual = _stayManager.GetStay(stayID).StayID == stayID;

            Assert.AreEqual(expected, actual);
        }
    }
}
