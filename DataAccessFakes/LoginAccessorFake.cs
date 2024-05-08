using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessInterfaces;
using DataObjects;

namespace DataAccessFakes
{
    /// <summary>
    /// Creator: Miyada Abas         
    /// Created: 02/27/2024
    /// Summary: Interface for login accessor.
    /// Last Updated By: Miyada Abas
    /// Last Updated: 02/27/2024
    /// What Was Changed: created.
    /// </summary>
    public class LoginAccessorFake : LoginAccessorInterFace
    {
        List<Employee> employees;

        public LoginAccessorFake()
        {
            employees = new List<Employee>();   
        }

        public bool signUp(EmployeePass employee)
        {
           
            int listSizeBeforeAdd = employees.Count;
            employees.Add(employee);
            int listSizeAfterAdd = employees.Count;
            return (listSizeAfterAdd - listSizeBeforeAdd > 0);
        }
    }
}
