using DataAccessInterfaces;
using DataObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessFakes
{
    public class VolunteerQuestionnaireAccessorFakes : IVolunteerQuestionnaireAccessor
    {
        List<Volunteer> fakeVolunteers = new List<Volunteer>();
        private List<VolunteerQuestionnaire> fakeVolunteerQuestionnaires = new List<VolunteerQuestionnaire> { };

        /// <summary>
        /// Creator: Darryl Shirley
        /// created: 04/17/2024
        /// Summary: VolunteerQuestionnaireAccessorFakes constructor
        /// Last updated By: Darryl Shirley
        /// Last Updated: 4/17/2024
        /// What was changed/updated: intial creation
        /// </summary>
        public VolunteerQuestionnaireAccessorFakes() 
        {
            fakeVolunteers.Add(new Volunteer() { UserID = "tested@test.com", FirstName = "vol1", LastName = "vollast", RegistrationDate = DateTime.Now, Roles = new List<Role>() { new Role() { RoleID = "CEO", Description = "TEST" } } });
            fakeVolunteers.Add(new Volunteer() { UserID = "testing@test.com", FirstName = "vol2", LastName = "vollast", RegistrationDate = DateTime.Now, Roles = new List<Role>() { new Role() { RoleID = "CEO", Description = "TEST" } } });
            fakeVolunteers.Add(new Volunteer() { UserID = "tommy@gmail.com", FirstName = "Tommy", LastName = "Pickles", RegistrationDate = DateTime.Now, Roles = new List<Role>() { new Role() { RoleID = "CEO", Description = "TEST" } } });
            fakeVolunteers.Add(new Volunteer() { UserID = "christine@hotmail.com", FirstName = "Christine", LastName = "Annatol", RegistrationDate = DateTime.Now, Roles = new List<Role>() { new Role() { RoleID = "CEO", Description = "TEST" } } });
            fakeVolunteers.Add(new Volunteer() { UserID = "jimmy@yahoo.com", FirstName = "Jimmy", LastName = "tomboy", RegistrationDate = DateTime.Now, Roles = new List<Role>() { new Role() { RoleID = "CEO", Description = "TEST" } } });

            fakeVolunteerQuestionnaires.Add(new VolunteerQuestionnaire
            {
                QuestionnaireID = 1,
                volunteerID = "tested@test.com",
                skillList = "Heavy Lifting",
                Vehicles = "Drives a Chevy Tahoe",
                PriorExperience = false,
                StudentCheck = true,
                SchoolName = "Kirkwood Community College",
                GroupWork = true,
                DateApplied= DateTime.Now

            });

            fakeVolunteerQuestionnaires.Add(new VolunteerQuestionnaire
            {
                QuestionnaireID = 2,
                volunteerID = "testing@test.com",
                skillList = "forklift certified",
                Vehicles = "N/A",
                PriorExperience = true,
                StudentCheck = false,
                SchoolName = "N/A",
                GroupWork = true,
                DateApplied = DateTime.Now

            });

            fakeVolunteerQuestionnaires.Add(new VolunteerQuestionnaire
            {
                QuestionnaireID = 3,
                volunteerID = "christine@hotmail.com",
                skillList = "Stock market manipulation",
                Vehicles = "N/A",
                PriorExperience = true,
                StudentCheck = true,
                SchoolName = "Trump University",
                GroupWork = false,
                DateApplied = DateTime.Now

            });


        }

        /// <summary>
        /// Creator: Darryl Shirley
        /// created: 04/17/2024
        /// Summary: createVolunteerQuestionnaire method
        /// Last updated By: Darryl Shirley
        /// Last Updated: 4/17/2024
        /// What was changed/updated: intial creation
        /// </summary>
        public int createVolunteerQuestionnaire(string volunteerID, string skillList, string vehicles, bool priorExperience, bool studentCheck, string schoolName, bool groupWork)
        {
            int rows = 0;
            try
            {
                List<Volunteer> volunteers = fakeVolunteers;
                foreach (Volunteer vol in volunteers)
                {
                    if (vol.UserID.Equals(volunteerID))
                    {
                        fakeVolunteerQuestionnaires.Add(new VolunteerQuestionnaire
                        {
                            volunteerID = volunteerID,
                            skillList = skillList,
                            Vehicles = vehicles,
                            PriorExperience = priorExperience,
                            StudentCheck = studentCheck,
                            SchoolName = schoolName,
                            GroupWork = groupWork,
                        });

                        rows = 1;
                    }
                }
                rows = 1;
            }
            catch(Exception ex)
            {
                throw ex;
            }

            return rows;
        }

        /// <summary>
        /// Creator: Darryl Shirley
        /// created: 04/17/2024
        /// Summary: SelectAllVolunteerQuestionnaires method
        /// Last updated By: Darryl Shirley
        /// Last Updated: 4/17/2024
        /// What was changed/updated: intial creation
        /// </summary>
        public List<VolunteerQuestionnaire> SelectAllVolunteerQuestionnaires()
        {
            List<VolunteerQuestionnaire> volunteerQuestionnaires = new List<VolunteerQuestionnaire>();
            try
            {
                volunteerQuestionnaires = fakeVolunteerQuestionnaires;
            }

            catch (Exception ex) { throw ex; }

            return volunteerQuestionnaires;
        }

        /// <summary>
        /// Creator: Darryl Shirley
        /// created: 04/17/2024
        /// Summary: SelectVolunteerQuestionnaireByID method
        /// Last updated By: Darryl Shirley
        /// Last Updated: 4/17/2024
        /// What was changed/updated: intial creation
        /// </summary>
        public VolunteerQuestionnaire SelectVolunteerQuestionnaireByID(string volunteerID)
        {
            VolunteerQuestionnaire volunteerQuestionnaire= null;
            try
            {
                List<VolunteerQuestionnaire> volunteerQuestionnaires = fakeVolunteerQuestionnaires;
                foreach (VolunteerQuestionnaire vol in volunteerQuestionnaires)
                {
                    if (vol.volunteerID.Equals(volunteerID))
                    {
                        volunteerQuestionnaire = vol;
                    }
                }
            }
            catch(Exception ex) { throw ex; }
            return volunteerQuestionnaire;
            
        }
    }
}
