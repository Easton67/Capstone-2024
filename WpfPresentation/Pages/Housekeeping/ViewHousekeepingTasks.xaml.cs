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
using WpfPresentation.Custom_Controls;

namespace WpfPresentation.Pages.Housekeeping {
    /// <summary>
    /// Creator: Jared Harvey
    /// Created: 02/16/2024
    /// Summary: 
    /// Last Updated By: Jared Harvey
    /// Last Updated: 02/16/2024
    /// What Was Changed: Initial Creation
    /// </summary>
    public partial class ViewHousekeepingTasks : Page {
        HousekeepingTaskManager taskManager = new HousekeepingTaskManager();
        List<HousekeepingTaskVM> tasks = null;
        public ViewHousekeepingTasks()
        {
            InitializeComponent();
            PopulateData();
        }

        /// <summary>
        /// Creator: Jared Harvey
        /// Created: 04/27/2024
        /// Summary: Makes sure that data is re-populated after this page is navigated to.
        /// Last Updated By: null
        /// Last Updated: null
        /// What Was Changed: null
        /// </summary>
        private void Page_Loaded(object sender, RoutedEventArgs e) {
            PopulateData();
        }

        /// <summary>
        /// Creator: Jared Harvey
        /// Created: 04/27/2024
        /// Summary: Publicly accessable method that populates the item controls on this page
        /// Last Updated By: null
        /// Last Updated: null
        /// What Was Changed: null
        /// </summary>
        public void PopulateData() {
            try {
                icDirty.Items.Clear();
                icInCleaning.Items.Clear();
                icNeedsInspected.Items.Clear();
                icClean.Items.Clear();
                tasks = taskManager.GetHousekeepingTasksByShelterID("Test Homeless Shelter");

                foreach (HousekeepingTaskVM task in tasks) {
                    switch (task.Status) {
                        case "Dirty":
                            icDirty.Items.Add(new HousekeepingTaskListItem(task));
                            break;
                        case "In Cleaning":
                            icInCleaning.Items.Add(new HousekeepingTaskListItem(task));
                            break;
                        case "Needs Inspected":
                            icNeedsInspected.Items.Add(new HousekeepingTaskListItem(task));
                            break;
                        case "Clean":
                            icClean.Items.Add(new HousekeepingTaskListItem(task));
                            break;
                    }
                }
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Creator: Jared Harvey
        /// Created: 02/16/2024
        /// Summary: Navigation stuff
        /// Last Updated By: Jared Harvey
        /// Last Updated: 02/16/2024
        /// What Was Changed: Initial Creation
        /// </summary>
        private static ViewHousekeepingTasks instance = null;
        public static ViewHousekeepingTasks GetViewHouseKeepingTasksPage() {
            return instance ?? (instance = new ViewHousekeepingTasks());
        }
    }
}
