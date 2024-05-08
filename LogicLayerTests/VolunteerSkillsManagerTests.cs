using DataAccessFakes;
using LogicLayer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace LogicLayerTests
{
    /// <summary>
    /// Creator: Darryl Shirley
    /// created: 04/04/2024
    /// Summary: VolunteerSkillsManagerTests.cs 
    /// Last updated By: Darryl Shirley
    /// Last Updated: 4/04/2024
    /// What was changed/updated: intial creation
    /// </summary>
    [TestClass]
    public class VolunteerSkillsManagerTests
    {
        private IVolunteerSkillManager _volunteerSkillManager = null;

        [TestInitialize]
        public void TestSetUp()
        {
            _volunteerSkillManager = new LogicLayer.VolunteerSkillManager(new VolunteerSkillAccessorFakes());
        }

        /// <summary>
        /// Creator: Darryl Shirley
        /// created: 04/04/2024
        /// Summary: TestfordeletionOfVolunteerSKills method
        /// Last updated By: Darryl Shirley
        /// Last Updated: 4/04/2024
        /// What was changed/updated: intial creation
        /// </summary>
        [TestMethod]
        public void TestfordeletionOfVolunteerSKills()
        {
            int expectCount = 3;
            string volunteerID = "tommy@gmail.com";
            int skillID = 1;


            int actualCount = 0;

            if(_volunteerSkillManager.RemoveVolunteerSkill(volunteerID, skillID) == true)
            {
                actualCount = 3;
            }

            Assert.AreEqual(expectCount, actualCount);
        }

        /// <summary>
        /// Creator: Darryl Shirley
        /// created: 04/04/2024
        /// Summary: TestforCreatingNewVolunteerSKills method 
        /// Last updated By: Darryl Shirley
        /// Last Updated: 4/04/2024
        /// What was changed/updated: intial creation
        /// </summary>
        [TestMethod]
        public void TestforCreatingNewVolunteerSKills()
        {
            int expectCount = 3;
            string volunteerID = "tommy@gmail.com";
            int skillID = 2;


            int actualCount = 0;

            if (_volunteerSkillManager.AddVolunteerSkill(volunteerID, skillID) == true)
            {
                actualCount = 3;
            }

            Assert.AreEqual(expectCount, actualCount);
        }

        /// <summary>
        /// Creator: Darryl Shirley
        /// created: 04/04/2024
        /// Summary: TestForGettingTheSkillsAlreadyAssigned method
        /// Last updated By: Darryl Shirley
        /// Last Updated: 4/04/2024
        /// What was changed/updated: intial creation
        /// </summary>
        [TestMethod]
        public void TestForGettingTheSkillsAlreadyAssigned()
        {
            int expectedCount = 2;
            string volunteerID = "tommy@gmail.com";
            int actualCount = 0;

            actualCount = _volunteerSkillManager.GetAssignedSkills(volunteerID).Count;

            Assert.AreEqual(expectedCount, actualCount);
        }

        /// <summary>
        /// Creator: Darryl Shirley
        /// created: 04/04/2024
        /// Summary: TestForGettingTheSkillsThatAreNotAssigned method 
        /// Last updated By: Darryl Shirley
        /// Last Updated: 4/04/2024
        /// What was changed/updated: intial creation
        /// </summary>
        [TestMethod]
        public void TestForGettingTheSkillsThatAreNotAssigned()
        {
            int expectedCount = 2;
            string volunteerID = "tommy@gmail.com";
            int actualCount = 0;

            actualCount= _volunteerSkillManager.GetUnAssignedSkills(volunteerID).Count;

            Assert.AreEqual(expectedCount, actualCount);
        }
    }
}
