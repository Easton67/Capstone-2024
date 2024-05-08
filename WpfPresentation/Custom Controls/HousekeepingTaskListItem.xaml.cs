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
using WpfPresentation.Pages.Housekeeping;
using WpfPresentation.UtilWindows;

namespace WpfPresentation.Custom_Controls {
    /// <summary>
    /// Interaction logic for HousekeepingTaskListItem.xaml
    /// </summary>
    public partial class HousekeepingTaskListItem : UserControl {
        private HousekeepingTaskVM housekeepingTaskVM = null;
        private MainManager _manager = null;

        /// <summary>
        /// Creator: Jared Harvey
        /// Created: 04/27/2024
        /// Summary: Constructor that takes in a task and splits them up by status
        /// Last Updated By: null
        /// Last Updated: null
        /// What Was Changed: null
        /// </summary>
        public HousekeepingTaskListItem(HousekeepingTaskVM housekeepingTaskVM) {
            this.housekeepingTaskVM = housekeepingTaskVM;
            _manager = MainManager.GetMainManager();
            DataContext = housekeepingTaskVM;
            InitializeComponent();
            if (housekeepingTaskVM.Status == "Dirty") {
                MenuItem item = new MenuItem();
                item.Header = "Assign Housekeeper";
                item.Name = "mnuAssignHousekeeper";
                item.Click += new RoutedEventHandler(mnuAssignHousekeeper_Click);
                MainGrid.ContextMenu.Items.Add(item);
            } else {
                MenuItem item = new MenuItem();
                item.Header = "Update Task Status";
                item.Name = "mnuUpdateTaskStatus";
                item.Click += new RoutedEventHandler(mnuUpdateTaskStatus_Click);
                MainGrid.ContextMenu.Items.Add(item);
            }
        }

        /// <summary>
        /// Creator: Jared Harvey
        /// Created: 04/27/2024
        /// Summary: Click Handler for assign housekeeper context menu item
        /// Last Updated By: null
        /// Last Updated: null
        /// What Was Changed: null
        /// </summary>
        private void mnuAssignHousekeeper_Click(object sender, RoutedEventArgs e) {
            // open util window
            AssignHousekeeperToTask assignHousekeeperToTask = new AssignHousekeeperToTask(housekeepingTaskVM);
            bool? result = assignHousekeeperToTask.ShowDialog();
            if(result == true) {
                ViewHousekeepingTasks.GetViewHouseKeepingTasksPage().PopulateData();
            }
        }

        /// <summary>
        /// Creator: Ethan McElree
        /// Created: 03/4/2024
        /// Summary: click handler for the group box items
        /// Last Updated By: Jared Harvey
        /// Last Updated: 04/27/2024
        /// What Was Changed: Moved to here
        /// </summary>
        private void mnuUpdateTaskStatus_Click(object sender, RoutedEventArgs e) {
            NavigationService navService = NavigationService.GetNavigationService(this);
            navService.Navigate(new pgConfirmAndCompleteCleaning(housekeepingTaskVM));
        }
    }
}
