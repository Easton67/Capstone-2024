using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using LogicLayer;
using DataAccessFakes;
using DataObjects;

namespace LogicLayerTests
{
    /// <summary>
    /// Summary description for VolunteerQuestionnaireTests
    /// </summary>
    [TestClass]
    public class VolunteerQuestionnaireTests
    {
        private IVolunteerQuestionnaireManager _volunteerQuestionnaireManager;

        [TestInitialize]
        public void TestSetUp()
        {
            _volunteerQuestionnaireManager = new VolunteerQuestionnaireManager(new VolunteerQuestionnaireAccessorFakes());
        }


        /// <summary>
        /// Creator: Darryl Shirley
        /// created: 04/17/2024
        /// Summary: TestToCreateAVolunteerQuestionnaire method
        /// Last updated By: Darryl Shirley
        /// Last Updated: 4/17/2024
        /// What was changed/updated: intial creation
        /// </summary>
        [TestMethod]
        public void TestToCreateAVolunteerQuestionnaire()
        {
            List<VolunteerQuestionnaire> questionnaires = _volunteerQuestionnaireManager.GetVolunteerQuestionnaires();
            int expected = 4;
            int actual = questionnaires.Count;
            if (_volunteerQuestionnaireManager.addVolunteerQuestionnaire("jimmy@yahoo.com", "Cooking and cleaning", "no driver's license", false, false, "n/a", true) == true)
            {
                actual = questionnaires.Count;
            }
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Creator: Darryl Shirley
        /// created: 04/17/2024
        /// Summary: TestToGetTheCorrectVolunteerQuestionnaireByID method
        /// Last updated By: Darryl Shirley
        /// Last Updated: 4/17/2024
        /// What was changed/updated: intial creation
        /// </summary>
        [TestMethod]
        public void TestToGetTheCorrectVolunteerQuestionnaireByID()
        {
            string expectedSkillList = "Stock market manipulation";
            string volunteerID = "christine@hotmail.com";
            VolunteerQuestionnaire actual = null;
            actual = _volunteerQuestionnaireManager.getVolunteerQuestionnaireByID(volunteerID);
            Assert.AreEqual(expectedSkillList, actual.skillList);
        }

        /// <summary>
        /// Creator: Darryl Shirley
        /// created: 04/17/2024
        /// Summary: TestToGetListOfVolunteerQuestionnaires method
        /// Last updated By: Darryl Shirley
        /// Last Updated: 4/17/2024
        /// What was changed/updated: intial creation
        /// </summary>
        [TestMethod]
        public void TestToGetListOfVolunteerQuestionnaires()
        {
            int expected = 3;
            int actual = 0;
            actual = _volunteerQuestionnaireManager.GetVolunteerQuestionnaires().Count;
            Assert.AreEqual(expected, actual);
        }
        
        
    }
}
