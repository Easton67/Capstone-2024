using LogicLayer;
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
using WpfPresentation.Pages.VolunteerCoordinator;

namespace WpfPresentation
{
    /// <summary>
    /// Creator: Darryl Shirley
    /// created: 01/22/2024
    /// Summary: VolunteerEventPage.xaml.cs 
    /// Last updated By: Darryl Shirley
    /// Last Updated: 3/05/2024
    /// What was changed/updated: added AssignVolbtn_Click method
    /// </summary>
    public partial class VolunteerEventPage : Page
    {
        LogicLayer.EventManager _eventManager = null;
        EventVM _event = null;

        /// <summary>
        /// Creator: Darryl Shirley
        /// created: 01/22/2024
        /// Summary: VolunteerEventPage/Page1 
        /// Last updated By: Darryl Shirley
        /// Last Updated: 2/07/2024
        /// What was changed/updated: Initial Creation
        /// </summary>
        public VolunteerEventPage()
        {
            InitializeComponent();

            try
            {
                _eventManager = new LogicLayer.EventManager();
                List<Event> eventList= new List<Event>();
                EventList.ItemsSource = null;
                if (EventList.ItemsSource == null)
                {
                    foreach(Event e in _eventManager.getAllEvents())
                    {
                        if(e.VolunteersNeeded > 0)
                        {
                            eventList.Add(e);
                        }
                    }
                    EventList.ItemsSource = eventList;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private static VolunteerEventPage instance = null;
        public static VolunteerEventPage GetVolunteerEventPage()
        {
            return instance ?? (instance = new VolunteerEventPage());
        }

        /// <summary>
        /// Creator: Darryl Shirley
        /// created: 01/22/2024
        /// Summary: AddVolunteerEvent Button Method
        /// Last updated By: Darryl Shirley
        /// Last Updated: 2/07/2024
        /// What was changed/updated: Initial Creation
        /// </summary>
        private void AddVolunteerEvent_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                AddEventPage addEventPage = new AddEventPage();
                addEventPage.ShowDialog();
                List<Event> eventList = new List<Event>();
                EventList.ItemsSource = null;
                if (EventList.ItemsSource == null)
                {
                    foreach (Event eve in _eventManager.getAllEvents())
                    {
                        if (eve.VolunteersNeeded > 0)
                        {
                            eventList.Add(eve);
                        }
                    }
                    EventList.ItemsSource = eventList;
                }
                _event = null;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }



        /// <summary>
        /// Creator: Darryl Shirley
        /// created: 01/22/2024
        /// Summary: Back Button Method
        /// Last updated By: Darryl Shirley
        /// Last Updated: 2/07/2024
        /// What was changed/updated: Initial Creation
        /// </summary>
        private void BackBtn_Click(object sender, RoutedEventArgs e)
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
        /// created: 02/14/2024
        /// Summary: EventList_MouseDoubleClick event
        /// Last updated By: Darryl Shirley
        /// Last Updated: 02/14/2024
        /// What was changed/updated: Initial Creation
        /// </summary>
        private void EventList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                _eventManager = new LogicLayer.EventManager();
                List<Event> eventList = new List<Event>();
                EventList.ItemsSource = null;
                if (EventList.ItemsSource == null)
                {
                    foreach (Event eve in _eventManager.getAllEvents())
                    {
                        if (eve.VolunteersNeeded > 0)
                        {
                            eventList.Add(eve);
                        }
                    }
                    EventList.ItemsSource = eventList;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// Creator: Darryl Shirley
        /// created: 02/14/2024
        /// Summary: EventList_SelectionChanged event
        /// Last updated By: Darryl Shirley
        /// Last Updated: 02/14/2024
        /// What was changed/updated: Initial Creation
        /// </summary>
        private void EventList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                _eventManager = new LogicLayer.EventManager();
                if (EventList.SelectedItems.Count != 0)
                {
                    _event = EventList.SelectedItem as DataObjects.EventVM;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n\n" + ex);
            }
        }

        /// <summary>
        /// Creator: Darryl Shirley
        /// created: 02/14/2024
        /// Summary: Update_Click event
        /// Last updated By: Darryl Shirley
        /// Last Updated: 02/14/2024
        /// What was changed/updated: Initial Creation
        /// </summary>
        private void Update_Click(object sender, RoutedEventArgs e)
        {
            if (_event != null)
            {
                UpdateVolunteerEventPage updateVolunteerEventPage = new UpdateVolunteerEventPage(_event);
                updateVolunteerEventPage.ShowDialog();
                List<Event> eventList = new List<Event>();
                EventList.ItemsSource = null;
                if (EventList.ItemsSource == null)
                {
                    foreach (Event eve in _eventManager.getAllEvents())
                    {
                        if (eve.VolunteersNeeded > 0)
                        {
                            eventList.Add(eve);
                        }
                    }
                    EventList.ItemsSource = eventList;
                }
                _event = null;
            }
            else
            {
                MessageBox.Show("Please select an Event");
            }
        }

        /// <summary>
        /// Creator: Darryl Shirley
        /// created: 03/04/2024
        /// Summary: AssignVolbtn_Click event
        /// Last updated By: Darryl Shirley
        /// Last Updated: 03/04/2024
        /// What was changed/updated: Initial Creation
        /// </summary>
        private void AssignVolbtn_Click(object sender, RoutedEventArgs e)
        {
            if (_event != null)
            {
                AddVolunteerToEventPage addVolunteerToEventPage = new AddVolunteerToEventPage(_event);
                addVolunteerToEventPage.ShowDialog();
                List<Event> eventList = new List<Event>();
                EventList.ItemsSource = null;
                if (EventList.ItemsSource == null)
                {
                    foreach (Event eve in _eventManager.getAllEvents())
                    {
                        if (eve.VolunteersNeeded > 0)
                        {
                            eventList.Add(eve);
                        }
                    }
                    EventList.ItemsSource = eventList;
                }
                _event = null;
            }
            else
            {
                MessageBox.Show("Please select an Event");
            }
        }

        /// <summary>
        /// Creator: Darryl Shirley
        /// created: 03/04/2024
        /// Summary: Delete_Click event
        /// Last updated By: Darryl Shirley
        /// Last Updated: 03/04/2024
        /// What was changed/updated: Initial Creation
        /// </summary>
        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (_event != null)
                {
                    DeleteVolunteerEventPage delete = new DeleteVolunteerEventPage(_event);
                    delete.ShowDialog();
                    List<Event> eventList = new List<Event>();
                    EventList.ItemsSource = null;
                    if (EventList.ItemsSource == null)
                    {
                        foreach (Event eve in _eventManager.getAllEvents())
                        {
                            if (eve.VolunteersNeeded > 0)
                            {
                                eventList.Add(eve);
                            }
                        }
                        EventList.ItemsSource = eventList;
                    }
                    _event = null;
                }
                else
                {
                    MessageBox.Show("Please Select an event to delete from the list.");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message + "\n\n" + ex);
            }
        }
    }
}
