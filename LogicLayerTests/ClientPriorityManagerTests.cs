using Microsoft.VisualStudio.TestTools.UnitTesting;
using LogicLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessFakes;
using DataObjects;

namespace LogicLayerTests
{
    [TestClass()]
    public class ClientPriorityManagerTests
    {
        [TestMethod()]
        public void SelectAllClientPrioritiesPasses()
        {
            //Arrange.
            var clientPrioritiesAccessor = new ClientPriorityFakes();
            List<ClientPriority> clientPriorities = new List<ClientPriority>();

            //Act.
            clientPriorities = clientPrioritiesAccessor.SelectAllClientPriorities();

            //Assert.
            Assert.IsTrue(clientPriorities.Any());
        }

        [TestMethod()]
        public void UpdateClientPriorityPasses()
        {
            //Arrange.
            var clientPrioritiesAccessor = new ClientPriorityFakes();
            int clientPriorityId = 100000;
            int basePriority = 0;
            int deductions = 0;
            string notableConvictions = "";
            string otherHousingSituation = "";
            int affectedRows = 0;

            //Act.
            affectedRows = clientPrioritiesAccessor.UpdateClientPriority(clientPriorityId, basePriority, deductions, notableConvictions, otherHousingSituation);

            //Assert.
            Assert.AreEqual(affectedRows, 1);
        }

        [TestMethod()]
        public void UpdateClientPriorityFails()
        {
            //Arrange.
            var clientPrioritiesAccessor = new ClientPriorityFakes();
            int clientPriorityId = -1;
            int basePriority = 0;
            int deductions = 0;
            string notableConvictions = "";
            string otherHousingSituation = "";
            int affectedRows = 0;

            //Act.
            affectedRows = clientPrioritiesAccessor.UpdateClientPriority(clientPriorityId, basePriority, deductions, notableConvictions, otherHousingSituation);

            //Assert.
            Assert.AreEqual(affectedRows, 0);
        }

        [TestMethod()]
        public void AddClientPriorityPasses()
        {
            //Arrange.
            var clientPrioritiesAccessor = new ClientPriorityFakes();
            string clientId = "sagan@email.com";
            int basePriority = 0;
            int deductions = 0;
            string notableConvictions = "";
            string otherHousingSituation = "";
            int affectedRows = 0;

            //Act.
            affectedRows = clientPrioritiesAccessor.AddClientPriority(clientId, basePriority, deductions, notableConvictions, otherHousingSituation);

            //Assert.
            Assert.AreEqual(affectedRows, 1);
        }

        [TestMethod()]
        public void AddClientPriorityFails()
        {
            //Arrange.
            var clientPrioritiesAccessor = new ClientPriorityFakes();
            string clientId = "john.doe@email.com";
            int basePriority = 0;
            int deductions = 0;
            string notableConvictions = "";
            string otherHousingSituation = "";
            int affectedRows = 0;

            //Act.
            affectedRows = clientPrioritiesAccessor.AddClientPriority(clientId, basePriority, deductions, notableConvictions, otherHousingSituation);

            //Assert.
            Assert.AreEqual(affectedRows, 0);
        }
    }
}