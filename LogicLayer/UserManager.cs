using DataObjects;
using DataAccessFakes;
using DataAccessInterfaces;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using static DataObjects.Enums;
using System.Collections;
using System.Text.RegularExpressions;

namespace LogicLayer
{
    /// <summary>
    /// Creator:            Tyler Barz
    /// Created:            02/14/2024
    /// Summary:            User Manager for accessing user details
    /// Last Updated By:    Tyler Barz
    /// Last Updated:       02/14/2024
    /// What Was Changed:   Inital creation
    /// </summary>
    public class UserManager : IUserManager
    {
        private IUserAccessor _userAccessor = null;

        public UserManager()
        {
            _userAccessor = new UserAccessor();
        }
        public UserManager(IUserAccessor userAccessor)
        {
            _userAccessor = userAccessor;
        }

        /*
          <summary>
          Creator: Tyler Barz
          Created: 02/14/2024
          Summary: Select Client By ID method
          Last Updated By: Tyler Barz
          Last Updated: 03/02/2024
          What was Changed: Added exception catch
          </summary>
        */
        public User SelectClientByID(string email)
        {
            try
            {
                Client user = _userAccessor.SelectClientByID(email) as Client;
                if (user == null || user.IsEmpty)
                {
                    throw new InvalidOperationException("User does not exist");
                }
                return user;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("An error occured when retrieving Client information", ex);
            }
        }

        /*
          <summary>
          Creator: Tyler Barz
          Created: 02/14/2024
          Summary: Select Employee By ID method
          Last Updated By: Tyler Barz
          Last Updated: 03/03/2024
          What was Changed: Added role selection
          </summary>
        */
        public User SelectEmployeeByID(string email)
        {
            try
            {
                Employee user = _userAccessor.SelectEmployeeByID(email) as Employee;
                if (user == null || user.IsEmpty)
                {
                    throw new InvalidOperationException("User does not exist");
                }
                user.Roles = _userAccessor.SelectEmployeeRoles(email);
                return user;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("An error occured when retrieving Employee information", ex);
            }
        }

        /*
          <summary>
          Creator: Tyler Barz
          Created: 02/14/2024
          Summary: Select Volunteer By ID method
          Last Updated By: Tyler Barz
          Last Updated: 03/03/2024
          What was Changed: Added role selection
          </summary>
        */
        public User SelectVolunteerByID(string email)
        {
            try
            {
                Volunteer user = _userAccessor.SelectVolunteerByID(email) as Volunteer;
                if (user == null || user.IsEmpty)
                {
                    throw new InvalidOperationException("Volunteer does not exist");
                }
                // Too late to change database table logic, so just making a list is easiest.
                user.Roles = new List<Role> { _userAccessor.SelectVolunteerRole(email) };

                return user;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("An error occured when retrieving Volunteer information", ex);
            }
        }


        /// <summary>
        /// Creator: Tyler Barz
        /// Created: 04/03/2024
        /// Summary: Select all volunteers
        /// Last Updated By: Tyler Barz
        /// Last Updated: 04/03/2024
        /// What was Changed: Inital Creation
        /// </summary>

        public List<Volunteer> SelectAllVolunteers()
        {
            try
            {
                return _userAccessor.SelectAllVolunteers();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("An error occured when retrieving Volunteer information", ex);
            }
        }

        /// <summary>
        /// Creator: Sagan DeWald
        /// Created: 1/31/2024
        /// Summary: Input a string, returns a SHA-256 hash of it. Used to verify passwords when logging in.
        /// Last Updated By: Tyler Barz
        /// Last Updated: 02/25/2024
        /// What was Changed: Completely rewrote method body
        ///                   Shortened code majorly
        /// </summary>
        public string HashSha256(string source)
        {
            byte[] data = SHA256.Create().ComputeHash(Encoding.UTF8.GetBytes(source));
            return string.Join("", data.Select(b => b.ToString("x2")));
        }

