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

namespace WpfPresentation.Custom_Controls {
    /// <summary>
    /// Creator: Jared Harvey
    /// Created: 02/07/2024
    /// Summary: This class is the logic behind the WeekSelector custom control
    /// Last Updated By: Jared Harvey
    /// Last Updated: 02/07/2024
    /// What Was Changed: Initial Creation
    /// </summary>
    public partial class WeekSelector : UserControl {
        public DateTime today;
        public DateTime thisWeekStart;
        public DateTime thisWeekEnd;
        public WeekSelector() {
            today = DateTime.Today;
            thisWeekStart = today.AddDays(-(int)today.DayOfWeek);
            thisWeekEnd = thisWeekStart.AddDays(7).AddSeconds(-1);

            InitializeComponent();
            UpdateWeekRangeLabel();
        }

        private void UpdateWeekRangeLabel() {
            // Displays date range for week
            lblWeekRange.Content = thisWeekStart.Date.ToShortDateString() + " / " + thisWeekEnd.Date.ToShortDateString();
        }

        private void btnRight_Click(object sender, RoutedEventArgs e) {
            thisWeekStart = thisWeekStart.AddDays(7).AddSeconds(1);
            thisWeekEnd = thisWeekEnd.AddDays(7).AddSeconds(-1);
            UpdateWeekRangeLabel();
        }

        private void btnLeft_Click(object sender, RoutedEventArgs e) {
            thisWeekStart = thisWeekStart.AddDays(-7).AddSeconds(1);
            thisWeekEnd = thisWeekEnd.AddDays(-7).AddSeconds(-1);
            UpdateWeekRangeLabel();
        }
    }
}
