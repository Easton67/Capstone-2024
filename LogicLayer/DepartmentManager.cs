using DataAccessInterfaces;
using DataAccessLayer;
using DataObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer {
    /// <summary>
    /// Creator: Jared Harvey
    /// Created: 02/07/2024
    /// Summary: This class is responsible for managing the logic relating to departments.
    /// Last Updated By: Jared Harvey
    /// Last Updated: 02/07/2024
    /// What Was Changed: Initial Creation
    /// </summary>
    public class DepartmentManager : IDepartmentManager
    {
        private IDepartmentAccessor departmentAccessor = null;

        public DepartmentManager()
        {
            departmentAccessor = new DepartmentAccessor();
        }

        public DepartmentManager(IDepartmentAccessor departmentAccessor)
        {
            this.departmentAccessor = departmentAccessor;
        }

        /// <summary>
        /// Creator: Jared Harvey
        /// Created: 02/07/2024
        /// Summary: This method gets the list of departments
        /// Parameters: string shelterID
        /// Returns: List<Department>
        /// Last Updated By: Jared Harvey
        /// Last Updated: 02/07/2024
        /// What Was Changed: Initial Creation
        /// </summary>
        public List<Department> GetShelterDepartments(string shelterID)
        {
            List<Department> result = new List<Department>();
            try 
			{
                result = departmentAccessor.SelectShelterDepartments(shelterID);
            }
            catch (Exception ex) 
			{
                throw ex;
            }
            return result;
        }
    }
}
