using DataObjects;
using LogicLayer;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
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
using WpfPresentation.Custom_Controls;
using WpfPresentation.Pages.User;

namespace WpfPresentation.Pages.Security
{
    /// <summary>
    /// Interaction logic for pgViewSubmittedIncidents.xaml
    /// </summary>
    public partial class pgViewSubmittedIncidents : Page
    {
        private MainManager _manager = MainManager.GetMainManager();
        private List<Incident> _incidents = new List<Incident>();
        private List<HiddenIncident> _hiddenIncidents = new List<HiddenIncident>();
        private List<string> severity = new List<string>();
        private int selectedIndex;

        public pgViewSubmittedIncidents()
        {
            InitializeComponent();
            RepopulateIncidents();
        }

        /// <Summary>
        /// Creator: Liam Easton
        /// created: 02/27/2024
        /// Summary: creation of the RepopulateIncidents method
        /// Last updated By: Sagan DeWald
        /// Last Updated: 04/23/2024
        /// What was changed/updated: Modified incident retrieval to ignore hidden incidents.
        /// </Summary>
        private void RepopulateIncidents()
        {
            try
            {
                _hiddenIncidents = _manager.HiddenIncidentManager.GetHiddenIncidentsByUserId(_manager.LoggedInUser.UserID);
                _incidents.Clear();
                foreach(Incident incident in _manager.IncidentManager.SelectAllIncidents())
                {
                    bool found = false;
                    foreach(HiddenIncident hiddenIncident in _hiddenIncidents)
                    {
                        if(incident.incidentID == hiddenIncident.IncidentId)
                        {
                            found = true;
                            break;
                        }
                    }
                    if(!found)
                    {
                        _incidents.Add(incident);
                    }
                }
                grdIncidents.ItemsSource = _incidents;
                grdIncidents.Items.Refresh();
            }
            catch (Exception ex)
            {
                string secondaryMessage = ex.InnerException != null ? "\n\n" + ex.InnerException.Message : "";
                MessageBox.Show(ex.Message + secondaryMessage, "Unable to find incidents.",
                MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
        }

        /// <Summary>
        /// Creator: Liam Easton
        /// created: 02/27/2024
        /// Summary: creation of the Page_Loaded event 
        /// Last updated By: Liam Easton
        /// Last Updated: 02/27/2024
        /// What was changed/updated: creation of the Page_Loaded event
        /// </Summary>
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            // set the combobox for severity
            severity.Add("All");
            for (int i = 0; i <= 5; i++)
            {
                severity.Add($"{i}");
            }
            cboSeverity.ItemsSource = severity;
        }

        /// <Summary>
        /// Creator: Liam Easton
        /// created: 02/27/2024
        /// Summary: creation of the instance of the page
        /// Last updated By: Liam Easton
        /// Last Updated: 02/27/2024
        /// What was changed/updated: creation of the instance of the page
        /// </Summary>
        private static pgViewSubmittedIncidents ViewSubmittedIncidents = null;

        public static pgViewSubmittedIncidents GetPgViewSubmittedIncidents()
        {
            return ViewSubmittedIncidents ?? (ViewSubmittedIncidents = new pgViewSubmittedIncidents());
        }

        /// <Summary>
        /// Creator: Liam Easton
        /// created: 02/27/2024
        /// Summary: creation of the txtSearchName_GotFocus event
        /// Last updated By: Liam Easton
        /// Last Updated: 02/27/2024
        /// What was changed/updated: creation of the txtSearchName_GotFocus event
        /// </Summary>
        private void txtSearchName_GotFocus(object sender, RoutedEventArgs e)
        {
            if (txtSearchName.Text.Replace(" ", "").Equals("Search"))
            {
                txtSearchName.Text = "";
            }
        }

        /// <Summary>
        /// Creator: Liam Easton
        /// created: 02/27/2024
        /// Summary: creation of the txtSearchName_LostFocus event
        /// Last updated By: Liam Easton
        /// Last Updated: 02/27/2024
        /// What was changed/updated: creation of the txtSearchName_LostFocus event
        /// </Summary>
        private void txtSearchName_LostFocus(object sender, RoutedEventArgs e)
        {
            if (txtSearchName.Text.Equals(""))
            {
                txtSearchName.Text = "Search";
                RepopulateIncidents();
            }
        }

        /// <Summary>
        /// Creator: Liam Easton
        /// created: 02/27/2024
        /// Summary: creation of the txtSearchName_TextChanged event
        /// Last updated By: Liam Easton
        /// Last Updated: 02/27/2024
        /// What was changed/updated: creation of the txtSearchName_TextChanged event
        /// </Summary>
        private void txtSearchName_TextChanged(object sender, TextChangedEventArgs e)
        {
            FilterCheck(selectedIndex);
        }

        /// <Summary>
        /// Creator: Liam Easton
        /// created: 02/27/2024
        /// Summary: creation of the FilterCheck helper
        /// Last updated By: Sagan DeWald
        /// Last Updated: 04/24/2024
        /// What was changed/updated: Checkboxes and search box now update the data grid.
        /// </Summary>
        public void FilterCheck(int SelectedIndex)
        {
            List<Incident> filteredIncidents = _incidents;

            List<string> selectedStatus = new List<string>();

            if (cboSeverity == null)
            {
                return;
            }

            if (selectedIndex > 0)
            {
                filteredIncidents = filteredIncidents
                    .Where(x => x.severity.Equals(cboSeverity.SelectedIndex - 1)).ToList();
            }

            if (!string.IsNullOrWhiteSpace(txtSearchName.Text) && txtSearchName.Text != "Search")
            {
                filteredIncidents = filteredIncidents
                    .Where(x => x.reportedBy.ToLower().Contains(txtSearchName.Text.ToLower()))
                    .ToList();
            }

            if (cboSeverity.SelectedIndex > 0)
            {
                filteredIncidents = filteredIncidents
                    .Where(x => x.severity.Equals(cboSeverity.SelectedIndex - 1))
                    .ToList();
            }

            if (chkUnviewed.IsChecked == true)
            {
                selectedStatus.Add("Unviewed");
            }

            if (chkProcessing.IsChecked == true)
            {
                selectedStatus.Add("Processing");
            }

            if (chkHandled.IsChecked == true)
            {
                selectedStatus.Add("Handled");
            }

            if (selectedStatus.Any())
            {
                filteredIncidents = filteredIncidents
                    .Where(x => selectedStatus.Contains(x.incidentStatus, StringComparer.OrdinalIgnoreCase))
                    .ToList();
            }

            grdIncidents.ItemsSource = filteredIncidents;
            grdIncidents.Items.Refresh();
        }

        /// <Summary>
        /// Creator: Liam Easton
        /// created: 02/27/2024
        /// Summary: creation of the cboSeverity_SelectionChanged event
        /// Last updated By: Liam Easton
        /// Last Updated: 02/27/2024
        /// What was changed/updated: creation of the cboSeverity_SelectionChanged event
        /// </Summary>
        private void cboSeverity_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedIndex = cboSeverity.SelectedIndex;

            if (selectedIndex == 0)
            {
                txtSearchName.Text = "Search";
                RepopulateIncidents();
            }
            if(selectedIndex > 0)
            {
                FilterCheck(selectedIndex);
            }
        }

