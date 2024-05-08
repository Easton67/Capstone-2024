using DataObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessInterfaces {
    /// <summary>
    /// Creator: Jared Harvey
    /// Created: 02/08/2024
    /// Summary: This class is an interface for ShiftAccessor
    /// Last Updated By: Jared Harvey
    /// Last Updated: 02/08/2024
    /// What Was Changed: Initial Creation
    /// </summary>
    public interface IShiftAccessor {
        int UpdateShift(Shift oldShift, Shift newShift);
        /// <summary>
        /// Creator: Jared Harvey
        /// Created: 02/08/2024
        /// Summary: This class is an interface for ShiftAccessor
        /// Last Updated By: Jared Harvey
        /// Last Updated: 02/08/2024
        /// What Was Changed: Initial Creation
        /// </summary>
        List<ShiftVM> SelectShiftVMsByDepartmentID(int departmentID);
        /// <summary>
        /// Creator:            Liam Easton
        /// Created:            02/11/2024
        /// Summary:            Creation of AddEmployeeShift interface
        /// Last Updated By:    Liam Easton
        /// Last Updated:       02/11/2024
        /// What Was Changed:   Creation of AddEmployeeShift interface
        /// </summary>
        int AddEmployeeShift(Shift shift);
        /// <summary>
        /// Creator: Liam Easton
        /// Created: 02/15/2024
        /// Summary: Creation of the SelectAllShftsFromEmployeeID Class
        /// Last Updated By: Liam Easton
        /// Last Updated: 02/15/2024
        /// What Was Changed: Creation of the SelectAllShftsFromEmployeeID Class
        /// </summary>
        List<ShiftVM> SelectAllShiftsFromEmployeeID(string employeeID);
        /// <summary>
        /// Creator: Liam Easton
        /// Created: 02/16/2024
        /// Summary: Creation of the RemoveShift Class
        /// Last Updated By: Liam Easton
        /// Last Updated: 02/16/2024
        /// What Was Changed: Creation of the RemoveShift Class
        /// </summary>
        int RemoveShift(int shiftID);
        /// <summary>
        /// Creator: Abdalgader Ibrahim
        /// Created: 03/26/2024
        /// Summary: Creation of the SelectShiftByScheduleID method
        /// </summary>
        List<ShiftVM> SelectShiftByScheduleID(int scheduleID);
    }
}
