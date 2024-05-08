using DataObjects;
using LogicLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Navigation;
using WpfPresentation.Pages.Stats;
using WpfPresentation.UtilWindows.AdminUtilWindows;

namespace WpfPresentation.Pages.Admin
{
    /// <summary>
    /// Interaction logic for pgCreateClient.xaml
    /// </summary>
    public partial class pgCreateUser : Page
    {
        private static pgCreateUser instance = null;
        private List<Role> _addRoles = new List<Role>();//this will be for employees only
        private List<Role> _roles;
        private MainManager _mainManager;
        private DataObjects.User _user;
        public static pgCreateUser GetCreateClientPage()
        {
            return instance ?? (instance = new pgCreateUser());
        }

        public pgCreateUser()
        {
            InitializeComponent();
            _mainManager = MainManager.GetMainManager();
        }

        /// <summary>
        /// Creator: Matthew Baccam
        /// Created: 03/21/2024
        /// Summary: Creates the page on load
        /// Last Updated By: Matthew Baccam
        /// Last Updated: 03/21/2024
        /// What Was changed: Initial creation
        /// </summary>
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            //Asks what they wanna create before the opage is loaded
            //This also gets the user type aswell 
            if (instance != null) ResetUI(); //Resets the UI if an instance of the page
            DisplayPopUp();
        }

