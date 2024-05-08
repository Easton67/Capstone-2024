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

namespace WpfPresentation.UtilWindows
{
    /// <summary>
    /// Interaction logic for ScheduleRepair.xaml
    /// </summary>
    public partial class ScheduleRepair : Window
    {
        UserManager _userManager = new UserManager();
        MaintenanceRequestManager _maintenanceRequestManager = new MaintenanceRequestManager();
        MaintenanceRequest _maintenanceRequest;

        public ScheduleRepair(MaintenanceRequest maintenanceRequest)
        {
            string label = "Scheduling repair for RequestID: " + maintenanceRequest._requestID;
            _maintenanceRequest = maintenanceRequest;
            InitializeComponent();
            lblScheduleRepair.Content = label;

            List<string> allEmployees = _userManager.GetAllEmployeeIDs();
            List<string> allEmployeeNames = new List<string>();

            foreach (var employee in allEmployees)
            {
                var employeeUser = _userManager.SelectEmployeeByID(employee);
                string employeeFirstName = employeeUser.FirstName;
                string employeeLastName = employeeUser.LastName;
                allEmployeeNames.Add(employeeFirstName + " " + employeeLastName);
            }


            cmbEmployees.ItemsSource = allEmployeeNames;
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }


        private void btnScheduleRepair_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DateTime selectedDate = repairDatePicker.SelectedDate.Value;
                var _selectedEmployeeName = cmbEmployees.SelectedItem;
                List<String> allEmployees = _userManager.GetAllEmployeeIDs();
                string selectedEmployeeId = null;
                foreach (var employee in allEmployees)
                {
                    var employeeUser = _userManager.SelectEmployeeByID(employee);
                    string employeeFirstName = employeeUser.FirstName;
                    string employeeLastName = employeeUser.LastName;
                    string employeeFullName = employeeFirstName + " " + employeeLastName;
                    if (employeeFullName.Equals(_selectedEmployeeName))
                    {
                        selectedEmployeeId = employeeUser.UserID;
                    }
                }
                try
                {

                    _maintenanceRequestManager.ScheduleRepair(_maintenanceRequest._requestID, selectedEmployeeId, selectedDate);
                    this.Close();
                    MessageBox.Show("Repair Scheduled!");
                }

                catch (Exception ex)
                {

                    MessageBox.Show("Unable to schedule repair, try again later", ex.Message);
                }
            }
            catch (Exception ex) 
            {
                MessageBox.Show("Unable to schedule repair, try again", ex.Message);
            }

        }
    }
}
