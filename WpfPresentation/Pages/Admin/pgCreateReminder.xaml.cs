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
using LogicLayer;

namespace WpfPresentation.Pages.Admin
{

    /// <summary>
    /// Creator: Marwa Ibrahim
    /// Created: 02/13/2024
    /// Summary: Interaction logic for pgCreateReminder.xaml
    /// Last Updated By: Marwa Ibrahim
    /// Last Updated: 02/13/2024
    /// What Was Changed: Initial Creation
    /// </summary>
    public partial class pgCreateReminder : Page
    {
        private static pgCreateReminder instance = null;

        public static pgCreateReminder GetpgCreateReminder()
        {
           
            if (instance == null)
            {
                instance = new pgCreateReminder();
            }

            return instance;
        }

        private IReminderManager reminderManager;
        public pgCreateReminder()
        {
            InitializeComponent();
            reminderManager = new ReminderManager();
        }

        /// <summary>
        /// Creator: Marwa Ibrahim
        /// Created: 02/13/2024
        /// Summary: Create button  submit
        /// Last Updated By: Mitchell Stirmel
        /// Last Updated 04/10/2024
        /// What was changed: Added try/catch and code cleanup
        /// </summary>

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!isFormValid())
                {
                    return;
                }

                Reminder reminder = new Reminder();
                reminder.EmailTo = txtEmailTo.Text;
                reminder.EmailFrom = txtEmailFrom.Text;
                reminder.Title = txtTitle.Text;
                reminder.Message = txtMessage.Text;
                reminder.Frequency = txtFrequency.Text;
                reminder.Date = DateTime.Now;
                reminder.Read = CkRead.IsChecked == true;
                reminder.Deactivate = CkDeactive.IsChecked == true;
                bool result = reminderManager.createReminder(reminder);
                if (result)
                {
                    //lblErrorMessage.Content = "Create Reminder is Done";
                    MessageBox.Show("Create Reminder is Done");

                }
                else
                {
                    //lblErrorMessage.Content = "Create Reminder is not Done";
                    MessageBox.Show("Create Reminder is not Done");
                }
            }
            catch (Exception)
            {

                throw;
            }

        }

        /// <summary>
        /// Creator: Marwa Ibrahim
        /// Created: 02/13/2024
        /// Summary: Create Reminder Validation.
        /// Last Updated By: Marwa Ibrahim
        /// Last Updated: 02/13/2024
        /// What Was Changed: Initial Creation
        /// </summary>
        private bool isFormValid()
        {
            if (txtEmailFrom.Text.Length==0)
            {
                lblErrorMessage.Content = "Email From is required";
                return false;
            }
            if (txtEmailTo.Text.Length == 0)
            {
                lblErrorMessage.Content = "Email To is required";
                return false;
            }
            if (txtTitle.Text.Length == 0)
            {
                lblErrorMessage.Content = "Title is required";
                return false;
            }
            if (txtMessage.Text.Length == 0)
            {
                lblErrorMessage.Content = "Message is required";
                return false;
            }
            if (txtFrequency.Text.Length == 0)
            {
                lblErrorMessage.Content = "Frequency is required";
                return false;
            }
            lblErrorMessage.Content = string.Empty;
            return true;
        }
    }
}
