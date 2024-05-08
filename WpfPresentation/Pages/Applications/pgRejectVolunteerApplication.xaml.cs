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

namespace WpfPresentation.Pages.Applications
{
    /// <summary>
    ///Creator:            Darryl Shirley
    ///Created:            04/10/2024
    ///Summary:           pgRejectVolunteerApplication.xaml.cs
    ///Last Updated By:    Darryl Shirley
    ///Last Updated:       04/10/2024
    ///What Was Changed:   Initial Creation
    /// </summary>
    public partial class pgRejectVolunteerApplication : Window
    {
        private MainManager _mainManager;
        private VolunteerApplication _volunteerApplication;

        public pgRejectVolunteerApplication(VolunteerApplication volunteerApplication)
        {
            InitializeComponent();

            _mainManager = MainManager.GetMainManager();

            try
            {
                this.Owner = App.Current.MainWindow;
                _volunteerApplication = volunteerApplication;
                tbApplicantID.Content += " Applicant " + volunteerApplication.ApplicantID.ToString() + ".";

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        ///Creator:            Darryl Shirley
        ///Created:            04/10/2024
        ///Summary:           btnBack_Click method
        ///Last Updated By:    Darryl Shirley
        ///Last Updated:       04/10/2024
        ///What Was Changed:   Initial Creation
        /// </summary>
        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        /// <summary>
        ///Creator:            Darryl Shirley
        ///Created:            04/10/2024
        ///Summary:           btnSubmit_Click method
        ///Last Updated By:    Darryl Shirley
        ///Last Updated:       04/10/2024
        ///What Was Changed:   Initial Creation
        /// </summary>
        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string status = "Rejected";
                string reasonForStatus = txtReasonForStatus.Text;
                if (!reasonForStatus.Equals(""))
                {
                    _mainManager.VolunteerApplicationManager.EditVolunteerAplicationStatus(_volunteerApplication.ApplicationID, status, reasonForStatus);
                    this.DialogResult = true;

                    MessageBox.Show(_volunteerApplication.ApplicationID + "'s " + "Application status has been updated!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
