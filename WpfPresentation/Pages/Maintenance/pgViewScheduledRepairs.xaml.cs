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
    ///Creator:            Seth Nerney
    ///Created:            02/25/2024
    ///Summary:            This is the class for pgViewScheduledRepairs
    ///Last Updated By:    Seth Nerney
    ///Last Updated:       02/25/2024
    ///What Was Changed:   Inital Creation
    /// </summary>
    public partial class pgViewScheduledRepairs : Page
    {
        private static pgViewScheduledRepairs instance = null;
        public static pgViewScheduledRepairs GetpgViewScheduledRepairs()
        {
            return instance ?? (instance = new pgViewScheduledRepairs());
        }
        public pgViewScheduledRepairs()
        {
            InitializeComponent();
            GetListOfScheduledRepairs();

        }

        public void GetListOfScheduledRepairs()
        {
            try
            {
                if (datScheduledRepairs.ItemsSource == null)
                {
                    var maintenanceManager = new MaintenanceRequestManager();
                    datScheduledRepairs.ItemsSource = maintenanceManager.GetScheduledRepairs("Scheduled for repair");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n\n" + ex.InnerException.Message);
            }
        }

        private void btnRefresh_Click(object sender, RoutedEventArgs e)
        {
            GetListOfScheduledRepairs();
        }
    }
}
