using DataObjects;
using LogicLayer;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfPresentation.Pages.Shifts;
using WpfPresentation.UtilWindows.AdminUtilWindows;

namespace WpfPresentation.Pages.Admin
{
    /// <summary>
    /// Interaction logic for pgViewUserAccounts.xaml
    /// </summary>
    public partial class pgViewUserAccounts : Page
    {
        private List<Employee> _filteredEmployees = new List<Employee>();
        private List<Employee> _allEmployees = new List<Employee>();
        private List<Client> _filteredClients = new List<Client>();
        private List<Client> _allClients = new List<Client>();
        private List<ClientPriority> _allClientPriorities = new List<ClientPriority>();
        private List<Employee> _filteredManagers = new List<Employee>();
        private List<Employee> _allManagers = new List<Employee>();
        private List<Role> _allRoles = new List<Role>();
        private List<Volunteer> _filteredVolunteers = new List<Volunteer>();
        private List<Volunteer> _allVolunteers = new List<Volunteer>();
        private MainManager _manager = MainManager.GetMainManager();


        /// <Summary>
        /// Creator: Marwa Ibrahim
        /// created: 03/27/2024
        /// What was changed/updated: Hidden the change password bottne
        /// </Summary>
        public pgViewUserAccounts()
        {
            InitializeComponent();
            btnChangePassword.Visibility = Visibility.Hidden;
            txtNewPassword.Visibility = Visibility.Hidden;
        }
        /// <Summary>
        /// Creator: Liam Easton
        /// created: 03/3/2024
        /// Summary: creation of the Page_Loaded method
        /// Last updated By: Liam Easton
        /// Last Updated: 03/3/2024
        /// What was changed/updated: initial creation
        /// </Summary>
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            EmployeeRefresh();
            ClientListRefresh();
            ManagerRefresh();
            VolunteerRefresh();
            grdEmployees.Visibility = Visibility.Visible;
            grdClients.Visibility = Visibility.Hidden;
            grdManagement.Visibility = Visibility.Hidden;
            grdVolunteers.Visibility = Visibility.Hidden;
            btnViweDeactivteApplication.Visibility = Visibility.Hidden;
        }
        #region Refresh Lists

