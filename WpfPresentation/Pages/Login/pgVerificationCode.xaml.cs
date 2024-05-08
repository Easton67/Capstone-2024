using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Net;
using System.Net.Mail;

//<summary>
//Creator:            Liam Easton
//Created:            01/30/2024
//Summary:            Creation of pgVerificationCode page
//Last Updated By:    Liam Easton
//Last Updated:       01/30/2024
//What Was Changed:   Creation of pgVerificationCode page
//</summary>
namespace WpfPresentation.Pages.Login
{
    /// <summary>
    /// Interaction logic for pgVerificationCode.xaml
    /// </summary>
    public partial class pgVerificationCode : Page
    {
        private string _resetCode = "";
        private Random _randomNumber = new Random();
        private Regex _numericalRegex = new Regex("[^0-9]+");
        private string _employeeID = "";

        public pgVerificationCode(string employeeID, string resetCode)
        {
            InitializeComponent();

            _employeeID = employeeID;
            _resetCode = resetCode;
        }
        //<summary>
        //Creator:            Liam Easton
        //Created:            01/30/2024
        //Summary:            Creating a helper method to clear the verification code
        //Last Updated By:    Liam Easton
        //Last Updated:       01/30/2024
        //What Was Changed:   initial creation of the ClearCode method
        //</summary>
        private void ClearCode()
        {
            txtCode1.Text = "";
            txtCode2.Text = "";
            txtCode3.Text = "";
            txtCode4.Text = "";
            txtCode5.Text = "";
            txtCode6.Text = "";
            txtCode1.Focus();
        }


        //<summary>
        //Creator:            Liam Easton
        //Created:            01/30/2024
        //Summary:            Creation of Page_Loaded method
        //Last Updated By:    Liam Easton
        //Last Updated:       01/30/2024
        //What Was Changed:   Creation of Page_Loaded method
        //</summary>
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(_resetCode);
            lblInvalid.Visibility = Visibility.Collapsed;
            txtCode1.Focus();
        }

        #region Code Checks
        //<summary>
        //Creator:            Liam Easton
        //Created:            01/30/2024
        //Summary:            Creation of txtCode1_PreviewTextInput method
        //Last Updated By:    Liam Easton
        //Last Updated:       01/30/2024
        //What Was Changed:   Creation of txtCode1_PreviewTextInput method
        //</summary>
        private void txtCode1_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = _numericalRegex.IsMatch(e.Text);

            if (txtCode1.Text != "")
            {
                txtCode2.Focus();
            }
        }


        //<summary>
        //Creator:            Liam Easton
        //Created:            01/30/2024
        //Summary:            Creation of txtCode2_PreviewTextInput method
        //Last Updated By:    Liam Easton
        //Last Updated:       01/30/2024
        //What Was Changed:   Creation of txtCode2_PreviewTextInput method
        //</summary>
        private void txtCode2_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = _numericalRegex.IsMatch(e.Text);

            if (txtCode2.Text != "")
            {
                txtCode3.Focus();
            }
        }


        //<summary>
        //Creator:            Liam Easton
        //Created:            01/30/2024
        //Summary:            Creation of txtCode3_PreviewTextInput method
        //Last Updated By:    Liam Easton
        //Last Updated:       01/30/2024
        //What Was Changed:   Creation of txtCode3_PreviewTextInput method
        //</summary>
        private void txtCode3_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = _numericalRegex.IsMatch(e.Text);

            if (txtCode3.Text != "")
            {
                txtCode4.Focus();
            }
        }

        //<summary>
        //Creator:            Liam Easton
        //Created:            01/30/2024
        //Summary:            Creation of txtCode4_PreviewTextInput method
        //Last Updated By:    Liam Easton
        //Last Updated:       01/30/2024
        //What Was Changed:   Creation of txtCode4_PreviewTextInput method
        //</summary>
        private void txtCode4_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = _numericalRegex.IsMatch(e.Text);

            if (txtCode4.Text != "")
            {
                txtCode5.Focus();
            }
        }

        //<summary>
        //Creator:            Liam Easton
        //Created:            01/30/2024
        //Summary:            Creation of txtCode5_PreviewTextInput method
        //Last Updated By:    Liam Easton
        //Last Updated:       01/30/2024
        //What Was Changed:   Creation of txtCode5_PreviewTextInput method
        //</summary>
        private void txtCode5_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = _numericalRegex.IsMatch(e.Text);

            if (txtCode5.Text != "")
            {
                txtCode6.Focus();
            }
        }

        //<summary>
        //Creator:            Liam Easton
        //Created:            01/30/2024
        //Summary:            Creation of txtCode6_PreviewTextInput method
        //Last Updated By:    Liam Easton
        //Last Updated:       01/30/2024
        //What Was Changed:   Creation of txtCode6_PreviewTextInput method
        //</summary>
        private void txtCode6_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = _numericalRegex.IsMatch(e.Text);

            if (txtCode6.Text != "")
            {
                btnVerifyCode.Focus();
            }
        }

        #endregion

        //<summary>
        //Creator:            Liam Easton
        //Created:            01/30/2024
        //Summary:            Creation of btnVerifyCode_Click method
        //Last Updated By:    Liam Easton
        //Last Updated:       01/30/2024
        //What Was Changed:   Creation of btnVerifyCode_Click method
        //</summary>
        private void btnVerifyCode_Click(object sender, RoutedEventArgs e)
        {
            string userEnteredCode = txtCode1.Text + txtCode2.Text + txtCode3.Text + txtCode4.Text + txtCode5.Text + txtCode6.Text;

            if (userEnteredCode == _resetCode)
            {
                lblInvalid.Visibility = Visibility.Collapsed;
                NavigationService.Navigate(new pgResetPassword(_employeeID));
            }
            else
            {
                lblInvalid.Visibility = Visibility.Visible;
                ClearCode();
                return;
            }
        }

        //<summary>
        //Creator:            Liam Easton
        //Created:            01/30/2024
        //Summary:            Creation of btnResendEmail_Click method
        //Last Updated By:    Liam Easton
        //Last Updated:       01/30/2024
        //What Was Changed:   Creation of btnResendEmail_Click method
        //</summary>
        private async void btnResendEmail_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (SmtpClient client = new SmtpClient("smtp.gmail.com", 587))
                {
                    _resetCode = _randomNumber.Next(111111, 999999).ToString();
                    string to = _employeeID;
                    string from = "homesforthehomelesscompany@gmail.com";
                    string subject = "Password Reset Code";
                    string body = _resetCode;
                    MailMessage message = new MailMessage(from, to, subject, body);

                    client.EnableSsl = true;
                    client.Credentials = new NetworkCredential("homesforthehomelesscompany@gmail.com", "ruyg cxwd mvyq lckp");

                    try
                    {
                        await Task.Run(() => client.Send(message));
                        ClearCode();
                        txtCode1.Focus();

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error sending email: " + ex.Message);
                    }
                }
            }
            catch (Exception ex)
            {
                lblInvalid.Visibility = Visibility.Visible;
                MessageBox.Show(ex.Message + "\n\n" + ex.InnerException.Message, "Unable to send email. Please click resend email, or go back and enter a new email.",
                MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
        }
    }
}
