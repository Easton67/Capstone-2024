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
    /// Created: 02/06/2024
    /// Summary: This class is responsible for accessing the Shift table in the database
    /// Last Updated By: Jared Harvey
    /// Last Updated: 02/06/2024
    /// What Was Changed: Initial Creation
    /// </summary>
    public class ShiftAccessor : IShiftAccessor {
        /// <summary>
        /// Creator: Jared Harvey
        /// Created: 02/06/2024
        /// Summary: This method queries the database to get a list of shifts for a given department.
        /// Last Updated By: Jared Harvey
        /// Last Updated: 02/06/2024
        /// What Was Changed: Initial Creation
        /// </summary>
        public List<ShiftVM> SelectShiftVMsByDepartmentID(int departmentID) 
        {

            List<ShiftVM> result = new List<ShiftVM>();

            var conn = DatabaseConnection.GetConnection();
            var commandText = "sp_get_department_shifts";
            var cmd = new SqlCommand(commandText, conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@DepartmentID", SqlDbType.Int);
            cmd.Parameters["@DepartmentID"].Value = departmentID;

            try {
                conn.Open();
                var reader = cmd.ExecuteReader();
				
                if (reader.HasRows) {
                    while (reader.Read()) {
                        ShiftVM s = new ShiftVM();
                        s.ShiftID = reader.GetInt32(0);
                        s.EmployeeID = reader.GetString(1);
                        s.StartTime = reader.GetDateTime(2);
                        s.EndTime = reader.GetDateTime(3);
                        s.EmployeeName = reader.GetString(4) + " " + reader.GetString(5);
                        s.ShiftDuration = s.StartTime.ToShortTimeString() + " - " + s.EndTime.ToShortTimeString();
                        result.Add(s);
                    }
                }
            } catch (Exception ex) {
                throw ex;
            } finally {
                conn.Close();
            }
            return result;
        }

        /// <summary>
        /// Creator: Jared Harvey
        /// Created: 02/13/2024
        /// Summary: This method calls the sp_update_shift stored procedure and updates the given shift
        /// Last Updated By: Jared Harvey
        /// Last Updated: 02/13/2024
        /// What Was Changed: Initial Creation
        /// </summary>
        public int UpdateShift(Shift oldShift, Shift newShift) 
        {
            int rows = 0;

            var conn = DatabaseConnection.GetConnection();
            var commandText = "sp_update_shift";
            var cmd = new SqlCommand(commandText, conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@ShiftID", SqlDbType.Int);
            cmd.Parameters.Add("@OldEmployeeID", SqlDbType.NVarChar);
            cmd.Parameters.Add("@OldStartTime", SqlDbType.DateTime);
            cmd.Parameters.Add("@OldEndTime", SqlDbType.DateTime);
            cmd.Parameters.Add("@NewEmployeeID", SqlDbType.NVarChar);
            cmd.Parameters.Add("@NewStartTime", SqlDbType.DateTime);
            cmd.Parameters.Add("@NewEndTime", SqlDbType.DateTime);

            cmd.Parameters["@ShiftID"].Value = oldShift.ShiftID;
            cmd.Parameters["@OldEmployeeID"].Value = oldShift.EmployeeID;
            cmd.Parameters["@OldStartTime"].Value = oldShift.StartTime;
            cmd.Parameters["@OldEndTime"].Value = oldShift.EndTime;
            cmd.Parameters["@NewEmployeeID"].Value = newShift.EmployeeID;
            cmd.Parameters["@NewStartTime"].Value = newShift.StartTime;
            cmd.Parameters["@NewEndTime"].Value = newShift.EndTime;

            try {
                conn.Open();
                rows = cmd.ExecuteNonQuery();

            } catch (Exception ex) {
                throw ex;
            } finally {
				conn.Close();
            }
            return rows;
		}
		
		/// <summary>
        /// Creator: Liam Easton
        /// Created: 02/09/2024
        /// Summary: Creation of the ShiftAccessor Class
        /// Last Updated By: Liam Easton
        /// Last Updated: 02/09/2024
        /// What Was Changed: Creation of the ShiftAccessor Class
        /// </summary>
        public int AddEmployeeShift (Shift shift)
        {
            int rows = 0;

            var conn = DatabaseConnection.GetConnection();
            var cmdText = "sp_add_employee_shift";
            var cmd = new SqlCommand(cmdText, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@EmployeeID", shift.EmployeeID);
            cmd.Parameters.AddWithValue("@StartTime", shift.StartTime);
            cmd.Parameters.AddWithValue("@EndTime", shift.EndTime);
           
            try
            {
                conn.Open();
                rows = cmd.ExecuteNonQuery();
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
        /// Creator: Liam Easton
        /// Created: 02/15/2024
        /// Summary: Creation of the SelectAllShiftsFromEmployeeID Class
        /// Last Updated By: Liam Easton
        /// Last Updated: 02/15/2024
        /// What Was Changed: Creation of the SelectAllShiftsFromEmployeeID Class
        /// </summary>
        public List<ShiftVM> SelectAllShiftsFromEmployeeID(string employeeID)
        {
            List<ShiftVM> result = new List<ShiftVM>();

            var conn = DatabaseConnection.GetConnection();
            var commandText = "sp_select_all_shifts_from_employeeID";
            var cmd = new SqlCommand(commandText, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@EmployeeID", SqlDbType.NVarChar);
            cmd.Parameters["@EmployeeID"].Value = employeeID;

            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        ShiftVM shift = new ShiftVM();
                        shift.ShiftID = reader.GetInt32(0);
                        shift.EmployeeID = reader.GetString(1);
                        shift.StartTime = reader.GetDateTime(2);
                        shift.EndTime = reader.GetDateTime(3);
                        result.Add(shift);
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
            return result;
        }

        /// <summary>
        /// Creator: Liam Easton
        /// Created: 02/16/2024
        /// Summary: Creation of the RemoveShift Class
        /// Last Updated By: Liam Easton
        /// Last Updated: 02/16/2024
        /// What Was Changed: Creation of the RemoveShift Class
        /// </summary>
        public int RemoveShift(int shiftID)
        {
            int rows = 0;

            var conn = DatabaseConnection.GetConnection();
            var commandText = "sp_remove_shift";
            var cmd = new SqlCommand(commandText, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ShiftID", SqlDbType.Int);
            cmd.Parameters["@ShiftID"].Value = shiftID;

            try
            {
                conn.Open();

                rows = cmd.ExecuteNonQuery();

                if (rows == 0)
                {
                    throw new ArgumentException("Could not remove this shift.");
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
        /// Created: 03/19/2024
        /// Summary: Creation of the SelectShiftByScheduleID method
        /// </summary>
        public List<ShiftVM> SelectShiftByScheduleID(int ScheduleID)
        {
            List<ShiftVM> result = new List<ShiftVM>();

            var conn = DatabaseConnection.GetConnection();
            var commandText = "sp_select_shift_by_schedule_id";
            var cmd = new SqlCommand(commandText, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ScheduleID", SqlDbType.Int);
            cmd.Parameters["@ScheduleID"].Value = ScheduleID;

            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        ShiftVM shift = new ShiftVM();
                        Employee employee = new Employee();
                        Schedule schedule = new Schedule();
                        shift.employee = employee;
                        shift.schedule = schedule;
                        shift.ShiftID = reader.GetInt32(0);
                        shift.employee.FirstName = reader.GetString(1);
                        shift.employee.LastName = reader.GetString(2);
                        shift.StartTime = reader.GetDateTime(3);
                        shift.EndTime = reader.GetDateTime(4);
                        shift.schedule.ScheduleStartDate = reader.GetDateTime(5);
                        shift.schedule.ScheduleEndDate = reader.GetDateTime(6);
                        result.Add(shift);
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
            return result;
        }
    }
}