        /// <Summary>
        /// Creator: Ibrahim Albashair
        /// created: 03/18/2024
        /// Summary: creation of the VolunteerRefresh method
        /// Last updated By: Ibrahim Albashair
        /// Last Updated: 03/18/2024
        /// What was changed/updated: initial creation
        /// </Summary>
        private void VolunteerRefresh()
        {
            try
            {
                _allVolunteers = _manager.UserManager.GetAllVolunteers();


                grdVolunteers.ItemsSource = _allVolunteers;
            }
            catch (Exception ex)
            {

                System.Windows.MessageBox.Show(ex.Message + "\n\n" + ex.InnerException.Message, "Unable to find volunteers.",
                MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
        }

        /// <Summary>
        /// Creator: Liam Easton
        /// created: 03/3/2024
        /// Summary: creation of the EmployeeRefresh method
        /// Last updated By: Liam Easton
        /// Last Updated: 03/3/2024
        /// What was changed/updated: initial creation
        /// Last updated By: Tyler Barz
        /// Last Updated: 03/06/2024
        /// What was changed/updated: Got rid of new object creation
        ///                           Updated each object to correct display data
        /// </Summary>
        private void EmployeeRefresh()
        {
            try
            {
                _allEmployees = _manager.UserManager.SelectAllEmployees();
                _allEmployees.ForEach(e =>
                {
                    e.UserID = e.EmployeeID;
                });

                grdEmployees.ItemsSource = _allEmployees;
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message + "\n\n" + ex.InnerException.Message, "Unable to find employees.",
                MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
        }
        /// <Summary>
        /// Creator: Liam Easton
        /// created: 03/3/2024
        /// Summary: creation of the ClientListRefresh method
        /// Last updated By: Liam Easton
        /// Last Updated: 03/3/2024
        /// What was changed/updated: initial creation
        /// Last updated By: Tyler Barz
        /// Last Updated: 03/06/2024
        /// What was changed/updated: Got rid of new object creation
        ///                           Updated each object to correct display data
        /// </Summary>
        private void ClientListRefresh()
        {
            try
            {
                _allClients = _manager.UserManager.GetAllClients();
                _allClientPriorities = _manager.ClientPriorityManager.SelectAllClientPriorities();
                foreach(var client in _allClients)
                {
                    ClientPriority clientPriority = (from p in _allClientPriorities where p.Client == client.UserID select p).SingleOrDefault();
                    int score = clientPriority != null ? clientPriority.BasePriority - clientPriority.Deductions : 1;
                    client.ClientPriority = score;
                }
                grdClients.ItemsSource = _allClients;
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message + "\n\n" + ex.InnerException.Message, "Unable to find clients.",
                MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
        }
        /// <Summary>
        /// Creator: Liam Easton
        /// created: 03/3/2024
        /// Summary: creation of the ManagerRefresh method
        /// Last updated By: Liam Easton
        /// Last Updated: 03/3/2024
        /// What was changed/updated: initial creation
        /// Last updated By: Tyler Barz
        /// Last Updated: 03/06/2024
        /// What was changed/updated: Got rid of new object creation
        ///                           Updated each object to correct display data
        /// Last updated By: Liam Easton
        /// Last Updated: 04/11/2024
        /// What was changed/updated: Added distinct to the management so it doesn't show multiple of the same employee
        /// </Summary>
        private void ManagerRefresh()
        {
            try
            {
                _allRoles = _manager.UserManager.SelectAllRoles();
                // get all of the roles
                List<string> roleIds = _allRoles.Select(role => role.RoleID).ToList();
                // loop through each one to get all of the employees that have that role
                foreach (var roleID in roleIds)
                {
                    List<Employee> emp = _manager.UserManager.SelectSpecificRoles(roleID);
                    _allManagers.AddRange(emp);
                }

                List<Employee> managerList = _allManagers.FindAll(x => x.Roles.Any(role => role.RoleID.Contains("Manager") || role.RoleID.Contains("CEO")));
                managerList.ForEach(e =>
                {
                    e.UserID = e.EmployeeID;
                });

                grdManagement.ItemsSource = managerList.Distinct();
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message + "\n\n" + ex.InnerException.Message, "Unable to find employees.",
                MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
        }
        #endregion
        /// <Summary>
        /// Creator: Liam Easton
        /// created: 03/3/2024
        /// Summary: creation of the pgViewUserAccounts instance
        /// Last updated By: Liam Easton
        /// Last Updated: 03/3/2024
        /// What was changed/updated: initial creation
        /// </Summary>
        private static pgViewUserAccounts instance = null;
        

        public static pgViewUserAccounts GetpgViewUserAccounts()
        {
            return instance ?? (instance = new pgViewUserAccounts());
        }
        #region Searchbox events
        /// <Summary>
        /// Creator: Liam Easton
        /// created: 03/3/2024
        /// Summary: creation of the txtSearchName_GotFocus event
        /// Last updated By: Liam Easton
        /// Last Updated: 03/3/2024
        /// What was changed/updated: initial creation
        /// </Summary>
        private void txtSearchName_GotFocus(object sender, RoutedEventArgs e)
        {
            if (txtSearchName.Text.Replace(" ", "").Equals("Search"))
            {
                txtSearchName.Text = "";
            }
        }
        /// <Summary>
        /// Creator: Liam Easton
        /// created: 03/3/2024
        /// Summary: creation of the txtSearchName_LostFocus event
        /// Last updated By: Liam Easton
        /// Last Updated: 03/3/2024
        /// What was changed/updated: initial creation
        /// </Summary>
        private void txtSearchName_LostFocus(object sender, RoutedEventArgs e)
        {
            if (txtSearchName.Text.Equals(""))
            {
                txtSearchName.Text = "Search";
            }
        }
        /// <Summary>
        /// Creator: Liam Easton
        /// created: 03/3/2024
        /// Summary: creation of the txtSearchName_TextChanged event
        /// Last updated By: Tyler Barz
        /// Last Updated: 03/05/2024
        /// What was changed/updated: Changed EmployeeID --> UserID
        /// Last updated By: Tyler Barz
        /// Last Updated: 03/07/2024
        /// What was changed/updated: Shortened code dramatically
        /// Last updated By: Ibrahim Albashair
        /// Last Updated: 03/21/2024
        /// What was changed/updated: Added search functionality for volunteers
        /// </Summary>
        private void txtSearchName_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtSearchName.Text == "Search")
            {
                return;
            }
            if (txtSearchName.Text != null || txtSearchName.Text != "Search")
            {
                // checks to see the type of the itemsource, and effect the list of the type that it matches
                if (grdEmployees.Visibility == Visibility.Visible)
                {
                    grdEmployees.ItemsSource = _allEmployees.FindAll(emp => emp.UserID.ToLower().Contains(txtSearchName.Text.ToLower())).ToList();
                }
                else if (grdClients.Visibility == Visibility.Visible)
                {
                    grdClients.ItemsSource = _allClients.FindAll(cli => cli.UserID.ToLower().Contains(txtSearchName.Text.ToLower())).ToList();
                }
                else if (grdVolunteers.Visibility == Visibility.Visible)
                {
                    grdVolunteers.ItemsSource = _allVolunteers.FindAll(vol => vol.UserID.ToLower().Contains(txtSearchName.Text.ToLower())).ToList();
                }
                else
                {
                    grdManagement.ItemsSource = _allManagers.Where(x => x.Roles.Any(role => role.RoleID.Contains("Manager") || role.RoleID.Contains("CEO"))).ToList()
                        .FindAll(emp => emp.UserID.ToLower().Contains(txtSearchName.Text.ToLower())).ToList();
                }
            }
        }
        #endregion
        #region View Users Button Events
        /// <Summary>
        /// Creator: Liam Easton
        /// created: 03/3/2024
        /// Summary: creation of the btnViewEmployees_Click event
        /// Last updated By: Ibrahim Albashair
        /// Last Updated: 03/18/2024
        /// What was changed/updated: Added Volunteers grid logic and btnViewVolunteers
        /// </Summary>
        private void btnViewEmployees_Click(object sender, RoutedEventArgs e)
        {
            grdVolunteers.Visibility = Visibility.Hidden;
            grdManagement.Visibility = Visibility.Hidden;
            grdEmployees.Visibility = Visibility.Visible;
            grdClients.Visibility = Visibility.Hidden;
            // Changes the background color of the selected tab by grabbing the key of the resource in the app.xaml file.
            btnViewEmployees.Background = (Brush)FindResource("clrPrimary");
            btnViewVolunteers.Background = (Brush)FindResource("clrLight");
            btnViewClients.Background = (Brush)FindResource("clrLight");
            btnViewManagement.Background = (Brush)FindResource("clrLight");

            btnChangePassword.Visibility = Visibility.Hidden;
            txtNewPassword.Visibility = Visibility.Hidden;
            btnViweDeactivteApplication.Visibility = Visibility.Hidden;
        }
        /// <Summary>
        /// Creator: Liam Easton
        /// created: 03/3/2024
        /// Summary: creation of the btnViewClients_Click event
        /// Last updated By: Ibrahim Albashair
        /// Last Updated: 03/18/2024
        /// What was changed/updated: Added Volunteers grid logic and btnViewVolunteers
        /// </Summary>
        private void btnViewClients_Click(object sender, RoutedEventArgs e)
        {
            grdVolunteers.Visibility = Visibility.Hidden;
            grdManagement.Visibility = Visibility.Hidden;
            grdEmployees.Visibility = Visibility.Hidden;
            grdClients.Visibility = Visibility.Visible;
            btnViewEmployees.Background = (Brush)FindResource("clrLight");
            btnViewVolunteers.Background = (Brush)FindResource("clrLight");
            btnViewClients.Background = (Brush)FindResource("clrPrimary");
            btnViewManagement.Background = (Brush)FindResource("clrLight");

            btnChangePassword.Visibility = Visibility.Visible;
            txtNewPassword.Visibility = Visibility.Visible;
            btnViweDeactivteApplication.Visibility = Visibility.Visible;
            txtNewPassword.Focus();
        }
        /// <Summary>
        /// Creator: Liam Easton
        /// created: 03/3/2024
        /// Summary: creation of the btnViewManagement_Click event
        /// Last updated By: Ibrahim Albashair
        /// Last Updated: 03/18/2024
        /// What was changed/updated: Added Volunteers grid logic and btnViewVolunteers
        /// </Summary>
        private void btnViewManagement_Click(object sender, RoutedEventArgs e)
        {
            grdVolunteers.Visibility = Visibility.Hidden;
            grdManagement.Visibility = Visibility.Visible;
            grdEmployees.Visibility = Visibility.Hidden;
            grdClients.Visibility = Visibility.Hidden;
            btnViewEmployees.Background = (Brush)FindResource("clrLight");
            btnViewVolunteers.Background = (Brush)FindResource("clrLight");
            btnViewClients.Background = (Brush)FindResource("clrLight");
            btnViewManagement.Background = (Brush)FindResource("clrPrimary");

            btnChangePassword.Visibility = Visibility.Hidden;
            txtNewPassword.Visibility = Visibility.Hidden;
            btnViweDeactivteApplication.Visibility = Visibility.Hidden;
        }
        /// <Summary>
        /// Creator: Ibrahim Albashair
        /// created: 03/18/2024
        /// Summary: creation of the btnViewVolunteers_Click event
        /// Last updated By: Ibrahim Albashair
        /// Last Updated: 03/18/2024
        /// What was changed/updated: initial creation
        /// </Summary>
        private void btnViewVolunteers_Click(object sender, RoutedEventArgs e)
        {
            grdVolunteers.Visibility = Visibility.Visible;
            grdManagement.Visibility = Visibility.Hidden;
            grdEmployees.Visibility = Visibility.Hidden;
            grdClients.Visibility = Visibility.Hidden;
            btnViewEmployees.Background = (Brush)FindResource("clrLight");
            btnViewVolunteers.Background = (Brush)FindResource("clrPrimary");
            btnViewClients.Background = (Brush)FindResource("clrLight");
            btnViewManagement.Background = (Brush)FindResource("clrLight");

            btnChangePassword.Visibility = Visibility.Hidden;
            txtNewPassword.Visibility = Visibility.Hidden;
            btnViweDeactivteApplication.Visibility = Visibility.Hidden;
        }
        #endregion
        /// <Summary>
        /// Creator: Liam Easton
        /// created: 03/05/2024
        /// Summary: creation of the MenuItem_Click event
        /// Last updated By: Liam Easton
        /// Last Updated: 03/05/2024
        /// What was changed/updated: initial creation.
        /// Last updated By: Tyler Barz
        /// Last Updated: 03/07/2024
        /// What was changed/updated: Removed repetative code
        /// Last updated By: Ibrahim Albashair
        /// Last Updated: 03/20/2024
        /// What was changed/updated: Added code for Volunteers
        /// </Summary>
        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            string userId = string.Empty;
            if (grdClients.Visibility == Visibility.Visible)
            {
                userId = GetUserID(grdClients);
                var editWindow = new EditUserWindow(_manager.UserManager.SelectClientByID(userId));
                editWindow.ShowDialog();
            }
            else if (grdEmployees.Visibility == Visibility.Visible)
            {
                userId = GetUserID(grdEmployees);
                var editWindow = new EditUserWindow(_manager.UserManager.SelectEmployeeByID(userId));
                editWindow.ShowDialog();
            }
            else if (grdVolunteers.Visibility == Visibility.Visible)
            {
                userId = GetUserID(grdVolunteers);
                var editWindow = new EditUserWindow(_manager.UserManager.SelectVolunteerByID(userId));
                editWindow.ShowDialog();
            }
            else
            {
                userId = GetUserID(grdManagement);
                var editWindow = new EditUserWindow(_manager.UserManager.SelectEmployeeByID(userId));
                editWindow.ShowDialog();
            }

            // For matts feature
            if (userId != string.Empty)
            {
                //NavigationService.Navigate(new UpdateUserPage(userId));
                // Code to navigate to update user details
            }
        }

        /// <summary>
        /// Creator: Tyler Barz
        /// Created: 03/07/2024
        /// Summary: Moved repetitive code into method body
        /// Last updated By: Tyler Barz
        /// Last Updated: 03/07/2024
        /// What was changed/updated: Initial Creation
        /// </summary>
        private string GetUserID(System.Windows.Controls.DataGrid grid)
        {
            string id = string.Empty;
            if (grid.SelectedItems.Count != 0 && grid.SelectedItem != null)
            {
                dynamic selectedItem = grid.SelectedItem;
                id = selectedItem.UserID;
            }
            return id;
        }

        /// <Summary>
        /// Creator: Marwa Ibrahim
        /// created: 03/27/2024
        /// Summary: 
        /// </Summary>
        private void btnChangePassword_Click(object sender, RoutedEventArgs e)
        {
            UserManager userManager = new UserManager();
            Client client = (Client)grdClients.SelectedItem;
            if (client == null)
            {
                System.Windows.MessageBox.Show("Please select a client");
                txtNewPassword.Focus();
                return;

            }
            if (txtNewPassword.Password.Length == 0)
            {
                System.Windows.MessageBox.Show("Enter New Password");
                txtNewPassword.Focus();
                return;
            }

            string newPassword = txtNewPassword.Password;

            bool result = userManager.changeClientPassword(client.UserID, newPassword);
            if (result)
            {
                System.Windows.MessageBox.Show("The Password has changed");
            }
            else
            {
                System.Windows.MessageBox.Show("The Password has not changed");
            }
            txtNewPassword.Password = "";
        }

        private string hashSHA256(string source)
        {
            // defult password is newuser
            string result = "";
            byte[] data;
            using (SHA256 sha256sha = SHA256.Create())
            {
                data = sha256sha.ComputeHash(Encoding.UTF8.GetBytes(source));
            }
            var s = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                s.Append(data[i].ToString("x2"));
            }
            result = s.ToString();
            return result;
        }


        /// <summary>
        /// Creator: Miyada Abas
        /// Created: 04/09/2024
        /// Summary: Deactivated Application
        /// Last updated By: Miyada Abas
        /// Last Updated: 04/09/2024
        /// What was changed/updated: 
        /// </summary>
        private void btnViweDeactivteApplication_Click(object sender, RoutedEventArgs e)
        {
            Client client = (Client)grdClients.SelectedItem;
            if (client == null)
            {
                System.Windows.MessageBox.Show("Please Select A Client");
                return;
            }
            bool result = _manager.UserManager.DeactivateClientApplication(client);
            if (result)
            {
                System.Windows.MessageBox.Show("Client Application Deactivated.");
                ClientListRefresh();
            }
        }
    }
}