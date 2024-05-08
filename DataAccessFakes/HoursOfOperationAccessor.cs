using DataAccessInterfaces;
using DataObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DataAccessLayer
{
    /// <summary>
    /// Creator: Andrew Larson
    /// Created: 01/29/2024
    /// Summary: This is the accessor class for HoursOfOperation.
    /// Last Updated By: Andrew Larson
    /// Last Updated 01/29/2024
    /// What was changed: Initial Creation
    /// </summary> 
    public class HoursOfOperationAccessor : IHoursOfOperationAccessor
    {
        /// <summary>
        /// Creator: Andrew Larson
        /// Created: 01/31/2024
        /// Summary: This method will retrieve all valid HoursOfOperation objects
        /// as a list, based on the users zipCode input.
        /// Last Updated By: Andrew Larson
        /// Last Updated 01/31/2024
        /// What was changed: Initial Creation
        /// </summary>
        public List<HoursOfOperation> SelectHoursOfOperation(int zipCode)
        {
            List<HoursOfOperation> hoursOfOperations = new List<HoursOfOperation>();
            var conn = DatabaseConnection.GetConnection();
            var commandText = "sp_select_homeless_shelter_by_zipcode";
            var cmd = new SqlCommand(commandText, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ZipCode", SqlDbType.Int);
            cmd.Parameters["@ZipCode"].Value = zipCode;

            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();
                if(reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Location location = new Location()
                        {
                            LocationName = reader.GetString(0),
                            Address = reader.GetString(1),
                            City = reader.GetString(2),
                            State = reader.GetString(3),
                            ZipCode = reader.GetInt32(4)
                        };

                        HoursOfOperation hoursOfOperation = new HoursOfOperation()
                        {
                            location = location,
                            HoursOfOperationString = reader.GetString(5)
                        };
                        hoursOfOperations.Add(hoursOfOperation);
                    }
                }
                else
                {
                    return new List<HoursOfOperation>();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            { 
                conn.Close();
            }
            return hoursOfOperations;
        }
    }
}
