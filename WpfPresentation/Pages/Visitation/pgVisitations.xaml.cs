using DataObjects;
using LogicLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Shell;
using WpfPresentation.Pages.Visitation;
using WpfPresentation.UtilWindows.AdminUtilWindows;

namespace WpfPresentation
{
    /// <summary>
    /// Creator: Matthew Baccam
    /// Created: 02/15/2024
    /// Summary: Initial Creation.
    /// Last Updated By: Matthew Baccam
    /// Last Updated: 02/15/2024
    /// What Was changed: Initial creation
    /// </summary>
    public partial class pgVisitations : Page
    {
        private MainManager _mainManager;
        private DateTime _from;
        private DateTime _to;
        private Visit _selectedVisitation;
        private List<Visit> _searchResults = new List<Visit>();

        private static pgVisitations instance = null;
        public static pgVisitations GetVisitationPage()
        {
            return instance ?? (instance = new pgVisitations());
        }

        public pgVisitations()
        {
            _mainManager = MainManager.GetMainManager();
            InitializeComponent();
        }

        /// <summary>
        /// Creator: Matthew Baccam
        /// Created: 02/15/2024
        /// Summary: Calls the query to show the default listitems
        /// Last Updated By: Matthew Baccam
        /// Last Updated: 02/15/2024
        /// What Was changed: Initial creation
        /// </summary>
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                _from = DateTime.Now.Date;
                _to = DateTime.Now.AddDays(31).Date;
                Search();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "No visitation could be find with criteria provided", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
        }

