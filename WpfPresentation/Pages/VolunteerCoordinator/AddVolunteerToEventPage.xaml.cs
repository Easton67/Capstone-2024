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
using DataObjects;

namespace WpfPresentation.Pages.VolunteerCoordinator
{
    /// <summary>
    /// Creator: Darryl Shirley
    /// created: 03/05/2024
    /// Summary: AddVolunteerToEventPage.xaml.cs 
    /// Last updated By: Darryl Shirley
    /// Last Updated: 03/05/2024
    /// What was changed/updated: Initial Creation
    /// </summary>
    public partial class AddVolunteerToEventPage : Window
    {
        UserManager _userManager = new UserManager();
        EventVM _eventVM= new EventVM();
        Volunteer vol = new Volunteer();
        LogicLayer.EventManager eventManager = new LogicLayer.EventManager();

        public AddVolunteerToEventPage(EventVM eventVM)
        {
            InitializeComponent();

            try
            {
                this.Owner = App.Current.MainWindow;
                VolunteerList.ItemsSource = null;
                _eventVM = eventVM;
                txtEventName.Content += " " + eventVM.EventName;

                List<Volunteer> volunteers = new List<Volunteer>();
                
                volunteers = _userManager.GetAllVolunteersNotAssignedToAnEvent(_eventVM.EventID);
                if (VolunteerList.ItemsSource == null)
                {
                    VolunteerList.ItemsSource = volunteers;
                }
            }
            catch
            {
                MessageBox.Show("There are no Volunteers unassigned to that event.");
            }
        }

        /// <summary>
        /// Creator: Darryl Shirley
        /// created: 03/05/2024
        /// Summary: btnSubmit_Click method
        /// Last updated By: Darryl Shirley
        /// Last Updated: 03/05/2024
        /// What was changed/updated: Initial Creation
        /// </summary>
        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (vol.UserID != null)
                {
                    _userManager.AddVolunteerToEvent(vol.UserID, _eventVM.EventID);
                    eventManager.addVolunteerEvent(_eventVM.EventID, _eventVM.VolunteersNeeded, (_eventVM.VolunteersNeeded - 1));
                    this.DialogResult = true;
                    MessageBox.Show("The volunteer was successfully added to event!");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message + "\n\n" + ex);
            }
        }

        /// <summary>
        /// Creator: Darryl Shirley
        /// created: 03/05/2024
        /// Summary: VolunteerList_SelectionChanged method 
        /// Last updated By: Darryl Shirley
        /// Last Updated: 03/05/2024
        /// What was changed/updated: Initial Creation
        /// </summary>
        private void VolunteerList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (VolunteerList.SelectedItems.Count != 0)
                {

                    vol = VolunteerList.SelectedItem as Volunteer;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n\n" + ex);
            }
        }

        /// <summary>
        /// Creator: Darryl Shirley
        /// created: 03/05/2024
        /// Summary: btnClose_Click method 
        /// Last updated By: Darryl Shirley
        /// Last Updated: 03/05/2024
        /// What was changed/updated: Initial Creation
        /// </summary>
        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
