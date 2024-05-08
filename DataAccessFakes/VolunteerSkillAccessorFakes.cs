using DataAccessInterfaces;
using DataObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessFakes
{
    /// <summary>
    /// Creator: Darryl Shirley
    /// created: 04/04/2024
    /// Summary: VolunteerSkillAccessorFakes.cs 
    /// Last updated By: Darryl Shirley
    /// Last Updated: 4/04/2024
    /// What was changed/updated: intial creation
    /// </summary>
    public class VolunteerSkillAccessorFakes : IVolunteerSkillAccessor
    {
        List<Volunteer> fakeVolunteers = new List<Volunteer>();
        private List<Skills> fakeSkills= new List<Skills>();
        private List<VolunteerSkills> fakeVolunteerSkills = new List<VolunteerSkills>();

        public VolunteerSkillAccessorFakes()
        {

            fakeVolunteers.Add(new Volunteer() { UserID = "tested@test.com", FirstName = "vol1", LastName = "vollast", RegistrationDate = DateTime.Now, Roles = new List<Role>() { new Role() { RoleID = "CEO", Description = "TEST" } } });
            fakeVolunteers.Add(new Volunteer() { UserID = "testing@test.com", FirstName = "vol2", LastName = "vollast", RegistrationDate = DateTime.Now, Roles = new List<Role>() { new Role() { RoleID = "CEO", Description = "TEST" } } });
            fakeVolunteers.Add(new Volunteer() { UserID = "tommy@gmail.com", FirstName = "Tommy", LastName = "Pickles", RegistrationDate = DateTime.Now, Roles = new List<Role>() { new Role() { RoleID = "CEO", Description = "TEST" } } });
            fakeVolunteers.Add(new Volunteer() { UserID = "christine@hotmail.com", FirstName = "Christine", LastName = "Annatol", RegistrationDate = DateTime.Now, Roles = new List<Role>() { new Role() { RoleID = "CEO", Description = "TEST" } } });
            fakeVolunteers.Add(new Volunteer() { UserID = "jimmy@yahoo.com", FirstName = "Jimmy", LastName = "tomboy", RegistrationDate = DateTime.Now, Roles = new List<Role>() { new Role() { RoleID = "CEO", Description = "TEST" } } });


            fakeSkills.Add(new Skills() { SkillID = 1, SkillName = "carpet cleaner" });
            fakeSkills.Add(new Skills() { SkillID = 2, SkillName = "heavy lifter" });
            fakeSkills.Add(new Skills() { SkillID = 3, SkillName = "Exercise trainer" });
            fakeSkills.Add(new Skills() { SkillID = 4, SkillName = "Vacuuming Specialist" });

            fakeVolunteerSkills.Add(new VolunteerSkills() { VolunteerID = "tommy@gmail.com", SkillID = 3 });
            fakeVolunteerSkills.Add(new VolunteerSkills() { VolunteerID = "tommy@gmail.com", SkillID = 1 });
            fakeVolunteerSkills.Add(new VolunteerSkills() { VolunteerID = "christine@hotmail.com", SkillID = 1 });
            fakeVolunteerSkills.Add(new VolunteerSkills() { VolunteerID = "jimmy@yahoo.com", SkillID = 2 });

        }

        /// <summary>
        /// Creator: Darryl Shirley
        /// created: 04/04/2024
        /// Summary: deleteSkill fake method
        /// Last updated By: Darryl Shirley
        /// Last Updated: 4/04/2024
        /// What was changed/updated: intial creation
        /// </summary>
        public int deleteSkill(string volunteerID, int skillID)
        {
            int deleted = 0;
            List<VolunteerSkills> volunteerSkills = fakeVolunteerSkills;
            List<VolunteerSkills> newList = new List<VolunteerSkills>();
            try
            {
                foreach(VolunteerSkills skills in volunteerSkills)
                {
                    if(skills.VolunteerID.Equals(volunteerID) && skills.SkillID == skillID)
                    {
                        newList.Add(skills);
                    }
                }

                if(newList.Count > 0)
                {
                    deleted= 1;
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }


            return deleted;
        }

        /// <summary>
        /// Creator: Darryl Shirley
        /// created: 04/04/2024
        /// Summary: insertSkill fake method 
        /// Last updated By: Darryl Shirley
        /// Last Updated: 4/04/2024
        /// What was changed/updated: intial creation
        /// </summary>
        public int insertSkill(string volunteerID, int skillID)
        {
            int added = 0;
            List<VolunteerSkills> volunteerSkills = fakeVolunteerSkills;
            List<Volunteer> volunteers = fakeVolunteers;
            List<string> volunteerIDS = new List<string>();
            int occurence = 0;
            foreach(Volunteer vol in volunteers)
            {
                volunteerIDS.Add(vol.UserID);
            }
            try
            {

                VolunteerSkills volunteerSkill = new VolunteerSkills()
                {
                    VolunteerID = volunteerID,
                    SkillID = skillID
                };

                if (volunteerIDS.Contains(volunteerID))
                {
                    foreach(VolunteerSkills skill in volunteerSkills)
                    {
                        if(skill.VolunteerID.Equals(volunteerSkill.VolunteerID) && skill.SkillID == volunteerSkill.SkillID)
                        {
                            occurence++;
                        }
                    }

                    if(occurence == 0)
                    {
                        volunteerSkills.Add(volunteerSkill);
                        added = 1;
                    }
                }
                

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return added;
        }

        /// <summary>
        /// Creator: Darryl Shirley
        /// created: 04/04/2024
        /// Summary: SelectAllSkillsAssigned fake method
        /// Last updated By: Darryl Shirley
        /// Last Updated: 4/04/2024
        /// What was changed/updated: intial creation
        /// </summary>
        public List<Skills> SelectAllSkillsAssigned(string volunteerID)
        {
            List<Skills> skillsassigned= new List<Skills>();
            List<VolunteerSkills> volunteerSkills = fakeVolunteerSkills;
            List<Skills> SkillFakess = fakeSkills;
            try
            {
                foreach(VolunteerSkills skill in volunteerSkills)
                {
                    if(skill.VolunteerID.Equals(volunteerID))
                    {
                        foreach(Skills skills1 in SkillFakess)
                        {
                            if(skill.SkillID == skills1.SkillID)
                            {
                                skillsassigned.Add(skills1);
                            }
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }


            return skillsassigned;
        }

        /// <summary>
        /// Creator: Darryl Shirley
        /// created: 04/04/2024
        /// Summary: SelectAllSkillsNotAssigned fake method
        /// Last updated By: Darryl Shirley
        /// Last Updated: 4/04/2024
        /// What was changed/updated: intial creation
        /// </summary>
        public List<Skills> SelectAllSkillsNotAssigned(string volunteerID)
        {
            List<Skills> skillsassigned = new List<Skills>();
            List<Skills> unassigned= new List<Skills>();
            List<VolunteerSkills> volunteerSkills = fakeVolunteerSkills;
            List<Skills> SkillFakess = fakeSkills;

            try
            {
                foreach (VolunteerSkills skill in volunteerSkills)
                {
                    if (skill.VolunteerID.Equals(volunteerID))
                    {
                        foreach (Skills skills1 in SkillFakess)
                        {
                            if (skill.SkillID == skills1.SkillID)
                            {
                                skillsassigned.Add(skills1);
                            }
                        }
                    }
                }


                foreach(Skills skill in SkillFakess)
                {
                    if (!skillsassigned.Contains(skill))
                    {
                        unassigned.Add(skill);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return unassigned;
        }
    }
}
