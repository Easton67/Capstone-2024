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

namespace WpfPresentation.Pages.Maintenance
{
    /// <summary>
    /// Creator: Kirsten Stage
    /// Created: 03/07/2024
    /// Summary: Interaction logic for completeRepair.xaml
    /// Last Updated By: Kirsten Stage
    /// Last Updated: 03/07/2024
    /// What Was Changed: Initial Creation
    ///Last Updated By:    Matthew Baccam
    ///Last Updated:       04/04/2024
    ///What Was Changed:   Removed the System.Windows.Forms reference because it was causing a ambigious type error when trying to use Messagebox
    /// </summary>

    public partial class completeRepair : Window
    {
        private MaintenanceRequest _maintenanceRequest = null;

        public completeRepair(MaintenanceRequest maintenanceRequest)
        {
            InitializeComponent();
            _maintenanceRequest = maintenanceRequest;
        }


        /// <summary>
        /// Creator: Kirsten Stage
        /// Created: 03/07/2024
        /// Summary: The content that will display upon opening the completeRepair window. 
        /// Last Updated By: Kirsten Stage
        /// Last Updated: 03/07/2024
        /// What Was Changed: Initial Creation
        /// </summary>
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            txtRequestID.Text = _maintenanceRequest._requestID.ToString();
            txtRoomID.Text = _maintenanceRequest._roomID.ToString();
            txtRequestor.Text = _maintenanceRequest._requestor;
            txtDateCreated.Text = _maintenanceRequest._dateCreated.ToString();
            txtPhone.Text = _maintenanceRequest._phone;
            txtDescription.Text = _maintenanceRequest._description;

            txtRequestID.IsReadOnly = true;
            txtRoomID.IsReadOnly = true;
            txtRequestor.IsReadOnly = true;
            txtDateCreated.IsReadOnly = true;
            txtPhone.IsReadOnly = true;
            txtDescription.IsReadOnly = true;
        }

        /// <summary>
        /// Creator: Kirsten Stage
        /// Created: 03/07/2024
        /// Summary: This click event will close the completeRepair window. 
        ///          No changes will be saved.
        /// Last Updated By: Kirsten Stage
        /// Last Updated: 03/07/2024
        /// What Was Changed: Initial Creation
        /// </summary>
        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Creator: Kirsten Stage
        /// Created: 03/07/2024
        /// Summary: This click event will mark the selected maintenance request as complete. 
        /// Last Updated By: Kirsten Stage
        /// Last Updated: 03/07/2024
        /// What Was Changed: Initial Creation
        ///Last Updated By:    Matthew Baccam
        ///Last Updated:       04/04/2024
        ///What Was Changed:   Wraped the UpdateMaintenanceRequestStatusToCompleted() in a try catch
        /// </summary>
        private void btnComplete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var maintenanceRequestManager = new MaintenanceRequestManager();
                try
                {
                    maintenanceRequestManager.UpdateMaintenanceRequestStatusToCompleted(_maintenanceRequest);
                }
                catch (Exception ex)
                {
                   MessageBox.Show(ex.Message, "Confirm failed", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                
                MessageBox.Show("Please press Refresh on the Maintenance Request page to see the updated status for this request.", "Changes Complete", MessageBoxButton.OK, MessageBoxImage.Information);

                this.Close();
            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message + "\n\n" + ex.InnerException.Message);
            }
        }
    }
}
