using DataAccessInterfaces;
using DataObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessFakes
{
    /// <summary>
    /// Creator: Jared Harvey
    /// Created: 02/08/2024
    /// Summary: This class creates fake shifts to be used by ShiftManagerTests
    /// Last Updated By: Jared Harvey
    /// Last Updated: 02/08/2024
    /// What Was Changed: Initial Creation
    /// </summary>
    public class ShiftAccessorFakes : IShiftAccessor
    {
        public List<ShiftVM> fakeShifts = new List<ShiftVM>();
        private DepartmentAccessorFakes _departmentAccessorFakes;
        private List<Department> _departments = new List<Department>();

        public ShiftAccessorFakes() {
            fakeShifts.Add(new ShiftVM() {
                ShiftID = 100000,
                EmployeeID = "tess@company.com",
                StartTime = DateTime.Now.AddDays(1),
                EndTime = DateTime.Now.AddDays(1),
                ScheduleID = 1,
            });
            fakeShifts.Add(new ShiftVM() {
                ShiftID = 100001,
                EmployeeID = "tess@company.com",
                StartTime = DateTime.Now.AddDays(2),
                EndTime = DateTime.Now.AddDays(2),
                ScheduleID = 2,

            });
            fakeShifts.Add(new ShiftVM() {
                ShiftID = 100002,
                EmployeeID = "tess@company.com",
                StartTime = DateTime.Now.AddDays(3),
                EndTime = DateTime.Now.AddDays(3),
                ScheduleID = 3,
            });
            fakeShifts.Add(new ShiftVM() {
                ShiftID = 100003,
                EmployeeID = "tess@company.com",
                StartTime = DateTime.Now.AddDays(4),
                EndTime = DateTime.Now.AddDays(4),
                ScheduleID = 4,
            });
            _departmentAccessorFakes = new DepartmentAccessorFakes();
            _departments = _departmentAccessorFakes.fakeDepartments;
        }

        /// <summary>
        /// Creator: Jared Harvey
        /// Created: 03/05/2024
        /// Summary: Fake accessor method SelectShiftVMsByDepartmentID
        /// Last Updated By: Jared Harvey
        /// Last Updated: 03/05/2024
        /// What Was Changed: Initial Creation
        /// </summary>
        public List<ShiftVM> SelectShiftVMsByDepartmentID(int departmentID) {
            return fakeShifts;
        }

        /// <summary>
        /// Creator: Jared Harvey
        /// Created: 02/16/2024
        /// Summary: Test method for updating shift
        /// Last Updated By: Jared Harvey
        /// Last Updated: 02/16/2024
        /// What Was Changed: Initial Creation
        /// </summary>
        public int UpdateShift(Shift oldShift, Shift newShift)
        {
            int rows = 0;
            for (int i = 0; i < fakeShifts.Count; i++)
            {
                if (fakeShifts[i].ShiftID.Equals(oldShift.ShiftID))
                {
                    // Update the existing shift's values with the new shift's values
                    fakeShifts[i].ShiftID = newShift.ShiftID;
                    fakeShifts[i].EmployeeID = newShift.EmployeeID;
                    fakeShifts[i].StartTime = newShift.StartTime;
                    fakeShifts[i].EndTime = newShift.EndTime;
                    rows = 1;
                    break;
                }
            }
            return rows;
        }

        /// <summary>
        /// Creator: Liam Easton
        /// Created: 02/15/2024
        /// Summary: Creation of the AddEmployeeShift method
        /// Last Updated By: Liam Easton
        /// Last Updated: 02/15/2024
        /// What Was Changed: Creation of the AddEmployeeShift method
        /// </summary>
        public int AddEmployeeShift(Shift shift)
        {
            ShiftVM newShift = new ShiftVM() {
                ShiftID = shift.ShiftID,
                EmployeeID = shift.EmployeeID,
                StartTime = shift.StartTime,
                EndTime = shift.EndTime,
                ScheduleID = shift.ScheduleID
            };

            fakeShifts.Add(newShift);

            return 1;
        }


        /// <summary>
        /// Creator: Liam Easton
        /// Created: 02/16/2024
        /// Summary: Creation of the RemoveShift method
        /// Last Updated By: Liam Easton
        /// Last Updated: 02/16/2024
        /// What Was Changed: Creation of the RemoveShift method
        /// </summary>
        public int RemoveShift(int shiftID)
        {
            int rows = fakeShifts.RemoveAll(shift => shift.ShiftID == shiftID);

            if (rows != 1)
            {
                throw new ApplicationException("Shift not found");
            }

            return rows;
        }

        /// <summary>
        /// Creator: Liam Easton
        /// Created: 02/15/2024
        /// Summary: Creation of the SelectAllShftsFromEmployeeID method
        /// Last Updated By: Liam Easton
        /// Last Updated: 02/15/2024
        /// What Was Changed: Creation of the SelectAllShftsFromEmployeeID method
        /// </summary>
        public List<ShiftVM> SelectAllShiftsFromEmployeeID(string employeeID)
        {
            return fakeShifts.Where(x => x.EmployeeID.Equals(employeeID)).ToList();
        }

        /// <summary>
        /// Creator: Abdalgader Ibrahim
        /// Created: 03/21/2024
        /// Summary: Creation of the SelectShiftByScheduleID method
        /// </summary>
        public List<ShiftVM> SelectShiftByScheduleID(int ScheduleID)
        {
            List<ShiftVM> shiftVMs = new List<ShiftVM>();
            foreach (ShiftVM shift in fakeShifts)
            {
                if (shift.ScheduleID == ScheduleID)
                {
                    shiftVMs.Add(shift);

                }
            }
            return shiftVMs;
        }
    }
}
