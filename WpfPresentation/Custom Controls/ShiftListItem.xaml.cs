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
using WpfPresentation.UtilWindows;
using WpfPresentation.Pages.Shifts;

namespace WpfPresentation.Custom_Controls {
    /// <summary>
    /// Interaction logic for ShiftListItem.xaml
    /// </summary>
    public partial class ShiftListItem : UserControl {
		private MainManager _manager;
        private ShiftVM _shift;
        private int _departmentID;
        public ShiftListItem(ShiftVM shift, int departmentID) {
            InitializeComponent();
			_manager = MainManager.GetMainManager();
            _shift = shift;
            _departmentID = departmentID;
            Init();
        }

        public ShiftListItem()
        {
            InitializeComponent();
        }
        private void Init() {
            txtEmployeeName.Text = _shift.EmployeeName;
            txtShiftDuration.Text = _shift.ShiftDuration;
        }
		
		/// <summary>
        /// Creator: Liam Easton
        /// Created: 02/22/2024
        /// Summary: Creation of the mnuAddShift_Click event
        /// Last Updated By: Liam Easton
        /// Last Updated: 02/22/2024
        /// What Was Changed: Creation of the mnuAddShift_Click event
        /// </summary>
        private void mnuAddShift_Click(object sender, RoutedEventArgs e)
        {
            new AddShift().ShowDialog();
        }

        /// <summary>
        /// Creator: Jared Harvey
        /// Created: 02/16/2024
        /// Summary: Creates a new EditShift window and gets the result from it
        /// Last Updated By: Jared Harvey
        /// Last Updated: 02/16/2024
        /// What Was Changed: Initial Creation
        /// </summary>
        private void mnuEditShift_Click(object sender, RoutedEventArgs e) {
            EditShift editShift = new EditShift(_shift, _departmentID);
            bool? result = editShift.ShowDialog();
            if (result == true) {
                (ViewDepartmentSchedule.GetViewDepartmentSchedule()).PopulateItemsControls(_departmentID);
                MessageBox.Show("Shift was edited successfully");
            }
        }
		
		/// <summary>
        /// Creator: Liam Easton
        /// Created: 02/22/2024
        /// Summary: Creation of the mnuRemoveShift_Click event
        /// Last Updated By: Liam Easton
        /// Last Updated: 02/22/2024
        /// What Was Changed: Creation of the mnuRemoveShift_Click event
        /// </summary>
        private void mnuRemoveShift_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show(
            $"Are you sure you want to delete this shift?",
            "Confirmation",
            MessageBoxButton.YesNo,
            MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                try
                {
                    int selectedShiftID = _shift.ShiftID;
                    _manager.ShiftManager.RemoveShift(selectedShiftID);
                    MessageBox.Show("Shift successfully removed", "Success!");
                    (ViewDepartmentSchedule.GetViewDepartmentSchedule()).PopulateItemsControls(_departmentID);
                    //_manager.messageManager.SendEmail($"{selectedShift.EmployeeID}", "New Shift Notification", $"Your shift on {selectedShift.StartTime.ToShortDateString()} has been removed");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message + "\n\n" + ex.InnerException.Message, "Could not delete this shift. Please try again",
                    MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
            }
        }
    }
}
