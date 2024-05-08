using DataObjects;
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
using LogicLayer;

namespace WpfPresentation.Pages.VolunteerCoordinator
{
    /// <summary>
    /// Creator: Darryl Shirley
    /// created: 04/17/2024
    /// Summary: pgViewVolunteerQuestionnaire
    /// Last updated By: Darryl Shirley
    /// Last Updated: 4/17/2024
    /// What was changed/updated: intial creation
    /// </summary>
    public partial class pgViewVolunteerQuestionnaire : Window
    {
        VolunteerQuestionnaire questionnaire;
        public pgViewVolunteerQuestionnaire(VolunteerQuestionnaire volunteerQuestionnaire)
        {
            InitializeComponent();
            try
            {
                this.Owner = App.Current.MainWindow;
                questionnaire = volunteerQuestionnaire;
                txtVolunteerID.Text = questionnaire.volunteerID;
                txtSkills.Text = questionnaire.skillList;
                txtVehicles.Text = questionnaire.Vehicles;
                txtExperienceYes1.Text = questionnaire.PriorExperience.ToString();
                txtStudentYes1.Text = questionnaire.StudentCheck.ToString();
                txtSchoolNames.Text = questionnaire.SchoolName;
                txtGroupYes1.Text = questionnaire.GroupWork.ToString();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Creator: Darryl Shirley
        /// created: 04/17/2024
        /// Summary: btnExit_Click method
        /// Last updated By: Darryl Shirley
        /// Last Updated: 4/17/2024
        /// What was changed/updated: intial creation
        /// </summary>
        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
