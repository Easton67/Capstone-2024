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
using DataObjects;
using LogicLayer;
namespace WpfPresentation.Pages.Events
{
    /* 
      <summary>
          Creator:            Marwa Ibrahim
          Created:            02/4/2024
          Summary:            EventSignup
          What Was Changed:   Initial creation
      </summary>
      */
    /// <summary>
    /// Interaction logic for pgEventSignUp.xaml
    /// </summary>
    public partial class pgEventSignUp : Page
    {
        private IEventManager _eventManager;
        List<EventVM> eventsList = new List<EventVM>();
        List<string> eventNameList = new List<string>();
        private int ID;
        EventVM selectedVM = null;
        public pgEventSignUp()
        {
            InitializeComponent();
            _eventManager = new LogicLayer.EventManager();
            fillGridOfEventNames();
        }

        private void fillGridOfEventNames()
        {
    
            eventsList = _eventManager.getAllEvents();
            foreach (EventVM eventVM in eventsList)
            {
                eventNameList.Add(eventVM.EventName);
            }
            comboEventName.ItemsSource = eventNameList;
        }

        private void lblSubmit_Click(object sender, RoutedEventArgs e)
        {
           
            EventParticipant eventParticipants = new EventParticipant();
            string _eventName = comboEventName.Text;
         
            foreach (EventVM eventVM in eventsList)
            {
                if (eventVM.EventName==_eventName)
                {
                    ID = eventVM.EventID;
                    selectedVM = eventVM; 
                    break;    
                }

            }

            if(!ValidationHelpers.IsValidEmail(txtEmail.Text))
            {
                MessageBox.Show("Please enter a valid email address");
                return;
            }
            if(_eventName == null || _eventName == "")
            {
                MessageBox.Show("Please select an event");
                return;
            }
            if (txtParticipantName.Text == null || txtParticipantName.Text == "")
            {
                MessageBox.Show("Please enter your name");
                return;
            }

            eventParticipants.EventID = ID; 
            eventParticipants.ParticipantName = txtParticipantName.Text;
            eventParticipants.Email = txtEmail.Text;    
            eventParticipants.RegistrationDate = DateTime.Now;
            try
            {
                _eventManager.AddEventParticipants(eventParticipants);
                MessageBox.Show(" Event Participant has been added!");
                NavigationService.Navigate(new pgViewEventInformation(selectedVM));
                
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
