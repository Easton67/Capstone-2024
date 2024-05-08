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

namespace WpfPresentation.Pages.VolunteerCoordinator
{
    /// <summary>
    /// Creator: Darryl Shirley
    /// created: 04/04/2024
    /// Summary: pgDeleteVolunteerSkill.xaml.cs 
    /// Last updated By: Darryl Shirley
    /// Last Updated: 4/04/2024
    /// What was changed/updated: intial creation
    /// </summary>
    public partial class pgDeleteVolunteerSkill : Window
    {
        VolunteerSkillManager _skillManager = null;
        Volunteer vol = null;
        Skills skill = null;

        public pgDeleteVolunteerSkill(Volunteer volunteer)
        {
            InitializeComponent();

            try
            {
                this.Owner = App.Current.MainWindow;
                vol = volunteer;
                _skillManager = new VolunteerSkillManager();
                txtskillListTitle.Text += " " + vol.FullName;

                dgSkillList.ItemsSource = null;
                dgSkillList.ItemsSource = _skillManager.GetAssignedSkills(vol.UserID);
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
            this.Close();
        }

        /// <summary>
        /// Creator: Darryl Shirley
        /// created: 04/04/2024
        /// Summary: btnSubmit_Click method
        /// Last updated By: Darryl Shirley
        /// Last Updated: 4/04/2024
        /// What was changed/updated: intial creation
        /// </summary>
        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (skill != null)
                {
                    int skillID = skill.SkillID;
                    string volunteerID = vol.UserID;
                    if (_skillManager.RemoveVolunteerSkill(volunteerID, skillID) == true)
                    {
                        this.DialogResult = true;
                        MessageBox.Show("Skill Has been removed!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }
                else
                {
                    MessageBox.Show("No skills selected");
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
        /// Summary: dgSkillList_SelectionChanged method
        /// Last updated By: Darryl Shirley
        /// Last Updated: 4/04/2024
        /// What was changed/updated: intial creation
        /// </summary>
        private void dgSkillList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (dgSkillList.SelectedItem != null)
                {
                    skill = (Skills)dgSkillList.SelectedItem;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
