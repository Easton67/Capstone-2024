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
         /// Creator: Ibrahim Ibrahim
         /// Created: 01/22/2024
         /// Summary: Create pgEditEvent() Method .
         /// </summary>
         /// <summary>
         /// Interaction logic for pgEditEvent.xaml
         /// </summary>
    public partial class pgEditEvent : Page
    {
        IEventManager _eventManager;
        Event OldEvent;
        public pgEditEvent()
        {
            InitializeComponent();
            _eventManager = new LogicLayer.EventManager();
        }
		
        /// <summary>
        ///Creator:            Marwa
        ///Created:            04/04/2024
        ///Summary:            Updates event
        ///Last Updated By:    Mitchell Stirmel
        ///Last Updated:       04/11/2024
        ///What Was changed:   Added try catch
        /// </summary>
        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            if (!valideData())
            {
                return;
            }

            DataObjects.Event newEvent = new DataObjects.Event();
            newEvent.EventName = txtEventName.Text;
            newEvent.Description = txtDescription.Text;
            newEvent.EventID = OldEvent.EventID;

            try
            {
                bool result = _eventManager.UpdateEvent(newEvent);
                if (result)
                {
                    lblErrorMessage.Content = "Event Update correctly";
                    txtEventName.Text = "";
                    txtDescription.Text = "";
                }
                else
                {
                    lblErrorMessage.Content = "Event did not Update";
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Unable to update event \n" + ex.ToString(), "Failure", MessageBoxButton.OK);
            }
        }

        private bool valideData()
        {
            if (txtEventName.Text.Length == 0)
            {
                lblErrorMessage.Content = "Event Name Is require";
                return false;

            }
            if (txtDescription.Text.Length == 0)
            {
                lblErrorMessage.Content = "Description is require";
                return false;
            }
            lblErrorMessage.Content = "";
            return true;
        }
    }
}
