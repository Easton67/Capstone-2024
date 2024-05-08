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
    /// created: 01/22/2024
    /// Summary: UpdateVolunteerEventPage 
    /// Last updated By: Darryl Shirley
    /// Last Updated: 2/07/2024
    /// What was changed/updated: Initial Creation
    /// </summary>
    /// 
    public partial class UpdateVolunteerEventPage : Window
    {
        EventVM newEvent = null;
        LogicLayer.EventManager _eventManager = null;

        public UpdateVolunteerEventPage(EventVM _event)
        {
            InitializeComponent();

            _eventManager = new LogicLayer.EventManager();
            try
            {
                this.Owner = App.Current.MainWindow;
                newEvent = _event;
                txtUpdateEventTitle.Content += " " + newEvent.EventName;
                txteventDate.Text = newEvent.EventDay.Date.ToShortDateString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// Creator: Darryl Shirley
        /// created: 01/22/2024
        /// Summary: btnSubmit_Click event 
        /// Last updated By: Tyler Barz
        /// Last Updated: 02/25/2024
        /// What was changed/updated: Removed unused caught exception
        /// </summary>
        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int newVolunteersNeeded = -1;
                if (int.Parse(txtEventCapacity.Text) > 0)
                {
                    if (int.Parse(txtEventCapacity.Text) < 100)
                    {
                        newVolunteersNeeded = int.Parse(txtEventCapacity.Text);
                    }
                    else
                    {
                        MessageBox.Show("Please input a lower volunteer count");
                    }
                }



                if (newVolunteersNeeded > 0)
                {
                    _eventManager.addVolunteerEvent(newEvent.EventID, newEvent.VolunteersNeeded, newVolunteersNeeded);
                    this.DialogResult = true;
                    MessageBox.Show("Event Updated!");
                }
                else
                {
                    MessageBox.Show("Please input a non-negative number");
                }
            }
            catch
            {
                MessageBox.Show("Please input a number");
            }
        }

        /// <summary>
        /// Creator: Darryl Shirley
        /// created: 01/22/2024
        /// Summary: btnCancel_Click event
        /// Last updated By: Darryl Shirley
        /// Last Updated: 2/07/2024
        /// What was changed/updated: Initial Creation
        /// </summary>
        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