        #region CheckBox Events

        /// <Summary>
        /// Creator: Liam Easton
        /// created: 02/27/2024
        /// Summary: creation of the chkUnviewed_Checked event
        /// Last updated By: Liam Easton
        /// Last Updated: 02/27/2024
        /// What was changed/updated: creation of the chkUnviewed_Checked event
        /// </Summary>
        private void chkUnviewed_Checked(object sender, RoutedEventArgs e)
        {
            FilterCheck(selectedIndex);
        }

        /// <Summary>
        /// Creator: Liam Easton
        /// created: 02/27/2024
        /// Summary: creation of the chkProcessing_Checked event
        /// Last updated By: Liam Easton
        /// Last Updated: 02/27/2024
        /// What was changed/updated: creation of the chkProcessing_Checked event
        /// </Summary>
        private void chkProcessing_Checked(object sender, RoutedEventArgs e)
        {
            FilterCheck(selectedIndex);
        }

        /// <Summary>
        /// Creator: Liam Easton
        /// created: 02/27/2024
        /// Summary: creation of the chkHandled_Checked event
        /// Last updated By: Liam Easton
        /// Last Updated: 02/27/2024
        /// What was changed/updated: creation of the chkHandled_Checked event
        /// </Summary>
        private void chkHandled_Checked(object sender, RoutedEventArgs e)
        {
            FilterCheck(selectedIndex);
        }

