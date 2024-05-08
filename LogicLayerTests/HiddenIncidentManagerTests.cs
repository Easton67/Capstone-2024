using DataAccessFakes;
using LogicLayer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayerTests
{
    [TestClass()]
    public class HiddenIncidentManagerTests
    {
        private HiddenIncidentManager _hiddenIncidentManager;

        [TestInitialize]
        public void TestInit()
        {
            _hiddenIncidentManager = new HiddenIncidentManager(new HiddenIncidentFakes());
        }

        //<summary>
        //Creator: Sagan DeWald
        //Created: 2/23/2024
        //Summary: Checks that getting hidden incidents will fails when an invalid user ID is given.
        //Last Updated By: Sagan DeWald
        //Last Updated: 2/23/2024
        //What was Changed: Initial Creation
        //</summary>
        [TestMethod()]
        public void GetHiddenIncidentsByUserIdFails()
        {
            // Arrange.
            string targetUser = "";
            int hiddenIncidentCount;
            int expected = 0;

            // Act.
            try
            {
                hiddenIncidentCount = _hiddenIncidentManager.GetHiddenIncidentsByUserId(targetUser).Count();
            }
            catch
            {
                throw;
            }

            //Assert.
            Assert.AreEqual(hiddenIncidentCount, expected);
        }

        //<summary>
        //Creator: Sagan DeWald
        //Created: 2/23/2024
        //Summary: Checks that getting hidden incidents will work when a correct user ID is given.
        //Last Updated By: Sagan DeWald
        //Last Updated: 2/23/2024
        //What was Changed: Initial Creation
        //</summary>
        [TestMethod()]
        public void GetHiddenIncidentsByUserIdPasses()
        {
            // Arrange.
            string targetUser = "john@company.com";
            Exception exception = null;

            // Act.
            try
            {
                _hiddenIncidentManager.GetHiddenIncidentsByUserId(targetUser);
            }
            catch (Exception e)
            {
                exception = e;
            }

            //Assert.
            Assert.IsNull(exception);

        }

        //<summary>
        //Creator: Sagan DeWald
        //Created: 2/23/2024
        //Summary: Checks that adding a hidden incident to the database will fail when an invalid incident ID is given.
        //Last Updated By: Sagan DeWald
        //Last Updated: 2/23/2024
        //What was Changed: Initial Creation
        //</summary>
        [TestMethod()]
        public void AddHiddenIncidentFails()
        {
            // Arrange.
            string userId = "john@company.com";
            int incidentId = -1;
            Exception exception = null;

            // Act.
            try
            {
                _hiddenIncidentManager.AddHiddenIncident(userId, incidentId);
            }
            catch (Exception e)
            {
                exception = e;
            }

            //Assert.
            Assert.IsNotNull(exception);
        }

        //<summary>
        //Creator: Sagan DeWald
        //Created: 2/23/2024
        //Summary: Checks that adding a hidden incident to the database will work when a correct incident ID is given.
        //Last Updated By: Sagan DeWald
        //Last Updated: 2/23/2024
        //What was Changed: Initial Creation
        //</summary>
        [TestMethod()]
        public void AddHiddenIncidentPasses()
        {
            // Arrange.
            string userId = "john@company.com";
            int incidentId = 100000;
            Exception exception = null;

            // Act.
            try
            {
                _hiddenIncidentManager.AddHiddenIncident(userId, incidentId);
            }
            catch (Exception e)
            {
                exception = e;
            }

            //Assert.
            Assert.IsNull(exception);
        }
    }
}
