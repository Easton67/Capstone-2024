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
    /// Summary: IVolunteerSkillManager.cs 
    /// Last updated By: Darryl Shirley
    /// Last Updated: 4/04/2024
    /// What was changed/updated: intial creation
    /// </summary>
    public interface IVolunteerSkillManager
    {
        bool RemoveVolunteerSkill(string volunteerID, int skillID);

        bool AddVolunteerSkill(string volunteerID, int skillID);

        List<Skills> GetAssignedSkills(string volunteerID);

        List<Skills> GetUnAssignedSkills(string volunteerID);
    }
}
