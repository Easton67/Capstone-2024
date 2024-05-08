using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using DataAccessInterfaces;
using DataObjects;

namespace LogicLayer
{
    public interface LoginManagerInterFace
    {
        bool SignUp(EmployeePass employee);
       
    }
}
