using DataObjects;
using LogicLayer;
using System;
using System.Windows;
using System.Windows.Controls;

/// <summary>
/// Creator:            Liam Easton
/// Created:            01/30/2024
/// Summary:            Creation of pgResetPassword page
/// Last Updated By:    Tyler Barz
/// Last Updated:       02/24/2024
/// What Was Changed:   Implemented MainManager
/// </summary>
namespace WpfPresentation.Pages.Login
{
    /// <summary>
    /// Interaction logic for pgResetPassword.xaml
    /// </summary>
    public partial class pgResetPassword : Page
    {
        private EmployeePass oldUser = new EmployeePass();
        private MainManager _mainManager;
        private Employee _employee = new Employee();
        private string _employeeID = "";

        public pgResetPassword(string employeeID)
        {
            InitializeComponent();
            _mainManager = MainManager.GetMainManager();
            _employeeID = employeeID;
        }

        /// <summary>
        /// Creator:            Liam Easton
        /// Created:            01/31/2024
        /// Summary:            Creation of Page_Loaded method
        /// Last Updated By:    Liam Easton
        /// Last Updated:       01/31/2024
        /// What Was Changed:   Creation of Page_Loaded method
        /// </summary>
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            lblInvalid.Visibility = Visibility.Hidden;
            oldUser = _mainManager.UserManager.SelectEmployeePasswordHashByEmployeeID(_employeeID);
        }

        /// <summary>
        /// Creator:            Liam Easton
        /// Created:            01/30/2024
        /// Summary:            Creation of btnResetPassword_Click method
        /// Last Updated By:    Liam Easton
        /// Last Updated:       01/30/2024
        /// What Was Changed:   Creation of btnResetPassword_Click method
        /// </summary>
        private void btnResetPassword_Click(object sender, RoutedEventArgs e)
        {
            if (pwdPassword.Password.Equals("") || pwdConfirmPassword.Password.Equals(""))
            {
                lblInvalid.Visibility = Visibility.Visible;
                MessageBox.Show("Please fill out all fields to continue.");
                return;
            }
            if(!pwdPassword.Password.IsValidPassword())
            {
                lblInvalid.Visibility = Visibility.Visible;
                MessageBox.Show("Your password must be 8 characters or longer.", "Invalid Password");
                return;
            }
            if (pwdPassword.Password.Equals(pwdConfirmPassword.Password) && pwdPassword.Password.IsValidPassword())
            {
                string newPassword = pwdPassword.Password;
                try
                {
                    _employee.EmployeeID = _employeeID;
                    _mainManager.UserManager.UpdateEmployeePasswordHash(_employee.EmployeeID, oldUser.PasswordHash, newPassword);
                    MessageBox.Show("Your password has been reset!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message + "\n\n" + ex.InnerException.Message, "Passwords don't match. Please try again.",
                    MessageBoxButton.OK, MessageBoxImage.Error);
                    lblInvalid.Visibility = Visibility.Visible;
                    throw;
                }
            }
            else
            {
                lblInvalid.Visibility = Visibility.Visible;
                MessageBox.Show("Your passwords don't match, please try again");
            }
        }
    }
}
