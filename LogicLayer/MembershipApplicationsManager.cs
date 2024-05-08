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
    ///Creator:            Donald Winchester
    ///Created:            04/16/2024
    ///Summary:            Class contains methods for membership applications
    ///Last Updated By:    Donald Winchester
    ///Last Updated:       04/16/2024
    ///What Was Changed:   Initial Creation
    /// </summary>
    public class MembershipApplicationsManager : IMembershipApplicationsManager
    {
        IMembershipApplicationsAccessor _membershipApplicationsAccessor;

        /// <summary>
        ///Creator:            Donald Winchester
        ///Created:            04/16/2024
        ///Summary:            Initial creation of the MembershipApplicationsManager method
        ///Last Updated By:    Donald Winchester
        ///Last Updated:       04/16/2024
        ///What Was Changed:   Initial Creation
        /// </summary>
        public MembershipApplicationsManager()
        {
            _membershipApplicationsAccessor = new MembershipApplicationsAccessor();
        }

        /// <summary>
        ///Creator:            Donald Winchester
        ///Created:            04/16/2024
        ///Summary:            Initializes the membershipApplicationAccessor
        ///Last Updated By:    Donald Winchester
        ///Last Updated:       04/16/2024
        ///What Was Changed:   Initial Creation
        /// </summary>
        public MembershipApplicationsManager(IMembershipApplicationsAccessor membershipApplicationsAccessor)
        {
            _membershipApplicationsAccessor = membershipApplicationsAccessor;
        }
        /// <summary>
        ///Creator:            Donald Winchester
        ///Created:            04/16/2024
        ///Summary:            Returns all membership applications
        ///Last Updated By:    Donald Winchester
        ///Last Updated:       04/16/2024
        ///What Was Changed:   Initial Creation
        /// </summary>
        public List<MembershipApplication> GetAllMembershipApplications()
        {
            try
            {
                return _membershipApplicationsAccessor.ViewAllMembershipApplications();
            }
            catch (Exception ex)
            {

                throw new ApplicationException("Failed to get applications.", ex);
            }
        }
    }
}
