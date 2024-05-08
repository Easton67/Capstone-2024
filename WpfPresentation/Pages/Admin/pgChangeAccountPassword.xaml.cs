using DataObjects;
using LogicLayer;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace WpfPresentation.Pages.Admin
{
    /// <summary>
    /// Creator: Abdalgader Ibrahim
    /// Created: 04/19/2024
    /// Summary: Create pgChangeAccountPassword() Method .
    /// </summary>

    /// <summary>
    /// Interaction logic for pgChangeAccountPassword.xaml
    /// </summary>
    public partial class pgChangeAccountPassword : Page
    {
        private string userID;
        private string userType;
        private UserManager userManager;

        public pgChangeAccountPassword()
        {
            InitializeComponent();
            txtNewPassword.Visibility = Visibility.Hidden;
        }
        /// <summary>
        /// Creator: Abdalgader Ibrahim
        /// Created: 04/19/2024
        /// Summary: Create pgChangeAccountPassword() Method .
        /// </summary>

        public pgChangeAccountPassword(string userID, string userType)
        {
            InitializeComponent();
            this.userID = userID;
            this.userType = userType;
            lblUserName.Content = userID;
            userManager = new UserManager();
        }
        /// <summary>
        /// Creator: Abdalgader Ibrahim
        /// Created: 04/19/2024
        /// Summary: Create btnCancel_Click() Method .
        /// </summary>

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
        /// <summary>
        /// Creator: Abdalgader Ibrahim
        /// Created: 04/19/2024
        /// Summary: Create btnSubmit_Click() Method .
        /// </summary>
        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                if (userType == "Employee")
                {
                    try
                    { // update employee password
                        if (txtNewPassword.Password.Length <= 7)
                        {
                            throw new Exception("Password Must Have eight characters.");
                        }
                        userManager.UpdateEmployeePassword(userID, txtNewPassword.Password);
                        System.Windows.MessageBox.Show("The Password has changed");
                        NavigationService.Navigate(new pgViewUserAccounts());
                    }
                    catch (Exception ex)
                    {
                        throw new ApplicationException(ex.Message);
                    }
                }
                else if (userType == "Manager")
                {
                    try
                    {
                        if (txtNewPassword.Password.Length <= 7)
                        {
                            throw new Exception("Password Must Have eight characters.");
                        }
                        // update employee password
                        userManager.UpdateEmployeePassword(userID, txtNewPassword.Password);
                        System.Windows.MessageBox.Show("The Password has changed");
                        NavigationService.Navigate(new pgViewUserAccounts());
                    }
                    catch (Exception ex)
                    {
                        throw new ApplicationException(ex.Message);
                    }
                }

                NavigationService.Navigate(new pgViewUserAccounts());
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }
    }
}
