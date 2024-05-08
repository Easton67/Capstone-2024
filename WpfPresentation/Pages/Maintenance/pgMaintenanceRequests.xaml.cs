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
using WpfPresentation.Pages.Login;
using WpfPresentation.UtilWindows;

namespace WpfPresentation.Pages.Maintenance
{        
         /// <summary>
         ///Creator:            Mitchell Stirmel
         ///Created:            02/07/2024
         ///Summary:            This is the class for pgMaintenanceRequests
         ///Last Updated By:    Tyler Barz
         ///Last Updated:       02/24/2024
         ///What Was Changed:   Implemented MainManager
         ///Last Updated By:    Mitchell Stirmel 
         ///Last Updated:       02/27/2024
         ///What Was Change:    Fixed null reference exception by calling GetMainManager() before GetMaintenanceRequest()
         /// </summary>
    public partial class pgMaintenanceRequests : Page
    {
        private MaintenanceRequest _maintenanceRequest;
        private MainManager _mainManager;
        public pgMaintenanceRequests()
        {
            InitializeComponent();
            _mainManager = MainManager.GetMainManager();

            GetMaintenanceRequests();
        }

        private static pgMaintenanceRequests instance = null;
        public static pgMaintenanceRequests GetPgMaintenanceRequests()
        {
            return instance ?? (instance = new pgMaintenanceRequests());
        }

        /// <summary>
        ///Creator:            Mitchell Stirmel
        ///Created:            02/07/2024
        ///Summary:            Refreshes the list of requests.
        ///Last Updated By:    Mitchell Stirmel
        ///Last Updated:       02/07/2024
        ///What Was Changed:   Initial Creation
        /// </summary>
        private void btnRefresh_Click(object sender, RoutedEventArgs e)
        {
            GetMaintenanceRequests();
        }

