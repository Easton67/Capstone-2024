using DataAccessInterfaces;
using DataObjects;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessFakes
{
    /// <summary>
    /// Creator:            Tyler Barz
    /// Created:            02/14/2024
    /// Summary:            Data fakes for users
    /// Last Updated By:    Darryl Shirley
    /// Last Updated:       03/05/2024
    /// What Was Changed:   added 3 new methods
    /// </summary>
    public class UserAccessFakes : IUserAccessor
    {
        private List<User> users = new List<User>();

        private EventAccessorFakes events = new EventAccessorFakes();

        private List<Employee> fakeEmployees = new List<Employee>();
        private List<string> passwordHashes = new List<string>();
        private List<Role> fakeRoles = new List<Role>();
        private DateTime _currentDate = DateTime.Now;

        /// <summary>
        /// Creator: Abdalgader Ibrahim 
        /// Created: 04/11/2024
        /// Summary: create employees List
        /// </summary>
        private List<Employee> employees = new List<Employee>();
        public UserAccessFakes()
        {
            users.Add(new Client() { UserID = "test@test.com", FirstName = "test", LastName = "tester", RegistrationDate = DateTime.Now });
            users.Add(new Employee() { UserID = "tester@test.com", FirstName = "emp1", LastName = "emplast", StartDate = DateTime.Now, Roles = new List<Role>() { new Role() { RoleID = "CEO", Description = "TEST" } } });
            users.Add(new Employee() { UserID = "testee@test.com", FirstName = "emp2", LastName = "emplast", StartDate = DateTime.Now, Roles = new List<Role>() { new Role() { RoleID = "CEO", Description = "TEST" } } });
            users.Add(new Volunteer() { UserID = "tested@test.com", FirstName = "vol1", LastName = "vollast", RegistrationDate = DateTime.Now, Roles = new List<Role>() { new Role() { RoleID = "CEO", Description = "TEST" } } });
            users.Add(new Volunteer() { UserID = "testing@test.com", FirstName = "vol2", LastName = "vollast", RegistrationDate = DateTime.Now, Roles = new List<Role>() { new Role() { RoleID = "CEO", Description = "TEST" } } });
            users.Add(new Volunteer() { UserID = "tommy@gmail.com", FirstName = "Tommy", LastName = "Pickles", RegistrationDate = DateTime.Now, Roles = new List<Role>() { new Role() { RoleID = "CEO", Description = "TEST" } } });
            users.Add(new Volunteer() { UserID = "christine@hotmail.com", FirstName = "Christine", LastName = "Annatol", RegistrationDate = DateTime.Now, Roles = new List<Role>() { new Role() { RoleID = "CEO", Description = "TEST" } } });
            users.Add(new Volunteer() { UserID = "jimmy@yahoo.com", FirstName = "Jimmy", LastName = "tomboy", RegistrationDate = DateTime.Now, Roles = new List<Role>() { new Role() { RoleID = "CEO", Description = "TEST" } } });

            fakeRoles.Add(new Role() { RoleID = "CEO", Description = "Boss" });
            fakeRoles.Add(new Role() { RoleID = "Maintenance Manager", Description = "Manager Of maintenance tasks" });
            fakeRoles.Add(new Role() { RoleID = "Front Desk Helper", Description = "Front desk greeter" });
            fakeRoles.Add(new Role() { RoleID = "Security Manager", Description = "Leader of security" });
            fakeRoles.Add(new Role() { RoleID = "Cook", Description = "cooks food for the homeless" });


            fakeEmployees.Add(new Employee()
            {
                EmployeeID = "Liam@gmail.com",
                FirstName = "Liam",
                LastName = "Easton",
                Gender = true,
                AccountStatus = true,
                StartDate = DateTime.Now,
                EndDate = null,
                Roles = new List<Role>()
                {
                    new Role() {RoleID = "CEO", Description="TEST"}
                }
            });

            fakeEmployees.Add(new Employee()
            {
                EmployeeID = "Matt@gmail.com",
                FirstName = "Matt",
                LastName = "Baccam",
                Gender = true,
                AccountStatus = true,
                StartDate = DateTime.Now,
                EndDate = null,
                Roles = new List<Role>()
                {
                    new Role() {RoleID = "CEO", Description="TEST"}
                }
            });

            fakeEmployees.Add(new Employee()
            {
                EmployeeID = "Tyler@gmail.com",
                FirstName = "Tyler",
                LastName = "Jelic",
                Gender = true,
                AccountStatus = true,
                StartDate = DateTime.Now,
                EndDate = null,
                Roles = new List<Role>()
                {
                    new Role() {RoleID = "Maintenance Manager", Description="TEST"}
                }
            });

            fakeEmployees.Add(new Employee()
            {
                EmployeeID = "Anthony@gmail.com",
                FirstName = "Anthony",
                LastName = "Talamantes",
                Gender = true,
                AccountStatus = true,
                StartDate = DateTime.Now,
                EndDate = null,
                Roles = new List<Role>()
                {
                    new Role() {RoleID = "CEO", Description="TEST"}
                }
            });

            fakeEmployees.Add(new Employee()
            {
                EmployeeID = "Andrew@gmail.com",
                FirstName = "Andrew",
                LastName = "Larson",
                Gender = true,
                AccountStatus = true,
                StartDate = DateTime.Now,
                EndDate = null,
                Roles = new List<Role>()
                {
                    new Role() {RoleID = "CEO", Description="TEST"}
                }
            });


            passwordHashes.Add("5e884898da28047151d0e56f8dc6292773603d0d6aabbdd62a11ef721d1542d8");
            passwordHashes.Add("5e884898da28047151d0e56f8dc6292773603d0d6aabbdd62a11ef721d1542d8");
            passwordHashes.Add("5e884898da28047151d0e56f8dc6292773603d0d6aabbdd62a11ef721d1542d8");
            passwordHashes.Add("5e884898da28047151d0e56f8dc6292773603d0d6aabbdd62a11ef721d1542d8");
            passwordHashes.Add("5e884898da28047151d0e56f8dc6292773603d0d6aabbdd62a11ef721d1542d8");
        }

        /// <summary>
        /// Creator:            Tyler Barz
        /// Created:            02/15/2024
        /// Summary:            Select client by id method
        /// Last Updated By:    Tyler Barz
        /// Last Updated:       02/15/2024
        /// What Was Changed:   Inital Creation
        /// </summary>
        public User SelectClientByID(string email)
        {
            try
            {
                return (Client)SelectUserByID(email);
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Creator:            Tyler Barz
        /// Created:            02/15/2024
        /// Summary:            Select Employee by id method
        /// Last Updated By:    Tyler Barz
        /// Last Updated:       02/15/2024
        /// What Was Changed:   Inital Creation
        /// </summary>
        public User SelectEmployeeByID(string email)
        {
            try
            {
                return (Employee)SelectUserByID(email);

            }
            catch 
            {
                throw;
            }
        }

        /// <summary>
        /// Creator:            Tyler Barz
        /// Created:            02/15/2024
        /// Summary:            Select Volunteer by id method
        /// Last Updated By:    Tyler Barz
        /// Last Updated:       02/15/2024
        /// What Was Changed:   Inital Creation
        /// </summary>
        public User SelectVolunteerByID(string email)
        {
            try
            {
                return (Volunteer)SelectUserByID(email);
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Creator:            Tyler Barz
        /// Created:            02/12/2024
        /// Summary:            Main method called upon selection methods
        /// Last Updated By:    Tyler Barz
        /// Last Updated:       02/12/2024
        /// What Was Changed:   Inital Creation
        /// </summary>
        private User SelectUserByID(string email)
        {
            // since this has a loaded list of 'all' users, can just return on the userID
            // instead of checking usertype
            try
            {
                User user = users.FirstOrDefault(u => u.UserID == email);
                return user;
            }
            catch (NullReferenceException ex)
            {
                throw ex;
            }
        }

        public bool AuthenticateVolunteerWithNameAndPasswordHash(string userName, string passwordHash)
        {
            var sampleUsers = new Dictionary<string, string>();
            sampleUsers.Add("newuser", "9c9064c59f1ffa2e174ee754d2979be80dd30db552ec03e7e327e9b1a4bd594e");
            sampleUsers.Add("olduser", "d7d97e37799e059c189486d89f6e1db1e4058c33bb7a7ce46db4811f5506a6bd");
            sampleUsers.Add("middleuser@gmail.com", "78aef08ecff3dafe3d55f09e48e1ce15eb74603aa22f8611d057937a98f16f6b");

            foreach (KeyValuePair<string, string> user in sampleUsers)
            {
                if (user.Key == userName && user.Value == passwordHash)
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Creator:            Liam Easton
        /// Created:            01/31/2024
        /// Summary:            Creation of UpdateEmployeePasswordHash class
        /// Last Updated By:    Liam Easton
        /// Last Updated:       01/31/2024
        /// What Was Changed:   Creation of UpdateEmployeePasswordHash class
        /// </summary>
        public int UpdateEmployeePasswordHash(string employeeID, string oldPasswordHash, string newPasswordHash)
        {
            int rows = 0;

            for (int i = 0; i < fakeEmployees.Count; i++)
            {
                if (fakeEmployees[i].EmployeeID == employeeID)
                {
                    if (passwordHashes[i] == oldPasswordHash)
                    {
                        passwordHashes[i] = newPasswordHash;
                        rows += 1;
                        break;
                    }
                }
            }
            if (rows != 1)
            {
                throw new ApplicationException("Bad Email or Password");
            }
            return rows;
        }

        /// <summary>
        /// Creator:            Liam Easton
        /// Created:            01/31/2024
        /// Summary:            Creation of SelectEmployeePasswordHashByEmployeeId class
        /// Last Updated By:    Liam Easton
        /// Last Updated:       01/31/2024
        /// What Was Changed:   Creation of SelectEmployeePasswordHashByEmployeeId class
        /// </summary>
        public EmployeePass SelectEmployeePasswordHashByEmployeeID(string employeeID)
        {
            EmployeePass employeePass = null;

            for (int i = 0; i < fakeEmployees.Count; i++)
            {
                if (fakeEmployees[i].EmployeeID == employeeID)
                {
                    employeePass = new EmployeePass { PasswordHash = passwordHashes[i] };
                    break;
                }
            }
            if (employeePass == null)
            {
                throw new ApplicationException("Bad Email or Password");
            }
            return employeePass;
        }

        /// <summary>
        /// Creator:            Sagan DeWald
        /// Created:            02/16/2024
        /// Summary:            Create a few fake users, then try to match the userName and passwordHash to them.
        /// Last Updated By:    Sagan DeWald
        /// Last Updated:       02/16/2024
        /// What Was Changed:   Initial creation.
        /// </summary>

        public bool AuthenticateEmployeeWithNameAndPasswordHash(string userName, string passwordHash)
        {
            var sampleUsers = new Dictionary<string, string>();
            sampleUsers.Add("newuser", "9c9064c59f1ffa2e174ee754d2979be80dd30db552ec03e7e327e9b1a4bd594e");
            sampleUsers.Add("olduser@gmail.com", "d7d97e37799e059c189486d89f6e1db1e4058c33bb7a7ce46db4811f5506a6bd");
            sampleUsers.Add("middleuser", "78aef08ecff3dafe3d55f09e48e1ce15eb74603aa22f8611d057937a98f16f6b");

            foreach (KeyValuePair<string, string> user in sampleUsers)
            {
                if (user.Key == userName && user.Value == passwordHash)
                {
                    return true;
                }
            }

            return false;
        }

        public bool AuthenticateClientWithNameAndPasswordHash(string userName, string passwordHash)
        {
            var sampleUsers = new Dictionary<string, string>();
            sampleUsers.Add("newuser@gmail.com", "9c9064c59f1ffa2e174ee754d2979be80dd30db552ec03e7e327e9b1a4bd594e");
            sampleUsers.Add("olduser", "d7d97e37799e059c189486d89f6e1db1e4058c33bb7a7ce46db4811f5506a6bd");
            sampleUsers.Add("middleuser", "78aef08ecff3dafe3d55f09e48e1ce15eb74603aa22f8611d057937a98f16f6b");

            foreach (KeyValuePair<string, string> user in sampleUsers)
            {
                if (user.Key == userName && user.Value == passwordHash)
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Creator:            Darryl Shirley
        /// Created:            02/21/2024
        /// Summary:            SelectAllEmployeeIDs method
        /// Last Updated By:    Tyler Barz
        /// Last Updated:       02/25/2024
        /// What Was Changed:   Removed unused caught exception
        /// </summary>
        public List<string> SelectAllEmployeeIDs()
        {
            List<string> employeeIDs = new List<string>();
            try
            {
                foreach (Employee emp in fakeEmployees)
                {
                    employeeIDs.Add(emp.EmployeeID);
                }
            }
            catch
            {
                throw new Exception("Could not get EmployeeIDs");
            }

            return employeeIDs;
        }

        /// <summary>
        /// Creator:            Jared Harvey
        /// Created:            03/05/2024
        /// Summary:            Fake accessor method for SelectAllClients.
        /// Last Updated By:    Jared Harvey
        /// Last Updated:       03/05/2024
        /// What Was Changed:   Inital Creation
        /// </summary>
        public List<Client> SelectAllClients() {
            List<Client> clients = new List<Client>();
            foreach(User c in users) {
                if (c.GetType() == typeof(Client)) clients.Add((Client)c);
            }
            return clients;
        }

        public List<Employee> SelectDepartmentEmployees(int departmentID)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Creator:            Liam Easton
        /// Created:            03/01/2024
        /// Summary:            Creation of SelectAllEmployees fakes method
        /// Last Updated By:    Liam Easton
        /// Last Updated:       03/01/2024
        /// What Was Changed:   Creation of SelectAllEmployees fakes method
        /// </summary>
        public List<Employee> SelectAllEmployees()
        {
            return fakeEmployees;
        }

        public List<Role> SelectEmployeeRoles(string email)
        {
            Employee user = new Employee();
            try
            {
                user = (Employee)users.FirstOrDefault(e => e.UserID == email);
            }
            catch { }
            return user.Roles;
        }

        public Role SelectVolunteerRole(string email)
        {
            Volunteer user = new Volunteer();
            try
            {
                user = (Volunteer)users.FirstOrDefault(e => e.UserID == email);
            }
            catch { }
            return user.Roles.First();
        }

        /// <summary>
        /// Creator:            Darryl Shirley
        /// Created:            03/05/2024
        /// Summary:            SelectAllVolunteersAssignedToEvent method
        /// Last Updated By:    Darryl Shirley
        /// Last Updated:       03/05/2024
        /// What Was Changed:   Initial Creation
        /// </summary>
        public List<Volunteer> SelectAllVolunteersAssignedToEvent(int eventID)
        {
            List<Volunteer> assigned = new List<Volunteer>();
            List<EventVolunteer> volunteers= new List<EventVolunteer>();

            List<EventVolunteer> vol = events.allEventVolunteers();

            foreach(User user in users)
            {
                if (user is Volunteer)
                {
                    foreach(EventVolunteer v in vol)
                    {
                        if (eventID == v.EventID)
                        {
                            if (user.UserID.Equals(v.VolunteerID))
                            {
                                assigned.Add((Volunteer)user);
                            }
                        }
                    }
                }
            }

            return assigned;
        }

        /// <summary>
        /// Creator:            Darryl Shirley
        /// Created:            03/05/2024
        /// Summary:            SelectAllVolunteersNotAssignedToEvent method
        /// Last Updated By:    Darryl Shirley
        /// Last Updated:       03/05/2024
        /// What Was Changed:   Initial Creation
        /// </summary>
        public List<Volunteer> SelectAllVolunteersNotAssignedToEvent(int eventID)
        {
            List<Volunteer> notAssigned = new List<Volunteer>();
            
            List<Volunteer> assigned = new List<Volunteer>();

            List<Volunteer> totalVolunteer = new List<Volunteer>();

            List<EventVolunteer> vol = events.allEventVolunteers();

            foreach (User user in users)
            {
                if (user is Volunteer)
                {
                    totalVolunteer.Add((Volunteer)user);
                }
            }

            foreach(User user in users)
            {
                if (user is Volunteer)
                {
                    foreach (EventVolunteer v in vol)
                    {
                        if (eventID == v.EventID)
                        {
                            if (user.UserID.Equals(v.VolunteerID))
                            {
                                assigned.Add((Volunteer)user);
                            }
                        }
                    }
                }
            }

            notAssigned = totalVolunteer.Except(assigned).ToList();

            return notAssigned;
        }

        /// <summary>
        /// Creator:            Darryl Shirley
        /// Created:            02/21/2024
        /// Summary:            addVolunteerToEvent method
        /// Last Updated By:    Darryl Shirley
        /// Last Updated:       02/25/2024
        /// What Was Changed:   Removed unused caught exception
        /// </summary>
        public int addVolunteerToEvent(string volunteerID, int eventID)
        {
            int added = 0;
            try 
            {

                List<EventVolunteer> eventVolunteers = events.allEventVolunteers();
                int oldtotal = eventVolunteers.Count;
                int newtotal = 0;

                EventVolunteer volunteer = new EventVolunteer
                {
                    VolunteerID = volunteerID,
                    EventID = eventID
                };
                
                eventVolunteers.Add(volunteer);

                newtotal = eventVolunteers.Count;
                if(newtotal > oldtotal)
                {
                    added = 1;
                }

            }
             catch(Exception ex)
            {
                throw ex;
            }

            return added;
		}
		
        /// <summary>
        /// Creator:            Liam Easton
        /// Created:            03/4/2024
        /// Summary:            Creation of SelectSpecificRoles fakes method
        /// Last Updated By:    Liam Easton
        /// Last Updated:       03/4/2024
        /// What Was Changed:   Creation of SelectSpecificRoles fakes method
        /// </summary>
        public List<Employee> SelectSpecificRoles(string RoleID)
        {
            List<Employee> selectedEmployees = new List<Employee>();

            try
            {
                foreach (Employee emp in fakeEmployees)
                {
                    if (emp.Roles.Any(e => e.RoleID.Equals(RoleID)))
                    {
                        selectedEmployees.Add(emp);
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }

            return selectedEmployees;
        }

        /// <summary>
        /// Creator:            Liam Easton
        /// Created:            03/4/2024
        /// Summary:            Creation of SelectSpecificRoles fakes method
        /// Last Updated By:    Liam Easton
        /// Last Updated:       03/4/2024
        /// What Was Changed:   Creation of SelectSpecificRoles fakes method
        /// </summary>
        public List<Role> SelectAllRoles()
        {
            return fakeRoles;
        }

        public User SelectClientVM(string userID)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Creator: Matthew Baccam
        /// Created: 03/15/2024
        /// Summary: Inserts users roles
        /// Last Updated By: Matthew Baccam
        /// Last Updated: 03/15/2024
        /// What Was changed: Initial creation
        /// </summary>
        public bool InsertEmployeeRoles(string employeeID, List<Role> roles)
        {
            var employee = users.FirstOrDefault(emp => emp.UserID == employeeID) as Employee;
            var originalCount = employee.Roles.Count + roles.Count;

            roles.ForEach(role => employee.Roles.Add(role));
            var actualCount = employee.Roles.Count;
            return originalCount == actualCount;
        }

        /// <summary>
        /// Creator: Matthew Baccam
        /// Created: 03/15/2024
        /// Summary: Removes users roles
        /// Last Updated By: Matthew Baccam
        /// Last Updated: 03/15/2024
        /// What Was changed: Initial creation
        /// </summary>
        public bool DeleteEmployeeRoles(string employeeID, List<Role> roles)
        {
            var employee = users.FirstOrDefault(emp => emp.UserID == employeeID) as Employee;
            var originalCount = employee.Roles.Count - roles.Count;

            roles.ForEach(role => employee.Roles.Remove(role));
            var actualCount = employee.Roles.Count;
            return originalCount == actualCount;
        }

        /// <summary>
        /// Creator: Matthew Baccam
        /// Created: 03/22/2024
        /// Summary: Inserts a new user into the users
        /// Last Updated By: Matthew Baccam
        /// Last Updated: 03/22/2024
        /// What Was changed: Initial creation
        /// </summary>
        public bool InsertNewUser(User user, string passwordHash)
        {
            var ogCount = fakeEmployees.Count;
            fakeEmployees.Add(user as Employee);
            return ogCount < fakeEmployees.Count;
        }

        /// <summary>
        /// Creator: Matthew Baccam
        /// Created: 03/22/2024
        /// Summary: Check email availability
        /// Last Updated By: Matthew Baccam
        /// Last Updated: 03/22/2024
        /// What Was changed: Initial creation
        /// </summary>
        public bool CheckEmailAvailability(string email)
        {
            var result = true;
            users.ForEach(user => {
                if (user.UserID == email)
                    result = false;
            });
            return result;
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
            if (oldUser is Employee)
            {
                var newEmp = new Employee();
                var emp = users.FirstOrDefault(user => user.UserID == oldUser.UserID) as Employee;
                emp.FirstName = newEmp.FirstName;
                emp.LastName = newEmp.LastName;
                return true;
            }
            else if (oldUser is Client)
            {
                var newClient = new Client();
                var client = users.FirstOrDefault(user => user.UserID == oldUser.UserID) as Client;
                client.FirstName = newClient.FirstName;
                client.LastName = newClient.LastName;
                return true;
            }
            return false;
        }

        /// <summary>
        /// Creator: Marwa Ibrahim
        /// Created: 03/27/2024
        /// Summary: Updates updates Client Password
        /// Last Updated By: Marwa Ibrahim
        /// Last Updated: 03/27/2024
        /// What Was changed: Initial creation
        /// </summary>
        public bool UpdateClientPassword(string userID, string newPassword)
        {

            foreach (var user in users)
            {
                if (user.UserID == userID)
                {
                    return true;
                }

            }
            return false;
        }
        public List<Volunteer> SelectAllVolunteers()
        {
            throw new NotImplementedException();
        }


        //public List<Volunteer> SelectAllVolunteers()
        //    {
        //        throw new NotImplementedException();
        //    }

        /// <summary>
        /// Creator:            Ibrahim Albashair
        /// Created:            03/18/2024
        /// Summary:            Creation of GetAllVolunteers fakes method
        /// Last Updated By:    Ibrahim Albashair
        /// Last Updated:       03/18/2024
        /// What Was Changed:   Creation of GetAllVolunteers fakes method
        /// </summary>
        public List<Volunteer> GetAllVolunteers()
        {
            List<Volunteer> volunteers = new List<Volunteer>();
            volunteers.Add(new Volunteer
            {
                UserID = "100001",
                FirstName = "Name",
                LastName = "Name",
                Gender = true
            });
            volunteers.Add(new Volunteer
            {
                UserID = "100002",
                FirstName = "Name",
                LastName = "Name",
                Gender = true
            });
            volunteers.Add(new Volunteer
            {
                UserID = "100003",
                FirstName = "Name",
                LastName = "Name",
                Gender = true
            });

            return volunteers;
        }

        /// <summary>
        /// Creator: Andres Garcia
        /// Created: 02/13/2024
        /// Summary: Select all ClientIDs
        /// Last Updated By: Andres Garcia
        /// Last Updated: 02/13/2024
        /// What Was Changed: Initial Creation
        /// </summary>
        public List<string> SelectAllClientIDs()
        {
            List<string> clientIds = new List<string>();
            foreach (var user in users)
            {
                if (user.UserType == "Client")
                {
                    clientIds.Add(user.UserID);
                }
            }
            return clientIds;
        }
        /// <summary>
        /// Creator:Miyada Abas
        /// Created: 04/09/2024
        /// Summary: DeactivtemClient pplication
        /// Last Updated By: Miyada Abas
        /// Last Updated: 04/09/2024
        /// What Was changed: Initial creation
        /// </summary>
        public bool DeactivteClientApplication(Client client)
        {
            bool result = false;
            foreach (var user in users)
            {
                if (user.UserID == client.UserID)
                {
                    user.AccountStatus = false;
                    result = true;
                    break;
                }

            }
            return result;
        }

        /// <summary>
        /// Creator: Abdalgader Ibrahim 
        /// Created: 04/11/2024
        /// Summary: Updates updates employee password
        /// Last Updated By: Abdalgader Ibrahim
        /// Last Updated: 04/11/2024
        /// What Was changed: Initial creation
        /// </summary>
        public bool UpdateEmployeePassword(string employeeID, string v)
        {
            foreach (var employee in employees)
            {
                if (employee.EmployeeID == employeeID)
                {
                    return true;
                }

            }
            return false;
        } 
    }
}

