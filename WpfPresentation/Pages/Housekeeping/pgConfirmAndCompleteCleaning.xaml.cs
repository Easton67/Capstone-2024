using LogicLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrackBar;
using DataObjects;

namespace WpfPresentation.Pages.Housekeeping
{
    /// <summary>
    /// Creator: Ethan McElree
    /// Created: 03/4/2024
    /// Summary: Page for confirm a cleaning task.
    /// Last Updated By: Ethan McElree
    /// Last Updated: 03/4/2024
    /// What Was Changed: Initial Creation
    ///Last Updated By:    Mitchell Stirmel
    ///Last Updated:       04/11/2024
    ///What Was changed:   Added try catch
    /// </summary>
    public partial class pgConfirmAndCompleteCleaning : Page
    {
        private IHousekeepingTaskManager _taskManager;
        private HousekeepingTaskVM housekeepingTaskVM;
        public pgConfirmAndCompleteCleaning(HousekeepingTaskVM housekeepingTaskVM)
        {
            InitializeComponent();
            _taskManager = new HousekeepingTaskManager();
            this.housekeepingTaskVM = housekeepingTaskVM;
            lblRoomNumber.Content = housekeepingTaskVM.RoomNumber;
            try
            { // This may need some fixing...
                var tasks = _taskManager.GetHousekeepingTasksByShelterID("Test Homeless Shelter");
                var status = new HashSet<string>();
                status.Add("Dirty");
                status.Add("In Cleaning");
                status.Add("Needs Inspected");
                status.Add("Clean");
                foreach (var task in tasks)
                {
                    status.Add(task.Status);
                }
                HousekeepingTaskStatus.ItemsSource = status;
            }
            catch (Exception ex)
            {

                MessageBox.Show("Unable to get housekeeping tasks \n" + ex.ToString(), "Failure", MessageBoxButton.OK);
            }
            
        }



        /// <summary>
        /// Creator: Ethan McElree
        /// Created: 03/4/2024
        /// Summary: Click handler for the confirm cleaning button.
        /// Last Updated By: Ethan McElree
        /// Last Updated: 03/8/2024
        /// What Was Changed: Added an if statement to bring up a messagebox if the confirm button is clicked while no task status is selected.
        ///Last Updated By:    Mitchell Stirmel
        ///Last Updated:       04/11/2024
        ///What Was changed:   Added try catch
        /// </summary>
        private void btnConfirmCleanig_Click(object sender, RoutedEventArgs e)
        {         
            if (HousekeepingTaskStatus.SelectedItem == null)
            {
                MessageBox.Show("Please select a status first then try again.");
            }
            else
            {
                try
                {
                    string newStatus = HousekeepingTaskStatus.SelectedItem as string;
                    _taskManager.UpdateHousekeepingTaskStatus(this.housekeepingTaskVM.TaskID, newStatus);
                    NavigationService.Navigate(ViewHousekeepingTasks.GetViewHouseKeepingTasksPage());
                }
                catch (Exception ex)
                {

                    MessageBox.Show("Unable to update status \n " + ex.ToString(), "Failure", MessageBoxButton.OK);
                }
            }                   
        }

        /// <summary>
        /// Creator: Ethan McElree
        /// Created: 03/4/2024
        /// Summary: Click handler for the cancel button.
        /// Last Updated By: Ethan McElree
        /// Last Updated: 03/4/2024
        /// What Was Changed: Initial Creation
        /// </summary>
        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
