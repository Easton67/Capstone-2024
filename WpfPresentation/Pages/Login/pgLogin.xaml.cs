using DataObjects;
using LogicLayer;
using System;
using System.Windows;
using System.Windows.Controls;
using WpfPresentation.Pages.Housekeeping;
using static DataObjects.Enums;

namespace WpfPresentation.Pages.Login
{
    /// <summary>
    /// Creator:            Sagan Dewald
    /// Created:            02/04/2024
    /// Summary:            Creation of pgLogin Page
    /// Last Updated By:    Tyler Barz
    /// Last Updated:       02/23/2024
    /// What Was Changed:
    ///                     Removed instance variables
    ///                     Implemented MainManager
    /// </summary>
    public partial class pgLogin : Page
    {
        private MainManager _mainManager;
        public pgLogin()
        {
            InitializeComponent();
            _mainManager = MainManager.GetMainManager();

            // Comment if u want to enter in custom user data, or change this
            tb_userName.Text = "john@company.com";
            pwb_password.Password = "newuser";
        }

        /// <summary>
        /// Creator:            Liam Easton
        /// Created:            03/22/2024
        /// Summary:            Creation of btn_forgotLogin_Click
        /// Last Updated By:    Liam Easton
        /// Last Updated:       03/22/2024
        /// What Was Changed:   Added the forget password functionality                   
        /// </summary>
        private void btn_forgotLogin_Click(object sender, RoutedEventArgs e)
        {
             NavigationService.Navigate(pgForgetPassword.GetpgForgetPassword());
        }

        /// <summary>
        /// Creator:            Sagan Dewald
        /// Created:            02/04/2024
        /// Summary:            Creation of login function
        /// Last Updated By:    Tyler Barz
        /// Last Updated:       02/23/2024-02/24/2024
        /// What Was Changed:
        ///                     Removed extra if statements
        ///                     Made variables belong to method body
        ///                     Removed password hashing call
        ///                     Implemented MainManager calls
        ///                     Gather user credentials
        ///                     Navigate to main window
        ///                     
        /// </summary>
        private void btn_submitLogin_Click(object sender, RoutedEventArgs e)
        {
            if (tb_userName.Text == "" || pwb_password.Password == "")
            {
                MessageBox.Show("Username and password cannot be empty", "Input Required", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            try
            {
                string userName = tb_userName.Text;
                AuthenticationType userType = _mainManager.UserManager.AuthenticateUser(userName, pwb_password.Password);

                switch (userType)
                {
                    case AuthenticationType.Unauthorized:
                        throw new ArgumentException("Username or password are incorrect, please try again");

                    case AuthenticationType.Employee:
                        _mainManager.LoggedInUser = _mainManager.UserManager.SelectEmployeeByID(userName);
                        break;

                    case AuthenticationType.Volunteer:
                        _mainManager.LoggedInUser = _mainManager.UserManager.SelectVolunteerByID(userName);
                        break;
                }

                new MainWindow().Show();
                CloseWindow.CloseParent();
            }
            catch(ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Unauthorized login request", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred during user authentication.\n\nUnable to login user", ex.Message, MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }
    }
}