        /// <Summary>
        /// Creator: Liam Easton
        /// created: 02/27/2024
        /// Summary: creation of the chkUnviewed_Unchecked event
        /// Last updated By: Liam Easton
        /// Last Updated: 02/27/2024
        /// What was changed/updated: creation of the chkUnviewed_Unchecked event
        /// </Summary>
        private void chkUnviewed_Unchecked(object sender, RoutedEventArgs e)
        {
            FilterCheck(selectedIndex);
        }

        /// <Summary>
        /// Creator: Liam Easton
        /// created: 02/27/2024
        /// Summary: creation of the chkProcessing_Unchecked event
        /// Last updated By: Liam Easton
        /// Last Updated: 02/27/2024
        /// What was changed/updated: creation of the chkProcessing_Unchecked event
        /// </Summary>
        private void chkProcessing_Unchecked(object sender, RoutedEventArgs e)
        {
            FilterCheck(selectedIndex);
        }

        /// <Summary>
        /// Creator: Liam Easton
        /// created: 02/27/2024
        /// Summary: creation of the chkHandled_Unchecked event
        /// Last updated By: Liam Easton
        /// Last Updated: 02/27/2024
        /// What was changed/updated: creation of the chkHandled_Unchecked event
        /// </Summary>
        private void chkHandled_Unchecked(object sender, RoutedEventArgs e)
        {
            FilterCheck(selectedIndex);
        }
        #endregion

        /// <Summary>
        /// Creator: Liam Easton
        /// created: 03/03/2024
        /// Summary: creation of the btnAddIncident_Click event
        /// Last updated By: Liam Easton
        /// Last Updated: 03/03/2024
        /// What was changed/updated: creation of the btnAddIncident_Click event
        /// </Summary>
        private void btnAddIncident_Click(object sender, RoutedEventArgs e)
        {
            var createIncident = new CreateIncidentReport();
            createIncident.Show();
        }

        /// <Summary>
        /// Creator: Sagan DeWald
        /// created: 04/23/2024
        /// Summary: creation of the btnAddIncident_Click event
        /// Last updated By: Sagan DeWald
        /// Last Updated: 04/23/2024
        /// What was changed/updated: creation of the btnRemoveIncident_Click event
        /// </Summary>
        private void btnRemoveIncident_Click(object sender, RoutedEventArgs e)
        {
            if(grdIncidents.SelectedIndex == -1)
            {
                MessageBox.Show("You must select an incident report to remove.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            MessageBoxResult choice = MessageBox.Show("Are you sure you want to delete this incident?", "Confirm", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No);
            Incident incident = grdIncidents.Items.CurrentItem as Incident;

            if(choice == MessageBoxResult.Yes)
            {
                try
                {
                    _manager.HiddenIncidentManager.AddHiddenIncident(_manager.LoggedInUser.UserID, incident.incidentID);
                    MessageBox.Show("Incident successfully deleted.", "Incident Deleted", MessageBoxButton.OK, MessageBoxImage.Information);
                    RepopulateIncidents();
                    FilterCheck(selectedIndex);
                }
                catch(Exception ex)
                {
                    string secondaryMessage = ex.InnerException != null ? ex.InnerException.Message : "";
                    MessageBox.Show("Could not delete this incident." + "\n\n" + secondaryMessage, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
    }
}
