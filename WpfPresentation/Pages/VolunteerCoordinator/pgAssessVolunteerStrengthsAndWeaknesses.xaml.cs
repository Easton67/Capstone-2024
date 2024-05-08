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
    /// Creator: Darryl Shirley
    /// created: 04/04/2024
    /// Summary: pgAssessVolunteerStrengthsAndWeaknesses.xaml.cs 
    /// Last updated By: Darryl Shirley
    /// Last Updated: 4/04/2024
    /// What was changed/updated: intial creation
    /// </summary>
    public partial class pgAssessVolunteerStrengthsAndWeaknesses : Page
    {
        UserManager _userManager = null;
        Volunteer vol = null;
        VolunteerSkillManager _skillManager = null;
        VolunteerQuestionnaireManager _questionnaireManager = null;
        VolunteerQuestionnaire volunteerQuestionnaire = null;

        public pgAssessVolunteerStrengthsAndWeaknesses()
        {
            _userManager = new UserManager();

            InitializeComponent();
            try
            {
                dgVolunteerList.ItemsSource = null;
                List<Volunteer> volunteers = new List<Volunteer>();

                volunteers = _userManager.SelectAllVolunteers();
                dgVolunteerList.ItemsSource = volunteers;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private static pgAssessVolunteerStrengthsAndWeaknesses instance = null;

        /// <summary>
        /// Creator: Darryl Shirley
        /// created: 04/04/2024
        /// Summary: GetVolunteerAssessStrengthsAndWeaknessesPage method
        /// Last updated By: Darryl Shirley
        /// Last Updated: 4/04/2024
        /// What was changed/updated: intial creation
        /// </summary>
        public static pgAssessVolunteerStrengthsAndWeaknesses GetVolunteerAssessStrengthsAndWeaknessesPage()
        {
            return instance ?? (instance = new pgAssessVolunteerStrengthsAndWeaknesses());
        }

        /// <summary>
        /// Creator: Darryl Shirley
        /// created: 04/04/2024
        /// Summary: btnAddSkill_Click method
        /// Last updated By: Darryl Shirley
        /// Last Updated: 4/04/2024
        /// What was changed/updated: intial creation
        /// </summary>
        private void btnAddSkill_Click(object sender, RoutedEventArgs e)
        {
            try 
            {
                if (vol != null)
                {
                    _userManager = new UserManager();
                    _skillManager = new VolunteerSkillManager();
                    if (_skillManager.GetUnAssignedSkills(vol.UserID).Count != 0)
                    {
                        pgAddVolunteerSkill pgAddVolunteerSkill = new pgAddVolunteerSkill(vol);
                        pgAddVolunteerSkill.ShowDialog();
                        if (dgVolunteerList.ItemsSource != null)
                        {
                            dgVolunteerList.ItemsSource = null;
                            dgVolunteerList.ItemsSource = _userManager.SelectAllVolunteers();

                        }
                        vol = null;
                    }
                }
                else
                {
                    MessageBox.Show("Please select a volunteer from the list");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Creator: Darryl Shirley
        /// created: 04/04/2024
        /// Summary: btnDeleteSkill_Click method
        /// Last updated By: Darryl Shirley
        /// Last Updated: 4/04/2024
        /// What was changed/updated: intial creation
        /// </summary>
        private void btnDeleteSkill_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (vol != null)
                {
                    _userManager = new UserManager();
                    _skillManager = new VolunteerSkillManager();
                    if (_skillManager.GetAssignedSkills(vol.UserID).Count != 0)
                    {
                        pgDeleteVolunteerSkill pgDeleteVolunteerSkill1 = new pgDeleteVolunteerSkill(vol);
                        pgDeleteVolunteerSkill1.ShowDialog();
                        if (dgVolunteerList.ItemsSource != null)
                        {
                            dgVolunteerList.ItemsSource = null;
                            dgVolunteerList.ItemsSource = _userManager.SelectAllVolunteers();

                        }
                        vol = null;
                    }
                }
                else
                {
                    MessageBox.Show("Please select a volunteer from the list.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Creator: Darryl Shirley
        /// created: 04/04/2024
        /// Summary: btnBack_Click method
        /// Last updated By: Darryl Shirley
        /// Last Updated: 4/04/2024
        /// What was changed/updated: intial creation
        /// </summary>
        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                NavigationService.GoBack();
            }
            catch (Exception)
            {
                MessageBox.Show("No page to go back to");
            }
        }

        /// <summary>
        /// Creator: Darryl Shirley
        /// created: 04/04/2024
        /// Summary: dgVolunteerList_SelectionChanged method
        /// Last updated By: Darryl Shirley
        /// Last Updated: 4/04/2024
        /// What was changed/updated: intial creation
        /// </summary>
        private void dgVolunteerList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                vol = new Volunteer();
                if(dgVolunteerList.SelectedItem != null)
                {
                    vol = (Volunteer)dgVolunteerList.SelectedItem;
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
        /// Summary: btnQuestionnaire_Click method
        /// Last updated By: Darryl Shirley
        /// Last Updated: 4/17/2024
        /// What was changed/updated: intial creation
        /// </summary>
        private void btnQuestionnaire_Click(object sender, RoutedEventArgs e)
        {
            List<VolunteerQuestionnaire> questionnaires = new List<VolunteerQuestionnaire>();
            _questionnaireManager = new VolunteerQuestionnaireManager();
            try
            {
                questionnaires = _questionnaireManager.GetVolunteerQuestionnaires();
                if(vol != null)
                {
                    foreach(VolunteerQuestionnaire questionnaire in questionnaires)
                    {
                        if (vol.UserID.Equals(questionnaire.volunteerID))
                        {
                            volunteerQuestionnaire = questionnaire;
                        }
                    }

                    if(volunteerQuestionnaire != null)
                    {
                        pgViewVolunteerQuestionnaire pgViewVolunteerQuestionnaire = new pgViewVolunteerQuestionnaire(volunteerQuestionnaire);
                        pgViewVolunteerQuestionnaire.ShowDialog();
                        volunteerQuestionnaire = null;
                    }
                    else
                    {
                        MessageBox.Show("No Volunteer Questionnaire for this individual");
                    }
                    
                }
                else
                {
                    MessageBox.Show("Please select a volunteer");
                }
                

            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to show questionnaire", ex.Message);
            }
        }
    }
}
