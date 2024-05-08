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

    /// <summary>
    /// Creator: Miyada Abas         
    /// Created: 02/27/2024
    /// Summary: Login manager for login activity
    /// Last Updated By: Miyada Abas
    /// Last Updated: 02/27/2024
    /// What Was Changed: Added StayManager
    /// </summary>
    public class LoginManger : LoginManagerInterFace
    {
        private LoginAccessorInterFace loginAccessor;

        public LoginManger(LoginAccessorInterFace loginAccessor)
        {
            this.loginAccessor = loginAccessor;
        }

        public LoginManger()
        {
            loginAccessor = new LoginAccessor();
        }

        /// <summary>
        /// Creator: Miyada Abas         
        /// Created: 02/27/2024
        /// Summary: Login manager for signup activity
        /// Last Updated By: Miyada Abas
        /// Last Updated: 02/27/2024
        /// What Was Changed: Added StayManager
        /// </summary>
        public bool SignUp(EmployeePass employee)
        {
            bool result = true;
            try
            {
                result = loginAccessor.signUp(employee);
                
            }
            catch (Exception)
            {

                throw;
            }
            return result;
        }
    
    }
}
