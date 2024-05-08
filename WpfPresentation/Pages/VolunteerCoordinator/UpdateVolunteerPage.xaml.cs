using DataObjects;
using LogicLayer;
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
using System.Windows.Forms.VisualStyles;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfPresentation.Pages.VolunteerCoordinator
{
    /// <summary>
    /// Creator: Andrew Larson
    /// Created: 04/5/2024
    /// Summary: xaml.cs for the update volunteer
    /// Last Updated By: Andrew Larson
    /// Last Updated: 04/5/2024
    /// What Was Changed: Initial Creation
    /// </summary>
    public partial class UpdateVolunteerPage : Page
    {
        private VolunteerVM selectedVolunteer;
        IVolunteerManager _volunteerManager;
        public UpdateVolunteerPage(VolunteerVM selectedVolunteer)
        {
            InitializeComponent();
            _volunteerManager = new VolunteerManager();
            this.selectedVolunteer = selectedVolunteer;
            LoadInformation();
        }

        /// <summary>
        /// Creator: Andrew Larson
        /// Created: 04/5/2024
        /// Summary: Loads the information to display on the page
        /// Last Updated By: Andrew Larson
        /// Last Updated: 04/5/2024
        /// What Was Changed: Initial Creation
        /// </summary>
        private void LoadInformation()
        {
            txtFirstName.Text = selectedVolunteer.Fname;
            txtLastName.Text = selectedVolunteer.Lname;
            txtPhone.Text = selectedVolunteer.Phone;
            if (selectedVolunteer.Gender == false)
            {
                cboGender.Text = "Male";
            }
            else
            {
                cboGender.Text = "Female";
            }
            txtAddress.Text = selectedVolunteer.Address;
            txtZip.Text = selectedVolunteer.ZipCode.ToString();
        }

        /// <summary>
        /// Creator: Andrew Larson
        /// Created: 04/5/2024
        /// Summary: Redirects user to previous page if they cancel the edit
        /// Last Updated By: Andrew Larson
        /// Last Updated: 04/5/2024
        /// What Was Changed: Initial Creation
        /// </summary>
        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        /// <summary>
        /// Creator: Andrew Larson
        /// Created: 04/5/2024
        /// Summary: Validates user input for phone number
        /// Last Updated By: Andrew Larson
        /// Last Updated: 04/5/2024
        /// What Was Changed: Initial Creation
        /// </summary>
        private bool ValidatePhone(string phone)
        {
            string regex = @"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$";
            if (phone != null)
            { 
                return Regex.IsMatch(phone, regex);
            }
            else { return false; }
        }

        /// <summary>
        /// Creator: Andrew Larson
        /// Created: 04/5/2024
        /// Summary: Validates user input for zipcode
        /// Last Updated By: Andrew Larson
        /// Last Updated: 04/5/2024
        /// What Was Changed: Initial Creation
        /// </summary>
        private bool ValidateZipCode(string zipCode)
        {
            string regex = "^(0\\d{4}|\\d{5})(?:-\\d{4})?$";
            if(zipCode != null) 
            {
                return Regex.IsMatch(zipCode, regex);
            }
            else { return false; }
        }

        /// <summary>
        /// Creator: Andrew Larson
        /// Created: 04/5/2024
        /// Summary: Validates data and updates if appropriate
        /// Last Updated By: Andrew Larson
        /// Last Updated: 04/5/2024
        /// What Was Changed: Initial Creation
        /// </summary>
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            bool genderValue;
            if (!ValidatePhone(txtPhone.Text))
            {
                MessageBox.Show("Please enter a phone number using one of the following formats.\n" +
                    "\t\t(123) 456-7890\n\t\t123-456-7890\n\t\t123.456.7890\n\t\t123 456 7890", "Incorrect Format", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            else if (!ValidateZipCode(txtZip.Text))
            {
                MessageBox.Show("Please enter a phone number using one of the following formats.\n" +
                    "\t\t12345\n\t\t12345-6789", "Incorrect Format", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            if (cboGender.Text.Equals("Male"))
            { 
                genderValue = false;
            } else { genderValue = true; }
            try
            {
                _volunteerManager.UpdateVolunteer(selectedVolunteer.VolunteerID, txtFirstName.Text, txtLastName.Text, txtPhone.Text, genderValue, txtAddress.Text, int.Parse(txtZip.Text));
                MessageBox.Show("Volunteer Successfully Updated", "Volunteer Updated", MessageBoxButton.OK, MessageBoxImage.Information);
                NavigationService.Navigate(new ViewVolunteers());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Updating Volunteer", ex.Message, MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
