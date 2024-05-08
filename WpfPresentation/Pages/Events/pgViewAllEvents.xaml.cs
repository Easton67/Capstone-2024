using DataObjects;
using LogicLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Linq;
using WpfPresentation.Pages.Donations;
using WpfPresentation.Pages.Rooms;
using WpfPresentation.UtilWindows;

namespace WpfPresentation.Pages.Events
{
    /// <summary>
    /// Interaction logic for pgViewAllEvents.xaml
    /// </summary>
    public partial class pgViewAllEvents : Page
    {
        private MainManager _mainManager;
        /// <summary>
        /// Creator: Abdalgader Ibrahim
        /// Created: 02/20/2024
        /// Summary: Create pgViewAllEvents() Method .
        /// Last updated by: Tyler Barz [02/24/2024]
        /// Summary: Added main manager
        ///Last Updated By:    Mitchell Stirmel
        ///Last Updated:       04/11/2024
        ///What Was changed:   Added try catch
        /// </summary>
        public pgViewAllEvents()
        {
            InitializeComponent();
            _mainManager = MainManager.GetMainManager();
            refreshList();
            RefreshDataGrid();

        }
        public void refreshList()
        {
            try
            {
                List<EventVM> events = _mainManager.EventManager.getAllEvents();
                EventDataGrid.ItemsSource = events;

                Style rowStyle = new Style(typeof(DataGridRow));
                rowStyle.Setters.Add(new EventSetter(DataGridRow.MouseDoubleClickEvent,
                                         new MouseButtonEventHandler(Row_DoubleClick)));
                EventDataGrid.RowStyle = rowStyle;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to get events \n" + ex.ToString(), "Failure", MessageBoxButton.OK);
            }
        }

        private void Row_DoubleClick(object sender, MouseButtonEventArgs e)
        {

            //DataGridRow row = sender as DataGridRow;
            //var data = row.DataContext as EventVM;
            if (EventDataGrid.SelectedItem == null)
            {
                MessageBox.Show("Please pick an event!");
                return;
            }
            EventVM _data = new EventVM();
            _data = (EventVM)EventDataGrid.SelectedItem;
            NavigationService.Navigate(new pgViewEventInformation(_data));


        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new pgRequestEvent());
        }

        private static pgViewAllEvents instance = null;
        public static pgViewAllEvents GetViewAllEvents()
        {
            return instance ?? (instance = new pgViewAllEvents());
        }

        private void EventDataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new pgRequestEvent());
        }
        /* 
       <summary>
           Creator:            Marwa Ibrahim
           Created:            02/4/2024
           Summary:            EventSignup
           What Was Changed:   Initial creation
       </summary>
       */
        private void btnEventSignUp_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new pgEventSignUp());
        }

        /// <summary>
        /// Creator: Marwa Ibrahim
        /// Created: 02/28/2024
        /// Summary: Delete Event() Method.
        /// Last Updated By:    Ibrahim Albashair
        ///Last Updated:       04/25/2024
        ///What Was changed:   Added try catch and confirmation before deletion
        /// </summary>
        private void btnDeleteEvent_Click(object sender, RoutedEventArgs e)
        {
            EventVM @event = new EventVM();
            @event = (EventVM)EventDataGrid.SelectedItem;
            if (@event == null)
            {
                MessageBox.Show("Please select Row", "Delete Event");
                return;
            }

            if (MessageBox.Show("Are you sure you want to Delete this event?", "Confirmation", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                bool result = false;
                try
                {
                    result = _mainManager.EventManager.DeleteEvent(@event);
                    RefreshDataGrid();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Could not Delete Event");

                }
            }
            else { return; }

        }
        private void RefreshDataGrid()
        {
            List<EventVM> events = _mainManager.EventManager.getAllEvents();
            EventDataGrid.ItemsSource = events;
        }

        private void btnEditEvent_Click(object sender, RoutedEventArgs e) {
            if(EventDataGrid.SelectedItem == null) {
                MessageBox.Show("Please select an event to edit.");
                return;
            }

            EditEvent editEventWindow = new EditEvent(EventDataGrid.SelectedItem as Event);
            bool? result = editEventWindow.ShowDialog();
            if(result == true) {
                MessageBox.Show("Successfully edited event");
                refreshList();
                return;
            }
        }
    }
}