        //<summary>
        //Creator: Sagan DeWald
        //Created: 1/31/2024
        //Summary: Input a username and password, return a userType integer representing the account type successfully authenticated.
        /*
         * userType Legend:
         * 0: Authentication failed.
         * 1: Client.
         * 2: Employee.
         * 3: Volunteer.
         */
        //Last Updated By: Tyler Barz
        //Last Updated: 02/23/2024
        //What was Changed: Commented out client auth call since they have no access on desktop
        ///Last Updated By:    Mitchell Stirmel
        ///Last Updated        04/10/2024
        ///What was changed:   Added try/catch and code cleanup
        //                  Removed == true
        //</summary>
        public AuthenticationType AuthenticateUser(string userName, string password)
        {
            try
            {
                AuthenticationType userType = AuthenticationType.Unauthorized;
                string passwordHash = HashSha256(password);

                // Is the user a Client?
                //if (_clientAccessor.AuthenticateClientWithNameAndPasswordHash(userName, passwordHash) == true)
                //{
                //    return 1;
                //}

                // Is the user an Employee?
                if (_userAccessor.AuthenticateEmployeeWithNameAndPasswordHash(userName, passwordHash))
                {
                    userType = AuthenticationType.Employee;
                }

                // Is the user a Volunteer?
                else if (_userAccessor.AuthenticateVolunteerWithNameAndPasswordHash(userName, passwordHash))
                {
                    userType = AuthenticationType.Volunteer;
                }

                return userType;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Unable to authenticate", ex);
            }

        }

        /// <summary>
        /// Creator:            Liam Easton
        /// Created:            01/30/2024
        /// Summary:            Creation of UpdateEmployeePasswordHash method
        /// Last Updated By:    Liam Easton
        /// Last Updated:       01/30/2024
        /// What Was Changed:   Creation of UpdateEmployeePasswordHash method
        /// </summary>
        public bool UpdateEmployeePasswordHash(string employeeID, string oldPasswordHash, string newPasswordHash)
        {
            bool result = false;
            newPasswordHash = HashSha256(newPasswordHash);

            try
            {
                result = (1 == _userAccessor.UpdateEmployeePasswordHash(employeeID, oldPasswordHash, newPasswordHash));
            }
            catch (Exception ex)
            {
                throw new ApplicationException("User or password not found.", ex);
            }
            return result;
        }

        /// <summary>
        /// Creator:            Liam Easton
        /// Created:            02/01/2024
        /// Summary:            Creation of SelectPasswordHashByEmail method
        /// Last Updated By:    Liam Easton
        /// Last Updated:       02/01/2024
        /// What Was Changed:   Creation of SelectPasswordHashByEmail method
        /// </summary>
        public EmployeePass SelectEmployeePasswordHashByEmployeeID(string employeeID)
        {
            EmployeePass employeePass = null;

            try
            {
                employeePass = _userAccessor.SelectEmployeePasswordHashByEmployeeID(employeeID);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Unable to find your old password. ", ex);
            }
            return employeePass;
        }

