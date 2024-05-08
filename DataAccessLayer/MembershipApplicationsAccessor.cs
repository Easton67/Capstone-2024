using DataObjects;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class MembershipApplicationsAccessor : IMembershipApplicationsAccessor
    {
        /// <summary>
        ///Creator:            Donald Winchester
        ///Created:            04/16/2024
        ///Summary:            Access class for the membership applications
        ///Last Updated By:    Donald Winchester
        ///Last Updated:       04/16/2024
        ///What Was Changed:   Initial Creation
        /// </summary>
        public List<MembershipApplication> ViewAllMembershipApplications()
        {
            List<MembershipApplication> membershipApplication = new List<MembershipApplication>();
            var conn = DatabaseConnection.GetConnection();
            var commandText = "sp_get_membership_applications";
            var cmd = new SqlCommand(commandText, conn);

            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        MembershipApplication application = new MembershipApplication()
                        {
                            _firstName = reader.GetString(0),
                            _lastName = reader.GetString(1),
                            _dateOfBirth = reader.GetString(2),
                            _sex = reader.GetString(3),
                            _ssn = reader.GetString(4),
                            _phoneNumber = reader.GetString(5),
                            _emailAddress = reader.GetString(6),
                            _status = reader.GetString(7)
                        };
                        membershipApplication.Add(application);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return membershipApplication;
        }
    }
}
