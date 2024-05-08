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
using WpfPresentation.Pages.Donations;

namespace WpfPresentation.Pages.Schedule
{
    /// <summary>
    /// Creator:            Abdalgader Ibrahim
    /// Created:            03/19/2024
    /// Summary:            Creation of the pgViewAllSchedules page code behind file.
    /// </summary>
    
    /// <summary>
    /// Interaction logic for pgViewAllSchedules.xaml
    /// </summary>
    public partial class pgViewAllSchedules : Page
    {
        IScheduleManager _scheduleManager;
        /// <summary>
        /// Creator:            Abdalgader Ibrahim
        /// Created:            03/19/2024
        /// Summary:            Creation of the pgViewAllSchedules() method.
        ///Last Updated By:    Mitchell Stirmel
        ///Last Updated:       04/11/2024
        ///What Was changed:   Added try catch
        /// </summary>
        public pgViewAllSchedules()
        {
            InitializeComponent();
            _scheduleManager = new ScheduleManager();
            try
            {

                dgSchedules.ItemsSource = _scheduleManager.GetAllSchedules();
                Style rowStyle = new Style(typeof(DataGridRow));
                rowStyle.Setters.Add(new EventSetter(DataGridRow.MouseDoubleClickEvent,
                                         new MouseButtonEventHandler(Row_DoubleClick)));
                dgSchedules.RowStyle = rowStyle;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to get schedules \n" + ex.ToString(), "Failure", MessageBoxButton.OK);
            }
        }
        /// <summary>
        /// Creator:            Abdalgader Ibrahim
        /// Created:            03/19/2024
        /// Summary:            Creation of the Row_DoubleClick click.
        /// </summary>
        private void Row_DoubleClick(object sender, MouseButtonEventArgs e)
        {
            DataGridRow row = sender as DataGridRow;
            var schedule = (ScheduleVM)row.DataContext;
            NavigationService.Navigate(new pgViewSchedule(schedule.ScheduleID));

        }
    }
}
