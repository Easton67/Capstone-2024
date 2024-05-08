using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using DataAccessInterfaces;
using DataAccessLayer;
using DataObjects;

namespace DataAccessFakes
{
    public class MembershipApplicationsAccessorFake : IMembershipApplicationsAccessor
    {
        List<MembershipApplication> _membershipApplications = new List<MembershipApplication>();
        /// <summary>
        ///Creator:            Donald Winchester
        ///Created:            04/16/2024
        ///Summary:            Fake data for Membership Applications Accessor
        ///Last Updated By:    Donald Winchester
        ///Last Updated:       04/16/2024
        ///What Was Changed:   Initial Creation
        /// </summary>
        public MembershipApplicationsAccessorFake() 
        {
            _membershipApplications.Add(new MembershipApplication
            {
                _firstName = "John",
                _lastName = "Doe",
                _dateOfBirth = "01/01/2000",
                _sex = "Male",
                _ssn = "123-45-6789",
                _phoneNumber = "3195551111",
                _emailAddress = "john@homelessshelter.com",
                _status = "Accepted"
            });
            _membershipApplications.Add(new MembershipApplication
            {
                _firstName = "Jane",
                _lastName = "Doe",
                _dateOfBirth = "01/01/2000",
                _sex = "Female",
                _ssn = "234-56-7890",
                _phoneNumber = "3195552222",
                _emailAddress = "jane@homelessshelter.com",
                _status = "Declined"
            });
        }
        /// <summary>
        ///Creator:            Donald Winchester
        ///Created:            04/16/2024
        ///Summary:            Returns data from the fake
        ///Last Updated By:    Donald Winchester
        ///Last Updated:       04/16/2024
        ///What Was Changed:   Initial Creation
        /// </summary>
        public List<MembershipApplication> ViewAllMembershipApplications()
        {
            List<MembershipApplication> membershipApplications = new List<MembershipApplication>();
            foreach (MembershipApplication membershipApplication in _membershipApplications)
            {
                MembershipApplication application = new MembershipApplication()
                {
                    _firstName = membershipApplication._firstName,
                    _lastName = membershipApplication._lastName,
                    _dateOfBirth = membershipApplication._dateOfBirth,
                    _sex = membershipApplication._sex,
                    _ssn = membershipApplication._ssn,
                    _phoneNumber = membershipApplication._phoneNumber,
                    _emailAddress = membershipApplication._emailAddress,
                    _status = membershipApplication._status,
                };
                membershipApplications.Add(application);
            }
            return membershipApplications;
        }
    }
}
