using DataObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer {
    /// <summary>
    /// Creator: Jared Harvey
    /// Created: 02/06/2024
    /// Summary: Interface for ShiftManager
    /// Last Updated By: Jared Harvey
    /// Last Updated: 02/06/2024
    /// What Was Changed: Initial Creation
    /// </summary>  
    public interface IShiftManager {
		/// <summary>
        /// Creator: Jared Harvey
        /// Created: 02/09/2024
        /// Summary: Creation of GetShiftsByDepartment
        /// Last Updated By: Jared Harvey
        /// Last Updated: 02/09/2024
        /// What Was Changed: Initial Creation
        /// </summary>
        List<ShiftVM> GetShiftsByDepartment(int departmentID);
		/// <summary>
        /// Creator: Jared Harvey
        /// Created: 02/09/2024
        /// Summary: Creation of EditShift
        /// Last Updated By: Jared Harvey
        /// Last Updated: 02/09/2024
        /// What Was Changed: Initial Creation
        /// </summary>
		bool EditShift(Shift oldShift, Shift newShift);
        /// <summary>
        /// Creator: Liam Easton
        /// Created: 02/09/2024
        /// Summary: Creation of the AddEmployeeShift interface
        /// Last Updated By: Liam Easton
        /// Last Updated: 02/09/2024
        /// What Was Changed: Creation of the AddEmployeeShift interface
        /// </summary>
        bool AddEmployeeShift(Shift shift);
        /// <summary>
        /// Creator: Liam Easton
        /// Created: 02/15/2024
        /// Summary: Creation of the SelectAllShiftsFromEmployeeID interface
        /// Last Updated By: Liam Easton
        /// Last Updated: 02/15/2024
        /// What Was Changed: Creation of the SelectAllShiftsFromEmployeeID interface
        /// </summary>
        List<ShiftVM> SelectAllShftsFromEmployeeID(string employeeID);
        /// <summary>
        /// Creator: Liam Easton
        /// Created: 02/16/2024
        /// Summary: Creation of the RemoveShift interface
        /// Last Updated By: Liam Easton
        /// Last Updated: 02/16/2024
        /// What Was Changed: Creation of the RemoveShift interface
        /// </summary>
        bool RemoveShift(int shiftID);

        /// <summary>
        /// Creator: Abdalgader Ibrahim
        /// Created: 03/26/2024
        /// Summary: Creation of the SelectShiftByScheduleID interface
        /// </summary>
        List<ShiftVM> SelectShiftByScheduleID(int ScheduleID);
    }
}
