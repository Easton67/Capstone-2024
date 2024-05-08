using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataObjects 
{
    /// <summary>
    /// Creator: Jared Harvey
    /// Created: 02/07/2024
    /// Summary: A model class that allows the system to store data from the Department table in the database.
    /// Last Updated By: Jared Harvey
    /// Last Updated: 02/07/2024
    /// What Was Changed: Initial Creation
    /// </summary>
    public class Department {

        public int DepartmentID { get; set; }
        public string ShelterID { get; set; }
        public string DepartmentName { get; set; }
        public string Description { get; set; }
    }
}
