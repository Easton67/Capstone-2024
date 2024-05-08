using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using DataObjects;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Web;
using DataAccessInterfaces;
using LogicLayer;
using System.Net.Mail;
using System.Net;
using System.Diagnostics;
using System.Windows.Media.Media3D;
using System.Runtime.CompilerServices;

namespace WpfPresentation.Pages.Login
{
    /// <summary>
    /// Interaction logic for pgForgetPassword.xaml
    /// </summary>
    /// 

    /// <summary>
    /// Creator:            Liam Easton
    /// Created:            01/30/2024
    /// Summary:            Creation of pgForgetPassword class
    /// Last Updated By:    Liam Easton
    /// Last Updated:       01/30/2024
    /// What Was Changed:   Creation of pgForgotPassword class 
    /// </summary>
    public partial class pgForgetPassword : Page
    {
        /// <summary>
        /// Creator:            Liam Easton
        /// Created:            01/30/2024
        /// Summary:            Creation of pgForgotPassword
        /// Last Updated By:    Liam Easton
        /// Last Updated:       01/30/2024
        /// What Was Changed:   Creation of pgForgotPassword 
        /// </summary>

        private string _resetCode = "";
        private Random _randomNumber = new Random();
        private string _employeeID = "";
        private MainManager manager;

        public pgForgetPassword()
        {
            InitializeComponent();
            manager = MainManager.GetMainManager();
        }


        private static pgForgetPassword instance = null;
        /// <summary>
        /// Creator:            Liam Easton
        /// Created:            03/22/2024
        /// Summary:            Creation of GetpgForgetPassword instance method
        /// Last Updated By:    Liam Easton
        /// Last Updated:       03/22/2024
        /// What Was Changed:   Creation of pgForgotPassword instance method
        /// </summary>
        public static pgForgetPassword GetpgForgetPassword()
        {
            return instance ?? (instance = new pgForgetPassword());
        }

        /// <summary>
        /// Creator:            Liam Easton
        /// Created:            01/30/2024
        /// Summary:            Creation of Page_Loaded method
        /// Last Updated By:    Liam Easton
        /// Last Updated:       01/30/2024
        /// What Was Changed:   Creation of Page_Loaded method 
        /// </summary>
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            lblInvalid.Visibility = Visibility.Hidden;
        }

        /// <summary>
        /// Creator:            Liam Easton
        /// Created:            01/30/2024
        /// Summary:            Creation of btnSendEmail_Click method
        /// Last Updated By:    Liam Easton
        /// Last Updated:       01/30/2024
        /// What Was Changed:   Creation of btnSendEmail_Click method 
        /// </summary>
        private async void btnSendEmail_Click(object sender, RoutedEventArgs e)
        {
            await SendEmail();
        }

        /// <summary>
        /// Creator:            Liam Easton
        /// Created:            02/06/2024
        /// Summary:            Creation of SendEmail method. This method will be reused, so it's its own method
        /// Last Updated By:    Tyler Barz
        /// Last Updated:       04/
        /// What Was Changed:   Change return type, added Task<bool> return
        /// </summary>
        private async Task<bool> SendEmail()
        {
            string email = txtEmail.Text;
            bool result = false;
            if (!email.IsValidEmail())
            {
                lblInvalid.Visibility = Visibility.Visible;
                MessageBox.Show("That is not a valid email address", "Invalid Email",
                MessageBoxButton.OK, MessageBoxImage.Error);
                txtEmail.Text = "";
                txtEmail.Focus();
            }
            else
            {
                try
                {
                    _resetCode = _randomNumber.Next(111111, 999999).ToString();
                    string to = txtEmail.Text;
                    string subject = "Password Reset Code";
                    string body = _resetCode;

                    await manager.messageManager.SendEmail(to, subject, _resetCode);
                    _employeeID = txtEmail.Text;
                    NavigationService.Navigate(new pgVerificationCode(_employeeID, _resetCode));
                    result = true;
                }
                catch (Exception ex)
                {
                    lblInvalid.Visibility = Visibility.Visible;
                    MessageBox.Show(ex.Message + "\n\n" + ex.InnerException.Message, "Unable to send email. Please click resend email, or go back and enter a new email.",
                    MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            return result;
        }

        /// <summary>
        /// Creator:            Liam Easton
        /// Created:            02/06/2024
        /// Summary:            Creation of txtEmail_KeyDown method. Sends email if the email is vaid
        /// Last Updated By:    Tyler Barz
        /// Last Updated:       02/15/2024
        /// What Was Changed:   Made method async, added await to send email
        /// </summary>
        private async void txtEmail_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                string email = txtEmail.Text;
                if (!email.IsValidEmail())
                {
                    lblInvalid.Visibility = Visibility.Visible;
                    MessageBox.Show("That is not a valid email address", "Invalid Email",
                    MessageBoxButton.OK, MessageBoxImage.Error);
                    txtEmail.Text = "";
                    txtEmail.Focus();
                    return;
                }
                else
                {
                    await SendEmail();
                }
            }
        }

        /// <summary>
        /// Creator:            Liam Easton
        /// Created:            02/08/2024
        /// Summary:            Removes the watermark for the text
        /// Last Updated By:    Liam Easton
        /// Last Updated:       02/08/2024
        /// What Was Changed:   Initial Creation
        /// </summary>
        private void txtEmail_GotFocus(object sender, RoutedEventArgs e)
        {
            if (txtEmail.Text.Replace(" ", "").Equals("Email"))
            {
                txtEmail.Text = "";
            }
        }

        /// <summary>
        /// Creator:            Liam Easton
        /// Created:            02/08/2024
        /// Summary:            Adds watermark on loss focus
        /// Last Updated By:    Liam Easton
        /// Last Updated:       02/08/2024
        /// What Was Changed:   Initial Creation
        /// </summary>
        private void txtEmail_LostFocus(object sender, RoutedEventArgs e)
        {
            if (txtEmail.Text.Equals(""))
            {
                txtEmail.Text = "Email";
            }
        }
    }
}
