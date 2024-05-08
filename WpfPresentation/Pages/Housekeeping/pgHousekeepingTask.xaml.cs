using DataObjects;
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
using LogicLayer;

namespace WpfPresentation.Pages.Housekeeping
{
    /// <summary>
    /// Interaction logic for pgHousekeepingTask.xaml
    /// </summary>
    public partial class pgHousekeepingTask : Page
    {
        /// <summary>
        /// Creator: Miyada Abas
        /// Created: 02/01/2024
        /// Summary: Constructor for pgHouseKeepingTask.xaml
        /// Last Updated By: Miyada Abas
        /// Last Updated: 02/01/2024
        /// What Was Changed: Initial Creation
        ///Last Updated By:    Mitchell Stirmel
        ///Last Updated:       04/11/2024
        ///What Was changed:   Added try catch
        /// </summary>
        private List<HouseKeepingTask> houseKeepingList;
        private IHouseKeepingManager houseKeepingManager;

        public pgHousekeepingTask()
        {
            InitializeComponent();
            houseKeepingManager = new HouseKeepingManager();
            houseKeepingList = new List<HouseKeepingTask>();
            filldatagrid();
        }
        private static pgHousekeepingTask pgHousekeepingTaskPage = null;
        public static pgHousekeepingTask GetViewHousekeepingTasksPage()
        {
            return pgHousekeepingTaskPage ?? (pgHousekeepingTaskPage = new pgHousekeepingTask());
        }

        private void filldatagrid()
        {
            try
            {
                houseKeepingList = houseKeepingManager.GetAllHouseKeepingTasks();
                dghousekeepingtask.ItemsSource = houseKeepingList;
            }
            catch (Exception ex)
            {

                MessageBox.Show("Unable to get housekeeping tasks \n" + ex.ToString(), "Failure", MessageBoxButton.OK);
            }
        }
    }

}
