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

namespace WpfPresentation.UtilWindows {
    /// <summary>
    /// Interaction logic for EditShift.xaml
    /// </summary>
    public partial class EditShift : Window {
        private MainManager _manager = null;
        private Regex _numericalRegex = new Regex("[^0-9]+");
        private List<Employee> _employees = new List<Employee>();
        ShiftVM _shift;
        int _departmentID;

        /// <summary>
        /// Creator:            Jared Harvey
        /// Created:            02/15/2024
        /// Summary:            Creation of EditShift Window
        /// Last Updated By:    Jared Harvey
        /// Last Updated:       02/15/2024
        /// What Was Changed:   Creation of EditShift Window
        /// </summary>
        public EditShift(ShiftVM shift, int departmentID) {
            _manager = MainManager.GetMainManager();
            _shift = shift;
            _departmentID = departmentID;
            InitializeComponent();
        }

        /// <summary>
        /// Creator:            Liam Easton
        /// Created:            02/13/2024
        /// Summary:            Creation of Window_Loaded method
        /// Last Updated By:    Jared Harvey
        /// Last Updated:       02/13/2024
        /// What Was Changed:   Changed code a little for edit shift instead of add
        /// </summary>
        private void Window_Loaded(object sender, RoutedEventArgs e) {
            List<string> AMPM = new List<string>();
            AMPM.Add("AM");
            AMPM.Add("PM");
            cboxStartAMPM.ItemsSource = AMPM;
            cboxEndAMPM.ItemsSource = AMPM;
            try {
                _employees = _manager.UserManager.GetDepartmentEmployees(_departmentID);
                dtpShiftDate.SelectedDate = _shift.StartTime.Date;
                FormatDates();
            } catch (Exception ex) {
                MessageBox.Show("Unable to retrieve list of employees.", ex.Message);
                return;
            }
            try {
                cbxDepartmentEmployees.ItemsSource = _employees;
                cbxDepartmentEmployees.SelectedIndex = _employees.FindIndex(x => x.EmployeeID == _shift.EmployeeID);
            } catch (Exception ex) {
                MessageBox.Show(ex.Message + "\n\n" + ex.InnerException.Message, "Unable to find shelter's departments",
                MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
        }

        /// <summary>
        /// Creator: Jared Harvey
        /// Created: 02/16/2024
        /// Summary: This helper method formats the dates from the inputed shift
        /// Last Updated By: Jared Harvey
        /// Last Updated: 02/16/2024
        /// What Was Changed: Initial Creation
        /// </summary>
        private void FormatDates() {
            txtShiftStartHour.Text = _shift.StartTime.ToString("hh");
            txtShiftStartMinute.Text = _shift.StartTime.ToString("mm");
            cboxStartAMPM.SelectedIndex = (_shift.StartTime.Hour > 11) ? 1 : 0;

            txtShiftEndHour.Text = _shift.EndTime.ToString("hh");
            txtShiftEndMinute.Text = _shift.EndTime.ToString("mm");
            cboxEndAMPM.SelectedIndex = (_shift.EndTime.Hour > 11) ? 1 : 0;
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
        private void txtShiftStartHour_PreviewTextInput(object sender, TextCompositionEventArgs e) {
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
        private void txtShiftStartMinute_PreviewTextInput(object sender, TextCompositionEventArgs e) {
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
        private void txtShiftEndHour_PreviewTextInput(object sender, TextCompositionEventArgs e) {
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
        private void txtShiftEndMinute_PreviewTextInput(object sender, TextCompositionEventArgs e) {
            e.Handled = _numericalRegex.IsMatch(e.Text);
        }
        #endregion

        /// <summary>
        /// Creator:            Liam Easton
        /// Created:            02/14/2024
        /// Summary:            Creation of btnSubmitShift_Click method
        /// Last Updated By:    Jared Harvey
        /// Last Updated:       02/14/2024
        /// What Was Changed:   Changed code a little for edit shift instead of add
        /// </summary>
        private void btnSubmitShift_Click(object sender, RoutedEventArgs e) {
            if (
               !txtShiftStartHour.Text.Equals("")
               && !txtShiftStartMinute.Text.Equals("")
               && !txtShiftEndHour.Text.Equals("")
               && !txtShiftEndMinute.Text.Equals("")) {
                int startHour = int.Parse(txtShiftStartHour.Text);
                int startMinute = int.Parse(txtShiftStartMinute.Text);
                int endHour = int.Parse(txtShiftEndHour.Text);
                int endMinute = int.Parse(txtShiftEndMinute.Text);

                if (!startHour.IsValidHour()) {
                    MessageBox.Show("That is not a valid hour", "Invalid Hour",
                    MessageBoxButton.OK, MessageBoxImage.Error);
                    txtShiftStartHour.Text.Equals("");
                    txtShiftStartHour.Focus();
                    return;
                }
                if (!startMinute.IsValidMinute()) {
                    MessageBox.Show("That is not a valid input for minutes", "Invalid Minutes",
                    MessageBoxButton.OK, MessageBoxImage.Error);
                    txtShiftEndMinute.Text.Equals("");
                    txtShiftEndMinute.Focus();
                    return;
                }
                if (!endHour.IsValidHour()) {
                    MessageBox.Show("That is not a valid hour", "Invalid Hour",
                    MessageBoxButton.OK, MessageBoxImage.Error);
                    txtShiftEndHour.Text.Equals("");
                    txtShiftStartHour.Focus();
                    return;
                }
                if (!endMinute.IsValidMinute()) {
                    MessageBox.Show("That is not a valid input for minutes", "Invalid Minutes",
                    MessageBoxButton.OK, MessageBoxImage.Error);
                    txtShiftEndMinute.Text.Equals("");
                    txtShiftEndMinute.Focus();
                    return;
                }

                DateTime? selectedDate = dtpShiftDate.SelectedDate;
                if (selectedDate.HasValue) {
                    Employee employee = (Employee)cbxDepartmentEmployees.SelectedItem;
                    DateTime startShiftTime = DateTime.Parse(selectedDate.Value.ToShortDateString() + " " + startHour.ToString() + ":" + startMinute.ToString() + " " + cboxStartAMPM.SelectedItem.ToString());
                    DateTime endShiftTime = DateTime.Parse(selectedDate.Value.ToShortDateString() + " " + endHour.ToString() + ":" + endMinute.ToString() + " " + cboxEndAMPM.SelectedItem.ToString());
                    if (startShiftTime < endShiftTime) {
                        var newShift = new Shift() {
                            EmployeeID = employee.EmployeeID,
                            StartTime = startShiftTime,
                            EndTime = endShiftTime
                        };

                        try {
                            if (_manager.ShiftManager.EditShift(_shift, newShift)) {
                                DialogResult = true;
                            } else {
                                MessageBox.Show("Failed to edit shift");
                            }
                        } catch (Exception ex) {
                            MessageBox.Show(ex.Message + "\n\n" + ex.Message, "Unable to edit shift.",
                            MessageBoxButton.OK, MessageBoxImage.Error);
                            return;
                        }
                    } else {
                        MessageBox.Show("Start of shift must be before the end of shift", "Invalid start or end of shift");
                    }
                } else {
                    MessageBox.Show("You must select a date", "Invalid date");
                }
            }
        }

        /// <summary>
        /// Creator:            Jared Harvey
        /// Created:            02/16/2024
        /// Summary:            Creation of btnCancel_Click
        /// Last Updated By:    Jared Harvey
        /// Last Updated:       02/16/2024
        /// What Was Changed:   Initial Creation
        /// </summary>
        private void btnCancel_Click(object sender, RoutedEventArgs e) {
            this.Close();
        }
    }
}