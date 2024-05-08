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
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfPresentation.Pages.Stats;
using WpfPresentation.Pages.Vendors;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Page = System.Windows.Controls.Page;

namespace WpfPresentation.Pages.VolunteerCoordinator
{
    /// <Summary>
    /// Creator: Ethan McElree
    /// created: 03/30/2024
    /// Summary: View Volunteers code behind file.
    /// Last updated By: Ethan McElree
    /// Last Updated: 03/30/2024
    /// What was changed/updated: Initial Creation
    /// Last updated By: Liam Easton
    /// Last Updated: 04/26/2024
    /// What was changed/updated: Main manager implementation
    /// </Summary>
    public partial class ViewVolunteers : Page
    {
        private MainManager _mainManager;

        /// <summary>
        /// Creator: Ethan McElree
        /// Created: 04/1/2024
        /// Summary: Constructor for ViewVolunteers.xaml
        ///Last Updated By:    Mitchell Stirmel
        ///Last Updated:       04/11/2024
        ///What Was changed:   Added try catch
        /// </summary>
        public ViewVolunteers()
        {

            _mainManager = MainManager.GetMainManager();

            InitializeComponent();


            try
            {
                datVolunteers.ItemsSource = _mainManager.VolunteerManager.ViewVolunteers();
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show("Unable to get volunteers \n" + ex.ToString(), "Failure", MessageBoxButton.OK);
            }
        }

        /// <summary>
        /// Creator: Ethan McElree
        /// Created: 04/1/2024
        /// Summary: Navigation static class for ViewVolunteers
        /// Last Updated By: Ethan McElree
        /// Last Updated: 04/1/2024
        /// What Was Changed: Initial Creation
        /// </summary>
        private static ViewVolunteers instance = null;
        public static ViewVolunteers GetViewVolunteers()
        {
            return instance ?? (instance = new ViewVolunteers());
        }

        /// <summary>
        /// Creator: Ethan McElree
        /// Created: 04/1/2024
        /// Summary: Click handler method for the exit button on the view volunteers page.
        /// Last Updated By: Ethan McElree
        /// Last Updated: 04/1/2024
        /// What Was Changed: Initial Creation
        /// </summary>
        private void ExitVolunteers_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(PgShelterDashboard.GetPgShelterDashboard());
        }

        /// <summary>
        /// Creator: Andrew Larson
        /// Created: 04/5/2024
        /// Summary: Click handler for the edit button for a selected volunteer
        /// Last Updated By: Andrew Larson
        /// Last Updated: 04/5/2024
        /// What Was Changed: Initial Creation
        /// </summary>
        private void btnEditVolunteers_Click(object sender, RoutedEventArgs e)
        {
            if(datVolunteers.SelectedItem != null) 
            {
                VolunteerVM selectedVolunteer = datVolunteers.SelectedItem as VolunteerVM;
                NavigationService.Navigate(new UpdateVolunteerPage(selectedVolunteer));
            }
        }
		
        /// Creator: Ethan McElree
        /// Created: 04/1/2024
        /// Summary: Click handler method for the delete button on the view volunteers page.
        /// Last Updated By: Ethan McElree
        /// Last Updated: 04/1/2024
        /// What Was Changed: Initial Creation
        /// </summary>
        private void DeleteVolunteers_Click(object sender, RoutedEventArgs e)
        {
            VolunteerVM volunteerVM = (VolunteerVM)datVolunteers.SelectedItem;
            if (volunteerVM == null)
            {
                System.Windows.MessageBox.Show("Please select a volunteer.");
                return;
            }
            MessageBoxResult result = System.Windows.MessageBox.Show("Are you sure? This cannot be undone.", "Caution", MessageBoxButton.YesNo, MessageBoxImage.Warning);

            try
            {
                if (result == MessageBoxResult.Yes)
                {
                    bool deleted = _mainManager.VolunteerManager.DeleteVolunteer(volunteerVM);
                    if (deleted)
                    {                        
                        datVolunteers.ItemsSource = _mainManager.VolunteerManager.ViewVolunteers();                
                    }
                }
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message);
            }
        }

        private void SignupVolunteer_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(pgSignUpVolunteer.GetPgSignUpVolunteer());
        }

        private void ReloadList_Click(object sender, RoutedEventArgs e)
        {
            GetViewVolunteers();
        }
    }
}
