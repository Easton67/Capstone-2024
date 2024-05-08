using DataObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer
{
    public interface IVolunteerQuestionnaireManager
    {
        VolunteerQuestionnaire getVolunteerQuestionnaireByID(string volunteerID);
        List<VolunteerQuestionnaire> GetVolunteerQuestionnaires();
        bool addVolunteerQuestionnaire(string volunteerID, string skillList, string vehicles, bool priorExperience, bool studentCheck, string schoolName, bool groupWork);
    }
}
