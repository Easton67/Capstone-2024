using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessInterfaces;
using DataObjects;

namespace DataAccessLayer
{
    /// <summary>
    /// Creator:Miyada Abas
    /// Created: 02/27/2024
    /// Summary: Created a public class for login accessor.
    /// Last Updated By: Miyada Abas
    /// Last Updated: Miyada Abas
    /// What Was Changed: created.
    /// </summary>
    public class LoginAccessor : LoginAccessorInterFace
    {
        public bool signUp(EmployeePass employee)
        {
            bool result = false;

            SqlConnection conn = DatabaseConnection.GetConnection();
            SqlCommand cmd = new SqlCommand("sp_signUp", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@email",employee.EmployeeID);
            cmd.Parameters.AddWithValue("@password", employee.PasswordHash);
            cmd.Parameters.AddWithValue("@employeeId", employee.EmployeeID);
            cmd.Parameters.AddWithValue("@Fname", employee.FirstName);
            cmd.Parameters.AddWithValue("@Phone", employee.PhoneNumber);
            cmd.Parameters.AddWithValue("@Gender", employee.Gender);
            cmd.Parameters.AddWithValue("@AccountStatus", employee.AccountStatus);
            cmd.Parameters.AddWithValue("@ZipCode", employee.ZipCode);
            cmd.Parameters.AddWithValue("@Address", employee.Address);
            cmd.Parameters.AddWithValue("@StartDate", employee.StartDate);
            cmd.Parameters.AddWithValue("@EndDate", employee.EndDate);

            try
            {
                conn.Open();
                result = cmd.ExecuteNonQuery()==1;
            }
            catch (Exception)
            {
                throw;
            }
            finally { conn.Close(); }
            return result;
        }
    }
}
