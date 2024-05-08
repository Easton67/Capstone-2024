using DataAccessInterfaces;
using DataObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessFakes {
    /// <summary>
    /// Creator: Jared Harvey
    /// Created: 03/03/2024
    /// Summary: This class accesses the fake department records for testing
    /// Last Updated By: Jared Harvey
    /// Last Updated: 03/03/2024
    /// What Was Changed: Initial Creation
    /// </summary>
    public class DepartmentAccessorFakes : IDepartmentAccessor {
        public List<Department> fakeDepartments = new List<Department>();

        /// <summary>
        /// Creator: Jared Harvey
        /// Created: 03/03/2024
        /// Summary: This constructor populates the fakeRooms list
        /// Last Updated By: Jared Harvey
        /// Last Updated: 03/03/2024
        /// What Was Changed: Initial Creation
        /// </summary>
        public DepartmentAccessorFakes() {
            fakeDepartments.Add(new Department() {
                DepartmentID = 100000,
                ShelterID = "Test Homeless Shelter",
                DepartmentName = "Housekeeping",
                Description = "Keeps the shelter clean."
            });
            fakeDepartments.Add(new Department() {
                DepartmentID = 100001,
                ShelterID = "Test Homeless Shelter",
                DepartmentName = "Maintenance",
                Description = "Keeps the shelter utilities humming."
            });
            fakeDepartments.Add(new Department() {
                DepartmentID = 100002,
                ShelterID = "Test Homeless Shelter",
                DepartmentName = "Transportation",
                Description = "Keeps the shelter mobile."
            });
            fakeDepartments.Add(new Department() {
                DepartmentID = 100003,
                ShelterID = "Test Homeless Shelter",
                DepartmentName = "Kitchen",
                Description = "Keeps the shelter fed."
            });
            fakeDepartments.Add(new Department() {
                DepartmentID = 100004,
                ShelterID = "Test Homeless Shelter",
                DepartmentName = "Security",
                Description = "Keeps the shelter safe."
            });
        }
        public List<Department> SelectShelterDepartments(string shelterID) {
            return fakeDepartments.Where(x => x.ShelterID == shelterID).ToList();
        }
    }
}
