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
    /// <summary>
    /// Creator: Darryl Shirley
    /// created: 04/04/2024
    /// Summary: VolunteerSkillManager.cs 
    /// Last updated By: Darryl Shirley
    /// Last Updated: 4/04/2024
    /// What was changed/updated: intial creation
    /// </summary>
    public class VolunteerSkillManager : IVolunteerSkillManager
    {
        private IVolunteerSkillAccessor _skillAccessor;

        public VolunteerSkillManager() 
        {
            _skillAccessor = new VolunteerSkillAccessor();
        }

        public VolunteerSkillManager(IVolunteerSkillAccessor skillAccessor)
        { 
            _skillAccessor = skillAccessor; 
        }

        /// <summary>
        /// Creator: Darryl Shirley
        /// created: 04/04/2024
        /// Summary: AddVolunteerSkill method 
        /// Last updated By: Darryl Shirley
        /// Last Updated: 4/04/2024
        /// What was changed/updated: intial creation
        /// </summary>
        public bool AddVolunteerSkill(string volunteerID, int skillID)
        {
            bool result = false;

            try
            {
                if (_skillAccessor.insertSkill(volunteerID, skillID) == 1)
                {
                    result = true;
                }
            }
            catch (Exception ex)
            {
                result = false;
                throw new ApplicationException("Volunteer Skill not created", ex);
            }

            return result;
        }

        /// <summary>
        /// Creator: Darryl Shirley
        /// created: 04/04/2024
        /// Summary: GetAssignedSkills method
        /// Last updated By: Darryl Shirley
        /// Last Updated: 4/04/2024
        /// What was changed/updated: intial creation
        /// </summary>
        public List<Skills> GetAssignedSkills(string volunteerID)
        {
            List<Skills> skills = new List<Skills>();
            try
            {
                skills = _skillAccessor.SelectAllSkillsAssigned(volunteerID);
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message, ex);
            }
            return skills;
        }

        /// <summary>
        /// Creator: Darryl Shirley
        /// created: 04/04/2024
        /// Summary: GetUnAssignedSkills method
        /// Last updated By: Darryl Shirley
        /// Last Updated: 4/04/2024
        /// What was changed/updated: intial creation
        /// </summary>
        public List<Skills> GetUnAssignedSkills(string volunteerID)
        {
            List<Skills> skills = new List<Skills>();
            try
            {
                skills = _skillAccessor.SelectAllSkillsNotAssigned(volunteerID);
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message, ex);
            }
            return skills;
        }

        /// <summary>
        /// Creator: Darryl Shirley
        /// created: 04/04/2024
        /// Summary: RemoveVolunteerSkill method 
        /// Last updated By: Darryl Shirley
        /// Last Updated: 4/04/2024
        /// What was changed/updated: intial creation
        /// </summary>
        public bool RemoveVolunteerSkill(string volunteerID, int skillID)
        {
            bool result = false;

            try
            {
                if (_skillAccessor.deleteSkill(volunteerID, skillID) == 1)
                {
                    result = true;
                }
            }
            catch (Exception ex)
            {
                result = false;
                throw new ApplicationException("Volunteer Skill not deleted", ex);
            }

            return result;
        }
    }
}