        /// <summary>
        /// Creator: Matthew Baccam
        /// Created: 02/15/2024
        /// Summary: Selects an item from the data grid
        /// Last Updated By: Matthew Baccam
        /// Last Updated: 02/15/2024
        /// What Was changed: Initial creation
        /// </summary>
        private void dataGridVisits_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (dataGridVisits.SelectedItem != null)
            {
                var visit = dataGridVisits.SelectedItem as Visit;
                SetUIForSelectedVisit(visit);
            }
        }

        /// <summary>
        /// Creator: Matthew Baccam
        /// Created: 02/15/2024
        /// Summary: Sets the ui for the current selected user
        /// Last Updated By: Matthew Baccam
        /// Last Updated: 02/22/2024
        /// What Was changed: Initial creation
        /// </summary>
        private void SetUIForSelectedVisit(Visit visit)
        {
            _selectedVisitation = visit;
            lblFirstName.Content = $"First Name: {visit.FirstName}";
            lblLastName.Content = $"Last Name: {visit.LastName}";
            lblCheckIn.Content = $"Check In: {visit.GetCheckIn}";
            lblCheckOut.Content = $"Check Out: {visit.GetCheckOut}";
            txtBoxVisitReason.Text = visit.VisitReason;
        }

        /// <summary>
        /// Creator: Matthew Baccam
        /// Created: 02/15/2024
        /// Summary: Create a popup window for the date selection
        /// Last Updated By: Matthew Baccam
        /// Last Updated: 02/15/2024
        /// What Was changed: Initial creation
        /// </summary>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var calendarWindow = new CalendarPopupWindow(_from);
            calendarWindow.ShowDialog();
            if (calendarWindow.DialogResult == true)
            {
                if (DateTime.Compare(calendarWindow._date, _to) <= 0)
                {
                    _from = calendarWindow._date;
                }
                else
                {
                    MessageBox.Show("Not a valid date selection", "Date selection error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        /// <summary>
        /// Creator: Matthew Baccam
        /// Created: 02/15/2024
        /// Summary: Create a popup window for the date selection
        /// Last Updated By: Matthew Baccam
        /// Last Updated: 02/15/2024
        /// What Was changed: Initial creation
        /// </summary>
        private void btnCalendarTo_Click(object sender, RoutedEventArgs e)
        {
            var calendarWindow = new CalendarPopupWindow(_to);
            calendarWindow.ShowDialog();
            if (calendarWindow.DialogResult == true)
            {
                if (DateTime.Compare(calendarWindow._date, _from) >= 0)
                {
                    _to = calendarWindow._date;
                }
                else
                {
                    MessageBox.Show("Not a valid date selection", "Date selection error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        /// <summary>
        /// Creator: Matthew Baccam
        /// Created: 02/15/2024
        /// Summary: Used to search
        /// Last Updated By: Matthew Baccam
        /// Last Updated: 02/15/2024
        /// What Was changed: Initial creation
        /// </summary>
        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Search();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Visit retrieval failed", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        /// <summary>
        /// Creator: Matthew Baccam
        /// Created: 02/22/2024
        /// Summary: Search logic
        /// Last Updated By: Matthew Baccam
        /// Last Updated: 02/22/2024
        /// What Was changed: Initial creation
        /// </summary>
        private void Search()
        {
            _searchResults = _mainManager.VisitManager.SelectVisitWithFromTo(_from, _to);
            if (!string.IsNullOrWhiteSpace(txtBoxFirstName.Text))
            {
                _searchResults.RemoveAll(v => !v.FirstName.ToLower().StartsWith(txtBoxFirstName.Text.ToLower()));
            }

            if (!string.IsNullOrWhiteSpace(txtBoxLastName.Text))
            {
                _searchResults.RemoveAll(v => !v.LastName.ToLower().StartsWith(txtBoxLastName.Text.ToLower()));
            }
            dataGridVisits.ItemsSource = _searchResults;
        }

        /// <summary>
        /// Creator: Matthew Baccam
        /// Created: 02/15/2024
        /// Summary: Used to cehck in guest
        ///Last Updated By:    Mitchell Stirmel
        ///Last Updated:       04/11/2024
        ///What Was changed:   Added try catch
        /// </summary>
        private void btnCheckIn_Click(object sender, RoutedEventArgs e)
        {
            if (_selectedVisitation != null)
            {
                if(_selectedVisitation.CheckIn.Date <= DateTime.Now.Date && _selectedVisitation.CheckOut.Date >= DateTime.Now.Date)
                {
                    try
                    {
                        _mainManager.VisitManager.CheckInGuest(_selectedVisitation.VisitID, _selectedVisitation.CheckIn);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Check Out failed", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    try
                    {
                        SetUIForSelectedVisit(_mainManager.VisitManager.GetVisitByVisitID(_selectedVisitation.VisitID));
                        Search();
                        MessageBox.Show("Checked in guest", "Check in", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Check Out failed", MessageBoxButton.OK, MessageBoxImage.Error);
                    }

                }
                else
                {
                    MessageBox.Show($"Cannot check in on {DateTime.Now.ToString("MM-dd-yyy")}", "Check in failed", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("No visit selected", "No visit selected", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        /// <summary>
        /// Creator: Matthew Baccam
        /// Created: 02/22/2024
        /// Summary: Used to cehck in guest
        ///Last Updated By:    Mitchell Stirmel
        ///Last Updated:       04/11/2024
        ///What Was changed:   Added try catch
        /// </summary>
        private void btnCheckOut_Click(object sender, RoutedEventArgs e)
        {
            if (_selectedVisitation != null)
            {
                if(_selectedVisitation.CheckIn.Date <= DateTime.Now.Date && _selectedVisitation.CheckOut.Date >= DateTime.Now.Date)
                {
                    try
                    {
                        _mainManager.VisitManager.CheckOutGuest(_selectedVisitation.VisitID, _selectedVisitation.CheckOut);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Check Out failed", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    try
                    {
                        SetUIForSelectedVisit(_mainManager.VisitManager.GetVisitByVisitID(_selectedVisitation.VisitID));
                        Search();
                        MessageBox.Show("Checked out guest", "Check out", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Check Out failed", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                else
                {
                    MessageBox.Show($"Cannot check in on {DateTime.Now.ToString("MM-dd-yyy")}", "Check out failed", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("No visit selected please select and visit", "No visit selected", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        /// <summary>
        /// Creator: Matthew Baccam
        /// Created: 02/22/2024
        /// Summary: Used to cehck in guest
        /// Last Updated By: Matthew Baccam
        /// Last Updated: 02/15/2024
        /// What Was changed: Initial creation
        /// </summary>
        private void btnCreateVisit_Click(object sender, RoutedEventArgs e)
        {
            var createVisitationWindow = new CreateVisitWindow();
            createVisitationWindow.ShowDialog();
            if(createVisitationWindow.DialogResult == true) Search();
        }

        /// <summary>
        /// Creator: Matthew Baccam
        /// Created: 02/22/2024
        /// Summary: Calls the EditVisitPopUp
        /// Last Updated By: Matthew Baccam
        /// Last Updated: 02/15/2024
        /// What Was changed: Initial creation
        /// </summary>
        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            if(_selectedVisitation != null)
            {
                var editWindow = new EditVisitPopUp(_selectedVisitation);
            }
        }

        /// <summary>
        /// Creator: Matthew Baccam
        /// Created: 02/22/2024
        /// Summary: Delete the visit
        /// Last Updated By: Matthew Baccam
        /// Last Updated: 02/15/2024
        /// What Was changed: Initial creation
        /// </summary>
        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (_selectedVisitation != null)
            {
                _mainManager.VisitManager.DeleteVisit(_selectedVisitation);
            }
        }
    }
}
