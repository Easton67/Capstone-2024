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
    /// Creator: Marwa Ibrahim
    /// Created: 02/01/2024
    /// Summary: Create event page
    /// Last Updated By: Tyler Barz
    /// Last Updated: 02/24/2024
    /// What Was Changed: Added MainManager
    /// </summary>
    public partial class pgCreateEvent : Page
    {
        private MainManager _mainManager;

        public pgCreateEvent()
        {
            InitializeComponent();
            _mainManager = MainManager.GetMainManager();
            //_eventManager = new EventManager();
        }

        private static pgCreateEvent instance = null;
        public static pgCreateEvent GetPgCreateEvent()
        {
            return instance ?? (instance = new pgCreateEvent());
        }

        /// <summary>
        /// Creator: ???
        /// Created: ???
        /// Summary: Create event page
        /// Last Updated By: Liam Easton
        /// Last Updated: 04/28/2024
        /// What Was Changed: fixed the else statement to be more secure
        /// </summary>
        private void btnSubmit_Click_1(object sender, RoutedEventArgs e)
        {
            if (txtEventName.Text.Length == 0)
            {
                lblErrorMessage.Content = "Event name is required";
                txtEventName.Focus();

            }
            else if (txtDescription.Text.Length == 0)
            {
                lblErrorMessage.Content = "Description is required";
                txtDescription.Focus();
            }
            else
            {
                Event ev = new Event()
                {
                    EventName = txtEventName.Text,
                    Description = txtDescription.Text
                };
                try
                {
                    _mainManager.EventManager.CreateEvent(ev);
                    MessageBox.Show($"{ev.EventName} has been added to events!");
                }
                catch (Exception)
                {
                    MessageBox.Show($"{ev.EventName} was not added to events.");
                }
            }
        }

        /// <summary>
        /// Creator: Darryl Shirley
        /// Created: 03/01/2024
        /// Summary: Create btnCancel_Click event
        /// Last Updated By: Darryl Shirley
        /// Last Updated: 03/01/2024
        /// What Was Changed: Initial Creation
        /// </summary>
        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
