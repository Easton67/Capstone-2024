using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataObjects
{
    public class Role
    {
        public string RoleID { get; set; }
        public string Description { get; set; }
        public int DepartmentID { get; set; }
        public int PositionsAvailable { get; set; }
    }
}
