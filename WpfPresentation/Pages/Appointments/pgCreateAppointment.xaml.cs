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
using WpfPresentation.Pages.Menu;

namespace WpfPresentation.Pages.Appointments
{
    /// <Summary>
    /// Creator: Ethan McElree
    /// Created: 03/25/2024
    /// Summary: Code behind for the create appointment page.
    /// Last Updated By: Ethan McElree
    /// Last Updated: 03/25/2024
    /// What Was Changed: Initial Creation.
    /// <Summary>
    public partial class pgCreateAppointment : Page
    {
        IAppointmentManager _appointmentManager;
        ILocationManager _locationManager;
        IUserManager _userManager;
        List<Employee> employees;
        List<Client> clients;
        List<Location> locations;
        public pgCreateAppointment()
        {
            InitializeComponent();
            _locationManager = new LocationManager();
            _userManager = new UserManager();
            _appointmentManager = new AppointmentManager();
            locations = _locationManager.GetLocations();
            employees = _userManager.SelectAllEmployees();
            clients = _userManager.GetAllClients();
            List<string> locationNames = new List<string>();
            foreach (Location location in locations)
            {
                locationNames.Add(location.LocationName);
            }
            List<string> employeeIds = new List<string>();
            foreach (Employee employee in employees)
            {
                employeeIds.Add(employee.EmployeeID);
            }
            List<string> clientIds = new List<string>();
            foreach (Client client in clients)
            {
                clientIds.Add(client.UserID);
            }
            cboAppointmentEmployee.ItemsSource = employeeIds;
            cboClient.ItemsSource = clientIds;
            cboLocation.ItemsSource = locationNames;
            cboAppointmentType.ItemsSource = new List<string>() { "Regular", "Checkup", "Consultation", "Follow-up", "Introduction"};
        }

        /// <Summary>
        /// Creator: Ethan McElree
        /// Created: 03/25/2024
        /// Summary: Click handler for the submit button on the create appointment page.
        /// Last Updated By: Ethan McElree
        /// Last Updated: 03/25/2024
        /// What Was Changed: Initial Creation.
        /// <Summary>
        private void SubmitAppointment_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string ClientID = "";
                if (cboClient.SelectedItem == null || cboClient.SelectedItem.ToString().Length == 0)
                {
                    throw new Exception("Client is required");
                }
                else
                {
                    ClientID = cboClient.SelectedItem.ToString();
                }

                int LocationID = 0;
                if (cboLocation.SelectedItem == null || cboLocation.SelectedItem.ToString().Length == 0)
                {
                    throw new Exception("Location is required");
                }
                else
                {
                    foreach (Location location in locations)
                    {
                        if (location.LocationName.Equals(cboLocation.SelectedItem.ToString()))
                        {
                            LocationID = location.LocationID;
                        }
                    }
                }

                string AppointmentType = "";
                if (cboAppointmentType.SelectedItem == null || cboAppointmentType.SelectedItem.ToString().Length == 0)
                {
                    throw new Exception("Type is required");
                }
                else
                {
                    AppointmentType = cboAppointmentType.SelectedItem.ToString();
                }

                string EmployeeID = "";
                if (cboAppointmentEmployee.SelectedItem == null || cboAppointmentEmployee.SelectedItem.ToString().Length == 0)
                {
                    throw new Exception("Employee is required");
                }
                else
                {
                    EmployeeID = cboAppointmentEmployee.SelectedItem.ToString();
                }
                try
                {
                    DateTime startTime = DateTime.Parse(dateStartTime.Value.ToString());
                    DateTime endTime = DateTime.Parse(dateEndTime.Value.ToString());
                    if (endTime < startTime)
                    {
                        throw new Exception("End time must be later than start time.");
                    }
                }
                catch (Exception)
                {
                    throw new Exception("Sorry, having trouble recognizing those times.");
                }                           
                AppointmentVM appointmentVM = new AppointmentVM()
                {
                    _employeeID = EmployeeID,
                    _clientID = ClientID,
                    _appointmentType = AppointmentType,
                    _appointmentStartTime = DateTime.Parse(dateStartTime.Value.ToString()),
                    _appointmentEndTime = DateTime.Parse(dateEndTime.Value.ToString()),
                    _locationId = LocationID,
                };
                _appointmentManager.CreateAppointment(appointmentVM);
                MessageBox.Show("Appointment Created.  Please don't be late.");
                NavigationService.Navigate(new ViewAppointment());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <Summary>
        /// Creator: Ethan McElree
        /// Created: 03/25/2024
        /// Summary: Click handler for the cancel button on the create appointment page.
        /// Last Updated By: Ethan McElree
        /// Last Updated: 03/25/2024
        /// What Was Changed: Initial Creation.
        /// <Summary>
        private void CancelAppointmentCreation_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ViewAppointment());
        }

        /// <summary>
        /// Creator: Ethan McElree
        /// Created: 03/25/2024
        /// Summary: Logic for navigation in the pgCreateAppointment file.
        /// Last Updated By: Ethan McElree
        /// Last Updated: 03/25/2024
        /// What Was Changed: Initial Creation
        /// </summary>
        private static pgCreateAppointment instance = null;
        public static pgCreateAppointment GetpgCreateAppointment()
        {
            return instance ?? (instance = new pgCreateAppointment());
        }
    }
}
