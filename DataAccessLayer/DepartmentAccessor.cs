using DataAccessInterfaces;
using DataObjects;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer {
    /// <summary>
    /// Creator: Jared Harvey
    /// Created: 02/08/2024
    /// Summary: This class is responsible for accessing the Department table in the database
    /// Last Updated By: Jared Harvey
    /// Last Updated: 02/08/2024
    /// What Was Changed: Initial Creation
    /// </summary>
    public class DepartmentAccessor : IDepartmentAccessor {

        /// <summary>
        /// Creator: Jared Harvey
        /// Created: 02/08/2024
        /// Summary: This method queries the Department database table and returns all departments in a shelter
        /// Last Updated By: Jared Harvey
        /// Last Updated: 02/08/2024
        /// What Was Changed: Initial Creation
        /// </summary>
        public List<Department> SelectShelterDepartments(string shelterID) {
            List<Department> result = new List<Department>();

            var conn = DatabaseConnection.GetConnection();
            var commandText = "sp_get_shelter_departments";
            var cmd = new SqlCommand(commandText, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ShelterID", SqlDbType.NVarChar, 50);
            cmd.Parameters["@ShelterID"].Value = shelterID;

            try {
                conn.Open();

                var reader = cmd.ExecuteReader();
                if (reader.HasRows) {
                    while (reader.Read()) {
                        Department d = new Department();
                        d.DepartmentID = reader.GetInt32(0);
                        d.ShelterID = reader.GetString(1);
                        d.DepartmentName = reader.GetString(2);
                        d.Description = reader.GetString(3);
                        result.Add(d);
                    }
                }
            } catch (Exception ex) {
                throw ex;
            } finally {
                conn.Close();
            }
            return result;
        }
    }
}