        /// <summary>
        /// Creator: Jared Harvey
        /// Created: 02/19/2024
        /// Summary: Creation of GetAllClients
        /// Last Updated By: Jared Harvey
        /// Last Updated: 02/19/2024
        /// What Was Changed: Initial Creation
        /// </summary>
        public List<Client> GetAllClients()
        {
            List<Client> result = new List<Client>();
            try
            {
                result = _userAccessor.SelectAllClients();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }

        /// <summary>
        /// Creator:            Darryl Shirley
        /// Created:            02/21/2024
        /// Summary:            GetAllEmployeeIDs method
        /// Last Updated By:    Darryl Shirley
        /// Last Updated:       02/21/2024
        /// What Was Changed:   Initial Creation
        /// </summary>
        public List<string> GetAllEmployeeIDs()
        {
            List<string> employeeIDs = new List<string>();
            try
            {
                employeeIDs = _userAccessor.SelectAllEmployeeIDs();
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Failed to get a list of employee IDs", ex);
            }

            return employeeIDs;
        }

        /// <summary>
        /// Creator:            Jared Harvey
        /// Created:            02/07/2024
        /// Summary:            Creation of GetDepartmentEmployees method
        /// Last Updated By:    Jared Harvey
        /// Last Updated:       02/07/2024
        /// What Was Changed:   Initial Creation
        /// </summary>
        public List<Employee> GetDepartmentEmployees(int departmentID)
        {
            List<Employee> result = new List<Employee>();
            try
            {
                result = _userAccessor.SelectDepartmentEmployees(departmentID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }

        /// <summary>
        /// Creator:            Liam Easton
        /// Created:            02/23/2024
        /// Summary:            Creation of SelectAllEmployees method
        /// Last Updated By:    Tyler Barz
        /// Last Updated:       04/12/2024
        /// What Was Changed:   Added employee roles
        /// </summary>
        public List<Employee> SelectAllEmployees()
        {
            List<Employee> employees = new List<Employee>();
            try
            {
                employees = _userAccessor.SelectAllEmployees();
            }
            catch
            {
                throw;
            }
            return employees;
        }

        /// <summary>
        /// Creator:            Tyler Barz
        /// Created:            04/13/2024
        /// Summary:            Return employees with roles since adding to select all breaks other logic
        /// Last Updated By:    Tyler Barz
        /// Last Updated:       04/13/2024
        /// What Was Changed:   
        /// </summary>
        public List<Employee> SelectAllEmployeesWithRoles()
        {
            List<Employee> employees = new List<Employee>();
            try
            {
                employees = _userAccessor.SelectAllEmployees().Select(emp =>
                {
                    emp.Roles = _userAccessor.SelectEmployeeRoles(emp.EmployeeID);
                    return emp;
                }).ToList();
            }
            catch
            {
                throw;
            }
            return employees;
        }

        public List<Employee> SelectSpecificRoles(string RoleID)
        {
            List<Employee> result = new List<Employee>();
            try
            {
                result = _userAccessor.SelectSpecificRoles(RoleID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }

        public List<Role> SelectAllRoles()
        {
            try
            {
                List<Role> roles = _userAccessor.SelectAllRoles();
                return roles;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Creator: Matthew Baccam
        /// Created: 03/07/2024
        /// Summary: Created SelectClientVM 
        /// Last Updated By: Matthew Baccam
        /// Last Updated: 03/07/2024
        /// What Was Changed: Initial Creation
        /// </summary>
        public ClientVM SelectClientVM(string userID)
        {
            try
            {
                var clientVM = _userAccessor.SelectClientVM(userID);
                if (clientVM == null || clientVM.IsEmpty)
                {
                    throw new InvalidOperationException("User does not exist");
                }
                return clientVM as ClientVM;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("An error occurred when retrieving user information", ex);
            }
        }

        /// <summary>
        /// Creator:            Darryl Shirley
        /// Created:            03/05/2024
        /// Summary:            Creation of GetAllVolunteersAssignedToAnEvent method
        /// Last Updated By:    Darryl Shirley
        /// Last Updated:       03/05/2024
        /// What Was Changed:   Initial Creation
        /// </summary>
        public List<Volunteer> GetAllVolunteersAssignedToAnEvent(int eventID)
        {
            List<Volunteer> volunteers = new List<Volunteer>();
            try
            {
                volunteers = _userAccessor.SelectAllVolunteersAssignedToEvent(eventID);
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message, ex);
            }
            return volunteers;
        }

        /// <summary>
        /// Creator:            Darryl Shirley
        /// Created:            03/05/2024
        /// Summary:            Creation of GetAllVolunteersNotAssignedToAnEvent method
        /// Last Updated By:    Darryl Shirley
        /// Last Updated:       03/05/2024
        /// What Was Changed:   Initial Creation
        /// </summary>
        public List<Volunteer> GetAllVolunteersNotAssignedToAnEvent(int eventID)
        {
            List<Volunteer> volunteers = new List<Volunteer>();
            try
            {
                volunteers = _userAccessor.SelectAllVolunteersNotAssignedToEvent(eventID);
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message, ex);
            }
            return volunteers;
        }

        /// <summary>
        /// Creator:            Darryl Shirley
        /// Created:            03/05/2024
        /// Summary:            Creation of AddVolunteerToEvent method
        /// Last Updated By:    Darryl Shirley
        /// Last Updated:       03/05/2024
        /// What Was Changed:   Initial Creation
        /// </summary>
        public bool AddVolunteerToEvent(string volunteerID, int eventID)
        {
            bool result = false;

            try
            {
                result = (1 == _userAccessor.addVolunteerToEvent(volunteerID, eventID));
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Volunteer not added to event", ex);
            }
            return result;
        }

        /// <summary>
        /// Creator: Matthew Baccam
        /// Created: 03/21/2024
        /// Summary: Inserts a new user into the database
        /// Last Updated By: Matthew Baccam
        /// Last Updated: 03/21/2024
        /// What Was changed: Initial creation
        /// </summary>
        public bool CreateNewUser(User user, string password)
        {
            try
            {
                return _userAccessor.InsertNewUser(user, HashSha256(password));
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to create new user", ex);
            }
        }

        /// <summary>
        /// Creator: Matthew Baccam
        /// Created: 03/22/2024
        /// Summary: Check email availability
        /// Last Updated By: Matthew Baccam
        /// Last Updated: 03/22/2024
        /// What Was changed: Initial creation
        /// </summary>
        public bool EmailAvailability(string email)
        {
            try
            {
                return _userAccessor.CheckEmailAvailability(email);
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to check email availability", ex);
            }
        }

        /// <summary>
        /// Creator: Matthew Baccam
        /// Created: 03/15/2024
        /// Summary: Updates updates users details
        /// Last Updated By: Matthew Baccam
        /// Last Updated: 03/15/2024
        /// What Was changed: Initial creation
        /// </summary>
        public bool UpdateUserDetails(User newUser, User oldUser)
        {
            try
            {
                return _userAccessor.UpdateUserDetails(newUser, oldUser);
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to update users details", ex);
            }
        }

        /// <summary>
        /// Creator: Matthew Baccam
        /// Created: 03/15/2024
        /// Summary: Inserts users roles
        /// Last Updated By: Matthew Baccam
        /// Last Updated: 03/15/2024
        /// What Was changed: Initial creation
        /// </summary>
        public bool CreateEmployeeRoles(string employeeID, List<Role> roles)
        {
            try
            {
                return _userAccessor.InsertEmployeeRoles(employeeID, roles);
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to insert employees roles", ex);
            }
        }

        /// <summary>
        /// Creator: Matthew Baccam
        /// Created: 03/15/2024
        /// Summary: Removes users roles
        /// Last Updated By: Matthew Baccam
        /// Last Updated: 03/15/2024
        /// What Was changed: Initial creation
        /// </summary>
        public bool RemoveEmployeeRoles(string employeeID, List<Role> roles)
        {
            try
            {
                return _userAccessor.DeleteEmployeeRoles(employeeID, roles);
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to remove employees roles", ex);
            }
        }


        /// <summary>
        /// Creator:            Marwa Ibrahim
        /// Created:            03/27/2024
        /// Summary:            Creation of UpdateClientPassword method
        /// Last Updated By:    Marwa Ibrahim
        /// Last Updated:       03/27/2024
        /// What Was Changed:   Creation of UpdateClientPassword method
        /// </summary>
        /// 
        public bool changeClientPassword(string userID, string newPassword) {
            //changeClientPassword(client.UserID, newPassword);
            try
            {
                return _userAccessor.UpdateClientPassword(userID, HashSha256(newPassword));
            }

            catch (Exception ex)
            {

                throw ex;
            }
        }


        /// <summary>
        /// Creator: Ibrahim Albashair
        /// Created: 02/10/2024
        /// Summary: Created GetAllVolunteers
        /// Last Updated By: Ibrahim Albashair
        /// Last Updated 03/18/2024
        /// What was changed: Initial Creation.
        /// </summary>
        public List<Volunteer> GetAllVolunteers()
        {
            List<Volunteer> volunteers = new List<Volunteer>();

            try
            {
                volunteers = _userAccessor.GetAllVolunteers();
            }
            catch (Exception ex)
            {

                throw new ApplicationException("Unable to fetch Volunteers", ex);
            }
            return volunteers;
        }

        /// <summary>
        /// Creator:Andres Garcia
        /// Created: 4/19/2024
        /// Summary: Selects all clientIds
        /// Last Updated: 1/30/2024
        /// What was Changed: Inital Creation
        /// </summary>
        public List<string> SelectAllClientIDs()
        {
            try
            {
                return _userAccessor.SelectAllClientIDs();
            }
            catch (Exception)
            {

                throw new Exception("Failed to retrieve client IDs");
            }
        }

        /// <summary>
        /// Creator: Miyada Abas
        /// Created: 04/04/2024
        /// Summary: Deactivate Client Apllication Method
        /// Last Updated By: Miyada Abas
        /// Last Updated: 04/04/2024
        /// What was Changed: 
        /// </summary>
        public bool DeactivateClientApplication(Client client)
        {
            bool result = false;
            client.AccountStatus = false;
            result = _userAccessor.DeactivteClientApplication(client);
            return result;
        }

        /// <summary>
        /// Creator:            Abdalgader Ibrahim
        /// Created:            04/18/2024
        /// Summary:            Creation of UpdateEmployeePassword method
        /// </summary>
        public bool UpdateEmployeePassword(string employeeID, string v)
        {
            try
            {
                return _userAccessor.UpdateEmployeePassword(employeeID, HashSha256(v));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }

    }


       


        
