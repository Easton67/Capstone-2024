using DataObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessInterfaces
{
    public interface IUserAccessor
    {

        #region Tylers'
        User SelectEmployeeByID(string email);
        User SelectVolunteerByID(string email);
        User SelectClientByID(string email);
        bool AuthenticateVolunteerWithNameAndPasswordHash(string email, string password);
        bool AuthenticateClientWithNameAndPasswordHash(string userName, string passwordHash);
        bool AuthenticateEmployeeWithNameAndPasswordHash(string userName, string passwordHash);
        List<Role> SelectEmployeeRoles(string email);
        Role SelectVolunteerRole(string email);
        #endregion

        /// <summary>
        /// Creator:            Liam Easton
        /// Created:            01/30/2024
        /// Summary:            Creation of UpdateEmployeePasswordHash method
        /// Last Updated By:    Tyler Barz
        /// Last Updated:       02/23/2024
        /// What Was Changed:   Moved into IUserAccessor
        /// </summary>
        int UpdateEmployeePasswordHash(string employeeID, string oldPasswordHash, string newPasswordHash);
        EmployeePass SelectEmployeePasswordHashByEmployeeID(string employeeID);
        List<Volunteer> SelectAllVolunteers();
        List<Client> SelectAllClients();
        /// <summary>
        /// Creator: Jared Harvey
        /// Created: 02/15/2024
        /// Summary: Creation of SelectDepartmentEmployees method
        /// Last Updated By: Jared Harvey
        /// Last Updated: 02/15/2024
        /// What Was Changed: Initial Creation
        /// </summary>
        List<Employee> SelectDepartmentEmployees(int departmentID);
        /// <summary>
        /// Creator:            Darryl Shirley
        /// Created:            02/21/2024
        /// Summary:            Creation of SelectAllEmployeeIDs method
        /// Last Updated By:    Darryl Shirley
        /// Last Updated:       02/21/2024
        /// What Was Changed:   Creation of SelectAllEmployeeIDs method
        /// </summary>
        List<string> SelectAllEmployeeIDs();
        /// <summary>
        /// Creator:            Liam Easton
        /// Created:            01/30/2024
        /// Summary:            Creation of SelectAllEmployees method
        /// Last Updated By:    Liam Easton
        /// Last Updated:       01/30/2024
        /// What Was Changed:   Creation of SelectAllEmployees method
        /// </summary>
        List<Employee> SelectAllEmployees();

        /// <summary>
        /// Creator:            Darryl Shirley
        /// Created:            03/05/2024
        /// Summary:            Creation of SelectAllVolunteersAssignedToEvent, SelectAllVolunteersNotAssignedToEvent, and addVolunteerToEvent methods
        /// Last Updated By:    Darryl Shirley
        /// Last Updated:       03/05/2024
        /// What Was Changed:   Creation of SelectAllVolunteersAssignedToEvent, SelectAllVolunteersNotAssignedToEvent, and addVolunteerToEvent methods
        /// </summary>
        List<Volunteer> SelectAllVolunteersAssignedToEvent(int eventID);
        List<Volunteer> SelectAllVolunteersNotAssignedToEvent(int eventID);
        int addVolunteerToEvent(string volunteerID, int eventID);

        /// <summary>
        /// Creator:            Liam Easton
        /// Created:            03/4/2024
        /// Summary:            Creation of SelectSpecificRoles method
        /// Last Updated By:    Liam Easton
        /// Last Updated:       03/4/2024
        /// What Was Changed:   Creation of SelectSpecificRoles method
        /// </summary>
        List<Employee> SelectSpecificRoles(string RoleID);
        /// <summary>
        /// Creator:            Liam Easton
        /// Created:            03/4/2024
        /// Summary:            Creation of SelectAllRoles method
        /// Last Updated By:    Liam Easton
        /// Last Updated:       03/4/2024
        /// What Was Changed:   Creation of SelectAllRoles method
        /// </summary>
        List<Role> SelectAllRoles();
        /// <summary>
        /// Creator: Matthew Baccam
        /// Created: 03/08/2024
        /// Summary: Creates a ClientVM
        /// Last Updated By: Matthew Baccam
        /// Last Updated: 03/08/2024
        /// What Was changed: Initial creation
        /// </summary>
        User SelectClientVM(string userID);

        /// <summary>
        /// Creator: Matthew Baccam
        /// Created: 03/22/2024
        /// Summary: Check email availability
        /// Last Updated By: Matthew Baccam
        /// Last Updated: 03/22/2024
        /// What Was changed: Initial creation
        /// </summary>
        bool CheckEmailAvailability(string email);
        /// <summary>
        /// Creator: Matthew Baccam
        /// Created: 03/21/2024
        /// Summary: Inserts a new user into the database
        /// Last Updated By: Matthew Baccam
        /// Last Updated: 03/21/2024
        /// What Was changed: Initial creation
        /// </summary>
        bool InsertNewUser(User user, string passwordHash);
        /// <summary>
        /// Creator: Matthew Baccam
        /// Created: 03/15/2024
        /// Summary: Updates updates users details
        /// Last Updated By: Matthew Baccam
        /// Last Updated: 03/15/2024
        /// What Was changed: Initial creation
        /// </summary>
        bool UpdateUserDetails(User newUser, User oldUser);
        /// <summary>
        /// Creator: Matthew Baccam
        /// Created: 03/15/2024
        /// Summary: Inserts users roles
        /// Last Updated By: Matthew Baccam
        /// Last Updated: 03/15/2024
        /// What Was changed: Initial creation
        /// </summary>
        bool InsertEmployeeRoles(string employeeID, List<Role> roles);
        /// <summary>
        /// Creator: Matthew Baccam
        /// Created: 03/15/2024
        /// Summary: Deletes users roles
        /// Last Updated By: Matthew Baccam
        /// Last Updated: 03/15/2024
        /// What Was changed: Initial creation
        /// </summary>
        bool DeleteEmployeeRoles(string employeeID, List<Role> roles);


        /// <summary>
        /// Creator: Marwa Ibrahim
        /// Created: 03/15/2024
        /// Summary: update client password
        /// Last Updated By: Marwa Ibrahim
        /// Last Updated: 03/15/2024
        /// What Was changed: Initial creation
        /// </summary>
        bool UpdateClientPassword(string userID, string v);


        /// <summary>
        /// Creator:            Ibrahim Albashair
        /// Created:            03/4/2024
        /// Summary:            Creation of GetAllVolunteers method
        /// Last Updated By:    Liam Easton
        /// Last Updated:       03/18/2024
        /// What Was Changed:   Creation of GetAllVolunteers method
        /// </summary>
        List<Volunteer> GetAllVolunteers();



        /// <summary>
        /// Creator:            Andres Garcia
        /// Created:            04/19/2024
        /// Summary:            Gets all employeeIds
        /// Last Updated By:    Andres Garcia
        /// Last Updated:       04/19/2024
        /// What Was Changed:   Inital Create
        /// </summary>

        List<string> SelectAllClientIDs();
        /// <summary>
        /// Creator: Miyada Abas
        /// Created: 04/05/2024
        /// Summary: Deactivte Client Application
        /// Last Updated By: Miyada Abas
        /// Last Updated: 04/05/2024
        /// What Was changed: Initial creation
        /// </summary>
      
        bool DeactivteClientApplication(Client client);

        /// <summary>
        /// Creator:            Abdalgader Ibrahim
        /// Created:            04/11/2024
        /// Summary:            Creation of UpdateClientPassword method
        /// </summary>
        bool UpdateEmployeePassword(string employeeID, string v);
    }
}
