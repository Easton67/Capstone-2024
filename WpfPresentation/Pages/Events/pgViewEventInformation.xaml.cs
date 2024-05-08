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

namespace WpfPresentation.Pages.Events
{
    /// <summary>
    /// Interaction logic for pgViewEventInformation.xaml
    /// </summary>

    /// <summary>
    /// Creator: Abdalgader Ibrahim
    /// Created: 02/28/2024
    /// Summary: Create partial class pgViewEventInformation for the page.
    /// </summary>

    public partial class pgViewEventInformation : Page
    {
        private MainManager _manager = MainManager.GetMainManager();
        private IEventManager eventManager;
        private EventVM EventVM { get; set; }
        private  string _selectedParticipant = null;
        public pgViewEventInformation()
        {
            InitializeComponent();
            eventManager = new LogicLayer.EventManager();
        }

        /// <summary>
        /// Creator: Abdalgader Ibrahim
        /// Created: 02/28/2024
        /// Summary: Create pgViewEventInformation() method.
        /// Last Updated By: Liam Easton
        /// Created: 05/08/2024
        /// Summary: took out uneccessary code from constructor
        /// </summary>
        public pgViewEventInformation(EventVM eventVM)
        {
            InitializeComponent();
            SetEventDetails(eventVM);
        }

        /// <summary>
        /// Creator: Liam Easton
        /// Created: 05/08/2024
        /// Summary: Made helper method to not use this in the initial constructor
        /// </summary>
        public void SetEventDetails(EventVM eventVM)
        {
            try
            {
                txtEventTitle.Content = eventVM.EventName;
                txtEventAddress.Content = eventVM.Address;
                txtTime.Content = eventVM.StartTime.ToShortTimeString() +  " - " +  eventVM.EndTime.ToShortTimeString();
                txtEventDay.Content = eventVM.EventDay.ToShortDateString();
                lbParticipants.ItemsSource = _manager.EventManager.GetParticipant(eventVM.EventID);
                //dgEventParticapant.ItemsSource = _manager.EventManager.GetParticipant(eventVM.EventID);
            }
            catch (Exception)
            {
                MessageBox.Show("Unable to find Event", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                txtEventTitle.Content = "";
                txtEventAddress.Content = "";
                txtTime.Content = "";
                txtEventDay.Content = "";
                //dgEventParticapant.ItemsSource = "";
            }
        }

        /// <summary>
        /// Creator: Liam Easton
        /// Created: 05/08/2024
        /// Summary: Getting the selected participant from the listbox
        /// </summary>
        private void lbParticipants_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _selectedParticipant = lbParticipants.SelectedItem.ToString();
            MessageBox.Show(_selectedParticipant);
        }

        /// <summary>
        /// Creator: Abdalgader Ibrahim
        /// Created: 02/28/2024
        /// Summary: Create Click event method get all event and return void.
        /// </summary>
        private void btnAllEvents_Click(object sender, RoutedEventArgs e)
        {
            pgViewAllEvents pgViewAllEvents = new pgViewAllEvents();
            NavigationService.Navigate(pgViewAllEvents);
        }


        ///// <summary>
        ///// Creator: Andrew Larson
        ///// Created: 03/19/2024
        ///// Summary: removes a specified volunteer from an event
        ///// Last Updated By: Andrew Larson
        ///// Last Updated 03/19/2024
        ///// What was changed: Initial Creation
        ///// </summary>
        //private void DeleteVolunteerFromEvent_Click(object sender, RoutedEventArgs e)
        //{
        //    int eventID = GetEventID();
        //    if (eventID != -1)
        //    {
        //        // calling GetEventVolunteerDetails to get the volunteer details
        //        try
        //        {
        //            var volunteers = eventManager.GetEventVolunteerDetails(eventID);
        //            var selectedVolunteerFullName = dgEventVolnteer.SelectedItem as string;
        //            if (selectedVolunteerFullName != null && volunteers.Any(v => v.FirstName + " " + v.LastName == selectedVolunteerFullName))
        //            {
        //                MessageBoxResult result = MessageBox.Show("Are you sure you want to delete this volunteer from the event?",
        //                                                            "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);
        //                if (result == MessageBoxResult.Yes)
        //                {
        //                    var selectedVolunteer = volunteers.FirstOrDefault(v => v.FirstName + " " + v.LastName == selectedVolunteerFullName);

        //                    if (selectedVolunteer != null)
        //                    {
        //                        int rowsAffected = eventManager.RemoveVolunteerFromEvent(selectedVolunteer.UserID, eventID);
        //                        if (rowsAffected > 0)
        //                        {
        //                            RefreshVolunteersDataGrid();
        //                        }
        //                        else
        //                        {
        //                            MessageBox.Show("Failed to remove the volunteer from the event", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        //                        }
        //                    }
        //                    else
        //                    {
        //                        MessageBox.Show("Selected volunteer not found in the event", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        //                    }
        //                }
        //            }
        //            else
        //            {
        //                MessageBox.Show("Failed to remove the volunteer from the event", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        //            }
        //        }
        //        catch (Exception)
        //        {
        //            MessageBox.Show("Failed to remove the volunteer from the event", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        //        }
        //    }
        //    else
        //    {
        //        throw new InvalidOperationException("DataContext Error");
        //    }
        //}

        /// <summary>
        /// Creator: Andrew Larson
        /// Created: 03/19/2024
        /// Summary: refreshes UI after user removes a volunteer from the event
        /// Last Updated By: Andrew Larson
        /// Last Updated 03/19/2024
        /// What was changed: Initial Creation
        /// </summary>
        //private void RefreshVolunteersDataGrid()
        //{
        //    int eventID = GetEventID();
        //    if (eventID != -1)
        //    {
        //        try
        //        {
        //            dgEventVolnteer.ItemsSource = eventManager.GetVolunteer(eventID);
        //        }
        //        catch (Exception)
        //        {
        //            dgEventVolnteer.ItemsSource = new List<string>();
        //        }
        //    }
        //    else
        //    {
        //        MessageBox.Show("Failed to refresh the volunteers data grid. DataContext Error", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        //    }
        //}

        /// <summary>
        /// Creator: Andrew Larson
        /// Created: 03/19/2024
        /// Summary: Get's the specified eventID from the current context
        /// Last Updated By: Andrew Larson
        /// Last Updated 03/19/2024
        /// What was changed: Initial Creation
        /// </summary>
        //private int GetEventID()
        //{
        //    if (DataContext is EventVM eventVM)
        //    {
        //        return eventVM.EventID;
        //    }
        //    else
        //    {
        //        return -1; // case if the EventID isn't available
        //    }
        //}

        /// <summary>
        /// Creator: Marwa Ibrahim
        /// Created: 03/18/2024
        /// Summary: Create Button CancelEventSignUp() method.
        /// </summary>
        private void btnCancelEventSignUp_Click(object sender, RoutedEventArgs e)
        {
            //if (dgEventParticapant.SelectedItem == null)
            //{
            //    MessageBox.Show("Please Select Participant");
            //    return;
            //}
            //string ParticipantName = dgEventParticapant.SelectedItem.ToString();
            //bool result = eventManager.CancelSignUp(ParticipantName, this.EventVM.EventID);
            //if (result)
            //{
            //    MessageBox.Show("Participant SigUp Canceled");
            //    dgEventParticapant.ItemsSource = eventManager.GetParticipant(this.EventVM.EventID);
            //}
            //else
            //{
            //    MessageBox.Show("Participant SignUp dose not Cancel");

            //}
        }
    }
}
