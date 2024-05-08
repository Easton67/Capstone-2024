using LogicLayer;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace WpfPresentation.Pages.Messaging
{
    /// <summary>
    /// Written By:     Tyler Barz
    /// Written:        04/13/2024
    /// Summary:        Mass alert/emailing system
    ///                 Asynchronous task pooling
    /// </summary>
    public partial class PgEmailAlert : Page
    {
        private static PgEmailAlert instance;
        public static PgEmailAlert GetPgEmailAlert()
        {
            return instance ?? (instance = new PgEmailAlert());
        }
        private MainManager manager;
        private PgEmailAlert()
        {
            InitializeComponent();
            manager = MainManager.GetMainManager();
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            tbEmailResponse.Text = string.Empty;
        }

        private async void btnSend_Click(object sender, RoutedEventArgs e)
        {
            btnClear_Click(sender, e);
            List<string> userIds = new List<string>();
            string subject = tbEmailHeader.Text;
            string body = tbEmailSubject.Text;

            if (!(subject.Length > 0 && subject.Length < 40) && !(body.Length > 0 && body.Length < 260))
            {
                MessageBox.Show("Subject must be between 0-40 characters\nEmail body must be between 0-260 characters", "Failed to send");
                return;
            }

            try
            {
                if ((bool)cbEmployees.IsChecked)
                {
                    userIds.AddRange(manager.UserManager.GetAllEmployeeIDs());
                }
                if ((bool)cbClients.IsChecked)
                {
                    userIds.AddRange(manager.UserManager.GetAllClients().Select(user => user.UserID));
                }
                if ((bool)cbVolunteers.IsChecked)
                {
                    userIds.AddRange(manager.UserManager.SelectAllVolunteers().Select(user => user.UserID));
                }
            }
            catch
            {
                MessageBox.Show("Unable to load user data, please try again later", "Failed to send");
                return;
            }

            if (!(userIds.Count > 0))
            {
                MessageBox.Show("Please select a group of users", "Failed to send");
                return;
            }

            try
            {
                tbEmailResponse.Text += $"Queued {userIds.Count} emails\n";
                List<Task> tasks = new List<Task>();
                userIds.ForEach(email =>
                {
                    Task task = manager.messageManager.SendEmail(email, subject, body);
                    // Since other thread uses the task, invoke ui update from background thread
                    task.ContinueWith(t =>
                    {
                        Dispatcher.Invoke(() => tbEmailResponse.Text += $"Sent: {email}\n");
                    }, TaskContinuationOptions.ExecuteSynchronously);
                    tasks.Add(task);
                });

                await Task.WhenAll(tasks);
                MessageBox.Show("All alert emails have been sent", "Alert Message Successful");
            }
            catch
            {
                tbEmailHeader.Text += "There was an unexpected error when sending emails, please try again later";
            }
        }

        // Kinda dumb, however no default placeholder text attribute
        private void tbEmailHeader_GotFocus(object sender, RoutedEventArgs e)
        {
            if (tbEmailHeader.Text == "Email Header")
            {
                tbEmailHeader.Text = string.Empty;
            }
        }

        private void tbEmailSubject_GotFocus(object sender, RoutedEventArgs e)
        {
            if (tbEmailSubject.Text == "Email Subject")
            {
                tbEmailSubject.Text = string.Empty;
            }
        }
    }
}
