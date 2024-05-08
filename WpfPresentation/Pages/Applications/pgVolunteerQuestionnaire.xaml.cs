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
using System.Windows.Navigation;
using System.Windows.Shapes;
using LogicLayer;

namespace WpfPresentation.Pages.Applications
{
    /// <summary>
    /// Creator: Darryl Shirley
    /// created: 04/17/2024
    /// Summary: pgVolunteerQuestionnaire method
    /// Last updated By: Darryl Shirley
    /// Last Updated: 4/17/2024
    /// What was changed/updated: intial creation
    /// </summary>
    public partial class pgVolunteerQuestionnaire : Page
    {
        VolunteerQuestionnaireManager _volunteerQuestionnaireManager;
        VolunteerManager _volunteerManager;
        string volunteerID = "";
        string skillList = "n/a";
        string vehicles = "n/a";
        bool priorExperience= false;
        bool studentCheck = false;
        string schoolName = "n/a";
        bool groupWork = false ;
        public pgVolunteerQuestionnaire()
        {
            InitializeComponent();
            try
            {
                _volunteerQuestionnaireManager = new VolunteerQuestionnaireManager();
                _volunteerManager = new VolunteerManager();
                List<VolunteerVM> volunteers = _volunteerManager.ViewVolunteers();
                List<string> volunteerIDs = new List<string>(); 
                foreach(VolunteerVM vol in volunteers)
                {
                    volunteerIDs.Add(vol.VolunteerID);
                }
                cboVolunteerList.ItemsSource = volunteerIDs;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private static pgVolunteerQuestionnaire _instance = null;

        /// <summary>
        /// Creator: Darryl Shirley
        /// created: 04/17/2024
        /// Summary: GetPgVolunteerQuestionnaire method
        /// Last updated By: Darryl Shirley
        /// Last Updated: 4/17/2024
        /// What was changed/updated: intial creation
        /// </summary>
        public static pgVolunteerQuestionnaire GetPgVolunteerQuestionnaire()
        {
            return _instance ?? (_instance = new pgVolunteerQuestionnaire());
        }

        /// <summary>
        /// Creator: Darryl Shirley
        /// created: 04/17/2024
        /// Summary: btnSubmit_Click method
        /// Last updated By: Darryl Shirley
        /// Last Updated: 4/17/2024
        /// What was changed/updated: intial creation
        /// </summary>
        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if(cbStudentYes1.IsChecked== true)
                {
                    studentCheck = true;
                }
                else
                {
                    studentCheck = false;
                }

                if(cbExperienceYes1.IsChecked== true) 
                { 
                    priorExperience= true;
                }
                else
                {
                    priorExperience= false;
                }

                if(cbGroupYes1.IsChecked== true)
                {
                    groupWork= true;
                }
                else
                {
                    groupWork= false;
                }
                if (volunteerID != "")
                {
                    skillList = txtSkills.Text;
                    vehicles = txtVehicles.Text;
                    schoolName = txtSchoolNames.Text;
                    if (_volunteerQuestionnaireManager.addVolunteerQuestionnaire(volunteerID, skillList, vehicles, priorExperience, studentCheck, schoolName, groupWork) == true)
                    {
                        MessageBox.Show("Questionnaire Submitted succesfully!");
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("Please select a volunteer ID");
                }

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);    
            }
        }

        /// <summary>
        /// Creator: Darryl Shirley
        /// created: 04/17/2024
        /// Summary: cboVolunteerList_SelectionChanged method
        /// Last updated By: Darryl Shirley
        /// Last Updated: 4/17/2024
        /// What was changed/updated: intial creation
        /// </summary>
        private void cboVolunteerList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if(cboVolunteerList.SelectedItem != null || !cboVolunteerList.SelectedItem.Equals(""))
                {
                    volunteerID = cboVolunteerList.SelectedItem.ToString();
                }
            }
            catch
            {
                MessageBox.Show("Item not selected");
            }
        }
    }
}
