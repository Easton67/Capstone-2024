using DataObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessInterfaces
{
    public interface IVolunteerQuestionnaireAccessor
    {
        VolunteerQuestionnaire SelectVolunteerQuestionnaireByID(string volunteerID);
        List<VolunteerQuestionnaire> SelectAllVolunteerQuestionnaires();
        int createVolunteerQuestionnaire(string volunteerID, string skillList, string vehicles, bool priorExperience, bool studentCheck, string schoolName, bool groupWork);
    }
}
