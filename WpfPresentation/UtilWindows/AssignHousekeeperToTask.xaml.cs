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

namespace WpfPresentation.UtilWindows {
    /// <summary>
    /// Creator: Jared Harvey
    /// Created: 04/27/2024
    /// Summary: Code behind for AssignHousekeeperToTask Util Window
    /// Last Updated By: null
    /// Last Updated: null
    /// What Was Changed: null
    /// </summary>
    public partial class AssignHousekeeperToTask : Window {
        private MainManager _manager;
        private HousekeepingTaskVM housekeepingTaskVM;
        public AssignHousekeeperToTask(HousekeepingTaskVM housekeepingTaskVM) {
            this.housekeepingTaskVM = housekeepingTaskVM;
            _manager = MainManager.GetMainManager();
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e) {
            try {
                cbxHousekeepers.ItemsSource = _manager.UserManager.GetDepartmentEmployees(100000); // housekeeping department id
            } catch (Exception ex) { 
                MessageBox.Show("Unable to retreive list of housekeeping staff", ex.Message);
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e) {
            this.DialogResult = false;
        }

        private void btnAssign_Click(object sender, RoutedEventArgs e) {
            if(cbxHousekeepers.SelectedItem == null) {
                MessageBox.Show("You must select a member of the housekeeping staff to assign to this task.");
                return;
            }
            try {
                Employee selected = cbxHousekeepers.SelectedItem as Employee;
                if(_manager.HousekeepingTaskManager.AssignHousekeeperToTask(housekeepingTaskVM.TaskID, selected.EmployeeID)) {
                    DialogResult = true;
                } else {
                    MessageBox.Show("Failed to assign housekeeper to task");
                    return;
                }
            } catch (Exception ex) {
                MessageBox.Show(ex.Message, "Failed to assign housekeeper to task");
                return;
            }

        }
    }
}
