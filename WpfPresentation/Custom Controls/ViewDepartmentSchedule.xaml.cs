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
using WpfPresentation.Pages.Housekeeping;
using WpfPresentation.Pages.Shifts;

namespace WpfPresentation.Custom_Controls {
    /// <summary>
    /// Creator: Jared Harvey
    /// Created: 02/16/2024
    /// Summary: ViewDepartmentSchedule allows one to view a department schedule.
    /// Last Updated By: Jared Harvey
    /// Last Updated: 02/16/2024
    /// What Was Changed: Initial Creation
    /// </summary>
    public partial class ViewDepartmentSchedule : UserControl {
        private MainManager _manager = MainManager.GetMainManager(); 

        private DateTime today;
        private DateTime thisWeekStart;
        private DateTime thisWeekEnd;
        private int departmentID;
		private List<ShiftVM> shifts = null;

        /// <summary>
        /// Creator: Jared Harvey
        /// Created: 02/16/2024
        /// Summary: Constructor for admin/higher up manager to view all department shifts.
        /// Last Updated By: Jared Harvey
        /// Last Updated: 02/16/2024
        /// What Was Changed: Initial Creation
        /// </summary>
        public ViewDepartmentSchedule() {
            today = DateTime.Today;
            thisWeekStart = today.AddDays(-(int)today.DayOfWeek);
            thisWeekEnd = thisWeekStart.AddDays(7).AddSeconds(-1);

            InitializeComponent();
            UpdateWeekRangeLabel();
            try {
                cbDepartmentSelector.ItemsSource = _manager.DepartmentManager.GetShelterDepartments("Test Homeless Shelter");
                cbDepartmentSelector.SelectedIndex = 0;
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Creator: Jared Harvey
        /// Created: 02/16/2024
        /// Summary: Gets week start and end based on the day and disables dropdown 
        /// for department if a departmentID is passed to it.
        /// Last Updated By: Jared Harvey
        /// Last Updated: 02/16/2024
        /// What Was Changed: Initial Creation
        /// </summary>
        public ViewDepartmentSchedule(int departmentID) {
            today = DateTime.Today;
            thisWeekStart = today.AddDays(-(int)today.DayOfWeek);
            thisWeekEnd = thisWeekStart.AddDays(7).AddSeconds(-1);
            this.departmentID = departmentID;

            InitializeComponent();
            UpdateWeekRangeLabel();
            cbDepartmentSelector.Visibility = Visibility.Collapsed;
            lblDepartment.Visibility = Visibility.Collapsed;
        }

        private static ViewDepartmentSchedule viewDepartmentSchedule = null;

        public static ViewDepartmentSchedule GetViewDepartmentSchedule()
        {
            return viewDepartmentSchedule ?? (viewDepartmentSchedule = new ViewDepartmentSchedule());
        }
        
        public static ViewDepartmentSchedule GetViewDepartmentSchedule(int departmentID) {
            return viewDepartmentSchedule ?? (viewDepartmentSchedule = new ViewDepartmentSchedule(departmentID));
        }

        /// <summary>
        /// Creator: Jared Harvey
        /// Created: 02/16/2024
        /// Summary: Populates ItemsControls
        /// Last Updated By: Jared Harvey
        /// Last Updated: 02/16/2024
        /// What Was Changed: Initial Creation
        /// </summary>
        public void PopulateItemsControls(int departmentID) {
            ClearItems();
            try
            {
                shifts = _manager.ShiftManager.GetShiftsByDepartment(departmentID);
            }
            catch
            {
                return;
            }
            shifts = shifts.Where(x => x.StartTime >= thisWeekStart && x.StartTime <= thisWeekEnd).ToList();
            foreach (ShiftVM shift in shifts) {
                switch (shift.StartTime.DayOfWeek) {
                    case DayOfWeek.Sunday:
                        icSunday.Items.Add(new ShiftListItem(shift, departmentID));
                        break;
                    case DayOfWeek.Monday:
                        icMonday.Items.Add(new ShiftListItem(shift, departmentID));
                        break;
                    case DayOfWeek.Tuesday:
                        icTuesday.Items.Add(new ShiftListItem(shift, departmentID));
                        break;
                    case DayOfWeek.Wednesday:
                        icWednesday.Items.Add(new ShiftListItem(shift, departmentID));
                        break;
                    case DayOfWeek.Thursday:
                        icThursday.Items.Add(new ShiftListItem(shift, departmentID));
                        break;
                    case DayOfWeek.Friday:
                        icFriday.Items.Add(new ShiftListItem(shift, departmentID));
                        break;
                    case DayOfWeek.Saturday:
                        icSaturday.Items.Add(new ShiftListItem(shift, departmentID));
                        break;
                }
            }
        }

        /// <summary>
        /// Creator: Jared Harvey
        /// Created: 02/16/2024
        /// Summary: Clears all Items out of each ItemsControl
        /// Last Updated By: Jared Harvey
        /// Last Updated: 02/16/2024
        /// What Was Changed: Initial Creation
        /// </summary>
        private void ClearItems() {
            icSunday.Items.Clear();
            icMonday.Items.Clear();
            icTuesday.Items.Clear();
            icWednesday.Items.Clear();
            icThursday.Items.Clear();
            icFriday.Items.Clear();
            icSaturday.Items.Clear();
        }

        /// <summary>
        /// Creator: Jared Harvey
        /// Created: 02/16/2024
        /// Summary: Updates stuff when selection is changed on combobox
        /// Last Updated By: Jared Harvey
        /// Last Updated: 02/16/2024
        /// What Was Changed: Initial Creation
        /// </summary>
        private void cbDepartmentSelector_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            //Department selected = (Department)cbDepartmentSelector.SelectedItem;
            //departmentID = selected.DepartmentID;
            //PopulateItemsControls(departmentID);
        }

        /// <summary>
        /// Creator: Jared Harvey
        /// Created: 02/16/2024
        /// Summary: Updates groupbox titles to match the date
        /// Last Updated By: Jared Harvey
        /// Last Updated: 02/16/2024
        /// What Was Changed: Initial Creation
        /// </summary>
        private void UpdateWeekRangeLabel() {
            // Displays date range for week
            lblWeekRange.Content = thisWeekStart.Date.ToShortDateString() + " / " + thisWeekEnd.Date.ToShortDateString();
            PopulateItemsControls(departmentID);

            //Update Column Names
            //gbSunday.Header = $"Sunday - {thisWeekStart.Date.ToShortDateString()}";

            gbSunday.Header = "Sunday" + "\n" + thisWeekStart.Date.ToShortDateString();
            gbMonday.Header = "Monday" + "\n" + thisWeekStart.AddDays(1).Date.ToShortDateString();
            gbTuesday.Header = "Tuesday" + "\n" + thisWeekStart.AddDays(2).Date.ToShortDateString();
            gbWednesday.Header = "Wednesday" + "\n" + thisWeekStart.AddDays(3).Date.ToShortDateString();
            gbThursday.Header = "Thursday" + "\n" + thisWeekStart.AddDays(4).Date.ToShortDateString();
            gbFriday.Header = "Friday" + "\n" + thisWeekStart.AddDays(5).Date.ToShortDateString();
            gbSaturday.Header = "Saturday" + "\n" + thisWeekStart.AddDays(6).Date.ToShortDateString();
        }

        /// <summary>
        /// Creator: Jared Harvey
        /// Created: 02/16/2024
        /// Summary: Shifts week calendar to the right.
        /// Last Updated By: Jared Harvey
        /// Last Updated: 02/16/2024
        /// What Was Changed: Initial Creation
        /// </summary>
        private void btnRight_Click(object sender, RoutedEventArgs e) {
            thisWeekStart = thisWeekStart.AddDays(7).AddSeconds(1);
            thisWeekEnd = thisWeekEnd.AddDays(7).AddSeconds(-1);
            UpdateWeekRangeLabel();
        }

        /// <summary>
        /// Creator: Jared Harvey
        /// Created: 02/16/2024
        /// Summary: Shifts week calendar to the left
        /// Last Updated By: Jared Harvey
        /// Last Updated: 02/16/2024
        /// What Was Changed: Initial Creation
        /// </summary>
        private void btnLeft_Click(object sender, RoutedEventArgs e) {
            thisWeekStart = thisWeekStart.AddDays(-7).AddSeconds(1);
            thisWeekEnd = thisWeekEnd.AddDays(-7).AddSeconds(-1);
            UpdateWeekRangeLabel();
        }

        /// <summary>
        /// Creator: Jared Harvey
        /// Created: 02/16/2024
        /// Summary: Calls subsequent method when keypress happens.
        /// Last Updated By: Jared Harvey
        /// Last Updated: 02/16/2024
        /// What Was Changed: Initial Creation
        /// </summary>
        private void UserControl_KeyDown(object sender, KeyEventArgs e) {
            if(e.Key == Key.Left) {
                btnLeft_Click(sender, e);
            }
            if (e.Key == Key.Right) {
                btnRight_Click(sender, e);
            }
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e) {
            this.Focus();
        }

        /// <summary>
        /// Creator: Liam Easton
        /// Created: 02/15/2024
        /// Summary: Creation of the btnAddShifts_Click method
        /// Last Updated By: Liam Easton
        /// Last Updated: 02/28/2024
        /// What Was Changed: Added the ability to refresh after adding a shift
        /// </summary>
        private void btnAddShifts_Click(object sender, RoutedEventArgs e)
        { 
            var addShift = new AddShift();
            addShift.ShowDialog();
            ScheduleRefresh();
        }


        /// <summary>
        /// Creator: Liam Easton
        /// Created: 02/28/2024
        /// Summary: Creation of the ScheduleRefresh helper method.
        /// Last Updated By: Liam Easton
        /// Last Updated: 02/28/2024
        /// What Was Changed: initial creation
        /// </summary>
        public void ScheduleRefresh()
        {
            PopulateItemsControls(departmentID);
        }
    }
}
