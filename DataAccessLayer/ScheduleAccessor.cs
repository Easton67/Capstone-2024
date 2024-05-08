using DataAccessInterfaces;
using DataObjects;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataObjects.Kitchen;

namespace DataAccessLayer
{
    /// <summary>
    /// Creator:            Ethan McElree
    /// Created:            02/13/2024
    /// Summary:            Creation of the ScheduleAccessor class
    /// Last Updated By:    Ethan McElree
    /// Last Updated:       02/13/2024
    /// What Was Changed:   Intial Creation
    /// </summary>
    public class ScheduleAccessor : IScheduleAccessor
    {

        /// <summary>
        /// Creator: Ethan McElree
        /// Created: 02/1/2024
        /// Summary: Creation of the CreateSchedule method.
        /// Last Updated By: Ethan McElree
        /// Last Updated: 02/05/2024
        /// What Was Changed: Added two more methods for the interface
        /// </summary>
        public int CreateSchedule(string ScheduleMonth, int ScheduleWeek, int ScheduleYear, DateTime ScheduleStartDate, DateTime ScheduleEndDate)
        {
            int rows = 0;

            var conn = DatabaseConnection.GetConnection();
            var commandText = "sp_create_schedule";
            var cmd = new SqlCommand(commandText, conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@ScheduleMonth", SqlDbType.NVarChar, 50);
            cmd.Parameters.Add("@ScheduleWeek", SqlDbType.Int);
            cmd.Parameters.Add("@ScheduleYear", SqlDbType.Int);
            cmd.Parameters.Add("@ScheduleStartDate", SqlDbType.Date);
            cmd.Parameters.Add("@ScheduleEndDate", SqlDbType.Date);

            cmd.Parameters["@ScheduleMonth"].Value = ScheduleMonth;
            cmd.Parameters["@ScheduleWeek"].Value = ScheduleWeek;
            cmd.Parameters["@ScheduleYear"].Value = ScheduleYear;
            cmd.Parameters["@ScheduleStartDate"].Value = ScheduleStartDate;
            cmd.Parameters["@ScheduleEndDate"].Value = ScheduleEndDate;

            try
            {
                conn.Open();
                rows = cmd.ExecuteNonQuery();
                if (rows == 0)
                {
                    throw new ArgumentException("Fields not updated");
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
            return rows;
        }
        /// <summary>
        /// Creator: Abdalgader Ibrahim
        /// Created: 03/26/2024
        /// Summary: Creation of the GetAllSchedules method.
        /// Last Updated By: Abdalgader Ibrahim
        /// Last Updated: 03/26/2024
        /// What Was Changed: Added two more methods for the interface
        /// </summary>
        public List<ScheduleVM> GetAllSchedules()
        {
            var List = new List<ScheduleVM>();

            var conn = DatabaseConnection.GetConnection();
            var cmdText = "sp_select_all_schedules";
            var cmd = new SqlCommand(cmdText, conn);
            cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        ScheduleVM schedule = new ScheduleVM();
                        schedule.ScheduleID = reader.GetInt32(0);
                        schedule.ScheduleMonth = reader.GetString(1);
                        schedule.ScheduleWeek = reader.GetInt32(2);
                        schedule.ScheduleYear = reader.GetInt32(3);
                        schedule.ScheduleStartDate = reader.GetDateTime(4);
                        schedule.ScheduleEndDate = reader.GetDateTime(5);
                        List.Add(schedule);
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
            return List;
        }

        /// <summary>
        /// Creator: Ethan McElree
        /// Created: 02/1/2024
        /// Summary: Creation of the ScheduleExists.
        /// Last Updated By: Ethan McElree
        /// Last Updated: 02/05/2024
        /// What Was Changed: Added two more methods for the interface
        /// </summary>
        public bool ScheduleExists(string ScheduleMonth, int ScheduleWeek, int ScheduleYear)
        {
            bool scheduleExists = false;

            var conn = DatabaseConnection.GetConnection();
            var commandText = "sp_check_schedule_exists";
            var cmd = new SqlCommand(commandText, conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@ScheduleMonth", SqlDbType.NVarChar, 50);
            cmd.Parameters.Add("@ScheduleWeek", SqlDbType.Int);
            cmd.Parameters.Add("@ScheduleYear", SqlDbType.Int);

            cmd.Parameters["@ScheduleMonth"].Value = ScheduleMonth;
            cmd.Parameters["@ScheduleWeek"].Value = ScheduleWeek;
            cmd.Parameters["@ScheduleYear"].Value = ScheduleYear;

            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    scheduleExists = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return scheduleExists;
        }
    }
}