        /// <summary>
        /// Creator: Tyler Barz
        /// Created: 03/25/2024
        /// Summary: This is the control of the popup that is presented on load it gives the user the choice of inputting what they want to create
        /// Last Updated By: Mitchell Stirmel
        /// Last Updated: 04/11/2024
        /// What Was changed: Added try catch
        /// </summary>
        //
        void DisplayPopUp()
        {
            try
            {
                var selectUser = new SelectUserTypeWindow();
                selectUser.ShowDialog();
                if (selectUser.DialogResult == true)
                {
                    _user = selectUser.UserType;
                    UpdateUI(_user);
                }
                else
                {
                    NavigationService.Navigate(PgShelterDashboard.GetPgShelterDashboard());
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Failure", MessageBoxButton.OK);
            }

        }

        /// <summary>
        /// Creator: Matthew Baccam
        /// Created: 03/21/2024
        /// Summary: Generates the ui for the according user
        /// Last Updated By: Matthew Baccam
        /// Last Updated: 03/21/2024
        /// What Was changed: Initial creation
        /// </summary>
        private void UpdateUI(DataObjects.User user)
        {
            cboAccountStatus.SelectedItem = cboItemActive;
            datePickerRegistration.SelectedDate = DateTime.Now;
            cboGender.SelectedItem = cboItemMale;
            if (user is Client)//Shows client related input
            {
                lblAccommodations.Visibility = Visibility.Visible;
                txtBoxAccommodations.Visibility = Visibility.Visible;
                lblHousingSituation.Visibility = Visibility.Visible;
                cboHousingSituation.Visibility = Visibility.Visible;
                lblCriminalRecord.Visibility = Visibility.Visible;
                stckPnlCriminalRecord.Visibility = Visibility.Visible;

                Grid.SetRow(lblPassword, 4);
                Grid.SetRow(txtBoxPassword, 4);
                Grid.SetRow(lblConfirmPassword, 5);
                Grid.SetRow(txtBoxConfirmPassword, 5);
            }
            else if (user is Volunteer)//Shows volunteer related inputs and also moves the password inputs so its better formatted
            {
                try
                {
                    _roles = _mainManager.UserManager.SelectAllRoles();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Role retrieval failed", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                Grid.SetRow(lblPassword, 3);
                Grid.SetRow(txtBoxPassword, 3);
                Grid.SetRow(lblConfirmPassword, 4);
                Grid.SetRow(txtBoxConfirmPassword, 4);
                lblAddRole.Visibility = Visibility.Visible;
                cboAddRoles.Visibility = Visibility.Visible;
                lblAddress.Visibility = Visibility.Visible;
                txtBoxAddress.Visibility = Visibility.Visible;
                lblZip.Visibility = Visibility.Visible;
                txtBoxZip.Visibility = Visibility.Visible;
                lblPhone.Visibility = Visibility.Visible;
                txtBoxPhone.Visibility = Visibility.Visible;
                cboAddRoles.SelectedItem = _roles[0].RoleID;
                cboAddRoles.ItemsSource = _roles.Select(role => role.RoleID).ToList();
                dataGridRoles.ItemsSource = _addRoles;
            }
            else if (user is Employee)
            {
                try
                {
                    _roles = _mainManager.UserManager.SelectAllRoles();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Role retrieval failed", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                Grid.SetRow(lblPassword, 5);
                Grid.SetRow(txtBoxPassword, 5);
                Grid.SetRow(lblConfirmPassword, 6);
                Grid.SetRow(txtBoxConfirmPassword, 6);
                lblAddRole.Visibility = Visibility.Visible;
                btnAddRole.Visibility = Visibility.Visible;
                dataGridRoles.Visibility = Visibility.Visible;
                cboAddRoles.Visibility = Visibility.Visible;
                lblAddress.Visibility = Visibility.Visible;
                txtBoxAddress.Visibility = Visibility.Visible;
                lblZip.Visibility = Visibility.Visible;
                txtBoxZip.Visibility = Visibility.Visible;
                lblPhone.Visibility = Visibility.Visible;
                txtBoxPhone.Visibility = Visibility.Visible;
                cboAddRoles.SelectedItem = _roles[0].RoleID;
                cboAddRoles.ItemsSource = _roles.Select(role => role.RoleID).ToList();
                dataGridRoles.ItemsSource = _addRoles;
            }
        }

        /// <summary>
        /// Creator: Matthew Baccam
        /// Created: 03/21/2024
        /// Summary: Resets the ui 
        /// Last Updated By: Sagan DeWald
        /// Last Updated: 03/21/2024
        /// What Was changed: Added visibility events for Client Priority items.
        /// </summary>
        private void ResetUI()
        {
            cboAccountStatus.SelectedItem = null;
            datePickerRegistration.SelectedDate = null;
            cboGender.SelectedItem = null;
            Grid.SetRow(lblPassword, 2);
            Grid.SetRow(txtBoxPassword, 2);
            Grid.SetRow(lblConfirmPassword, 3);
            Grid.SetRow(txtBoxConfirmPassword, 3);
            lblAddRole.Visibility = Visibility.Hidden;
            lblAddress.Visibility = Visibility.Hidden;
            lblZip.Visibility = Visibility.Hidden;
            lblPhone.Visibility = Visibility.Hidden;
            lblAddRole.Visibility = Visibility.Hidden;
            lblPhone.Visibility = Visibility.Hidden;
            lblHousingSituation.Visibility = Visibility.Hidden;
            cboHousingSituation.Visibility = Visibility.Hidden;
            lblHousingSituation.Visibility = Visibility.Hidden;
            lblHousingExplanation.Visibility = Visibility.Hidden;
            txtBoxHousingExplanation.Visibility = Visibility.Hidden;
            lblCriminalRecord.Visibility = Visibility.Hidden;
            stckPnlCriminalRecord.Visibility = Visibility.Hidden;
            lblCrimeExplanation.Visibility = Visibility.Hidden;
            txtBoxCrimeExplanation.Visibility = Visibility.Hidden;
            lblAccommodations.Visibility = Visibility.Hidden;
            btnAddRole.Visibility = Visibility.Hidden;
            dataGridRoles.Visibility = Visibility.Hidden;
            cboAddRoles.Visibility = Visibility.Hidden;
            txtBoxAddress.Visibility = Visibility.Hidden;
            txtBoxZip.Visibility = Visibility.Hidden;
            txtBoxPhone.Visibility = Visibility.Hidden;
            txtBoxAccommodations.Visibility = Visibility.Hidden;

            txtBoxEmail.Text = "";
            txtBoxFirstName.Text = "";
            txtBoxLastName.Text = "";
            cboAddRoles.Text = "";
            txtBoxAddress.Text = "";
            txtBoxZip.Text = "";
            txtBoxPhone.Text = "";
            txtBoxAccommodations.Text = "";
        }

        /// <summary>
        /// Creator: Matthew Baccam
        /// Created: 03/21/2024
        /// Summary: Saves the new client
        /// Last Updated By: Sagan DeWald
        /// Last Updated: 04/25/2024
        /// What Was changed: Support for Client Priority.
        /// </summary>
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (IsValidForm())
            {
                try
                {
                    _user = BuildDedicatedUserObject();
                    if (_mainManager.UserManager.CreateNewUser(_user, txtBoxPassword.Password))
                    {
                        if (_user is Employee)
                        {
                            try
                            {
                                if (_mainManager.UserManager.CreateEmployeeRoles(txtBoxEmail.Text, _addRoles))
                                {
                                    MessageBox.Show($"Successfully created {_user}: {_user.FullName}\n", "Creation Success", MessageBoxButton.OK, MessageBoxImage.Error);
                                    return;
                                }
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message, ex.InnerException.Message, MessageBoxButton.OK, MessageBoxImage.Error);
                            }
                        }
                        else if(_user is Client)
                        {
                            try
                            {
                                int basePriority = 1; //"Other" housing situation is lowest by default, but their explanation is stored to be reviewed and manually adjusted later.
                                int deductions = 0;

                                string otherHousingSituation = "";
                                if (cboHousingSituation.SelectedIndex == 0) //Currently homeless.
                                {
                                    basePriority = 4;
                                }
                                else if (cboHousingSituation.SelectedIndex == 1) //In danger of being homeless within two weeks.
                                {
                                    basePriority = 3;
                                }
                                else if (cboHousingSituation.SelectedIndex == 2) //Unstable housing.
                                {
                                    basePriority = 2;
                                }
                                else if(cboHousingSituation.SelectedIndex == 3)
                                {
                                    otherHousingSituation = txtBoxHousingExplanation.Text;
                                }

                                string notableConvictions = "";
                                //Lower their priority be default if convicted of a crime, but their explanation is stored so this can be reviewed and possibly reversed later.
                                if ((bool)rbConvicted_Yes.IsChecked)
                                {
                                    deductions++;
                                    notableConvictions = txtBoxCrimeExplanation.Text;
                                }

                                if (_mainManager.ClientPriorityManager.AddClientPriority(_user.UserID, basePriority, deductions, notableConvictions, otherHousingSituation) > 0)
                                {
                                    MessageBox.Show($"Successfully created {_user}: {_user.FullName}\n", "Creation Success", MessageBoxButton.OK, MessageBoxImage.Error);
                                    return;
                                }
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message, ex.InnerException.Message, MessageBoxButton.OK, MessageBoxImage.Error);
                            }
                        }
                    }
                    MessageBox.Show($"Successfully created: {_user.FullName}\n", "Creation Success", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, ex.InnerException.Message, MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        /// <summary>
        /// Creator: Matthew Baccam
        /// Created: 03/21/2024
        /// Summary: Builds an object from the input and retuirns it 
        /// Last Updated By: Matthew Baccam
        /// Last Updated: 03/21/2024
        /// What Was changed: Initial creation
        /// </summary>
        private DataObjects.User BuildDedicatedUserObject()
        {
            if (IsValidForm()) //Checks if general user fields are not blank
            {
                _user.UserID = txtBoxEmail.Text;
                _user.FirstName = txtBoxFirstName.Text;
                _user.LastName = txtBoxLastName.Text;
                _user.AccountStatus = cboAccountStatus.Text == "Active" ? true : false;
                _user.Gender = cboGender.Text == "Male" ? true : false;
                if (_user is Client)//Creates a Client object and returns it
                {
                    var client = _user as Client;
                    client.Accomadations = txtBoxAccommodations.Text;
                    client.RegistrationDate = DateTime.Parse(datePickerRegistration.SelectedDate.ToString());
                    return client;
                }
                else if (_user is Volunteer)//Creates a Volunteer object and returns it
                {
                    var volunteer = _user as Volunteer;
                    volunteer.PhoneNumber = txtBoxPhone.Text;
                    volunteer.Address = txtBoxAddress.Text;
                    volunteer.ZipCode = int.Parse(txtBoxZip.Text);
                    volunteer.RegistrationDate = DateTime.Parse(datePickerRegistration.SelectedDate.ToString());
                    volunteer.Roles = _roles.Where(role => role.RoleID == cboAddRoles.SelectedItem.ToString()).ToList();
                    return volunteer;
                }
                else if (_user is Employee)//Creates a Employee object and returns it
                {
                    var employee = _user as Employee;
                    employee.PhoneNumber = txtBoxPhone.Text;
                    employee.Address = txtBoxAddress.Text;
                    employee.ZipCode = int.Parse(txtBoxZip.Text);
                    employee.StartDate = DateTime.Parse(datePickerRegistration.SelectedDate.ToString());
                    employee.Roles = _addRoles;
                    return employee;
                }
            }
            return _user;//returns a new user if all fails
        }

        /// <summary>
        /// Creator: Matthew Baccam
        /// Created: 03/21/2024
        /// Summary: Checks if the form is valid and returns error msg if false
        /// Last Updated By: Sagan DeWald
        /// Last Updated: 03/21/2024
        /// What Was changed: Support for Client Priority.
        /// </summary>
        private bool IsValidForm()
        {
            string missingAttributes = "";//This will be used to display whats wrong
            //Checking common user inputs
            try
            {
                if (string.IsNullOrEmpty(txtBoxEmail.Text))
                    missingAttributes += "Email, ";
                else if (!txtBoxEmail.Text.IsValidEmail())
                    missingAttributes += "Invalid Email, ";
                else if (!_mainManager.UserManager.EmailAvailability(txtBoxEmail.Text))
                    missingAttributes += "Email already in use, ";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.InnerException.Message, MessageBoxButton.OK, MessageBoxImage.Error);
            }

            if (string.IsNullOrEmpty(txtBoxFirstName.Text))
                missingAttributes += "First Name, ";

            if (string.IsNullOrEmpty(txtBoxLastName.Text))
                missingAttributes += "Last Name, ";

            if (string.IsNullOrEmpty(txtBoxPassword.Password))
                missingAttributes += "Password, ";

            if (string.IsNullOrEmpty(txtBoxConfirmPassword.Password))
                missingAttributes += "Confirm Password, ";
            else if (txtBoxConfirmPassword.Password != txtBoxPassword.Password)
                missingAttributes += "Password Mismatch, ";
            else if (!ValidationHelpers.IsValidPassword(txtBoxConfirmPassword.Password))
                missingAttributes += "Invalid Password, ";

            if (datePickerRegistration.SelectedDate == null)
                missingAttributes += "Registration Date, ";

            // Checking user specific inputs
            if (_user is Employee)
            {
                if (string.IsNullOrEmpty(txtBoxAddress.Text))
                    missingAttributes += "Address, ";
                if (string.IsNullOrEmpty(txtBoxZip.Text))
                    missingAttributes += "Zip, ";
                if (string.IsNullOrEmpty(txtBoxPhone.Text))
                    missingAttributes += "Phone, ";
                if (dataGridRoles.Items.Count == 0)
                    missingAttributes += "Missing roles, ";
            }
            else if (_user is Client)
            {
                if(cboHousingSituation.SelectedItem == null)
                {
                    missingAttributes += "Housing Situation Selection, ";
                }
                else
                {
                    string residenceSelection = (string)((ComboBoxItem)cboHousingSituation.SelectedItem).Content;
                    if(residenceSelection == "Other" && string.IsNullOrEmpty(txtBoxHousingExplanation.Text))
                    {
                        missingAttributes += "Housing Situation Explanation, ";
                    }
                }

                if((bool)rbConvicted_Yes.IsChecked && string.IsNullOrEmpty(txtBoxCrimeExplanation.Text)) 
                {
                    missingAttributes += "Conviction Explanation, ";
                }

                if (string.IsNullOrEmpty(txtBoxAccommodations.Text))
                    missingAttributes += "Accommodations, ";
            }
            else if (_user is Volunteer)
            {
                if (string.IsNullOrEmpty(txtBoxAddress.Text))
                    missingAttributes += "Address, ";
                if (string.IsNullOrEmpty(txtBoxZip.Text))
                    missingAttributes += "Zip, ";
                if (string.IsNullOrEmpty(txtBoxPhone.Text))
                    missingAttributes += "Phone, ";
            }
            if (string.IsNullOrEmpty(missingAttributes))
            {
                return true;
            }
            else
            {
                MessageBox.Show("The following field(s) are invalid\n" + missingAttributes.Remove(missingAttributes.Length - 2), "Invalid form", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
        }


        /// <summary>
        /// Creator: Matthew Baccam
        /// Created: 03/21/2024
        /// Summary: Checks if zip is an int
        /// Last Updated By: Matthew Baccam
        /// Last Updated: 03/21/2024
        /// What Was changed: Initial creation
        /// </summary>
        private void txtBoxZip_LostFocus(object sender, RoutedEventArgs e)
        {
            int r;
            if (txtBoxZip.Text.Replace(" ", string.Empty) == string.Empty || !Int32.TryParse(txtBoxZip.Text, out r))
            {
                txtBoxZip.Text = "";
            }
        }

        /// <summary>
        /// Creator: Matthew Baccam
        /// Created: 03/21/2024
        /// Summary: Adds a role
        /// Last Updated By: Mitchell Stirmel
        /// Last Updated: 04/11/2024
        /// What Was changed: Added try catch
        /// </summary>
        private void btnAddRole_Click(object sender, RoutedEventArgs e)
        {
            var newRole = _roles.FirstOrDefault(role => role.RoleID == cboAddRoles.Text && role.PositionsAvailable > 0);
            if (newRole != null)
            {
                try
                {
                    _addRoles.Add(newRole);
                    dataGridRoles.Items.Refresh();
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.ToString(), "Failed to add role", MessageBoxButton.OK);
                }
            }
            else
            {
                MessageBox.Show($"No positions available for {cboAddRoles.Text}", "No Availability", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        /// <summary>
        /// Creator: Matthew Baccam
        /// Created: 03/21/2024
        /// Summary: Deletes the item from the data grid on double click
        /// Last Updated By: Matthew Baccam
        /// Last Updated: 03/21/2024
        /// What Was changed: Initial creation
        /// </summary>
        private void dataGridRoles_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (dataGridRoles.SelectedItem != null)
            {
                var selectedRole = dataGridRoles.SelectedItem as Role;
                var roleList = (List<Role>)dataGridRoles.ItemsSource;
                _addRoles.Remove(selectedRole);
                dataGridRoles.Items.Refresh();
            }
        }

        /// <summary>
        /// Creator: Matthew Baccam
        /// Created: 03/21/2024
        /// Summary: Canceled any change
        /// Last Updated By: Matthew Baccam
        /// Last Updated: 03/21/2024
        /// What Was changed: Initial creation
        /// </summary>
        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(PgShelterDashboard.GetPgShelterDashboard());
        }

        /// <summary>
        /// Creator: Matthew Baccam
        /// Created: 03/21/2024
        /// Summary: Activates confirm password if its a valid pass
        /// Last Updated By: Matthew Baccam
        /// Last Updated: 03/21/2024
        /// What Was changed: Initial creation
        /// </summary>

        private void txtBoxPassword_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtBoxPassword.Password.IsValidPassword() && txtBoxPassword.Password == txtBoxConfirmPassword.Password)
            {
                txtBoxConfirmPassword.BorderThickness = new Thickness(1);
                txtBoxPassword.BorderThickness = new Thickness(1);
                txtBoxPassword.BorderBrush = new SolidColorBrush(Colors.Black);
                txtBoxConfirmPassword.BorderBrush = new SolidColorBrush(Colors.Black);
            }
            else
            {
                txtBoxConfirmPassword.BorderThickness = new Thickness(1);
                txtBoxPassword.BorderThickness = new Thickness(1);
                txtBoxConfirmPassword.BorderBrush = new SolidColorBrush(Colors.LightSalmon);
                txtBoxPassword.BorderBrush = new SolidColorBrush(Colors.LightSalmon);
            }

        }

        /// <summary>
        /// Creator: Matthew Baccam
        /// Created: 03/21/2024
        /// Summary: Checks if the passwords match on txt change
        /// Last Updated By: Matthew Baccam
        /// Last Updated: 03/21/2024
        /// What Was changed: Initial creation
        /// </summary>
        private void txtBoxConfirmPassword_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtBoxPassword.Password.IsValidPassword() && txtBoxPassword.Password == txtBoxConfirmPassword.Password)
            {
                txtBoxPassword.BorderThickness = new Thickness(1);
                txtBoxConfirmPassword.BorderThickness = new Thickness(1);
                txtBoxPassword.BorderBrush = new SolidColorBrush(Colors.Black);
                txtBoxConfirmPassword.BorderBrush = new SolidColorBrush(Colors.Black);
            }
            else
            {
                txtBoxPassword.BorderThickness = new Thickness(1);
                txtBoxConfirmPassword.BorderThickness = new Thickness(1);
                txtBoxPassword.BorderBrush = new SolidColorBrush(Colors.LightSalmon);
                txtBoxConfirmPassword.BorderBrush = new SolidColorBrush(Colors.LightSalmon);
            }
        }

        /// <summary>
        /// Creator:            Sagan Dewald
        /// Created:            03/29/2024
        /// Summary:            If your housing situations does not match the other choices, you must explain it. Displays and hides the text box for doing so.
        /// Last Updated By:    Sagan DeWald
        /// Last Updated:       03/29/2024
        /// What Was Changed:   Initial Creation
        /// </summary>
        private void cboHousingSituation_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(!lblHousingExplanation.IsLoaded || !txtBoxHousingExplanation.IsLoaded)
            {
                return;
            }

            string residenceSelection = (string)((ComboBoxItem)cboHousingSituation.SelectedItem).Content;

            if (residenceSelection == "Other")
            {
                lblHousingExplanation.Visibility = Visibility.Visible;
                txtBoxHousingExplanation.Visibility = Visibility.Visible;
            }
            else
            {
                lblHousingExplanation.Visibility = Visibility.Hidden;
                txtBoxHousingExplanation.Visibility = Visibility.Hidden;
            }
        }

        /// <summary>
        /// Creator:            Sagan Dewald
        /// Created:            03/29/2024
        /// Summary:            If you have been convicted of a crime, you must explain it. Displays or hides the text box for doing so.
        /// Last Updated By:    Sagan DeWald
        /// Last Updated:       03/29/2024
        /// What Was Changed:   Initial Creation
        /// </summary>
        void rbConvicted_Checked(object sender, RoutedEventArgs e)
        {
            if (rbConvicted_No == null || !rbConvicted_No.IsLoaded || rbConvicted_Yes == null || !rbConvicted_Yes.IsLoaded)
            {
                return;
            }

            if ((bool)rbConvicted_Yes.IsChecked)
            {
                lblCrimeExplanation.Visibility = Visibility.Visible;
                txtBoxCrimeExplanation.Visibility = Visibility.Visible;
            }
            else
            {
                lblCrimeExplanation.Visibility = Visibility.Hidden;
                txtBoxCrimeExplanation.Visibility = Visibility.Hidden;
            }
        }
    }
}
