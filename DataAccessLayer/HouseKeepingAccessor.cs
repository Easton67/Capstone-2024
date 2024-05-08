using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessInterfaces;
using DataObjects;

namespace DataAccessLayer
{

    /// <summary>
    /// Creator: Miyada Abas
    /// Created: 02/06/2024
    /// Summary: This is the accessor class for HouseKeepingTasks class.
    /// Last Updated By: Miyada Abas
    /// Last Updated 03/01/2024
    /// What was changed: 
    /// </summary> 
    public class HouseKeepingAccessor : IHouseKeepingAccessor
    {

        /// <summary>
        /// Creator: Miyada Abas
        /// Created: 02/06/2024
        /// Summary: This method will retrieve all HouseKeepingTasks objects from the 
        /// available database.
        /// Last Updated By: Miyada Abas
        /// Last Updated 03/01/2024
        /// What was changed: 
        /// </summary>
        public List<HouseKeepingTask> SelectAllHouseKeepingTasks()
        {

            List<HouseKeepingTask> houseKeepingTasks = new List<HouseKeepingTask>();

            var conn = DatabaseConnection.GetConnection();
            var commandText = "sp_SelectAllHouseKeepingTask";
            var cmd = new SqlCommand(commandText, conn);
            cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                conn.Open();
                var result = cmd.ExecuteReader();
                if(result.HasRows) {
                    while(result.Read())
                    {
                        HouseKeepingTask houseKeepingTask = new HouseKeepingTask();
                        houseKeepingTask.TaskID = result.GetInt32(0);
                        houseKeepingTask.RoomID = result.GetInt32(1);
                        houseKeepingTask.EmployeeID = result.IsDBNull(2) ? "" : result.GetString(2);
                        houseKeepingTask.Type = result.IsDBNull(3) ? "" : result.GetString(3);
                        houseKeepingTask.Description = result.GetString(4);
                        houseKeepingTask.Date = result.GetDateTime(5);
                        houseKeepingTask.Status = result.GetString(6);
                        houseKeepingTasks.Add(houseKeepingTask);
                    }
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
            return houseKeepingTasks;
        }
    }
}
