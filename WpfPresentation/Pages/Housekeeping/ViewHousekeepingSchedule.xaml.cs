using DataObjects;
using LogicLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// Created: 02/07/2024
    /// Summary: This class is the logic behind the ViewHousekeepingSchedule page.
    /// Last Updated By: Jared Harvey
    /// Last Updated: 02/07/2024
    /// What Was Changed: Initial Creation
    /// </summary>
    public partial class ViewHousekeepingSchedule : Page {
        /// <summary>
        /// Creator: Jared Harvey
        /// Created: 02/07/2024
        /// Summary: This constructor sets the content control to be the ViewDepartmentSchedule view.
        /// Last Updated By: Jared Harvey
        /// Last Updated: 02/07/2024
        /// What Was Changed: Initial Creation
        /// </summary>
        public ViewHousekeepingSchedule() {
            InitializeComponent();
            try
            {
                ccMain.Content = ViewDepartmentSchedule.GetViewDepartmentSchedule(100000);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to get department schedule \n" + ex.ToString(), "Failure", MessageBoxButton.OK);
            }
        }

        private static ViewHousekeepingSchedule pgViewHousekeepingSchedule = null;

        public static ViewHousekeepingSchedule GetViewHousekeepingSchedulePage() {
            return pgViewHousekeepingSchedule ?? (pgViewHousekeepingSchedule = new ViewHousekeepingSchedule());
        }
    }
}
