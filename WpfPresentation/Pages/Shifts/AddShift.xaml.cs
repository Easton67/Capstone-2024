using DataObjects;
using LogicLayer;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WpfPresentation.Custom_Controls;
using static System.Net.Mime.MediaTypeNames;

namespace WpfPresentation.Pages.Shifts
{
    /// <summary>
    /// Interaction logic for AddShift.xaml
    /// </summary>
    public partial class AddShift : Window
    {
        private MainManager _mainManager = null;
        private Regex _numericalRegex = new Regex("[^0-9]+");
        private MainManager _manager = MainManager.GetMainManager();
        private List<Employee> _employees = new List<Employee>();
        private string _selectedEmployee;

        /// <summary>
        /// Creator:            Liam Easton
        /// Created:            02/13/2024
        /// Summary:            Creation of AddShift Window
        /// Last Updated By:    Liam Easton
        /// Last Updated:       02/13/2024
        /// What Was Changed:   Creation of AddShift Window
        /// </summary>
        public AddShift()
        {
            InitializeComponent();
            _mainManager = MainManager.GetMainManager();
        }

        /// <summary>
        /// Creator:            Liam Easton
        /// Created:            02/13/2024
        /// Summary:            Creation of Window_Loaded method
        /// Last Updated By:    Tyler Barz
        /// Last Updated:       04/12/2024
        /// What Was Changed:   Added lambdas to filter
        /// </summary>
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            List<string> AMPM = new List<string>();
            AMPM.Add("AM");
            AMPM.Add("PM");
            cboxStartAMPM.ItemsSource = AMPM;
            cboxEndAMPM.ItemsSource = AMPM;
            try
            {
                lbFilteredEmployees.Visibility = Visibility.Collapsed;
                _employees = _manager.UserManager.SelectAllEmployeesWithRoles()
                    .FindAll(r => r.RoleDisplay.Contains("Housekeeping Staff"));
                lbFilteredEmployees.ItemsSource = _employees;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to retrieve list of employees.", ex.Message);
                return;
            }
        }

        #region Sanitizing Text Inputs

