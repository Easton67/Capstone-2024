using LogicLayer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using DataAccessFakes;
using System.Collections.Generic;
using DataObjects;

namespace LogicLayerTests
{
    [TestClass]
    public class IncidentManagerTests
    {
        private IIncidentManager _incidentManager;

        
        /// <summary>
        /// Creator:            Darryl Shirley
        /// Created:            02/21/2024
        /// Summary:            Create TestSetUp method
        /// Last Updated By:    Darryl Shirley
        /// Last Updated:       02/21/2024
        /// What Was Changed:   Initial creation  
        /// </summary>

        [TestInitialize]
        public void TestSetUp()
        {
            _incidentManager= new IncidentManager(new IncidentAccessorFakes());
        }

        
        /// <summary>
        /// Creator:            Darryl Shirley
        /// Created:            02/21/2024
        /// Summary:            Create TestAddIncidentMethod
        /// Last Updated By:    Darryl Shirley
        /// Last Updated:       02/21/2024
        /// What Was Changed:   Initial creation  
        /// </summary>

        [TestMethod]
        public void TestAddIncidentMethod()
        {
            string description = "Johnny kicked a soccer ball through a window on east hall";
            string reported = "John Doe";
            string reportedBy = "john@company.com";
            int severity = 3;
            int expectedCount = 5;
            int actualCount = 4;

            if(_incidentManager.AddIncident(description, reported, reportedBy, severity) == true)
            {
                actualCount++; 
            }

            Assert.AreEqual(expectedCount, actualCount);
        }

        /// <summary>
        /// Creator:            Liam Easton
        /// Created:            02/27/2024
        /// Summary:            Creation of TestGetAllIncidentsWorkCorrectly method
        /// Last Updated By:    Liam Easton
        /// Last Updated:       02/27/2024
        /// What Was Changed:   Creation of TestGetAllIncidentsWorkCorrectly method
        /// </summary>
        [TestMethod]
        public void TestGetAllIncidentsWorkCorrectly()
        {
            int expectedIncidents = 4;
            int actualIncidents = 0;

            actualIncidents = _incidentManager.SelectAllIncidents().Count;

            Assert.AreEqual(expectedIncidents, actualIncidents);
        }

        /// <summary>
        /// Creator:            Andrew Larson
        /// Created:            03/03/2024
        /// Summary:            Creation of TestGetCurrentLoggedInEmployeeIncidentsByReportedByWorksCorrectly method
        /// Last Updated By:    Andrew Larson
        /// Last Updated:       03/03/2024
        /// What Was Changed:   Initial Creation
        /// </summary>
        [TestMethod]
        public void TestGetCurrentLoggedInEmployeeIncidentsByReportedByWorksCorrectly()
        {
            int expectedIncidentID = 1;
            string expectedDescription = "Carl pooped on the hallway floor in front of the children.";
            string expectedIncidentStatus = "unread";
            string expectedReported = "Sarah mcAlistor";
            string expectedReportedBy = "sarah@gmail.com";
            string expectedFeedback = null;
            int expectedSeverity = 1;

            List<Incident> actualIncident = _incidentManager.GetCurrentUserIncidents(expectedReportedBy);

            Assert.AreEqual(expectedIncidentID, actualIncident[0].incidentID);
            Assert.AreEqual(expectedDescription, actualIncident[0].description);
            Assert.AreEqual(expectedIncidentStatus, actualIncident[0].incidentStatus);
            Assert.AreEqual(expectedReported, actualIncident[0].reported);
            Assert.AreEqual(expectedReportedBy, actualIncident[0].reportedBy);
            Assert.AreEqual(expectedFeedback, actualIncident[0].feedBack);
            Assert.AreEqual(expectedSeverity, actualIncident[0].severity);
        }

        /// <summary>
        /// Creator:            Andrew Larson
        /// Created:            03/03/2024
        /// Summary:            Creation of TestGetCurrentLoggedInEmployeeIncidentsByReportedByReturnsNothingWithBadInput method
        /// Last Updated By:    Andrew Larson
        /// Last Updated:       03/03/2024
        /// What Was Changed:   Creation of TestGetCurrentLoggedInEmployeeIncidentsByReportedByReturnsNothingWithBadInput method
        /// </summary>
        [TestMethod]
        public void TestGetCurrentLoggedInEmployeeIncidentsByReportedByReturnsNothingWithBadInput()
        {
            int expectedCount = 0;

            List<Incident> actualIncident = _incidentManager.GetCurrentUserIncidents("NotAValidEmail@fake.com");
            int actualCount = actualIncident.Count;

            Assert.AreEqual(expectedCount, actualCount);
        }
    }
}
