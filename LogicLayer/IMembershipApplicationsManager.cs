using DataObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer
{
    public interface IMembershipApplicationsManager
    {
        /// <summary>
        ///Creator:            Donald Winchester
        ///Created:            04/16/2024
        ///Summary:            Interface for the Membership Applications Logic Layer
        ///Last Updated By:    Donald Winchester
        ///Last Updated:       04/16/2024
        ///What Was Changed:   Initial Creation
        /// </summary>
        List<MembershipApplication> GetAllMembershipApplications();
    }
}
