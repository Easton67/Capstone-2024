using DataAccessInterfaces;
using DataAccessLayer;
using DataObjects;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer {
    /// <summary>
    /// Creator: Jared Harvey
    /// Created: 02/07/2024
    /// Summary: This class is responsible for shift logic.
    /// Last Updated By: Jared Harvey
    /// Last Updated: 02/07/2024
    /// What Was Changed: Initial Creation
    /// </summary>
    public class ShiftManager : IShiftManager {
        private IShiftAccessor shiftAccessor = null;

        public ShiftManager() {
            shiftAccessor = new ShiftAccessor();
        }

        public ShiftManager(IShiftAccessor shiftAccessor) {
            this.shiftAccessor = shiftAccessor;
        }

        /// <summary>
        /// Creator: Jared Harvey
        /// Created: 02/13/2024
        /// Summary: This method calls the accessor method to update a shift record.
        /// Parameters: Shift oldShift, Shift newShift
        /// Returns: bool
        /// Last Updated By: Jared Harvey
        /// Last Updated: 02/13/2024
        /// What Was Changed: Initial Creation
        /// </summary>
        public bool EditShift(Shift oldShift, Shift newShift) {
            bool result = false;
            try {
                result = (1 == shiftAccessor.UpdateShift(oldShift, newShift));
                if(!result) {
                    throw new Exception("failed to edit shift");
                }
                return result;
            } catch (Exception ex) {
                throw ex;
            }
		}
		
		/// <summary>
        /// Creator: Liam Easton
        /// Created: 02/09/2024
        /// Summary: Creation of the AddEmployeeShift class
        /// Last Updated By: Liam Easton
        /// Last Updated: 02/15/2024
        /// What Was Changed: added summary to method
        /// </summary>
        public bool AddEmployeeShift(Shift shift)
        {
            bool result = false;

            try
            {
                result = (1 == shiftAccessor.AddEmployeeShift(shift));
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Shift could not be added.", ex);
            }
            return result;
        }

        /// <summary>
        /// Creator: Jared Harvey
        /// Created: 02/07/2024
        /// Summary: This method gets the list of shifts from a given department.
        /// Parameters: string departmentID
        /// Returns: List<ShiftVM>
        /// Last Updated By: Jared Harvey
        /// Last Updated: 02/07/2024
        /// What Was Changed: Initial Creation
        /// </summary>
        public List<ShiftVM> GetShiftsByDepartment(int departmentID) {
            List<ShiftVM> result = new List<ShiftVM>();
            try {
                result = shiftAccessor.SelectShiftVMsByDepartmentID(departmentID);
            } catch (Exception ex) {
                throw ex;
            }
            return result;
        }

        /// <summary>
        /// Creator: Liam Easton
        /// Created: 02/15/2024
        /// Summary: Creation of the SelectAllShiftsFromEmployeeID Class
        /// Last Updated By: Liam Easton
        /// Last Updated: 02/15/2024
        /// What Was Changed: Creation of the SelectAllShiftsFromEmployeeID Class
        /// </summary>
        public List<ShiftVM> SelectAllShftsFromEmployeeID(string employeeID)
        {
            List<ShiftVM> result = new List<ShiftVM>();
            try
            {
                result = shiftAccessor.SelectAllShiftsFromEmployeeID(employeeID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }

        /// <summary>
        /// Creator: Liam Easton
        /// Created: 02/15/2024
        /// Summary: Creation of the SelectAllShiftsFromEmployeeID Class
        /// Last Updated By: Liam Easton
        /// Last Updated: 02/15/2024
        /// What Was Changed: Creation of the SelectAllShiftsFromEmployeeID Class
        /// </summary>
        public bool RemoveShift(int shiftID)
        {
            bool result = false;

            try
            {
                result = (1 == shiftAccessor.RemoveShift(shiftID));
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }
        /// <summary>
        /// Creator: Abdalgader
        /// Created: 03/19/2024
        /// Summary: Creation of the SelectShiftByScheduleID method
        /// </summary>
        public List<ShiftVM> SelectShiftByScheduleID(int ScheduleID)
        {
            try
            {
                return shiftAccessor.SelectShiftByScheduleID(ScheduleID);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
