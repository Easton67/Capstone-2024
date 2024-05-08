using DataAccessInterfaces;
using DataAccessLayer;
using DataObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer
{
    public class VolunteerQuestionnaireManager : IVolunteerQuestionnaireManager
    {
        private IVolunteerQuestionnaireAccessor _volunteerQuestionnaireAccessor;

        public VolunteerQuestionnaireManager()
        {
            _volunteerQuestionnaireAccessor = new VolunteerQuestionnaireAccessor();
        }

        public VolunteerQuestionnaireManager(IVolunteerQuestionnaireAccessor volunteerQuestionnaireAccessor)
        {
            _volunteerQuestionnaireAccessor = volunteerQuestionnaireAccessor;
        }

        /// <summary>
        /// Creator: Darryl Shirley
        /// created: 04/17/2024
        /// Summary: addVolunteerQuestionnaire method
        /// Last updated By: Darryl Shirley
        /// Last Updated: 4/17/2024
        /// What was changed/updated: intial creation
        /// </summary>
        public bool addVolunteerQuestionnaire(string volunteerID, string skillList, string vehicles, bool priorExperience, bool studentCheck, string schoolName, bool groupWork)
        {
            bool result = false;

            try
            {
                if (_volunteerQuestionnaireAccessor.createVolunteerQuestionnaire(volunteerID, skillList, vehicles, priorExperience, studentCheck, schoolName, groupWork) == 1)
                {
                    result = true;
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Volunteer Questionnaire not created", ex);
            }

            return result;
        }

        /// <summary>
        /// Creator: Darryl Shirley
        /// created: 04/17/2024
        /// Summary: getVolunteerQuestionnaireByID method
        /// Last updated By: Darryl Shirley
        /// Last Updated: 4/17/2024
        /// What was changed/updated: intial creation
        /// </summary>
        public VolunteerQuestionnaire getVolunteerQuestionnaireByID(string volunteerID)
        {
            VolunteerQuestionnaire questionnaire = null;
            try
            {
                questionnaire = _volunteerQuestionnaireAccessor.SelectVolunteerQuestionnaireByID(volunteerID);
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message, ex);
            }
            return questionnaire;
        }

        /// <summary>
        /// Creator: Darryl Shirley
        /// created: 04/17/2024
        /// Summary: GetVolunteerQuestionnaires method
        /// Last updated By: Darryl Shirley
        /// Last Updated: 4/17/2024
        /// What was changed/updated: intial creation
        /// </summary>
        public List<VolunteerQuestionnaire> GetVolunteerQuestionnaires()
        {
            List<VolunteerQuestionnaire> questionnaires = new List<VolunteerQuestionnaire>();
            try
            {
                questionnaires = _volunteerQuestionnaireAccessor.SelectAllVolunteerQuestionnaires();
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message, ex);
            }
            return questionnaires;
        }
    }
}
