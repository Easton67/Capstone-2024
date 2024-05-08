using DataAccessInterfaces;
using DataObjects;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Xml.Linq;
using System.Diagnostics;
using System.Net;
using System.Reflection.Emit;

namespace DataAccessLayer
{
    public class UserAccessor : IUserAccessor {

        /// <summary>
        /// Creator:            Tyler Barz
        /// Created:            02/15/2024
        /// Summary:            Divided user selection methods based on user types
        /// Last Updated By:    Tyler Barz
        /// Last Updated:       02/15/2024
        /// What Was Changed:   Inital creation
        /// </summary>
        #region Select Client,Employee,Voluntter by ID
        /// <summary>
        /// Creator:            Tyler Barz
        /// Created:            02/14/2024
        /// Summary:            Method to separate client selection instead of a centralized method
        /// Last Updated By:    Tyler Barz
        /// Last Updated:       02/14/2024
        /// What Was Changed:   Initial creation
        /// </summary>
        public User SelectClientByID(string email)
        {
            try
            {
                return SelectUserByID(Enums.AuthenticationType.Client, email);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Creator:            Tyler Barz
        /// Created:            02/14/2024
        /// Summary:            Method to separate employee selection instead of a centralized method
        /// Last Updated By:    Tyler Barz
        /// Last Updated:       02/14/2024
        /// What Was Changed:   Initial creation
        /// </summary>
        public User SelectEmployeeByID(string email)
        {
            try
            {
                return SelectUserByID(Enums.AuthenticationType.Employee, email);
            }
            catch (Exception ex)
            {
                throw ex;
            }        
        }
        /// <summary>
        /// Creator:            Tyler Barz
        /// Created:            02/14/2024
        /// Summary:            Method to separate volunteer selection instead of a centralized method
        /// Last Updated By:    Tyler Barz
        /// Last Updated:       02/14/2024
        /// What Was Changed:   Initial creation
        /// </summary>
        public User SelectVolunteerByID(string email)
        {
            try
            {
                return SelectUserByID(Enums.AuthenticationType.Volunteer, email);
            }
            catch (Exception ex)
            {
                throw ex;
            }       
        }
        #endregion

        /// <summary>
        /// Creator:            Tyler Barz
        /// Created:            02/14/2024
        /// Summary:            Centralized user selection
        /// Last Updated By:    Tyler Barz
        /// Last Updated:       03/02/2024
        /// What Was Changed:   Added nested using statement, commented out RoleID retreival for volunteer
        /// </summary>
        private User SelectUserByID(Enums.AuthenticationType userType, string email)
        {
            User user = null;
            string typeOfUser = string.Empty;
            string userID = string.Empty;

            // Identify user type [Employee, Volunteer, Client]
            switch (userType)
            {
                case Enums.AuthenticationType.Employee:
                    typeOfUser = "employee";
                    userID = "EmployeeID";
                    user = new Employee();
                    break;
                case Enums.AuthenticationType.Volunteer:
                    typeOfUser = "volunteer";
                    userID = "VolunteerID";
                    user = new Volunteer();
                    break;
                case Enums.AuthenticationType.Client:
                    typeOfUser = "client";
                    userID = "ClientID";
                    user = new Client();
                    break;
            }

            using (var conn = DatabaseConnection.GetConnection())
            using (var cmd = DatabaseConnection.NewCommand($"sp_select_{typeOfUser}_details", conn, CommandType.StoredProcedure))
            {
                cmd.Parameters.AddWithValue(userID, email);

                try
                {
                    conn.Open();
                    SqlDataReader dbResult = cmd.ExecuteReader();
                    if (dbResult.HasRows && dbResult.Read())
                    {
                        user.UserID = dbResult.GetString(0);
                        // Check object type, assign details accordingly
                        if (user is Employee emp)
                        {
                            emp.FirstName = dbResult.GetString(1);
                            emp.LastName = dbResult.GetString(2);
                            emp.PhoneNumber = dbResult.GetString(3);
                            emp.Gender = dbResult.GetBoolean(4);
                            emp.AccountStatus = dbResult.GetBoolean(5);
                            emp.ZipCode = dbResult.GetInt32(6);
                            emp.Address = dbResult.GetString(7);
                            emp.StartDate = dbResult.GetDateTime(8);
                            // Only casting to nullable datetime because just null isn't supported in C# 7.3
                            emp.EndDate = dbResult.IsDBNull(9) ? (DateTime?)null : dbResult.GetDateTime(9);
                        }
                        else if (user is Volunteer vol)
                        {
                            vol.FirstName = dbResult.GetString(1);
                            vol.LastName = dbResult.GetString(2);
                            vol.PhoneNumber = dbResult.GetString(3);
                            vol.Gender = dbResult.GetBoolean(4);
                            vol.AccountStatus = dbResult.GetBoolean(5);
                            //vol.RoleID = dbResult.GetString(6); -- Commented since changed to Role object
                            vol.ZipCode = dbResult.GetInt32(7);
                            vol.Address = dbResult.GetString(8);
                            vol.RegistrationDate = dbResult.GetDateTime(9);
                        }
                        else if (user is Client cli)
                        {
                            cli.FirstName = dbResult.GetString(1);
                            cli.LastName = dbResult.GetString(2);
                            cli.Gender = dbResult.GetBoolean(3);
                            cli.Accomadations = dbResult.GetString(4);
                            cli.AccountStatus = dbResult.GetBoolean(5);
                            cli.RegistrationDate = dbResult.GetDateTime(6);
                            cli.ExitDate = dbResult.IsDBNull(7) ? (DateTime?)null : dbResult.GetDateTime(7);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return user;
        }

        /// <summary>
        /// Creator:            Tyler Barz
        /// Created:            04/03/2024
        /// Summary:            Select all Volunteers
        /// Last Updated By:    Tyler Barz
        /// Last Updated:       04/03/2024
        /// What Was Changed:   Inital creation
        /// </summary>
        public List<Volunteer> SelectAllVolunteers()
        {
            List<Volunteer> vols = new List<Volunteer>();   

            using (var conn = DatabaseConnection.GetConnection())
            using (var cmd = DatabaseConnection.NewCommand($"sp_select_all_Volunteers", conn, CommandType.StoredProcedure))
            {
                try
                {
                    conn.Open();
                    SqlDataReader dbResult = cmd.ExecuteReader();
                    while (dbResult.Read())
                    {
                        vols.Add(new Volunteer()
                        {
                            UserID = dbResult.GetString(0),
                            FirstName = dbResult.GetString(1),
                            LastName = dbResult.GetString(2),
                            PhoneNumber = dbResult.GetString(3),
                            Gender = dbResult.GetBoolean(4),
                            AccountStatus = dbResult.GetBoolean(5),
                            ZipCode = dbResult.GetInt32(9),
                            Address = dbResult.GetString(8),
                            RegistrationDate = dbResult.GetDateTime(7)
                        });
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return vols;
        }

        #region Matts code

        /// <summary>
        /// Creator: Matthew Baccam
        /// Created: 03/08/2024
        /// Summary: Creates a clientVM
        /// Last Updated By: Matthew Baccam
        /// Last Updated: 03/08/2024
        /// What Was changed: Initial creation
        /// </summary>
        public User SelectClientVM(string userID)
        {
            ClientVM clientVM = new ClientVM();

            var conn = DatabaseConnection.GetConnection();

            var commandText = "sp_select_client_details_vm";

            var cmd = new SqlCommand(commandText, conn);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@ClientID", userID);

            try
            {
                conn.Open();

                var reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        clientVM.UserID = reader.GetString(0);
                        clientVM.FirstName = reader.GetString(1);
                        clientVM.LastName = reader.GetString(2);
                        clientVM.Gender = reader.GetBoolean(3);
                        clientVM.Accomadations = reader.GetString(4);
                        clientVM.AccountStatus = reader.GetBoolean(5);
                        clientVM.RegistrationDate = reader.GetDateTime(6);
                        clientVM.ExitDate = reader.IsDBNull(7) ? (DateTime?)null : reader.GetDateTime(7);
                        clientVM.Stay = new StayVM()
                        {
                            StayID = reader.GetInt32(8),
                            ClientID = reader.GetString(9),
                            RoomID = reader.GetInt32(10),
                            InDate = reader.GetDateTime(11),
                            OutDate = reader.GetDateTime(12),
                            CheckedOut = reader.GetBoolean(13),
                        };
                        clientVM.Room = new Room() {
                            RoomID = reader.GetInt32(14),
                            ShelterID = reader.GetString(15),
                            RoomNumber = reader.GetInt32(16),
                            Status = reader.GetString(17)
                        };
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
            return clientVM;
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
            var conn = DatabaseConnection.GetConnection();
            SqlCommand cmd = new SqlCommand();

            //this is to assign the general Users information since all three user types have similiar columns
            //Made this a method since i cannot the assign the similiar columns they have while also having different command text for the sp
            void AssignUserParameters(string commandText)
            {
                cmd = new SqlCommand(commandText, conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@UserID", oldUser.UserID);
                cmd.Parameters.AddWithValue("@OldFname", oldUser.FirstName);
                cmd.Parameters.AddWithValue("@OldLname", oldUser.LastName);
                cmd.Parameters.AddWithValue("@OldGender", oldUser.Gender);
                cmd.Parameters.AddWithValue("@OldAccountStatus", oldUser.AccountStatus);

                cmd.Parameters.AddWithValue("@NewFname", newUser.FirstName);
                cmd.Parameters.AddWithValue("@NewLname", newUser.LastName);
                cmd.Parameters.AddWithValue("@NewGender", newUser.Gender);
                cmd.Parameters.AddWithValue("@NewAccountStatus", newUser.AccountStatus);
            }
            if (oldUser is Employee)
            {
                var newEmployee = newUser as Employee;
                var oldEmployee = oldUser as Employee;
                AssignUserParameters("sp_update_employee_details");
                cmd.Parameters.AddWithValue("@OldZipCode", oldEmployee.ZipCode);
                cmd.Parameters.AddWithValue("@OldAddress", oldEmployee.Address);
                cmd.Parameters.AddWithValue("@OldStartDate", oldEmployee.StartDate);
                cmd.Parameters.AddWithValue("@OldPhone", oldEmployee.PhoneNumber);
                cmd.Parameters.AddWithValue("@OldEndDate", oldEmployee.EndDate);

                cmd.Parameters.AddWithValue("@NewPhone", newEmployee.PhoneNumber);
                cmd.Parameters.AddWithValue("@NewZipCode", newEmployee.ZipCode);
                cmd.Parameters.AddWithValue("@NewAddress", newEmployee.Address);
                cmd.Parameters.AddWithValue("@NewStartDate", newEmployee.StartDate);
                cmd.Parameters.AddWithValue("@NewEndDate", newEmployee.EndDate);
            }

            else if (oldUser is Client)
            {
                var newClient = newUser as Client;
                var oldClient = oldUser as Client;
                AssignUserParameters("sp_update_client_details");
                cmd.Parameters.AddWithValue("@OldAccomodations", oldClient.Accomadations);
                cmd.Parameters.AddWithValue("@OldRegistrationDate", oldClient.RegistrationDate);
                cmd.Parameters.AddWithValue("@OldExitDate", oldClient.ExitDate);

                cmd.Parameters.AddWithValue("@NewAccomodations", newClient.Accomadations);
                cmd.Parameters.AddWithValue("@NewRegistrationDate", newClient.RegistrationDate);
                cmd.Parameters.AddWithValue("@NewExitDate", newClient.ExitDate);
            }
            else if (oldUser is Volunteer)
            {
                var newVolunteer = newUser as Volunteer;
                var oldVolunteer = oldUser as Volunteer;
                string commandText = "sp_update_volunteer_details";
                cmd = new SqlCommand(commandText, conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@UserID", oldVolunteer.UserID);

                cmd.Parameters.AddWithValue("@NewFname", newVolunteer.FirstName);
                cmd.Parameters.AddWithValue("@NewLname", newVolunteer.LastName);
                cmd.Parameters.AddWithValue("@NewGender", newVolunteer.Gender);
                cmd.Parameters.AddWithValue("@NewAccountStatus", newVolunteer.AccountStatus);
                cmd.Parameters.AddWithValue("@NewPhone", newVolunteer.PhoneNumber);
                cmd.Parameters.AddWithValue("@NewAddress", newVolunteer.Address);
                cmd.Parameters.AddWithValue("@NewZipCode", newVolunteer.ZipCode);
                cmd.Parameters.AddWithValue("@NewRegistrationDate", newVolunteer.RegistrationDate);
            }

            try
            {
                conn.Open();

                var rows = cmd.ExecuteNonQuery();
                if (rows == 0 || rows > 1)
                {
                    throw new Exception("Something went wrong with updating clients information");
                }
                return rows == 1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
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
        public bool InsertEmployeeRoles(string employeeID, List<Role> roles)
        {
            var result = false;
            roles.ForEach(role =>
            {
                var conn = DatabaseConnection.GetConnection();

                var commandText = "sp_add_employee_role";

                var cmd = new SqlCommand(commandText, conn);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@EmployeeID", employeeID);
                cmd.Parameters.AddWithValue("@RoleID", role.RoleID);

                //Finally, open the connection and execute the command. Watch for errors.
                try
                {
                    // open the connection
                    conn.Open();

                    // execute the command and capture the result
                    var rows = cmd.ExecuteNonQuery();
                    if (rows > 2 || rows <= 0)
                    {
                        throw new Exception("Failed to delete the role(s)");
                    }
                    result = rows == 2;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    conn.Close();
                }

            });
            return result;
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
            var result = false;
            roles.ForEach(role =>
            {
                var conn = DatabaseConnection.GetConnection();

                var commandText = "sp_delete_employee_role";

                var cmd = new SqlCommand(commandText, conn);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@EmployeeID", employeeID);
                cmd.Parameters.AddWithValue("@RoleID", role.RoleID);

                try
                {
                    // open the connection
                    conn.Open();

                    var rows = cmd.ExecuteNonQuery();
                    if (rows > 2 || rows <= 0)
                    {
                        throw new Exception("Failed to delete the role(s)");
                    }
                    result = rows == 2;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    conn.Close();
                }

            });
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
        public bool InsertNewUser(User user, string passwordHash)
        {
            var conn = new SqlConnection();
            var cmd = new SqlCommand();
            void CreateDBConnection(string queryParam)//This creates the connection and assigns the common parameters that the different user types have
            {
                conn = DatabaseConnection.GetConnection();
                cmd = new SqlCommand();
                string commandText = $"sp_insert_{queryParam}";
                cmd = new SqlCommand(commandText, conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("UserID", user.UserID);
                cmd.Parameters.AddWithValue("Fname", user.FirstName);
                cmd.Parameters.AddWithValue("Lname", user.LastName);
                cmd.Parameters.AddWithValue("PasswordHash", passwordHash);
                cmd.Parameters.AddWithValue("Gender", user.Gender);
                cmd.Parameters.AddWithValue("AccountStatus", user.AccountStatus);
            }
            if (user is Client)//Adding the params for client
            {
                var client = user as Client;
                CreateDBConnection("client");
                cmd.Parameters.AddWithValue("Accomodations", client.Accomadations);
                cmd.Parameters.AddWithValue("RegistrationDate", client.RegistrationDate);
            }
            else if (user is Employee)//Adding the params for employee
            {
                var employee = user as Employee;
                CreateDBConnection("employee");
                cmd.Parameters.AddWithValue("Phone", employee.PhoneNumber);
                cmd.Parameters.AddWithValue("StartDate", employee.StartDate);
                cmd.Parameters.AddWithValue("ZipCode", employee.ZipCode);
                cmd.Parameters.AddWithValue("Address", employee.Address);
            }
            else//If its not either its volunteer & Adding the params for volunteer
            {
                var volunteer = user as Volunteer;
                CreateDBConnection("volunteer");
                cmd.Parameters.AddWithValue("Phone", volunteer.PhoneNumber);
                cmd.Parameters.AddWithValue("RegistrationDate", volunteer.RegistrationDate);
                cmd.Parameters.AddWithValue("ZipCode", volunteer.ZipCode);
                cmd.Parameters.AddWithValue("Address", volunteer.Address);
                cmd.Parameters.AddWithValue("RoleID", volunteer.Roles[0].RoleID);
            }
            try
            {
                conn.Open();

                var rows = cmd.ExecuteNonQuery();
                if (rows == 0 || rows > 1)
                {
                    throw new Exception("Something went wrong with creating user");
                }
                return rows == 1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
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
        public bool CheckEmailAvailability(string email)
        {
            int rows = 0;
            var conn = DatabaseConnection.GetConnection();

            var commandText = "sp_check_if_email_is_valid";

            var cmd = new SqlCommand(commandText, conn);

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("UserID", email);

            try
            {
                conn.Open();

                var reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        rows += reader.GetInt32(0);
                        rows += reader.GetInt32(1);
                        rows += reader.GetInt32(2);
                    }
                }
                return rows == 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
        }

        #endregion


        #region Select Employee,Volunteer Roles
        /// <summary>
        /// Creator:            Tyler Barz
        /// Created:            03/02/2024
        /// Summary:            Accessor to return list of employee roles
        /// Last Updated By:    Tyler Barz
        /// Last Updated:       03/02/2024
        /// What Was Changed:   Initial creation
        /// </summary>
        public List<Role> SelectEmployeeRoles(string email)
        {
            List<Role > roles = new List<Role>();

            using (var conn = DatabaseConnection.GetConnection())
            using (var cmd = DatabaseConnection.NewCommand("sp_select_employee_roles", conn, CommandType.StoredProcedure))
            {
                cmd.Parameters.AddWithValue("@EmployeeID", email);
                try
                {
                    conn.Open();
                    SqlDataReader dbResult = cmd.ExecuteReader();
                    if (!dbResult.HasRows)
                    {
                        return roles;
                    }

                    while (dbResult.Read())
                    {
                        roles.Add(new Role()
                        {
                            RoleID = dbResult.GetString(0),
                            Description = dbResult.GetString(1)
                        });
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return roles;
        }
        /// <summary>
        /// Creator:            Tyler Barz
        /// Created:            03/02/2024
        /// Summary:            Accessor to return volunteers' role
        /// Last Updated By:    Tyler Barz
        /// Last Updated:       03/02/2024
        /// What Was Changed:   Initial creation
        /// </summary>
        public Role SelectVolunteerRole(string email)
        {
            Role role = null;

            using (var conn = DatabaseConnection.GetConnection())
            using (var cmd = DatabaseConnection.NewCommand("sp_select_volunteer_role", conn, CommandType.StoredProcedure))
            {
                cmd.Parameters.AddWithValue("@VolunteerID", email);
                try
                {
                    conn.Open();
                    SqlDataReader dbResult = cmd.ExecuteReader();
                    if (dbResult.HasRows && dbResult.Read())
                    {
                        role = new Role()
                        {
                            RoleID = dbResult.GetString(0),
                            Description = dbResult.GetString(1)
                        };
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return role;
        }
        #endregion

        #region Sagans Code
        //<summary>
        //Creator: Sagan DeWald
        //Created: 1/31/2024
        //Summary: Input an username and password hash as strings. Calls the "sp_authenticate_volunteer" stored procedure with the username and password hash, then returns a boolean indicating success or failure.
        //Last Updated By: Sagan DeWald
        //Last Updated: 1/31/2024
        //What was Changed: Initial Creation
        //</summary>
        public bool AuthenticateVolunteerWithNameAndPasswordHash(string userName, string passwordHash)
        {
            int result = 0;

            //Create a connection to the database.
            var conn = DatabaseConnection.GetConnection();

            //Specify the stored procedure to call.
            var commandText = "sp_authenticate_volunteer";

            //Use the connection and stored procedure to make a command object.
            var cmd = new SqlCommand(commandText, conn);

            //Specify to the command object that we're calling a stored procedure.
            cmd.CommandType = CommandType.StoredProcedure;

            //Add the E-Mail and password hash as parameters.
            cmd.Parameters.Add("@VolunteerID", SqlDbType.NVarChar, 100);
            cmd.Parameters.Add("@PasswordHash", SqlDbType.NVarChar, 255); //This might break when the Volunteer SQL table is fixed.

            //Set the value of the E-Mail and password parameters.
            cmd.Parameters["@VolunteerID"].Value = userName;
            cmd.Parameters["@PasswordHash"].Value = passwordHash;

            //Finally, open the connection and execute the command. Watch for errors.
            try
            {
                // open the connection
                conn.Open();

                // execute the command and capture the result
                result = Convert.ToInt32(cmd.ExecuteScalar());
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }

            return Convert.ToBoolean(result);
        }

        //<summary>
        //Creator: Sagan DeWald
        //Created: 1/31/2024
        //Summary: Input an username and password hash as strings. Calls the "sp_authenticate_client" stored procedure with the username and password hash, then returns a boolean indicating success or failure.
        //Last Updated By: Sagan DeWald
        //Last Updated: 1/31/2024
        //What was Changed: Initial Creation
        //</summary>
        public bool AuthenticateClientWithNameAndPasswordHash(string userName, string passwordHash)
        {
            int result = 0;

            //Create a connection to the database.
            var conn = DatabaseConnection.GetConnection();

            //Specify the stored procedure to call.
            var commandText = "sp_authenticate_client";

            //Use the connection and stored procedure to make a command object.
            var cmd = new SqlCommand(commandText, conn);

            //Specify to the command object that we're calling a stored procedure.
            cmd.CommandType = CommandType.StoredProcedure;

            //Add the E-Mail and password hash as parameters.
            cmd.Parameters.Add("@ClientID", SqlDbType.NVarChar, 100);
            cmd.Parameters.Add("@PasswordHash", SqlDbType.NVarChar, 256);

            //Set the value of the E-Mail and password parameters.
            cmd.Parameters["@ClientID"].Value = userName;
            cmd.Parameters["@PasswordHash"].Value = passwordHash;

            //Finally, open the connection and execute the command. Watch for errors.
            try
            {
                // open the connection
                conn.Open();

                // execute the command and capture the result
                result = Convert.ToInt32(cmd.ExecuteScalar());
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }

            return Convert.ToBoolean(result);
        }

        //<summary>
        //Creator: Sagan DeWald
        //Created: 1/31/2024
        //Summary: Input an username and password hash as strings. Calls the "sp_authenticate_employee" stored procedure with the username and password hash, then returns a boolean indicating success or failure.
        //Last Updated By: Sagan DeWald
        //Last Updated: 1/31/2024
        //What was Changed: Initial Creation
        //</summary>
        public bool AuthenticateEmployeeWithNameAndPasswordHash(string userName, string passwordHash)
        {
            int result = 0;

            //Create a connection to the database.
            var conn = DatabaseConnection.GetConnection();

            //Specify the stored procedure to call.
            var commandText = "sp_authenticate_employee";

            //Use the connection and stored procedure to make a command object.
            var cmd = new SqlCommand(commandText, conn);

            //Specify to the command object that we're calling a stored procedure.
            cmd.CommandType = CommandType.StoredProcedure;

            //Add the E-Mail and password hash as parameters.
            cmd.Parameters.Add("@EmployeeID", SqlDbType.NVarChar, 100);
            cmd.Parameters.Add("@PasswordHash", SqlDbType.NVarChar, 256);

            //Set the value of the E-Mail and password parameters.
            cmd.Parameters["@EmployeeID"].Value = userName;
            cmd.Parameters["@PasswordHash"].Value = passwordHash;

            //Finally, open the connection and execute the command. Watch for errors.
            try
            {
                // open the connection
                conn.Open();

                // execute the command and capture the result
                result = Convert.ToInt32(cmd.ExecuteScalar());
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }

            return Convert.ToBoolean(result);
        }
        #endregion

        #region Liams Code
        /// <summary>
        /// Creator:            Liam Easton
        /// Created:            02/13/2024
        /// Summary:            Creation of SelectAllEmployees method
        /// Last Updated By:    Liam Easton
        /// Last Updated:       02/13/2024
        /// What Was Changed:   Creation of SelectAllEmployees method
        /// </summary>
        public List<Employee> SelectAllEmployees()
        {
            List<Employee> employeeList = new List<Employee>();

            var conn = DatabaseConnection.GetConnection();

            var cmdText = "sp_select_all_employees";

            var cmd = new SqlCommand(cmdText, conn);

            cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                conn.Open();

                var reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Employee employee = new Employee();

                        employee.EmployeeID = reader.GetString(0);
                        employee.FirstName = reader.GetString(1);
                        employee.LastName = reader.GetString(2);
                        employee.PhoneNumber = reader.GetString(3);
                        employee.Gender = reader.GetBoolean(4);
                        employee.AccountStatus = reader.GetBoolean(5);
                        employee.ZipCode = reader.GetInt32(6);
                        employee.Address = reader.GetString(7);
                        employee.StartDate = reader.GetDateTime(8);

                        employeeList.Add(employee);
                    }
                }
                return employeeList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
        }

        /// <summary>
        /// Creator:            Liam Easton
        /// Created:            03/04/2024
        /// Summary:            Creation of SelectAllRoles method
        /// Last Updated By:    Liam Easton
        /// Last Updated:       03/04/2024
        /// What Was Changed:   Creation of SelectAllRoles method
        /// </summary>
        public List<Role> SelectAllRoles()
        {
            List<Role> rolesList = new List<Role>();

            var conn = DatabaseConnection.GetConnection();

            var cmdText = "sp_select_all_roles";

            var cmd = new SqlCommand(cmdText, conn);

            cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                conn.Open();

                var reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Role role = new Role();

                        role.RoleID = reader.GetString(0);
                        role.DepartmentID = reader.GetInt32(1); 
                        role.Description = reader.GetString(2);
                        role.PositionsAvailable = reader.GetInt32(3);

                        rolesList.Add(role);
                    }
                }
                return rolesList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
        }

        /// <summary>
        /// Creator:            Liam Easton
        /// Created:            03/03/2024
        /// Summary:            Creation of SelectSpecificRoles method
        /// Last Updated By:    Liam Easton
        /// Last Updated:       03/03/2024
        /// What Was Changed:   Creation of SelectSpecificRoles method
        /// </summary>
        public List<Employee> SelectSpecificRoles(string RoleID)
        {
            List<Employee> employeeList = new List<Employee>();
            var conn = DatabaseConnection.GetConnection();
            var cmdText = "sp_select_specific_roles";
            var cmd = new SqlCommand(cmdText, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@RoleID", SqlDbType.NVarChar).Value = RoleID;
            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Employee employee = new Employee();

                        employee.EmployeeID = reader.GetString(0);
                        employee.Roles = new List<Role> { new Role { RoleID = reader.GetString(1) } };
                        employee.FirstName = reader.GetString(2);
                        employee.LastName = reader.GetString(3);
                        employee.PhoneNumber = reader.GetString(4);
                        employee.Gender = reader.GetBoolean(5);
                        employee.AccountStatus = reader.GetBoolean(6);
                        employee.ZipCode = reader.GetInt32(7);
                        employee.Address = reader.GetString(8);
                        employee.StartDate = reader.GetDateTime(9);

                        employeeList.Add(employee);
                    }
                }
                return employeeList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
        }

        /// <summary>
        /// Creator:            Liam Easton
        /// Created:            01/30/2024
        /// Summary:            Creation of UpdateEmployeePasswordHash method
        /// Last Updated By:    Liam Easton
        /// Last Updated:       01/30/2024
        /// What Was Changed:   Creation of UpdateEmployeePasswordHash method
        /// Last Updated By: Liam Easton
        /// Last Updated: 04/04/2024
        /// What Was Changed: Changed procedure name from UpdateEmployeePasswordHash to sp_update_employee_passwordHash
        /// </summary>
        public int UpdateEmployeePasswordHash(string employeeID, string oldPasswordHash, string newPasswordHash)
        {
            int rows = 0;

            var conn = DatabaseConnection.GetConnection();
            var commandText = "sp_update_employee_passwordHash";
            var cmd = new SqlCommand(commandText, conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@EmployeeID", SqlDbType.NVarChar, 100);
            cmd.Parameters.Add("@NewPasswordHash", SqlDbType.NVarChar, 100);
            cmd.Parameters.Add("@OldPasswordHash", SqlDbType.NVarChar, 100);

            cmd.Parameters["@EmployeeID"].Value = employeeID;
            cmd.Parameters["@NewPasswordHash"].Value = newPasswordHash;
            cmd.Parameters["@OldPasswordHash"].Value = oldPasswordHash;

            try
            {
                conn.Open();

                rows = cmd.ExecuteNonQuery();

                if (rows == 0)
                {
                    throw new ArgumentException("Bad Email or Password");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }

            return rows;
        }

        /// <summary>
        /// Creator:            Liam Easton
        /// Created:            02/01/2024
        /// Summary:            Creation of SelectEmployeePasswordHashByEmployeeID method
        /// Last Updated By:    Liam Easton
        /// Last Updated:       02/01/2024
        /// What Was Changed:   Creation of SelectEmployeePasswordHashByEmployeeID method
        /// </summary>
        public EmployeePass SelectEmployeePasswordHashByEmployeeID(string employeeID)
        {
            EmployeePass employeePass = new EmployeePass();

            var conn = DatabaseConnection.GetConnection();
            var cmdText = "sp_select_employee_passwordHash_by_employeeID";
            var cmd = new SqlCommand(cmdText, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@EmployeeID", SqlDbType.NVarChar, 100);
            cmd.Parameters["@EmployeeID"].Value = employeeID;

            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    if (reader.Read())
                    {
                        employeePass.PasswordHash = reader.GetString(0);
                    }
                    else
                    {
                        throw new ArgumentException("Password not found");
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
            return employeePass;
        }
        #endregion

        #region Jareds code
        /// <summary>
        /// Creator:            Jared Harvey
        /// Created:            02/19/2024
        /// Summary:            Implementation for SelectAllClients method
        /// Last Updated By:    Jared Harvey
        /// Last Updated:       02/19/2024
        /// What Was Changed:   Initial Creation
        /// Last Updated By:    Matthew Baccam
        /// Last Updated:       03/22/2024
        /// What Was Changed:   Fixed exit date not allowing null values to be read in
        /// </summary>
        public List<Client> SelectAllClients()
        {
            List<Client> result = new List<Client>();

            // create connection object
            var conn = DatabaseConnection.GetConnection();

            // set the command text
            var commandText = "sp_get_all_clients";

            // create command object
            var cmd = new SqlCommand(commandText, conn);

            // set command type
            cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                // open connection
                conn.Open();

                // execute command
                var reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Client d = new Client();
                        d.UserID = reader.GetString(0);
                        d.FirstName = reader.GetString(1);
                        d.LastName = reader.GetString(2);
                        d.Gender = reader.GetBoolean(3);
                        d.Accomadations = reader.GetString(4);
                        d.AccountStatus = reader.GetBoolean(5);
                        d.RegistrationDate = reader.GetDateTime(6);
                        if (reader.IsDBNull(7))
                        {
                            d.ExitDate = null;
                        }
                        else
                        {
                            d.ExitDate = reader.GetDateTime(7);
                        }
                        result.Add(d);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
            return result;
        }

        public List<Employee> SelectDepartmentEmployees(int departmentID)
        {
            List<Employee> result = new List<Employee>();

            // create connection object
            var conn = DatabaseConnection.GetConnection();

            // set the command text
            var commandText = "sp_get_department_employees";

            // create command object
            var cmd = new SqlCommand(commandText, conn);

            // set command type
            cmd.CommandType = CommandType.StoredProcedure;

            // add parameters to command
            cmd.Parameters.Add("@DepartmentID", SqlDbType.Int);

            // set parameter values
            cmd.Parameters["@DepartmentID"].Value = departmentID;

            try
            {
                // open connection
                conn.Open();

                // execute command
                var reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Employee s = new Employee();
                        s.EmployeeID = reader.GetString(0);
                        s.FirstName = reader.GetString(1);
                        s.LastName = reader.GetString(2);
                        s.PhoneNumber = reader.GetString(3);
                        s.Gender = reader.GetBoolean(4);
                        s.AccountStatus = reader.GetBoolean(5);
                        s.ZipCode = reader.GetInt32(6);
                        s.Address = reader.GetString(7);
                        s.StartDate = reader.GetDateTime(8);
                        s.EndDate = reader.IsDBNull(9) ? DateTime.Now : reader.GetDateTime(9);
                        result.Add(s);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
            return result;
        }
        #endregion

        #region Darryls Code
        /// <summary>
        /// Creator:            Darryl Shirley
        /// Created:            02/21/2024
        /// Summary:            SelectAllEmployeeIDs method
        /// Last Updated By:    Darryl Shirley
        /// Last Updated:       02/21/2024
        /// What Was Changed:   Initial Creation
        /// </summary>
        public List<string> SelectAllEmployeeIDs()
        {
            List<string> employeeIDs = new List<string>();


            var conn = DatabaseConnection.GetConnection();



            var cmdText = "sp_select_All_EmployeeIDs";


            var cmd = new SqlCommand(cmdText, conn);


            cmd.CommandType = CommandType.StoredProcedure;



            try
            {

                conn.Open();


                var reader = cmd.ExecuteReader();


                if (reader.HasRows)
                {
                    while (reader.Read())
                    {

                        employeeIDs.Add(reader.GetString(0));
                    }
                }
                else
                {
                    throw new ArgumentException("Employees not found");
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                conn.Close();
            }
            return employeeIDs;
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
            List<Volunteer> volunteers = new List<Volunteer>();


            var conn = DatabaseConnection.GetConnection();



            var cmdText = "sp_select_all_volunteers_assigned_field";


            var cmd = new SqlCommand(cmdText, conn);


            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@EventID", SqlDbType.Int);
            cmd.Parameters["@EventID"].Value = eventID;


            try
            {

                conn.Open();


                var reader = cmd.ExecuteReader();


                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        volunteers.Add(new Volunteer()
                        {
                            UserID = reader.GetString(0),
                            FirstName = reader.GetString(1),
                            LastName = reader.GetString(2),
                            PhoneNumber = reader.GetString(3),
                            Gender = reader.GetBoolean(4),
                            AccountStatus = reader.GetBoolean(6),
                            RegistrationDate = reader.GetDateTime(8),
                            Address = reader.GetString(9),
                            ZipCode = reader.GetInt32(10)



                        });
                    }
                }
                else
                {
                    throw new ArgumentException("Volunteers not found");
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                conn.Close();
            }



            return volunteers;
        }

        /// <summary>
        /// Creator:            Darryl Shirley
        /// Created:            03/05/2024
        /// Summary:            SelectAllVolunteersNotAssignedToEvent method
        /// Last Updated By:    Darryl Shirley
        /// Last Updated:       02/21/2024
        /// What Was Changed:   Initial Creation
        /// </summary>
        public List<Volunteer> SelectAllVolunteersNotAssignedToEvent(int eventID)
        {
            List<Volunteer> volunteers = new List<Volunteer>();
            var conn = DatabaseConnection.GetConnection();
            var cmdText = "sp_select_all_volunteers_not_assigned_field";
            var cmd = new SqlCommand(cmdText, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@EventID", SqlDbType.Int);
            cmd.Parameters["@EventID"].Value = eventID;
            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        volunteers.Add(new Volunteer()
                        {
                            UserID = reader.GetString(0),
                            FirstName = reader.GetString(1),
                            LastName = reader.GetString(2),
                            PhoneNumber = reader.GetString(3),
                            Gender = reader.GetBoolean(4),
                            AccountStatus = reader.GetBoolean(6),
                            RegistrationDate = reader.GetDateTime(8),
                            Address = reader.GetString(9),
                            ZipCode = reader.GetInt32(10)

                        });
                    }
                }
                else
                {
                    throw new ArgumentException("Volunteers not found");
                }
            }
            catch (Exception ex)
            {

                throw new ApplicationException(ex.Message, ex);
            }
            finally
            {
                conn.Close();
            }
            return volunteers;
        }

        /// <summary>
        /// Creator:            Darryl Shirley
        /// Created:            03/05/2024
        /// Summary:            addVolunteerToEvent method
        /// Last Updated By:    Darryl Shirley
        /// Last Updated:       02/21/2024
        /// What Was Changed:   Initial Creation
        /// </summary>
        public int addVolunteerToEvent(string volunteerID, int eventID)
        {
            int rows = 0;



            var conn = DatabaseConnection.GetConnection();


            var commandText = "sp_add_volunteer_event_line_field";


            var cmd = new SqlCommand(commandText, conn);


            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@VolunteerID", SqlDbType.NVarChar, 100);
            cmd.Parameters.Add("@EventID", SqlDbType.Int);


            cmd.Parameters["@VolunteerID"].Value = volunteerID;
            cmd.Parameters["@EventID"].Value = eventID;



            try
            {

                conn.Open();


                rows = cmd.ExecuteNonQuery();

                if (rows == 0)
                {

                    throw new ArgumentException("Fields not updated");
                }


            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally { conn.Close(); }

            return rows;
        }

      
        /// <summary>
        /// Creator:            Marwa Ibrahim
        /// Created:            03/27/2024
        /// Summary:            UpdateClientPassword method
        /// Last Updated By:    Marwa Ibrahim
        /// Last Updated:       03/27/2024
        /// What Was Changed:   Initial Creation
        /// </summary>
        public bool UpdateClientPassword(string userID, string newPassword)
        {
            bool result = false;
            var conn = DatabaseConnection.GetConnection();
            SqlCommand cmd = new SqlCommand();
            var commandText = "sp_Update_Client_Password";
            cmd = new SqlCommand(commandText, conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@ClientID", userID);
            cmd.Parameters.AddWithValue("@PasswordHash", newPassword);

            try
            {
                conn.Open();
                result = cmd.ExecuteNonQuery() == 1;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally { conn.Close(); }
            return result;


        }
        #endregion

        #region Ibrahim's Code
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

            // connection
            var conn = DatabaseConnection.GetConnection();

            // command text
            var cmdText = "sp_select_all_Volunteers";

            // command 
            var cmd = new SqlCommand(cmdText, conn);

            // command type
            cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                conn.Open();

                var reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var v = new Volunteer();
                        v.UserID = reader.GetString(0);
                        v.FirstName = reader.GetString(1);
                        v.LastName = reader.GetString(2);
                        v.PhoneNumber = reader.GetString(3);
                        v.Gender = reader.GetBoolean(4);
                        v.AccountStatus = reader.GetBoolean(5);
                        v.Roles = new List<Role> { new Role { RoleID = reader.GetString(6) } };
                        v.RegistrationDate = reader.GetDateTime(7);
                        v.Address = reader.GetString(8);
                        v.ZipCode = reader.GetInt32(9);

                        volunteers.Add(v);
                    }
                }
            }
            catch (Exception ex) { throw ex; }
            finally { conn.Close(); }
            return volunteers;
        }
        #endregion

        /// <summary>
        /// Creator:Andres Garcia
        /// Created: 04/19/2024
        /// Summary: Selects all clientIds
        /// Last Updated By: Andres Garcia
        /// Last Updated: 04/19/2024
        /// What was Changed: Initial Creation
        /// </summary>
        public List<string> SelectAllClientIDs()
        {
            List<string> clientIDs = new List<string>();

            var conn = DatabaseConnection.GetConnection();
            var cmdText = "sp_select_Client_IDs";
            var cmd = new SqlCommand(cmdText, conn);
            cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        clientIDs.Add(reader.GetString(0));
                    }
                }
                else
                {
                    throw new ArgumentException("Clients not found");
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                conn.Close();
            }
            return clientIDs;
        }
        /// <summary>
        /// Creator:            Miyada Abas
        /// Created:            04/04/2024
        /// Summary:            Deactivte Client Application method
        /// Last Updated By:    Miyada Abas
        /// Last Updated:       04/04/2024
        /// What Was Changed:   Initial Creation
        /// </summary>
        public bool DeactivteClientApplication(Client client)
        {
            bool result = false;
            SqlConnection conn = DatabaseConnection.GetConnection();
            string commandText = "sp_deactivate_client_application";
            SqlCommand cmd = new SqlCommand(commandText, conn);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@UserID", client.UserID);
            cmd.Parameters.AddWithValue("@FirstName", client.FirstName);
            cmd.Parameters.AddWithValue("@LastName", client.LastName);
            cmd.Parameters.AddWithValue("@Gender", client.Gender);
            cmd.Parameters.AddWithValue("@Accomadations", client.Accomadations);
            cmd.Parameters.AddWithValue("@AccountStatus", client.AccountStatus);
            cmd.Parameters.AddWithValue("@RegistrationDate", client.RegistrationDate);

            try
            {
                conn.Open();
                result = cmd.ExecuteNonQuery() == 1;
            }
            catch (Exception)
            {

                throw;
            }
            finally { conn.Close(); }


            return result;

        }
        /// <summary>
        /// Creator:            Abdalgader Ibrahim
        /// Created:            04/11/2024
        /// Summary:            UpdateEmployeePassword method
        /// </summary>
        public bool UpdateEmployeePassword(string employeeID, string v)
        {
            bool result = false;
            var conn = DatabaseConnection.GetConnection();
            SqlCommand cmd = new SqlCommand();
            var commandText = "sp_update_employee_password";
            cmd = new SqlCommand(commandText, conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@EmployeeID", employeeID);
            cmd.Parameters.AddWithValue("@PasswordHash", v);

            try
            {
                conn.Open();
                result = cmd.ExecuteNonQuery() == 1;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally { conn.Close(); }
            return result;
        }
    }
}