        /// <summary>
        ///Creator:            Mitchell Stirmel
        ///Created:            02/07/2024
        ///Summary:            This method sets the datagrid to the list of current maintenance requests.
        ///Last Updated By:    Mitchell Stirmel
        ///Last Updated:       02/07/2024
        ///What Was Changed:   Initial Creation
        ///Last Updated By:    Matthew Baccam
        ///Last Updated:       04/04/2024
        ///What Was Changed:   Wraped the GetMaintenanceRequests() in a try catch
        /// </summary>
        public void GetMaintenanceRequests()
        {
            try
            {
                List<MaintenanceRequest> list = _mainManager.MaintenanceRequestManager.GetMaintenanceRequests();
                dgdMaintenanceRequest.ItemsSource = list;
            }
            catch (Exception ex)    
            {
                MessageBox.Show(ex.Message, "Failed to retrieve maintenance requests", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        /// <summary>
        ///Creator:           Marwa Ibrahim
        ///Created:            03/03/2024
        ///Summary:           Create MaintenanceRequest 
        ///What Was Changed:   Initial Creation
        /// </summary>

        private void btnScheduleRepair_Click_1(object sender, RoutedEventArgs e)
        {
            
            NavigationService.Navigate(new pgCreateMaintenanceRequest());
           
        }


        /// <summary>
        ///Creator:            Kirsten Stage
        ///Created:            03/07/2024
        ///Summary:            This button click event will open the Complete Maintenance Request window.
        ///Last Updated By:    Kirsten Stage
        ///Last Updated:       03/07/2024
        ///What Was Changed:   Initial Creation
        /// </summary>
        private void btnCompleteRepair_Click(object sender, RoutedEventArgs e)
        {
            if(dgdMaintenanceRequest.SelectedItem == null)
            {
                MessageBox.Show("You need to select a request to complete.");
                return;
            }

            var maintenanceRequest = dgdMaintenanceRequest.SelectedItem as MaintenanceRequest;

            if (maintenanceRequest._status == "Completed")
            {
                MessageBox.Show("This request has already been marked as complete.");
                return;
            }

            var completeRepair = new completeRepair(maintenanceRequest);
            completeRepair.Show();
        }
        /// <summary>
        ///Creator:            Donald Winchester
        ///Created:            02/23/2024
        ///Summary:           This method sets the datagrid (maintenance request status) to a specific string 
        ///Last Updated By:    Donald Winchester
        ///Last Updated:       03/08/2024
        ///What Was Changed:   Initial Creation
        ///Last Updated By:    Matthew Baccam
        ///Last Updated:       Did something with the ex instead of doing nothing and nothing
        /// </summary>
        public bool ConfirmMaintenanceRequest(int requestID, string status)
        {
            bool result = false;
            try
            {
                result = ConfirmMaintenanceRequest(requestID, status);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Failed to confirm request", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            return result;
        }
        /// <summary>
        ///Creator:            Donald Winchester
        ///Created:            02/23/2024
        ///Summary:            This click function sets the status of the maintenance request to "In Progress"
        ///Last Updated By:    Donald Winchester
        ///Last Updated:       03/08/2024
        ///What Was Changed:   Initial Creation
        ///Last Updated By:    Matthew Baccam
        ///Last Updated:       04/04/2024
        ///What Was Changed:   Made the catch do something in instead of just throw since that will error out on the presentation layer
        /// </summary>

        private void btnConfirmRepair_Click(object sender, RoutedEventArgs e)
        {
            MaintenanceRequest maintenanceRequest = (MaintenanceRequest)dgdMaintenanceRequest.SelectedItem;
            try
            {
                _mainManager.MaintenanceRequestManager.ConfirmMaintenanceRequest(maintenanceRequest._requestID, "In Progress");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Confirm failed", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        /// <summary>
        ///Creator:            Matthew Baccam
        ///Created:            03/08/2024
        ///Summary:            Suspends a maintenance request
        ///Last Updated By:    Matthew Baccam
        ///Last Updated:       03/08/2024
        ///What Was Changed:   Initial Creation
        /// </summary>
        private void menuItemSuspend_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (_maintenanceRequest != null)
                {
                    if (_mainManager.MaintenanceRequestManager.SuspendMaintenanceRequest(_maintenanceRequest._requestID, _maintenanceRequest._description, _maintenanceRequest._description + $"\nSuspended: {DateTime.Now}"))
                    {
                        MessageBox.Show("Suspended maintenance request", "Suspension success", MessageBoxButton.OK, MessageBoxImage.Information);
                        dgdMaintenanceRequest.ItemsSource = _mainManager.MaintenanceRequestManager.GetMaintenanceRequests();
                    }
                    else
                    {
                        MessageBox.Show("Suspended maintenance request failed", "Suspension fail", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Suspension failed", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        /// <summary>
        ///Creator:            Matthew Baccam
        ///Created:            03/08/2024
        ///Summary:            Selects a maintenance request from the data grid
        ///Last Updated By:    Matthew Baccam
        ///Last Updated:       03/08/2024
        ///What Was Changed:   Initial Creation
        /// </summary>
        private void dgdMaintenanceRequest_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (dgdMaintenanceRequest.SelectedItem != null)
            {
                _maintenanceRequest = dgdMaintenanceRequest.SelectedItem as MaintenanceRequest;
            }
        }


        /// <summary>
        /// Creator:Andres Garcia
        /// Created: 4/19/2024
        /// Summary: Schedule repair button schedules repair.
        /// Last Updated By: Andres Garcia
        /// Last Updated: 4/19/2024
        /// What was Changed: Inital Creation
        /// </summary>

        private void btnRepair_Click(object sender, RoutedEventArgs e)
        {
            MaintenanceRequest maintenanceRequest = null;
            maintenanceRequest = dgdMaintenanceRequest.SelectedItem as MaintenanceRequest;

            if (maintenanceRequest == null)
            {
                MessageBox.Show("Please select a request to schedule repair for");
            }
            else
            {
                ScheduleRepair winScheduleRepair = new ScheduleRepair(maintenanceRequest);
                winScheduleRepair.ShowDialog();
            }
        }
    }
}
