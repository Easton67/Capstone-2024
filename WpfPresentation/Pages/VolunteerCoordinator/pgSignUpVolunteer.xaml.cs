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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfPresentation.Pages.VolunteerCoordinator
{
    /// <summary>
    /// Interaction logic for pgSignUpVolunteer.xaml
    /// </summary>
    public partial class pgSignUpVolunteer : Page
    {
        private MainManager _mainManager;
        public pgSignUpVolunteer()
        {
            InitializeComponent();
            _mainManager = MainManager.GetMainManager();
        }
        private static pgSignUpVolunteer instance = null;
        public static pgSignUpVolunteer GetPgSignUpVolunteer()
        {
            return instance ?? (instance = new pgSignUpVolunteer());
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(ViewVolunteers.GetViewVolunteers());
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (txtBoxFirstName.Text.Length == 0)
            {
                lblErrorMessage.Content = "First name is required!";
                txtBoxFirstName.Focus();

            }
            else if (txtBoxLastName.Text.Length == 0)
            {
                lblErrorMessage.Content = "Last name is required!";
                txtBoxLastName.Focus();
            }
            else if (txtBoxEmail.Text.Length == 0)
            {
                lblErrorMessage.Content = "Email is required!";
                txtBoxEmail.Focus();
            }
            else if (txtBoxAddress.Text.Length == 0)
            {
                lblErrorMessage.Content = "Address is required!";
                txtBoxAddress.Focus();
            }
            else if (txtBoxPhoneNumber.Text.Length == 0)
            {
                lblErrorMessage.Content = "Phone number is required!";
                txtBoxPhoneNumber.Focus();
            }
            else if (txtBoxPassword.Text.Length == 0)
            {
                lblErrorMessage.Content = "Password is required!";
                txtBoxPassword.Focus();
            }
            else if (txtBoxRegDate.Text.Length == 0)
            {
                lblErrorMessage.Content = "Date is required!";
                txtBoxRegDate.Focus();
            }
            else if (txtBoxZip.Text.Length == 0)
            {
                lblErrorMessage.Content = "ZIP code is required!";
                txtBoxZip.Focus();
            }
            else if (cboAccountStatus == null)
            {
                lblErrorMessage.Content = "Account Status is required!";
                cboAccountStatus.Focus();
            }
            else if (cboGender == null)
            {
                lblErrorMessage.Content = "Gender is required!";
                cboGender.Focus();
            }
            else if (cboRole == null)
            {
                lblErrorMessage.Content = "Role is required!";
                cboRole.Focus();
            }
            else
            {

                bool gender;
                bool.TryParse(cboGender.SelectedItem != null ? ((ComboBoxItem)cboGender.SelectedItem).Content.ToString() : "false", out gender);

                bool accountStatus;
                bool.TryParse(cboAccountStatus.SelectedItem != null ? ((ComboBoxItem)cboAccountStatus.SelectedItem).Content.ToString() : "false", out accountStatus);

                string roleId = cboRole.SelectedItem != null ? ((ComboBoxItem)cboRole.SelectedItem).Content.ToString() : null;

                Volunteer volunteer = new Volunteer()
                {
                    FirstName = txtBoxFirstName.Text,
                    LastName = txtBoxLastName.Text,
                    Phone = txtBoxPhoneNumber.Text,
                    VolunteerID = txtBoxEmail.Text,
                    Address = txtBoxAddress.Text,
                    PasswordHash = txtBoxPassword.Text,
                    RegistrationDate = DateTime.Parse(txtBoxRegDate.Text),
                    ZipCode = Int32.Parse(txtBoxZip.Text),
                    Gender = gender,
                    AccountStatus = accountStatus,
                    RoleID = roleId
                };

                try
                {
                    if (_mainManager.VolunteerManager.CreateVolunteer(volunteer) == true)
                    {

                        MessageBox.Show("Volunteer has been Created Successfully! ");
                        txtBoxFirstName.Clear();
                        txtBoxLastName.Clear();
                        txtBoxPhoneNumber.Clear();
                        txtBoxEmail.Clear();
                        txtBoxAddress.Clear();
                        txtBoxPassword.Clear();
                        txtBoxRegDate.Clear();
                        txtBoxZip.Clear();
                        cboGender.SelectedIndex = 0;
                        cboAccountStatus.SelectedIndex = 0;
                        cboRole.SelectedIndex = 0;
                    }
                    else
                    {
                        MessageBox.Show("Failed to create volunteer");
                        txtBoxFirstName.Clear();
                        txtBoxLastName.Clear();
                        txtBoxPhoneNumber.Clear();
                        txtBoxEmail.Clear();
                        txtBoxAddress.Clear();
                        txtBoxPassword.Clear();
                        txtBoxRegDate.Clear();
                        txtBoxZip.Clear();
                        cboGender.SelectedIndex = 0;
                        cboAccountStatus.SelectedIndex = 0;
                        cboRole.SelectedIndex = 0;
                    }


                }
                catch (Exception ex)
                {

                    throw ex;
                }
            }
        }
    }
}
