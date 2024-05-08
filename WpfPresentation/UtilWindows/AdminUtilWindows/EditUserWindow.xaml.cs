using DataObjects;
using LogicLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfPresentation.UtilWindows.AdminUtilWindows
{
    /// <summary>
    /// Creator: Matthew Baccam
    /// Created: 03/15/2024
    /// Summary: Edit Window for User
    /// Last Updated By: Matthew Baccam
    /// Last Updated: 03/15/2024
    /// What Was changed: Initial creation
    /// </summary>
    public partial class EditUserWindow : Window
    {
        User _user;
        MainManager _mainManager;
        List<Role> _roleList;//This will be used so I can grab a specific Role object in other places

        private static pgVisitations instance = null;
        public static pgVisitations GetVisitationPage()
        {
            return instance ?? (instance = new pgVisitations());
        }

        public EditUserWindow(User user)
        {
            InitializeComponent();
            _mainManager = MainManager.GetMainManager();
            _user = user;
        }


        /// <summary>
        /// Creator: Matthew Baccam
        /// Created: 02/15/2024
        /// Summary: Updates the UI in general based on the user type
        /// Last Updated By: Matthew Baccam
        /// Last Updated: 02/15/2024
        /// What Was changed: Initial creation
        /// /// Last Updated By: Ibrahim Albashair
        /// Last Updated: 03/21/2024
        /// What Was changed: Added Volunteers
        /// </summary>
        private void UpdateUI()
        {
            UpdateUIForUser();
            if (_user is Employee)
            {
                UpdateUiForEmployee();
            }
            else if (_user is Client)
            {
                UpdateUiForClient();
            }
            else if (_user is Volunteer)
            {
                UpdateUiForVolunteer();
            }
        }


        /// <summary>
        /// Creator: Matthew Baccam
        /// Created: 03/15/2024
        /// Summary: Updates the UI for the general "User" class
        /// Last Updated By: Matthew Baccam
        /// Last Updated: 03/15/2024
        /// What Was changed: Initial creation
        /// </summary>
        private void UpdateUIForUser()
        {
            lblEditTitle.Content = $"Edit: {_user.UserID}";
            txtBoxFirstName.Text = _user.FirstName;
            txtBoxLastName.Text = _user.LastName;
            cboAccountStatus.Text = _user.AccountStatus == true ? "Active" : "Inactive";
            cboGender.SelectedItem = _user.DisplayGender == "Male" ? cboItemMale : cboItemFemale;
        }


        /// <summary>
        /// Creator: Matthew Baccam
        /// Created: 03/15/2024
        /// Summary: Updates the ui for an employee
        /// Last Updated By: Matthew Baccam
        /// Last Updated: 03/15/2024
        /// What Was changed: Initial creation
        /// </summary>
        private void UpdateUiForEmployee()
        {
            Employee employee = _user as Employee;
            try
            {
                _roleList = _mainManager.UserManager.SelectAllRoles();
            }
            catch (Exception)
            {
                MessageBox.Show("Could not retrieve roles", "Failed to get roles", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            lblPhone.Visibility = Visibility.Visible;
            txtBoxPhone.Visibility = Visibility.Visible;
            lblZip.Visibility = Visibility.Visible;
            txtBoxZip.Visibility = Visibility.Visible;
            lblAddress.Visibility = Visibility.Visible;
            txtBoxAddress.Visibility = Visibility.Visible;
            lblAddRole.Visibility = Visibility.Visible;
            cboAddRoles.Visibility = Visibility.Visible;
            dataGridRoles.Visibility = Visibility.Visible;
            btnAddRole.Visibility = Visibility.Visible;
            cboAddRoles.ItemsSource = _roleList.Select(role => role.RoleID);
            txtBoxPhone.Text = employee.PhoneNumber;
            txtBoxZip.Text = employee.ZipCode.ToString();
            txtBoxAddress.Text = employee.Address;
            cboAddRoles.Text = employee.Roles.Count != 0 ? employee.Roles[0].RoleID : "";
            dataGridRoles.ItemsSource = employee.Roles;
            datePickerRegistration.SelectedDate = employee.StartDate;
            if (employee.EndDate != null)
            {
                datePickerExit.SelectedDate = employee.EndDate;
            }
        }

        /// <summary>
        /// Creator: Matthew Baccam
        /// Created: 03/06/2024
        /// Summary: Updates the ui for an client
        /// Last Updated By: Matthew Baccam
        /// Last Updated: 03/06/2024
        /// What Was changed: Initial creation
        /// </summary>
        private void UpdateUiForClient()
        {
            try
            {
                var client = _user as Client;
                Grid.SetRow(txtBoxAccommodations, 1);
                Grid.SetRow(lblAccommodations, 1);
                lblAccommodations.Visibility = Visibility.Visible;
                txtBoxAccommodations.Visibility = Visibility.Visible;
                txtBoxAccommodations.Text = client.Accomadations;
                datePickerRegistration.SelectedDate = client.RegistrationDate;
                if (client.ExitDate != null)
                {
                    datePickerExit.SelectedDate = client.ExitDate;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Could not select client", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        /// <summary>
        /// Creator: Ibrahim Albashair
        /// Created: 03/21/2024
        /// Summary: Updates the ui for a Volunteer
        /// Last Updated By: Ibrahim Albashair
        /// Last Updated: 03/21/2024
        /// What Was changed: Initial creation
        /// </summary>
        private void UpdateUiForVolunteer()
        {

            Volunteer volunteer = _user as Volunteer;
            lblPhone.Visibility = Visibility.Visible;
            datePickerExit.Visibility = Visibility.Hidden;
            txtBoxPhone.Visibility = Visibility.Visible;
            lblZip.Visibility = Visibility.Visible;
            txtBoxZip.Visibility = Visibility.Visible;
            lblAddress.Visibility = Visibility.Visible;
            txtBoxAddress.Visibility = Visibility.Visible;
            lblAddRole.Visibility = Visibility.Hidden;
            cboAddRoles.Visibility = Visibility.Hidden;
            dataGridRoles.Visibility = Visibility.Hidden;
            btnAddRole.Visibility = Visibility.Hidden;
            datePickerExitLabel.Visibility = Visibility.Hidden;
            lblEditTitle.Content = $"Edit: {volunteer.UserID}";
            txtBoxPhone.Text = volunteer.PhoneNumber;
            int gender = volunteer.Gender ? 1 : 0;
            cboGender.SelectedIndex = gender;
            txtBoxZip.Text = volunteer.ZipCode.ToString();
            txtBoxAddress.Text = volunteer.Address;
            txtBoxFirstName.Text = volunteer.FirstName;
            txtBoxLastName.Text = volunteer.LastName;
            datePickerRegistration.SelectedDate = volunteer.RegistrationDate;
            cboAccountStatus.Text = volunteer.AccountStatus == true ? "Active" : "Inactive";
        }


        /// <summary>
        /// Creator: Matthew Baccam
        /// Created: 03/15/2024
        /// Summary: Updates the users info based on the type
        /// Last Updated By: Matthew Baccam
        /// Last Updated: 03/15/2024
        /// What Was changed: Initial creation
        /// Last Updated By: Ibrahim 
        /// Last Updated: 03/27/2024
        /// What Was changed: Moved Messagebox and close dialog code
        /// </summary>
        private void UpdateUserInformation()
        {
            var result = MessageBox.Show("Are you sure you want to save", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                try
                {
                    var newUser = BuildDedicatedUserObject();
                    if (newUser != null)
                    {
                        //Saving the details
                        if (_mainManager.UserManager.UpdateUserDetails(newUser, _user))
                        {

                            if (_user is Employee)
                            {//HERE: Remove the roles or add if any
                                List<Role> addList = new List<Role>();
                                List<Role> removeList = new List<Role>();
                                try
                                {
                                    var unupdatedEmployeeRoles = _mainManager.UserManager.SelectEmployeeByID(_user.UserID) as Employee;
                                    var updatedEmployeeRoles = _user as Employee;

                                    //If current employee does contain newly assigned roles then add them to the addlist so we can add them since the admin has assigned those roles
                                    updatedEmployeeRoles.Roles.ForEach(newRole =>
                                    {
                                        var similiarRole = unupdatedEmployeeRoles.Roles.FirstOrDefault(ogRole => ogRole.RoleID == newRole.RoleID);
                                        if (similiarRole == null)
                                        {
                                            addList.Add(newRole);
                                        }
                                    });

                                    //If current employee does not contain newly assigned roles then add them to the deletelist so we can remove them since the admin has unnasigned those roles
                                    unupdatedEmployeeRoles.Roles.ForEach(ogRole =>
                                    {
                                        var similiarRole = updatedEmployeeRoles.Roles.FirstOrDefault(newRole => newRole.RoleID == ogRole.RoleID);
                                        if (similiarRole == null)
                                        {
                                            removeList.Add(ogRole);
                                        }
                                    });

                                    try
                                    {
                                        if (addList.Count > 0) _mainManager.UserManager.CreateEmployeeRoles(_user.UserID, addList);
                                    }
                                    catch (Exception ex)
                                    {
                                        MessageBox.Show(ex.Message, "Failed to create", MessageBoxButton.OK, MessageBoxImage.Error);
                                        return;
                                    }
                                    try
                                    {
                                        if (removeList.Count > 0) _mainManager.UserManager.RemoveEmployeeRoles(_user.UserID, removeList);
                                    }
                                    catch (Exception ex)
                                    {
                                        MessageBox.Show(ex.Message, "Failed to remove", MessageBoxButton.OK, MessageBoxImage.Error);
                                        return;
                                    }
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show(ex.Message, "Select employee", MessageBoxButton.OK, MessageBoxImage.Error);
                                }
                            }
                            MessageBox.Show("User details saved", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Save failed", "Fail", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }
                    else
                    {
                        UpdateUI();
                        return;
                    }
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.InnerException.Message, "Failed to update", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
        }

        /// <summary>
        /// Creator: Matthew Baccam
        /// Created: 03/15/2024
        /// Summary: builds the object for the newUser param in the udpate method using the inputs on the screeen provided to the user
        /// Last Updated By: Matthew Baccam
        /// Last Updated: 03/15/2024
        /// What Was changed: Initial creation
        /// Last Updated By: Ibrahim Albashair
        /// Last Updated: 03/22/2024
        /// What Was changed: Added Volunteer Functions
        /// </summary>
        private User BuildDedicatedUserObject()
        {
            if (IsValidForm()) //Checks if general user fields are not blank
            {
                if (_user is Employee)
                {//builds an employee object with the inputs provided
                    var employee = new Employee();
                    employee.FirstName = txtBoxFirstName.Text;
                    employee.LastName = txtBoxLastName.Text;
                    employee.AccountStatus = cboAccountStatus.Text == "Active" ? true : false;
                    employee.Gender = cboGender.Text == "Male" ? true : false;
                    employee.PhoneNumber = txtBoxPhone.Text;
                    employee.Address = txtBoxAddress.Text;
                    employee.ZipCode = int.Parse(txtBoxZip.Text);
                    employee.StartDate = DateTime.Parse(datePickerRegistration.SelectedDate.ToString());
                    employee.EndDate = datePickerExit.SelectedDate == null ? null : datePickerExit.SelectedDate;
                    return employee;
                }
                else if (_user is Client)
                {//builds an client object with the inputs provided
                    var client = new Client();
                    client.FirstName = txtBoxFirstName.Text;
                    client.LastName = txtBoxLastName.Text;
                    client.AccountStatus = cboAccountStatus.Text == "Active" ? true : false;
                    client.Gender = cboGender.Text == "Male" ? true : false;
                    client.Accomadations = txtBoxAccommodations.Text;
                    client.RegistrationDate = DateTime.Parse(datePickerRegistration.SelectedDate.ToString());
                    client.ExitDate = datePickerExit.SelectedDate == null ? null : datePickerExit.SelectedDate;
                    return client;
                }
                else if (_user is Volunteer)
                {
                    var volunteer = new Volunteer();
                    volunteer.FirstName = txtBoxFirstName.Text;
                    volunteer.LastName = txtBoxLastName.Text;
                    volunteer.AccountStatus = cboAccountStatus.Text == "Active" ? true : false;
                    volunteer.PhoneNumber = txtBoxPhone.Text;
                    volunteer.Address = txtBoxAddress.Text;
                    volunteer.Gender = cboGender.Text == "Male" ? true : false;
                    volunteer.ZipCode = int.Parse(txtBoxZip.Text);
                    volunteer.RegistrationDate = (DateTime)datePickerRegistration.SelectedDate;
                    return volunteer;
                }
            }
            return null;//returns a new user if all fails
        }

        /// <summary>
        /// Creator: Matthew Baccam
        /// Created: 03/15/2024
        /// Summary: Calls the updateui method
        /// Last Updated By: Matthew Baccam
        /// Last Updated: 03/15/2024
        /// What Was changed: Initial creation
        /// </summary>
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            UpdateUI();
        }

        /// <summary>
        /// Creator: Matthew Baccam
        /// Created: 03/15/2024
        /// Summary: Adds roles to the datagrid
        /// Last Updated By: Matthew Baccam
        /// Last Updated: 03/15/2024
        /// What Was changed: Initial creation
        /// </summary>
        private void btnAddRole_Click(object sender, RoutedEventArgs e)
        {
            var employee = _user as Employee;
            var volunteer = _user as Volunteer;
            var newRole = _roleList.FirstOrDefault(role => role.RoleID == cboAddRoles.Text && role.PositionsAvailable > 0);
            if (_user is Employee)
            {
                if (newRole != null && employee.Roles != null && employee.Roles.FirstOrDefault(role => role.RoleID == newRole.RoleID) == null)
                {
                    employee.Roles.Add(newRole);
                    dataGridRoles.ItemsSource = employee.Roles;
                    dataGridRoles.Items.Refresh(); //Had to use refresh because the itemssource's collection was always the "same" because it referenced the employee.Roles
                }
            }
            else if (_user is Volunteer)
            {
                if (newRole != null && volunteer.Roles != null && volunteer.Roles.FirstOrDefault(role => role.RoleID == newRole.RoleID) == null)
                {
                    volunteer.Roles.Add(newRole);
                    dataGridRoles.ItemsSource = volunteer.Roles;
                    dataGridRoles.Items.Refresh();
                }
            }
            else if (newRole == null)
            {
                MessageBox.Show("Role has no open positions", "Role assignment failed", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        /// <summary>
        /// Creator: Matthew Baccam
        /// Created: 03/15/2024
        /// Summary: Updates the User
        /// Last Updated By: Matthew Baccam
        /// Last Updated: 03/15/2024
        /// What Was changed: Initial creation
        /// </summary>
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            //Are you sure prompt here
            UpdateUserInformation();
        }

        /// <summary>
        /// Creator: Matthew Baccam
        /// Created: 03/15/2024
        /// Summary: Validates that its a number
        /// Last Updated By: Matthew Baccam
        /// Last Updated: 03/15/2024
        /// What Was changed: Initial creation
        /// </summary>
        private void txtBoxZip_LostFocus(object sender, RoutedEventArgs e)
        {
            int r;
            if (txtBoxZip.Text.Replace(" ", string.Empty) == string.Empty || !Int32.TryParse(txtBoxZip.Text, out r))
            {
                var employee = _user as Employee;
                txtBoxZip.Text = employee.ZipCode.ToString();
            }
        }

        /// <summary>
        /// Creator: Matthew Baccam
        /// Created: 03/15/2024
        /// Summary: Closes the page
        /// Last Updated By: Matthew Baccam
        /// Last Updated: 03/15/2024
        /// What Was changed: Initial creation
        /// </summary>
        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            var choice = MessageBox.Show("Are you sure you want to exit", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Information);
            if (choice == MessageBoxResult.Yes)
            {
                this.Close();
            }
        }

        /// <summary>
        /// Creator: Matthew Baccam
        /// Created: 03/15/2024
        /// Summary: Removes the selected role from the data grid
        /// Last Updated By: Matthew Baccam
        /// Last Updated: 03/15/2024
        /// What Was changed: Initial creation
        /// </summary>
        private void dataGridRoles_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (dataGridRoles.SelectedItem != null)
            {
                var employee = _user as Employee;
                var volunteer = _user as Volunteer;
                var role = dataGridRoles.SelectedItem as Role;
                var result = MessageBox.Show($"Are you sure you want to delete the selected role {role.RoleID}", "Confirm", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                if (result == MessageBoxResult.Yes)
                {
                    if (_user is Employee)
                    {
                        employee.Roles.Remove(role);
                        dataGridRoles.Items.Refresh();
                    }
                    else if (_user is Volunteer)
                    {
                        volunteer.Roles.Remove(role);
                        dataGridRoles.Items.Refresh();
                    }
                }
            }
        }

        /// <summary>
        /// Creator: Matthew Baccam
        /// Created: 03/22/2024
        /// Summary: Checks if form is valid
        /// Last Updated By: Matthew Baccam
        /// Last Updated: 03/22/2024
        /// What Was changed: Initial creation
        /// </summary>
        private bool IsValidForm()
        {
            string missingAttributes = "";

            // Checking common user inputs
            if (string.IsNullOrEmpty(txtBoxFirstName.Text))
                missingAttributes += "First Name, ";

            if (string.IsNullOrEmpty(txtBoxLastName.Text))
                missingAttributes += "Last Name, ";

            if (datePickerRegistration.SelectedDate == null)
                missingAttributes += "Registration Date, ";

            if (cboAccountStatus.SelectedItem == null)
                missingAttributes += "Account Status, ";

            if (cboGender.SelectedItem == null)
                missingAttributes += "Gender, ";

            // Checking user-specific inputs
            if (txtBoxAccommodations.Visibility == Visibility.Visible)
            {
                if (string.IsNullOrEmpty(txtBoxAccommodations.Text))
                    missingAttributes += "Accommodations, ";
            }

            if (txtBoxAddress.Visibility == Visibility.Visible)
            {
                if (string.IsNullOrEmpty(txtBoxAddress.Text))
                    missingAttributes += "Address, ";
            }

            if (txtBoxZip.Visibility == Visibility.Visible)
            {
                if (string.IsNullOrEmpty(txtBoxZip.Text))
                    missingAttributes += "Zip, ";
            }

            if (txtBoxPhone.Visibility == Visibility.Visible)
            {
                if (string.IsNullOrEmpty(txtBoxPhone.Text))
                    missingAttributes += "Phone, ";
            }

            if (dataGridRoles.Visibility == Visibility.Visible)
            {
                if (dataGridRoles.Items.Count == 0)
                    missingAttributes += "Missing roles, ";
            }

            if (string.IsNullOrEmpty(missingAttributes))
            {
                return true;
            }
            else
            {
                MessageBox.Show("The following field(s) are invalid:\n" + missingAttributes.Remove(missingAttributes.Length - 2), "Invalid form", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
        }
    }
}
