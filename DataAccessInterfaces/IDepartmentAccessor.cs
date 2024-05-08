using DataObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessInterfaces 
{
    /// <summary>
    /// Creator: Jared Harvey
    /// Created: 02/08/2024
    /// Summary: This class is an interface for DepartmentAccessor
    /// Last Updated By: Jared Harvey
    /// Last Updated: 02/08/2024
    /// What Was Changed: Initial Creation
    /// </summary>
    public interface IDepartmentAccessor {
        List<Department> SelectShelterDepartments(string shelterID);
    }
}
