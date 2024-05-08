using DataObjects;
using LogicLayer;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using WpfPresentation.Pages.Stats;
using MessageBox = System.Windows.MessageBox;

namespace WpfPresentation.Pages.Schedule
{
    /// <summary>
    /// Creator:            Ethan McElree
    /// Created:            02/13/2024
    /// Summary:            Creation of the CreateSchedule page code behind file.
    /// Last Updated By:    Ethan McElree
    /// Last Updated:       02/13/2024
    /// What Was Changed:   Initial Creation
    /// </summary>
    public partial class pgCreateSchedule : Page
    {
        private IScheduleManager scheduleManager;
        public pgCreateSchedule()
        {
            InitializeComponent();
            scheduleManager = new ScheduleManager();
        }

        /// <summary>
        /// Creator:            Ethan McElree
        /// Created:            02/13/2024
        /// Summary:            Creation of the CreateSchedule page code behind file.
        /// Last Updated By:    Ethan McElree
        /// Last Updated:       03/22/2024
        /// What Was Changed:   Cancel button now navigates to home.
        /// </summary>
        private void btnCancelCreateSchedule_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(PgShelterDashboard.GetPgShelterDashboard());
        }

        /// <summary>
        /// Creator:            Ethan McElree
        /// Created:            02/13/2024
        /// Summary:            Creation of the CreateSchedule page code behind file.
        /// Last Updated By:    Ethan McElree
        /// Last Updated:       02/13/2024
        /// What Was Changed:   Initial Creation
        /// </summary>
        private void btnCreateSchedule_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int rows = 0;
                ScheduleVM vm = new ScheduleVM();
                vm.ScheduleMonth = cboScheduleMonth.Text;
                if (vm.ScheduleMonth.Length == 0)
                {
                    throw new Exception("Month must be selected.");
                }
                string weekNumber = cboScheduleWeek.Text.Replace("Week ", "");
                if (weekNumber.Length == 0)
                {
                    throw new Exception("Week must be selected.");
                }
                vm.ScheduleWeek = Convert.ToInt32(weekNumber);
                if (cboScheduleYear.Text.Length == 0)
                {
                    throw new Exception("Year must be selected.");
                }
                vm.ScheduleYear = Convert.ToInt32(cboScheduleYear.Text);
                bool scheduleExists = scheduleManager.ScheduleExists(vm.ScheduleMonth, vm.ScheduleWeek, vm.ScheduleYear);
                if (scheduleExists)
                {
                    throw new Exception("Sorry, that schedule already exists.");
                }
                try
                {
                    vm.ScheduleStartDate = DateTime.Parse(dateScheduleStartDate.SelectedDate.ToString());
                    vm.ScheduleEndDate = DateTime.Parse(dateScheduleEndDate.SelectedDate.ToString());
                }
                catch
                {
                    throw new Exception("Don't recognize those dates.  Please try again.");
                }
                if (getMonth(vm.ScheduleMonth) != vm.ScheduleStartDate.Month)
                {
                    throw new Exception("Schedule must start in the month specified");
                }
                if (vm.ScheduleYear != vm.ScheduleEndDate.Year)
                {
                    throw new Exception("Schedule must be in the year specified");
                }
                if (vm.ScheduleEndDate <= vm.ScheduleStartDate)
                {
                    throw new Exception("The end date must be later than the start date.");
                }
                rows = scheduleManager.CreateSchedule(vm.ScheduleMonth, vm.ScheduleWeek, vm.ScheduleYear, vm.ScheduleStartDate, vm.ScheduleEndDate);
                if (rows != 0)
                {
                    MessageBox.Show("Schedule successfully created.");
                }
                else
                {
                    MessageBox.Show("There was an issue.  Please check your inputs and try again.");
                }
                cboScheduleMonth.SelectedItem = null;
                cboScheduleWeek.SelectedItem = null;
                cboScheduleYear.SelectedItem = null;

                NavigationService.Navigate(PgShelterDashboard.GetPgShelterDashboard());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Creator:            Ethan McElree
        /// Created:            04/22/2024
        /// Summary:            Helper method to get the month number.
        /// Last Updated By:    Ethan McElree
        /// Last Updated:       04/22/2024
        /// What Was Changed:   Initial Creation
        /// </summary>
        public int getMonth(string MonthName)
        {
            int month = 0;
            switch (MonthName)
            {
                case "January":
                    month = 1;
                    break;
                case "February":
                    month = 2;
                    break;
                case "March":
                    month = 3;
                    break;
                case "April":
                    month = 4;
                    break;
                case "May":
                    month = 5;
                    break;
                case "June":
                    month = 6;
                    break;
                case "July":
                    month = 7;
                    break;
                case "August":
                    month = 8;
                    break;
                case "September":
                    month = 9;
                    break;
                case "October":
                    month = 10;
                    break;
                case "November":
                    month = 11;
                    break;
                case "December":
                    month = 12;
                    break;
            }
            return month;
        }

        /// <summary>
        /// Creator: Ethan McElree
        /// Created: 02/15/2024
        /// Summary: Logic for navigation in the pgCreateSchedule file.
        /// Last Updated By: Ethan McElree
        /// Last Updated: 02/15/2024
        /// What Was Changed: Initial Creation
        /// </summary>
        private static pgCreateSchedule instance = null;
        public static pgCreateSchedule GetpgCreateSchedule()
        {
            return instance ?? (instance = new pgCreateSchedule());
        }
    }
}
