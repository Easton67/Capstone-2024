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
using MessageBox = System.Windows.Forms.MessageBox;

namespace WpfPresentation.Pages.Events
{
    /// <summary>
    /// Creator: Kirsten Stage
    /// Created: 04/11/2024
    /// Summary: Interaction logic for pgCreateFundraisingEvent
    /// Last Updated By: Kirsten Stage
    /// Last Updated: 04/11/2024
    /// What Was Changed: Initial Creation
    /// </summary>
    public partial class pgCreateFundraisingEvent : Page
    {
        private static pgCreateFundraisingEvent instance = null;
        public static pgCreateFundraisingEvent GetCreateFundraisingEventPage()
        {
            return instance ?? (instance = new pgCreateFundraisingEvent());
        }

        public pgCreateFundraisingEvent()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Creator: Kirsten Stage
        /// Created: 04/11/2024
        /// Summary: Event handler to cancel the create fundraising event process
        /// Last Updated By: Kirsten Stage
        /// Last Updated: 04/11/2024
        /// What Was Changed: Initial Creation
        /// </summary>

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show("You will now exit this page. Are you sure you'd like to cancel?", "Cancel Changes", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                new MainWindow().Show();
            }
        }

        /// <summary>
        /// Creator: Kirsten Stage
        /// Created: 04/11/2024
        /// Summary: Event handler to submit the create fundraising event process
        /// Last Updated By: Kirsten Stage
        /// Last Updated: 04/11/2024
        /// What Was Changed: Initial Creation
        /// </summary>

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            if (txtEventName.Text == "")
            {
                MessageBox.Show("You need to enter the Event Name.");
                return;
            }
            if (txtFundraisingGoal.Text == "")
            {
                MessageBox.Show("You need to enter the Fundraising Goal.");
                return;
            }
            decimal d;
            if (!decimal.TryParse(txtFundraisingGoal.Text, out d))
            {
                MessageBox.Show("Please enter a valid number for the fundraising goal.");
                return;
            }
            if (txtEventAddress.Text == "")
            {
                MessageBox.Show("You need to enter the Event Address.");
                return;
            }
            if (dpEventDate.SelectedDate == null)
            {
                MessageBox.Show("You need to enter the Event Date.");
                return;
            }
            
            if (txtStartTime.Text == "")
            {
                MessageBox.Show("You need to enter the Start Time.");
                return;
            }
            DateTime dt;
            if (!DateTime.TryParse(txtStartTime.Text, out dt))
            {
                MessageBox.Show("Please enter a valid start time.");
                return;
            }
            if (txtEndTime.Text == "")
            {
                MessageBox.Show("You need to enter the End Time.");
                return;
            }
            if (!DateTime.TryParse(txtEndTime.Text, out dt))
            {
                MessageBox.Show("Please enter a valid end time.");
                return;
            }
            if (txtEventDescription.Text == "")
            {
                MessageBox.Show("You need to enter the Event Description.");
                return;
            }

            var newFundraisingEvent = new FundraisingEvent()
            {
                EventName = txtEventName.Text,
                FundraisingGoal = decimal.Parse(txtFundraisingGoal.Text),
                EventAddress = txtEventAddress.Text,
                EventDate = (DateTime)dpEventDate.SelectedDate,
                StartTime = DateTime.Parse(txtStartTime.Text),
                EndTime = DateTime.Parse(txtEndTime.Text),
                EventDescription = txtEventDescription.Text
            };

            try
            {
                var fundraisingEventManager = new FundraisingEventManager();
                bool result = fundraisingEventManager.CreateFundraisingEvent(newFundraisingEvent);
                MessageBox.Show("Fundraising Event Successfully Added.");
                txtEventName.Clear();
                txtFundraisingGoal.Clear();
                txtEventAddress.Clear();
                dpEventDate.SelectedDate = null;
                txtStartTime.Clear();
                txtEndTime.Clear();
                txtEventDescription.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n\n" + ex.InnerException.Message);
            }
        }
    }
}
