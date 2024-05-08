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
using System.Windows.Shapes;

namespace WpfPresentation
{
    /// <summary>
    /// Interaction logic for CalendarPopupWindow.xaml
    /// </summary>
    public partial class CalendarPopupWindow : Window
    {
        public DateTime _date;
        public CalendarPopupWindow(DateTime date)
        {
            InitializeComponent();
            _date = date;
            labelCalendarDate.Content = date.ToShortDateString();
            calendar.SelectedDate = date;
            calendar.DisplayDate = date;
        }

        /// <summary>
        /// Creator: Matthew Baccam
        /// Created: 02/15/2024
        /// Summary: Selects the current date selected and assigns it to the _date var
        /// Last Updated By: Matthew Baccam
        /// Last Updated: 02/15/2024
        /// What Was changed: Initial creation
        /// </summary>
        private void calendar_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (DateTime.TryParse(calendar.SelectedDate.ToString(), out DateTime result))
            {
                _date = DateTime.Parse(calendar.SelectedDate.ToString());
                labelCalendarDate.Content = _date.ToShortDateString();
            }
        }

        /// <summary>
        /// Creator: Matthew Baccam
        /// Created: 02/15/2024
        /// Summary: Closes the window 
        /// Last Updated By: Matthew Baccam
        /// Last Updated: 02/15/2024
        /// What Was changed: Initial creation
        /// </summary>
        private void buttonCalendarDiscard_Click(object sender, RoutedEventArgs e)
        {
            var userChoice = MessageBox.Show("Are you sure you want to discard the current changes", "Cancel confirmation", MessageBoxButton.OKCancel, MessageBoxImage.Question);
            if (userChoice == MessageBoxResult.OK)
            {
                this.DialogResult = false;
                this.Close();
            }
        }

        /// <summary>
        /// Creator: Matthew Baccam
        /// Created: 02/15/2024
        /// Summary: Saves the selected date
        /// Last Updated By: Matthew Baccam
        /// Last Updated: 02/15/2024
        /// What Was changed: Initial creation
        /// </summary>
        private void buttonCalendarSave_Click(object sender, RoutedEventArgs e)
        {
            var userChoice = MessageBox.Show("Are you sure you want to save the current changes", "Save confirmation", MessageBoxButton.OKCancel, MessageBoxImage.Question);
            if (userChoice == MessageBoxResult.OK)
            {
                this.DialogResult = true;
                this.Close();
            }
        }
    }
}
