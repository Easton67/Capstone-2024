using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataObjects;

namespace DataAccessInterfaces
{
    /// <summary>
    /// Creator: Darryl Shirley
    /// created: 04/04/2024
    /// Summary: IVolunteerSkillAccessor.cs
    /// Last updated By: Darryl Shirley
    /// Last Updated: 4/04/2024
    /// What was changed/updated: intial creation
    /// </summary>
    public interface IVolunteerSkillAccessor
    {
        List<Skills> SelectAllSkillsNotAssigned(string volunteerID);

        List<Skills> SelectAllSkillsAssigned(string volunteerID);

        int insertSkill(string volunteerID, int skillID);

        int deleteSkill(string volunteerID, int skillID);
    }
}
