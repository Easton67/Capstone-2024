using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataObjects
{
    public class VolunteerQuestionnaire
    {
        public int QuestionnaireID { get; set; }
        public string volunteerID { get; set;}
        public string skillList { get; set; }
        public string Vehicles { get; set; }
        public bool PriorExperience { get; set; }
        public bool StudentCheck { get; set; }
        public string SchoolName { get; set; }
        public bool GroupWork { get; set; }
        public DateTime DateApplied { get; set; }
    }
}
