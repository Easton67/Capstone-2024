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
    /// Creator: Abdalgader Ibrahim
    /// Created: 03/05/2024
    /// Summary: Create pgRequestEvent() Method .
    /// </summary>

    /// <summary>
    /// Interaction logic for pgRequestEvent.xaml
    /// </summary>
    public partial class pgRequestEvent : Page
    {
        private IEventManager eventManager;
        public pgRequestEvent()
        {
            InitializeComponent();
            eventManager = new LogicLayer.EventManager();
            ClientIDSelcter.ItemsSource = eventManager.GetClientIDs();
            EventTypeIDSelcter.ItemsSource = eventManager.GetEventTypeIDs();
        }

        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                EventRequestVM eventRequestVM = new EventRequestVM();
              
                if(ClientIDSelcter.SelectedItem != null)
                {
                    eventRequestVM.ClientID = ClientIDSelcter.SelectedItem.ToString();
                }
                else
                {
                    throw new Exception("Client ID required");
                }
                if (EventTypeIDSelcter.SelectedItem != null)
                {
                    eventRequestVM.EventTypeID = EventTypeIDSelcter.SelectedItem.ToString();
                }
                else
                {
                    throw new Exception("Event Type ID required");
                }

                if (EventInformation.Text.Length != 0)
                {
                    eventRequestVM.Information = EventInformation.Text;
                }
                else
                {
                    throw new Exception("Event information required");
                }
              
                eventManager.InsertEventRequest(eventRequestVM);
                MessageBox.Show("Request Event sent to Manager");
                NavigationService.GoBack();
            }
            catch (Exception ex)
            {

               MessageBox.Show(ex.Message);
            }
            
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