        /// <summary>
        /// Creator:            Liam Easton
        /// Created:            02/13/2024
        /// Summary:            Creation of txtShiftStartHour_PreviewTextInput method
        /// Last Updated By:    Liam Easton
        /// Last Updated:       02/13/2024
        /// What Was Changed:   Creation of txtShiftStartHour_PreviewTextInput method
        /// </summary>
        private void txtShiftStartHour_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = _numericalRegex.IsMatch(e.Text);
        }

        /// <summary>
        /// Creator:            Liam Easton
        /// Created:            02/13/2024
        /// Summary:            Creation of txtShiftStartMinute_PreviewTextInput method
        /// Last Updated By:    Liam Easton
        /// Last Updated:       02/13/2024
        /// What Was Changed:   Creation of txtShiftStartMinute_PreviewTextInput method
        /// </summary>
        private void txtShiftStartMinute_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = _numericalRegex.IsMatch(e.Text);
        }

        /// <summary>
        /// Creator:            Liam Easton
        /// Created:            02/13/2024
        /// Summary:            Creation of txtShiftEndHour_PreviewTextInput method
        /// Last Updated By:    Liam Easton
        /// Last Updated:       02/13/2024
        /// What Was Changed:   Creation of txtShiftEndHour_PreviewTextInput method
        /// </summary>
        private void txtShiftEndHour_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = _numericalRegex.IsMatch(e.Text);
        }

        /// <summary>
        /// Creator:            Liam Easton
        /// Created:            02/13/2024
        /// Summary:            Creation of txtShiftEndMinute_PreviewTextInput method
        /// Last Updated By:    Liam Easton
        /// Last Updated:       02/13/2024
        /// What Was Changed:   Creation of txtShiftEndMinute_PreviewTextInput method
        /// </summary>
        private void txtShiftEndMinute_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = _numericalRegex.IsMatch(e.Text);
        }
        #endregion

        #region Search methods
        /// <summary>
        /// Creator:            Liam Easton
        /// Created:            02/13/2024
        /// Summary:            Creation of txtSearch_GotFocus method
        /// Last Updated By:    Liam Easton
        /// Last Updated:       02/13/2024
        /// What Was Changed:   Creation of txtSearch_GotFocus method
        /// </summary>
        private void txtSearch_GotFocus(object sender, RoutedEventArgs e)
        {
            if (txtSearch.Text.Replace(" ", "").Equals("Search"))
            {
                txtSearch.Text = "";
                lbFilteredEmployees.Visibility = Visibility.Visible;
            }
        }
        /// <summary>
        /// Creator:            Liam Easton
        /// Created:            02/13/2024
        /// Summary:            Creation of txtSearch_LostFocus method
        /// Last Updated By:    Liam Easton
        /// Last Updated:       02/13/2024
        /// What Was Changed:   Creation of txtSearch_LostFocus method
        /// </summary>
        private void txtSearch_LostFocus(object sender, RoutedEventArgs e)
        {
            if (txtSearch.Text.Equals(""))
            {
                txtSearch.Text = "Search";
                lbFilteredEmployees.Visibility = Visibility.Collapsed;
            }
        }
        /// <summary>
        /// Creator:            Liam Easton
        /// Created:            02/14/2024
        /// Summary:            Creation of txtSearch_TextChanged method
        /// Last Updated By:    Liam Easton
        /// Last Updated:       02/14/2024
        /// What Was Changed:   Creation of txtSearch_TextChanged method
        /// </summary>
        private void txtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtSearch.Text.Equals(""))
            {
                lbFilteredEmployees.Visibility = Visibility.Visible;
            }
            if (txtSearch.Text != "Search")
            {
                List<string> filteredEmployees = new List<string>();
                filteredEmployees = _employees.Where(x => x.EmployeeID.ToLower().Contains(txtSearch.Text.ToLower())).Select(x => x.EmployeeID).ToList();
                lbFilteredEmployees.ItemsSource = filteredEmployees;
            }
        }
        #endregion

        private static AddShift instance = null;
        public static AddShift addShift()
        {
            return instance ?? (instance = new AddShift());
        }

        /// <summary>
        /// Creator:            Liam Easton
        /// Created:            02/14/2024
        /// Summary:            Creation of lbFilteredEmployees_SelectionChanged method
        /// Last Updated By:    Liam Easton
        /// Last Updated:       02/14/2024
        /// What Was Changed:   Creation of lbFilteredEmployees_SelectionChanged method
        /// </summary>
        private void lbFilteredEmployees_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lbFilteredEmployees.SelectedItem != null)
            {
                _selectedEmployee = lbFilteredEmployees.SelectedItem.ToString();
                txtSearch.Text = _selectedEmployee;
                lbFilteredEmployees.Visibility = Visibility.Collapsed;
            }
        }

        /// <summary>
        /// Creator:            Liam Easton
        /// Created:            02/14/2024
        /// Summary:            Creation of btnSubmitShift_Click method
        /// Last Updated By:    Liam Easton
        /// Last Updated:       02/14/2024
        /// What Was Changed:   Creation of btnSubmitShift_Click method
        /// </summary>
        private void btnSubmitShift_Click(object sender, RoutedEventArgs e)
        {
            if (!txtSearch.Text.Equals("")
               && !txtShiftStartHour.Text.Equals("")
               && !txtShiftStartMinute.Text.Equals("")
               && !txtShiftEndHour.Text.Equals("")
               && !txtShiftEndMinute.Text.Equals(""))
            {
                int startHour = int.Parse(txtShiftStartHour.Text);
                int startMinute = int.Parse(txtShiftStartMinute.Text);
                int endHour = int.Parse(txtShiftEndHour.Text);
                int endMinute = int.Parse(txtShiftEndMinute.Text);

                if (!startHour.IsValidHour())
                {
                    MessageBox.Show("That is not a valid hour", "Invalid Hour",
                    MessageBoxButton.OK, MessageBoxImage.Error);
                    txtShiftStartHour.Text = "";
                    txtShiftStartHour.Focus();
                    return;
                }
                if (!startMinute.IsValidMinute())
                {
                    MessageBox.Show("That is not a valid input for minutes", "Invalid Minutes",
                    MessageBoxButton.OK, MessageBoxImage.Error);
                    txtShiftEndMinute.Text = "";
                    txtShiftEndMinute.Focus();
                    return;
                }
                if (!endHour.IsValidHour())
                {
                    MessageBox.Show("That is not a valid hour", "Invalid Hour",
                    MessageBoxButton.OK, MessageBoxImage.Error);
                    txtShiftEndHour.Text = "";
                    txtShiftStartHour.Focus();
                    return;
                }
                if (!endMinute.IsValidMinute())
                {
                    MessageBox.Show("That is not a valid input for minutes", "Invalid Minutes",
                    MessageBoxButton.OK, MessageBoxImage.Error);
                    txtShiftEndMinute.Text = "";
                    txtShiftEndMinute.Focus();
                    return;
                }

                DateTime? selectedDate = dtpShiftDate.SelectedDate; 
                if (selectedDate.HasValue)
                {
                    DateTime startShiftTime = DateTime.Parse(selectedDate.Value.ToShortDateString() + " " + startHour.ToString() + ":" + startMinute.ToString() + " " + cboxStartAMPM.SelectedItem.ToString());
                    DateTime endShiftTime = DateTime.Parse(selectedDate.Value.ToShortDateString() + " " + endHour.ToString() + ":" + endMinute.ToString() + " " + cboxEndAMPM.SelectedItem.ToString());

                    if (startShiftTime < endShiftTime)
                    {
                        var newShift = new Shift()
                        {
                            EmployeeID = _selectedEmployee,
                            StartTime = startShiftTime,
                            EndTime = endShiftTime
                        };

                        try
                        {
                            bool shiftAlreadyExists = _manager.ShiftManager.SelectAllShftsFromEmployeeID(newShift.EmployeeID).Any(x => x.StartTime == newShift.StartTime && x.EndTime == newShift.EndTime);

                            if (shiftAlreadyExists)
                            {
                                MessageBox.Show($"{_selectedEmployee} already has a shift scheduled for that time.", "Unable to add shift");
                                return;
                            }
                            else
                            {
                                _manager.ShiftManager.AddEmployeeShift(newShift);
                                MessageBox.Show($"Shift added successfully for {newShift.EmployeeID}");
                                _mainManager.messageManager.SendEmail(newShift.EmployeeID, "New Shift Added", 
                                                                      $"A new shift has been added for {newShift.StartTime.ToShortDateString()} from \n " +
                                                                      $"{newShift.StartTime.ToString("hh:mm tt")} to {newShift.EndTime.ToString("hh:mm tt")}");
                                txtShiftStartHour.Text = "";
                                txtShiftStartMinute.Text = "";
                                txtShiftEndHour.Text = "";
                                txtShiftEndMinute.Text = "";
                                txtSearch.Clear();
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message + "\n\n" + ex.InnerException.Message, "Unable to add shifts.",
                            MessageBoxButton.OK, MessageBoxImage.Error);
                            return;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Start of shift must be before the end of shift", "Invalid start or end of shift");
                    }
                }
            }
        }

        /// <summary>
        /// Creator:            Liam Easton
        /// Created:            02/15/2024
        /// Summary:            Creation of btnCancel_Click method
        /// Last Updated By:    Liam Easton
        /// Last Updated:       02/15/2024
        /// What Was Changed:   Creation of btnCancel_Click method
        /// </summary>
        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
