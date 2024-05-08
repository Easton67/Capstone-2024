using DataObjects;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DataObjects.Enums;

namespace LogicLayer
{
    public interface IUserManager
    {
        string HashSha256(string source);
        AuthenticationType AuthenticateUser(string userName, string password);


        User SelectClientByID(string email);
        ClientVM SelectClientVM(string userID);
        User SelectEmployeeByID(string email);
        User SelectVolunteerByID(string email);
        //User SelectUserByID(Enums.AuthenicationType userType, string email);
        List<Employee> SelectAllEmployeesWithRoles();
        List<Role> SelectAllRoles();
        List<Employee> SelectSpecificRoles(string RoleID);
        EmployeePass SelectEmployeePasswordHashByEmployeeID(string employeeID);
        bool UpdateEmployeePasswordHash(string employeeID, string oldPasswordHash, string newPasswordHash);
        List<Employee> GetDepartmentEmployees(int departmentID);
        List<string> GetAllEmployeeIDs();
        List<Employee> SelectAllEmployees();
        List<Client> GetAllClients();
        List<Volunteer> SelectAllVolunteers();

        /// <summary>
        /// Creator:            Darryl Shirley
        /// Created:            03/05/2024
        /// Summary:            Creation of GetAllVolunteersAssignedToAnEvent, GetAllVolunteersNotAssignedToAnEvent, and AddVolunteerToEvent methods
        /// Last Updated By:    Darryl Shirley
        /// Last Updated:       03/05/2024
        /// What Was Changed:   Creation of GetAllVolunteersAssignedToAnEvent, GetAllVolunteersNotAssignedToAnEvent, and AddVolunteerToEvent methods
        /// </summary>
        List<Volunteer> GetAllVolunteersAssignedToAnEvent(int eventID);
        List<Volunteer> GetAllVolunteersNotAssignedToAnEvent(int eventID);
        bool AddVolunteerToEvent(string volunteerID, int eventID);

        /// <summary>
        /// Creator: Matthew Baccam
        /// Created: 03/21/2024
        /// Summary: Inserts a new user into the database
        /// Last Updated By: Matthew Baccam
        /// Last Updated: 03/21/2024
        /// What Was changed: Initial creation
        /// </summary>
        bool CreateNewUser(User user, string password);
        /// <summary>
        /// Creator: Matthew Baccam
        /// Created: 03/22/2024
        /// Summary: Check email availability. Returns false if it already exists otherwise true
        /// Last Updated By: Matthew Baccam
        /// Last Updated: 03/22/2024
        /// What Was changed: Initial creation
        /// </summary>
        bool EmailAvailability(string email);
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
        bool CreateEmployeeRoles(string employeeID, List<Role> roles);
        /// <summary>
        /// Creator: Matthew Baccam
        /// Created: 03/15/2024
        /// Summary: Removes users roles
        /// Last Updated By: Matthew Baccam
        /// Last Updated: 03/15/2024
        /// What Was changed: Initial creation
        /// </summary>
        bool RemoveEmployeeRoles(string employeeID, List<Role> roles);


        /// <summary>
        /// Creator: Marwa Ibrahim
        /// Created: 03/27/2024
        /// Summary: change Client Password method
        /// Last Updated By: Marwa Ibrahim
        /// Last Updated: 03/27/2024
        /// What Was changed: Initial creation
        /// </summary>
        bool changeClientPassword(string userID, string newPassword);

        /// <summary>
        /// Creator:            Ibrahim Albashair
        /// Created:            03/22/2024
        /// Summary:            created GetAllVolunteers
        /// Last Updated By:    Ibrahim Albashair
        /// Last Updated:       03/22/2024
        /// What Was Changed:   created GetAllVolunteers
        /// </summary>
        List<Volunteer> GetAllVolunteers();

        /// <summary>
        /// Creator:Andres Garcia
        /// Created: 04/19/2024
        /// Summary: Gets all clientIds
        /// Last Updated By: Andres Garcia
        /// Last Updated: 04/19/2024
        /// What was Changed: Initial Creation
        /// </summary>
        List<string> SelectAllClientIDs();
        /// <summary>
        /// Creator: Miyada Abas
        /// Created: 04/05/2024
        /// Summary: Deactivate Client Application
        /// Last Updated By: Miyada Abas
        /// Last Updated: 04/05/2024
        /// What Was changed: Initial creation
        /// </summary>
        bool DeactivateClientApplication(Client client);
        /// <summary>
        /// Creator:            Abdalgader Ibrahim
        /// Created:            03/29/2024
        /// Summary:            Creation of UpdateClientPassword method
        /// </summary>
        bool UpdateEmployeePassword(string employeeID, string v);
    }

}

